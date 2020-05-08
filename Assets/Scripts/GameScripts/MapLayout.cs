using System.Collections.Generic;

public abstract class MapLayout {

	protected enum hexType{CITY, RAD, MOUNTAIN, PLAINS, WATER, BASE, RAND_LOC, RESOURCE, VALID};

	protected Dictionary<hexType, bool>[,] arrayOfHexes = new Dictionary<hexType, bool>[MapCreation.width, MapCreation.height]; //2D array of dictionaries that map an int from the enum above -> boolean


	public bool IsHexInGame(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.VALID];
	}

	public bool IsHexInGame(Coordinates coords)
	{
		return arrayOfHexes [coords.GetX(), coords.GetY()] [hexType.VALID];
	}

	public bool IsCity(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.CITY];
	}

	public bool IsCity(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.CITY];
	}

	public bool IsRad(int x, int y)
	{
		return arrayOfHexes [x, y][hexType.RAD];
	}

	public bool IsRad(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.RAD];
	}

	public bool IsMountain(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.MOUNTAIN];
	}

	public bool IsMountain(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.MOUNTAIN];
	}

	public bool IsPlains(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.PLAINS];
	}

	public bool IsPlains(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.PLAINS];
	}

	public bool IsWater(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.WATER];
	}

	public bool IsWater(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.WATER];
	}

	public bool IsFactionBase(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.BASE];
	}

	public bool IsFactionBase(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.BASE];
	}

	public bool IsRandomLocation(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.RAND_LOC];
	}

	public bool IsRandomLocation(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.RAND_LOC];
	}

	public bool IsResource(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.RESOURCE];
	}

	public bool IsResource(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.RESOURCE];
	}

	public abstract void InitializeMapOfHexes();
}
