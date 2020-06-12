/*
 * A lot of this code comes from the PunTurnManager implementation from Photon.Pun.UtilityScripts.
 * There are many things I need from it, but some things I don't want and some things I want to add.
 */

using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace FallenLand
{
    public class MyTurnManager : MonoBehaviourPunCallbacks, IOnEventCallback
    {
        Photon.Realtime.Player Sender;
        private bool _MovedToNextPlayerAlready = false;
        private int CurrentFirstPlayerIndex;

        public int Turn
        {
            get
            {
                return PhotonNetwork.CurrentRoom.GetTurn();
            }
            private set
            {
                PhotonNetwork.CurrentRoom.SetTurn(value);
            }
        }

        public Phases Phase
        {
            get
            {
                return PhotonNetwork.CurrentRoom.GetPhase();
            }
            private set
            {
                PhotonNetwork.CurrentRoom.SetPhase(value);
            }
        }

        public Photon.Realtime.Player CurrentPlayer
        {
            get
            {
                return PhotonNetwork.CurrentRoom.GetCurrentPlayer();
            }
            private set
            {
                PhotonNetwork.CurrentRoom.SetCurrentPlayer(value);
            }
        }

        public float ElapsedTimeInTurn
        {
            get
            {
                return ((float)(PhotonNetwork.ServerTimestamp - PhotonNetwork.CurrentRoom.GetTurnStart())) / 1000.0f;
            }
        }

        public bool IsPhaseCompletedByAll
        {
            get
            {
                return PhotonNetwork.CurrentRoom != null && Turn > 0 && this.FinishedPlayers.Count == PhotonNetwork.CurrentRoom.PlayerCount;
            }
        }

        public bool IsFinishedByMe
        {
            get
            {
                return this.FinishedPlayers.Contains(PhotonNetwork.LocalPlayer);
            }
        }

        void Start()
        {
            CurrentFirstPlayerIndex = 0;
            CurrentPlayer = PhotonNetwork.PlayerList[CurrentFirstPlayerIndex];
        }


        public IMyTurnManagerCallbacks TurnManagerListener;
        private readonly HashSet<Photon.Realtime.Player> FinishedPlayers = new HashSet<Photon.Realtime.Player>();
        public const byte TurnManagerEventOffset = 0;
        public const byte EvMove = 1 + TurnManagerEventOffset;
        public const byte EvFinalMove = 2 + TurnManagerEventOffset;

        public void BeginNextTurn()
        {
            Debug.Log("TurnManager: BeginNextTurn");
            CurrentFirstPlayerIndex = (CurrentFirstPlayerIndex + 1) % PhotonNetwork.PlayerList.Length;
            CurrentPlayer = PhotonNetwork.PlayerList[CurrentFirstPlayerIndex];
            _MovedToNextPlayerAlready = true;
            Turn++;
        }

        public void BeginNextPhase()
        {
            Debug.Log("TurnManager: BeginNextPhase");
            if (Phase == Phases.After_End_Turn_Phase)
            {
                Phase = Phases.Before_Effects_Phase;
                BeginNextTurn();
            }
            else
            {
                CurrentPlayer = PhotonNetwork.PlayerList[CurrentFirstPlayerIndex];
                _MovedToNextPlayerAlready = true;
                Phase++;
            }
        }

        public void SendMove(object move, bool finished)
        {
            Debug.Log("SendMove");
            if (!IsFinishedByMe)
            {
                Hashtable moveHt = new Hashtable
                {
                { "Phase", Phase },
                { "Move", move }
                };

                byte evCode = (finished) ? EvFinalMove : EvMove;
                PhotonNetwork.RaiseEvent(evCode, moveHt, new RaiseEventOptions() { CachingOption = EventCaching.AddToRoomCache }, SendOptions.SendReliable);
                if (finished)
                {
                    PhotonNetwork.LocalPlayer.SetFinishedTurn(Turn);
                }

                // the server won't send the event back to the origin (by default). to get the event, call it locally
                // (note: the order of events might be mixed up as we do this locally)
                ProcessOnEvent(evCode, moveHt, PhotonNetwork.LocalPlayer.ActorNumber);
            }
        }

        public bool GetPlayerFinishedTurn(Photon.Realtime.Player player)
        {
            bool isPlayerFinishedTurn = false;
            if (player != null && this.FinishedPlayers != null && this.FinishedPlayers.Contains(player))
            {
                isPlayerFinishedTurn = true;
            }

            return isPlayerFinishedTurn;
        }

        #region Callbacks
        void ProcessOnEvent(byte eventCode, object content, int senderId)
        {
            if (senderId != -1)
            {
                Sender = PhotonNetwork.CurrentRoom.GetPlayer(senderId);
                
                switch (eventCode)
                {
                    case EvMove:
                        {
                            Hashtable evTable = content as Hashtable;
                            Phases phase = (Phases)evTable["Phase"];
                            object move = evTable["Move"];
                            TurnManagerListener.OnPlayerMove(Sender, phase, move);

                            break;
                        }
                    case EvFinalMove:
                        {
                            Hashtable evTable = content as Hashtable;
                            Phases phase = (Phases)evTable["Phase"];
                            object move = evTable["Move"];
                            if (phase == Phase)
                            {
                                FinishedPlayers.Add(Sender);

                                TurnManagerListener.OnPlayerFinished(Sender, phase, move);
                                for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
                                {
                                    if (PhotonNetwork.PlayerList[i] == Sender && !_MovedToNextPlayerAlready)
                                    {
                                        CurrentPlayer = PhotonNetwork.PlayerList[(i+1) % PhotonNetwork.PlayerList.Length];
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

		public void OnEvent(EventData photonEvent)
        {
            this.ProcessOnEvent(photonEvent.Code, photonEvent.CustomData, photonEvent.Sender);
        }

        public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
            Debug.Log("OnRoomPropertiesUpdate in TurnManager");
            if (propertiesThatChanged.ContainsKey("Phase"))
            {
                Debug.Log("propertiesThatChanged constains Phase");
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

        public static void SetTurn(this Room room, int turn)
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

        public static void SetPhase(this Room room, Phases phase)
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

        public static int GetTurn(this RoomInfo room)
        {
            int turn = 0;
            if (room != null && room.CustomProperties != null && room.CustomProperties.ContainsKey(TurnPropKey))
            {
                turn = (int)room.CustomProperties[TurnPropKey];
            }

            return turn;
        }

        public static Phases GetPhase(this RoomInfo room)
        {
            Phases phase = Phases.Game_Start_Setup;
            if (room != null && room.CustomProperties != null && room.CustomProperties.ContainsKey(PhasePropKey))
            {
                phase = (Phases)room.CustomProperties[PhasePropKey];
            }

            return phase;
        }

        public static int GetTurnStart(this RoomInfo room)
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
            Room room = PhotonNetwork.CurrentRoom;
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
            Room room = PhotonNetwork.CurrentRoom;
            if (room != null && room.CustomProperties != null)
            {
                string propKey = FinishedTurnPropKey + player.ActorNumber;
                Hashtable finishedTurnProp = new Hashtable();
                finishedTurnProp[propKey] = turn;

                room.SetCustomProperties(finishedTurnProp);
            }
        }

        public static Photon.Realtime.Player GetCurrentPlayer(this RoomInfo room)
        {
            Photon.Realtime.Player playerToReturn = null;
            if (room != null && room.CustomProperties != null && room.CustomProperties.ContainsKey(CurrentPlayerKey))
            {
                int currentActorNumber = (int)room.CustomProperties[CurrentPlayerKey];
                playerToReturn = PhotonNetwork.CurrentRoom.GetPlayer(currentActorNumber);
            }

            return playerToReturn;
        }

        public static void SetCurrentPlayer(this RoomInfo roomInfo, Photon.Realtime.Player player)
        {
            Room room = PhotonNetwork.CurrentRoom;
            if (room != null && room.CustomProperties != null && player != null)
            {
                Hashtable currentPlayerHashTable = new Hashtable();
                currentPlayerHashTable[CurrentPlayerKey] = player.ActorNumber;

                room.SetCustomProperties(currentPlayerHashTable);
            }
        }
    }
}
