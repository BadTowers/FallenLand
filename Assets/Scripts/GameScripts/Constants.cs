using System.Collections.Generic;

namespace FallenLand
{
	public static class Constants
	{
		public const int DONT_CARE = 0;
		public const int INVALID_LOCATION = -1;
		public const int NUM_PARTY_MEMBERS = 5;
		public const int VEHICLE_INDEX = 5;
		public const int MAX_NUM_PLAYERS = 5;
		public const int D6 = 6;
		public const int D10 = 10;
		public const int D20 = 20;
		public const int D100 = 100;
		public const int CRIT_SUCCESS = 1;
		public const int CRIT_FAIL = 10;
		public const int HAS_NOT_ROLLED = -1;
		public static readonly Dictionary<Skills, int> ALL_SKILLS_ZERO = new Dictionary<Skills, int>
		{
			{ Skills.Mechanical, 0 },
			{ Skills.Diplomacy, 0 },
			{ Skills.Technical, 0 },
			{ Skills.Combat, 0 },
			{ Skills.Survival, 0 },
			{ Skills.Medical, 0 }
		};
		public const int MAX_NUM_RESOURCES_OWNED = 5;

		//Used for EvDealCard
		public const byte SPOILS_CARD = 1;
		public const byte CHARACTER_CARD = 2;
		public const byte ACTION_CARD = 3;
		public const byte SPECIAL_SPOILS_CARD = 4;
		public const byte DISCARDED_SPOILS_CARD = 5;

		//Used for EvSendPlayerInformation
		public const byte REMOVE_FROM_TOWN_ROSTER = 1;
		public const byte REMOVE_FROM_AUCTION_HOUSE = 2;
		public const byte ADD_CHARACTER_TO_SLOT = 3;
		public const byte REMOVE_CHARACTER_FROM_SLOT = 4;
		public const byte ADD_VEHICLE = 5;
		public const byte REMOVE_VEHICLE = 6;
		public const byte ADD_SPOILS_TO_SLOT = 7;
		public const byte REMOVE_SPOILS_FROM_SLOT = 8;
		public const byte ADD_SPOILS_TO_VEHICLE = 9;
		public const byte REMOVE_SPOILS_FROM_VEHICLE = 10;
		public const byte ADD_TO_TOWN_ROSTER = 11;
		public const byte ADD_TO_AUCTION_HOUSE = 12;

		//Used for EvPartyExploits
		public const byte PARTY_EXPLOITS_MOVEMENT = 1;
		public const byte PARTY_EXPLOITS_ENCOUNTER = 2;
		public const byte PARTY_EXPLOITS_MISSION = 3;
		public const byte PARTY_EXPLOITS_HEALING = 4;
		public const byte PARTY_EXPLOITS_PVP = 5;
		public const byte PARTY_EXPLOITS_RESOURCE = 6;

		//Used for EvPartyExploits
		public const int ENCOUNTER_NONE = 0;
		public const int ENCOUNTER_PLAINS = 1;
		public const int ENCOUNTER_MOUNTAINS = 2;
		public const int ENCOUNTER_CITY_RAD = 3;

		//Used for EvEncounterStatus
		public const byte STATUS_BEGIN = 0;
		public const byte STATUS_FLIGHT = 1;
		public const byte STATUS_PASSED = 2;
		public const byte STATUS_FAILED = 3;

		//Used for EvMovement
		public const int PARTY_MOVEMENT = 0;
		//NPCM movement might be here later

		//Used for EvCharacterHealth
		public const byte DAMAGE_PHYSICAL = 0;
		public const byte DAMAGE_PSYCHOLOGICAL = 1;
		public const byte DAMAGE_INFECTED = 2;
		public const byte DAMAGE_RADIATION = 3;

		//Used for both callbacks and for event code
		public const byte EvMove = 1;
		public const byte EvFinalMove = 2;
		public const byte EvDealCard = 3;
		public const byte EvSendFactionInformation = 4;
		public const byte EvSendPlayerInformation = 5;
		public const byte EvRequestUpdateToPlayerInformation = 6;
		public const byte EvMissionLocation = 7;
		public const byte EvTownEventRoll = 8;
		public const byte EvPartyExploits = 9;
		public const byte EvEncounterStatus = 10;
		public const byte EvMovement = 11;
		public const byte EvCharacterHealth = 12;
	}
}