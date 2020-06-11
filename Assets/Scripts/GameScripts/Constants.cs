using System.Collections.Generic;

namespace FallenLand
{
	public static class Constants
	{
		public const int DONT_CARE = 0;
		public const int INVALID_LOCATION = -1;
		public const int NUM_PARTY_MEMBERS = 5;
		public const int VEHICLE_INDEX = 5;
		public static readonly Dictionary<Skills, int> ALL_SKILLS_ZERO = new Dictionary<Skills, int>
			{
				{ Skills.Mechanical, 0 },
				{ Skills.Diplomacy, 0 },
				{ Skills.Technical, 0 },
				{ Skills.Combat, 0 },
				{ Skills.Survival, 0 },
				{ Skills.Medical, 0 }
			};
	}
}