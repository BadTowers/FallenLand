﻿/*
 * A lot of this code comes from the PunTurnManager implementation from Photon.Pun.UtilityScripts.
 * There are many things I need from it, but some things I don't want and some things I want to add.
 */

using System.Collections.Generic;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace FallenLand
{
    public class MyTurnManager : Photon.Pun.MonoBehaviourPunCallbacks, Photon.Realtime.IOnEventCallback
    {
        Photon.Realtime.Player Sender;
        private bool _MovedToNextPlayerAlready = false;
        private int CurrentFirstPlayerIndex;

        public int Turn
        {
            get
            {
                return Photon.Pun.PhotonNetwork.CurrentRoom.GetTurn();
            }
            private set
            {
                Photon.Pun.PhotonNetwork.CurrentRoom.SetTurn(value);
            }
        }

        public Phases Phase
        {
            get
            {
                return Photon.Pun.PhotonNetwork.CurrentRoom.GetPhase();
            }
            private set
            {
                Photon.Pun.PhotonNetwork.CurrentRoom.SetPhase(value);
            }
        }

        public Photon.Realtime.Player CurrentPlayer
        {
            get
            {
                return Photon.Pun.PhotonNetwork.CurrentRoom.GetCurrentPlayer();
            }
            private set
            {
                Photon.Pun.PhotonNetwork.CurrentRoom.SetCurrentPlayer(value);
            }
        }

        public float ElapsedTimeInTurn
        {
            get
            {
                return ((float)(Photon.Pun.PhotonNetwork.ServerTimestamp - Photon.Pun.PhotonNetwork.CurrentRoom.GetTurnStart())) / 1000.0f;
            }
        }

        public bool IsPhaseCompletedByAll
        {
            get
            {
                return Photon.Pun.PhotonNetwork.CurrentRoom != null && Turn > 0 && this.FinishedPlayers.Count == Photon.Pun.PhotonNetwork.CurrentRoom.PlayerCount;
            }
        }

        public bool IsFinishedByMe
        {
            get
            {
                return FinishedPlayers.Contains(Photon.Pun.PhotonNetwork.LocalPlayer);
            }
        }

        void Start()
        {
            CurrentFirstPlayerIndex = 0;
            CurrentPlayer = Photon.Pun.PhotonNetwork.PlayerList[CurrentFirstPlayerIndex];
        }


        public IMyTurnManagerCallbacks TurnManagerListener;
        private readonly HashSet<Photon.Realtime.Player> FinishedPlayers = new HashSet<Photon.Realtime.Player>();
        public const byte TurnManagerEventOffset = 0;

        public void BeginNextTurn()
        {
            TurnManagerListener.OnTurnCompleted(Turn);
            if (Turn > 0) //Don't move current player the first turn
            {
                CurrentFirstPlayerIndex = (CurrentFirstPlayerIndex + 1) % Photon.Pun.PhotonNetwork.PlayerList.Length;
            }
            CurrentPlayer = Photon.Pun.PhotonNetwork.PlayerList[CurrentFirstPlayerIndex];
            _MovedToNextPlayerAlready = true;
            Turn++;
            TurnManagerListener.OnTurnBegins(Turn);
        }

        public void BeginNextPhase()
        {
            if (Phase == Phases.After_End_Turn_Phase)
            {
                Phase = Phases.Before_Effects_Phase;
                BeginNextTurn();
            }
            else
            {
                CurrentPlayer = Photon.Pun.PhotonNetwork.PlayerList[CurrentFirstPlayerIndex];
                _MovedToNextPlayerAlready = true;
                Phase++;
            }
        }

        public void SendMove(object move, bool finished)
        {
            if (!IsFinishedByMe)
            {
                Hashtable moveHt = new Hashtable
                {
                { "Phase", Phase },
                { "Move", move }
                };

                byte evCode = (finished) ? Constants.EvFinalMove : Constants.EvMove;
                Photon.Pun.PhotonNetwork.RaiseEvent(evCode, moveHt, new Photon.Realtime.RaiseEventOptions() { CachingOption = Photon.Realtime.EventCaching.AddToRoomCache }, ExitGames.Client.Photon.SendOptions.SendReliable);
                if (finished)
                {
                    Photon.Pun.PhotonNetwork.LocalPlayer.SetFinishedTurn(Turn);
                }

                // the server won't send the event back to the origin (by default). to get the event, call it locally
                // (note: the order of events might be mixed up as we do this locally)
                ProcessOnEvent(evCode, moveHt, Photon.Pun.PhotonNetwork.LocalPlayer.ActorNumber);
            }
        }

        #region Callbacks
        void ProcessOnEvent(byte eventCode, object content, int senderId)
        {
            if (senderId != -1)
            {
                Sender = Photon.Pun.PhotonNetwork.CurrentRoom.GetPlayer(senderId);
                
                switch (eventCode)
                {
                    case Constants.EvMove:
                        {
                            Hashtable evTable = content as Hashtable;
                            Phases phase = (Phases)evTable["Phase"];
                            object move = evTable["Move"];
                            TurnManagerListener.OnPlayerMove(Sender, phase, move);

                            break;
                        }
                    case Constants.EvFinalMove:
                        {
                            Hashtable evTable = content as Hashtable;
                            Phases phase = (Phases)evTable["Phase"];
                            object move = evTable["Move"];
                            if (phase == Phase)
                            {
                                FinishedPlayers.Add(Sender);

                                TurnManagerListener.OnPlayerFinished(Sender, phase, move);
                                for (int i = 0; i < Photon.Pun.PhotonNetwork.PlayerList.Length; i++)
                                {
                                    //Don't change "current player" during an async phase because we will handle moving out of that phase by seeing all players in FinishedPlayers (i.e, IsPhaseCompletedByAll)
                                    if (Photon.Pun.PhotonNetwork.PlayerList[i] == Sender && !_MovedToNextPlayerAlready && !PhasesHelpers.IsAsyncPhase(Phase))
                                    {
                                        CurrentPlayer = Photon.Pun.PhotonNetwork.PlayerList[(i+1) % Photon.Pun.PhotonNetwork.PlayerList.Length];
                                        break;
                                    }
                                }
                                _MovedToNextPlayerAlready = false;
                            }

                            if (IsPhaseCompletedByAll)
                            {
                                TurnManagerListener.OnPhaseCompleted(Phase);
                            }
                            break;
                        }
                }
            }
        }

		public void OnEvent(ExitGames.Client.Photon.EventData photonEvent)
        {
            this.ProcessOnEvent(photonEvent.Code, photonEvent.CustomData, photonEvent.Sender);
        }

        public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
            if (propertiesThatChanged.ContainsKey("Phase"))
            {
                FinishedPlayers.Clear();
                TurnManagerListener.OnPhaseBegins(Phase);
            }
        }

        #endregion
    }

    public interface IMyTurnManagerCallbacks
    {
        void OnTurnBegins(int turn);

        void OnTurnCompleted(int turn);

        //void OnTurnTimeEnds(int turn);

        void OnPhaseBegins(Phases phase);

        void OnPhaseCompleted(Phases phase);

        void OnPlayerMove(Photon.Realtime.Player player, Phases phase, object move);

        void OnPlayerFinished(Photon.Realtime.Player player, Phases phase, object move);

        //void OnPhaseTimeEnds(Phases phase);
    }


    public static class TurnExtensions
    {
        public static readonly string TurnPropKey = "Turn";
        public static readonly string PhasePropKey = "Phase";
        public static readonly string TurnStartPropKey = "TStart";
        public static readonly string FinishedTurnPropKey = "FToA";
        public static readonly string CurrentPlayerKey = "CurPlayer";

        public static void SetTurn(this Photon.Realtime.Room room, int turn)
        {
            if (room != null && room.CustomProperties != null)
            {
                Hashtable turnProps = new Hashtable
                {
                    [TurnPropKey] = turn
                };

                room.SetCustomProperties(turnProps);
            }
        }

        public static void SetPhase(this Photon.Realtime.Room room, Phases phase)
        {
            if (room != null && room.CustomProperties != null)
            {
                Hashtable phaseProps = new Hashtable
                {
                    [PhasePropKey] = phase
                };

                room.SetCustomProperties(phaseProps);
            }
        }

        public static int GetTurn(this Photon.Realtime.RoomInfo room)
        {
            int turn = 0;
            if (room != null && room.CustomProperties != null && room.CustomProperties.ContainsKey(TurnPropKey))
            {
                turn = (int)room.CustomProperties[TurnPropKey];
            }

            return turn;
        }

        public static Phases GetPhase(this Photon.Realtime.RoomInfo room)
        {
            Phases phase = Phases.Game_Start_Setup;
            if (room != null && room.CustomProperties != null && room.CustomProperties.ContainsKey(PhasePropKey))
            {
                phase = (Phases)room.CustomProperties[PhasePropKey];
            }

            return phase;
        }

        public static int GetTurnStart(this Photon.Realtime.RoomInfo room)
        {
            int turn = 0;
            if (room != null && room.CustomProperties != null && room.CustomProperties.ContainsKey(TurnStartPropKey))
            {
                turn = (int)room.CustomProperties[TurnStartPropKey];
            }

            return turn;
        }

        public static int GetFinishedTurn(this Photon.Realtime.Player player)
        {
            Photon.Realtime.Room room = Photon.Pun.PhotonNetwork.CurrentRoom;
            int finishedTurn = 0;
            if (room != null && room.CustomProperties != null && room.CustomProperties.ContainsKey(TurnPropKey))
            {
                string propKey = FinishedTurnPropKey + player.ActorNumber;
                finishedTurn = (int)room.CustomProperties[propKey];
            }
            return finishedTurn;
        }

        public static void SetFinishedTurn(this Photon.Realtime.Player player, int turn)
        {
            Photon.Realtime.Room room = Photon.Pun.PhotonNetwork.CurrentRoom;
            if (room != null && room.CustomProperties != null)
            {
                string propKey = FinishedTurnPropKey + player.ActorNumber;
                Hashtable finishedTurnProp = new Hashtable();
                finishedTurnProp[propKey] = turn;

                room.SetCustomProperties(finishedTurnProp);
            }
        }

        public static Photon.Realtime.Player GetCurrentPlayer(this Photon.Realtime.RoomInfo room)
        {
            Photon.Realtime.Player playerToReturn = null;
            if (room != null && room.CustomProperties != null && room.CustomProperties.ContainsKey(CurrentPlayerKey))
            {
                int currentActorNumber = (int)room.CustomProperties[CurrentPlayerKey];
                playerToReturn = Photon.Pun.PhotonNetwork.CurrentRoom.GetPlayer(currentActorNumber);
            }

            return playerToReturn;
        }

        public static void SetCurrentPlayer(this Photon.Realtime.RoomInfo roomInfo, Photon.Realtime.Player player)
        {
            Photon.Realtime.Room room = Photon.Pun.PhotonNetwork.CurrentRoom;
            if (room != null && room.CustomProperties != null && player != null)
            {
                Hashtable currentPlayerHashTable = new Hashtable();
                currentPlayerHashTable[CurrentPlayerKey] = player.ActorNumber;

                room.SetCustomProperties(currentPlayerHashTable);
            }
        }
    }
}
