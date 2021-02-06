
namespace FallenLand
{
	public class Resource
	{
		private Coordinates Location;

		public Resource(Coordinates location)
        {
			Location = location;
		}

		public Coordinates GetLocation()
		{
			return Location;
		}
	}
}
