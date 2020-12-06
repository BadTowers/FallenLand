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
		public static readonly Dictionary<Skills, int> ALL_SKILLS_ZERO = new Dictionary<Skills, int>
			{
				{ Skills.Mechanical, 0 },
				{ Skills.Diplomacy, 0 },
				{ Skills.Technical, 0 },
				{ Skills.Combat, 0 },
				{ Skills.Survival, 0 },
				{ Skills.Medical, 0 }
			};

		//Used for EvDealCard
		public const byte SPOILS_CARD = 1;
		public const byte CHARACTER_CARD = 2;
		public const byte ACTION_CARD = 3;

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

		//Used for both callbacks and for event code
		public const byte EvMove = 1;
		public const byte EvFinalMove = 2;
		public const byte EvDealCard = 3;
		public const byte EvSendFactionInformation = 4;
		public const byte EvSendPlayerInformation = 5;
		public const byte EvRequestUpdateToPlayerInformation = 6;
		public const byte EvMissionLocation = 7;
	}
}