using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class GameCreation : MonoBehaviour
	{
		private Faction FactionInstance;
		private GameInformation.GameModes GameMode;
		private GameInformation.SoloII SoloIIDifficulty;
		private List<GameInformation.GameModifier> ListOfModifiers;
		private Dictionary<int, string> Factions;


		void Start()
		{
			ListOfModifiers = new List<GameInformation.GameModifier>();
			GameMode = GameInformation.GameModes.Null;
			SoloIIDifficulty = GameInformation.SoloII.Null;
			Factions = new Dictionary<int, string>();

			DontDestroyOnLoad(this.gameObject);
		}

		void Update()
		{
		}

		public void SetFaction(Faction faction)
		{
			FactionInstance = faction;
		}

		public void SetFactions(Dictionary<int, string> factions)
		{
			Factions = factions;
		}

		public void AddFaction(int playerIndex, string faction)
		{
			Factions.Add(playerIndex, faction);
		}

		public Faction GetFaction()
		{
			return FactionInstance;
		}

		public Dictionary<int, string> GetFactions()
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
	}
}
