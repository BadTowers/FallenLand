using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class GameCreation : MonoBehaviour
	{
		public bool WasRead = false;

		private Faction FactionInstance; //TODO for multiplayer, this likely needs to be a list of factions or a dictionary of factions (map IP to faction)
		private GameInformation.GameModes GameMode;
		private GameInformation.SoloII SoloIIDifficulty;
		private List<GameInformation.GameModifier> ListOfModifiers;


		void Start()
		{
			ListOfModifiers = new List<GameInformation.GameModifier>();
			GameMode = GameInformation.GameModes.Null;
			SoloIIDifficulty = GameInformation.SoloII.Null;
		}

		void Update()
		{
			if (!WasRead)
			{
				DontDestroyOnLoad(this.gameObject);
			}
			else
			{
				DestroyImmediate(this.gameObject);
			}
		}

		public void SetFaction(Faction faction)
		{
			FactionInstance = faction;
		}

		public Faction GetFaction()
		{
			return FactionInstance;
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
