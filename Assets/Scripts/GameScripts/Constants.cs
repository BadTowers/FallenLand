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

		//Used to mark what card is being sent
		public const byte SPOILS_CARD = 1;
		public const byte CHARACTER_CARD = 2;
		public const byte ACTION_CARD = 3;

		//Used for both callbacks and for event code
		public const byte EvMove = 1;
		public const byte EvFinalMove = 2;
		public const byte EvDealCard = 3;
		public const byte EvSendFactionInformation = 4;
	}
}