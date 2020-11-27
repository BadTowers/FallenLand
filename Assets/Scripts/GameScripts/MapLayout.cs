using System.Collections.Generic;

namespace FallenLand
{
	public abstract class MapLayout
	{
		protected enum HexType { CITY, RAD, MOUNTAIN, PLAINS, WATER, BASE, RAND_LOC, RESOURCE, VALID };

		protected Dictionary<HexType, bool>[,] ArrayOfHexes = new Dictionary<HexType, bool>[MapCreation.MAP_WIDTH, MapCreation.MAP_HEIGHT]; //2D array of dictionaries that map an int from the enum above -> boolean


		public bool IsHexInGame(int x, int y)
		{
			return ArrayOfHexes[x, y][HexType.VALID];
		}

		public bool IsHexInGame(Coordinates coords)
		{
			return ArrayOfHexes[coords.GetX(), coords.GetY()][HexType.VALID];
		}

		public bool IsCity(int x, int y)
		{
			return ArrayOfHexes[x, y][HexType.CITY];
		}

		public bool IsCity(Coordinates coords)
		{
			return ArrayOfHexes[coords.GetX(), coords.GetY()][HexType.CITY];
		}

		public bool IsRad(int x, int y)
		{
			return ArrayOfHexes[x, y][HexType.RAD];
		}

		public bool IsRad(Coordinates coords)
		{
			return ArrayOfHexes[coords.GetX(), coords.GetY()][HexType.RAD];
		}

		public bool IsMountain(int x, int y)
		{
			return ArrayOfHexes[x, y][HexType.MOUNTAIN];
		}

		public bool IsMountain(Coordinates coords)
		{
			return ArrayOfHexes[coords.GetX(), coords.GetY()][HexType.MOUNTAIN];
		}

		public bool IsPlains(int x, int y)
		{
			return ArrayOfHexes[x, y][HexType.PLAINS];
		}

		public bool IsPlains(Coordinates coords)
		{
			return ArrayOfHexes[coords.GetX(), coords.GetY()][HexType.PLAINS];
		}

		public bool IsWater(int x, int y)
		{
			return ArrayOfHexes[x, y][HexType.WATER];
		}

		public bool IsWater(Coordinates coords)
		{
			return ArrayOfHexes[coords.GetX(), coords.GetY()][HexType.WATER];
		}

		public bool IsFactionBase(int x, int y)
		{
			return ArrayOfHexes[x, y][HexType.BASE];
		}

		public bool IsFactionBase(Coordinates coords)
		{
			return ArrayOfHexes[coords.GetX(), coords.GetY()][HexType.BASE];
		}

		public bool IsRandomLocation(int x, int y)
		{
			return ArrayOfHexes[x, y][HexType.RAND_LOC];
		}

		public bool IsRandomLocation(Coordinates coords)
		{
			return ArrayOfHexes[coords.GetX(), coords.GetY()][HexType.RAND_LOC];
		}

		public bool IsResource(int x, int y)
		{
			return ArrayOfHexes[x, y][HexType.RESOURCE];
		}

		public bool IsResource(Coordinates coords)
		{
			return ArrayOfHexes[coords.GetX(), coords.GetY()][HexType.RESOURCE];
		}

		public abstract void InitializeMapOfHexes();
	}
}
