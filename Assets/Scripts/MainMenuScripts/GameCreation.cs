using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	[RequireComponent(typeof(PhotonView))]
	public class GameCreation : MonoBehaviour, IPunObservable
	{
		private Faction FactionInstance;
		private GameInformation.GameModes GameMode;
		private GameInformation.SoloII SoloIIDifficulty;
		private List<GameInformation.GameModifier> ListOfModifiers;
		[SerializeField]
		private Dictionary<string, string> Factions;
		private bool ShouldSendStartOfGameData;


		void Start()
		{
			ListOfModifiers = new List<GameInformation.GameModifier>();
			GameMode = GameInformation.GameModes.Null;
			SoloIIDifficulty = GameInformation.SoloII.Null;
			Factions = new Dictionary<string, string>();

			DontDestroyOnLoad(this.gameObject);
		}

		void Update()
		{
		}

		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
			if (stream.IsWriting && ShouldSendStartOfGameData)
			{
				Debug.Log("Writing start of game data");
				stream.SendNext(Factions);
				ShouldSendStartOfGameData = false; //Only need to send it once. It won't change
			}
			if (stream.IsReading)
			{
				Debug.Log("Reading start of game data");
				Factions = (Dictionary<string, string>)stream.ReceiveNext();
			}
		}

		public void SetFaction(Faction faction)
		{
			FactionInstance = faction;
		}

		public void SetFactions(Dictionary<string, string> factions)
		{
			Factions = factions;
		}

		public void AddFaction(string userId, string faction)
		{
			Factions.Add(userId, faction);
		}

		public Faction GetFaction()
		{
			return FactionInstance;
		}

		public Faction GetFaction(string userId)
		{
			Faction toReturn = new Faction("dummy", new Coordinates(Constants.INVALID_LOCATION, Constants.INVALID_LOCATION));
			if (Factions.ContainsKey(userId))
			{
				string factionString = Factions[userId];
				List<Faction> defaultFactions = (new DefaultFactionInfo()).GetDefaultFactionList();
				for (int i = 0; i < defaultFactions.Count; i++)
				{
					if (factionString == defaultFactions[i].GetName())
					{
						toReturn = defaultFactions[i];
					}
				}
			}

			return toReturn;
		}

		public Dictionary<string, string> GetFactions()
		{
			return Factions;
		}

		public void SetMode(GameInformation.GameModes mode)
		{
			GameMode = mode;
		}

		public GameInformation.GameModes GetMode()
		{
			return GameMode;
		}

		public void SetSoloIIDifficulty(GameInformation.SoloII difficulty)
		{
			SoloIIDifficulty = difficulty;
		}

		public GameInformation.SoloII GetSoloIIDifficulty()
		{
			return SoloIIDifficulty;
		}

		public void AddModifier(GameInformation.GameModifier modifier)
		{
			ListOfModifiers.Add(modifier);
		}

		public List<GameInformation.GameModifier> GetListOfModifiers()
		{
			return ListOfModifiers;
		}

		public void SendData(bool shouldSend)
		{
			ShouldSendStartOfGameData = shouldSend;
		}
	}
}
