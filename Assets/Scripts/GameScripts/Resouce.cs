
namespace FallenLand
{
	public class Resource
	{
		private Coordinates Location;
		private int NumberOfTownDefenseChips;

		public Resource(Coordinates location)
        {
			Location = location;
			NumberOfTownDefenseChips = 0;
		}

		public Coordinates GetLocation()
		{
			return Location;
		}

        public int GetNumberOfTownDefenseChips()
        {
			return NumberOfTownDefenseChips;
        }
	}
}
