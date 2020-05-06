using System.Collections.Generic;

public abstract class MapLayout {

	protected enum hexType{CITY, RAD, MOUNTAIN, PLAINS, WATER, BASE, RAND_LOC, RESOURCE, VALID};

	protected Dictionary<hexType, bool>[,] arrayOfHexes = new Dictionary<hexType, bool>[MapCreation.width, MapCreation.height]; //2D array of dictionaries that map an int from the enum above -> boolean


	public bool isHexInGame(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.VALID];
	}

	public bool isHexInGame(Coordinates coords)
	{
		return arrayOfHexes [coords.GetX(), coords.GetY()] [hexType.VALID];
	}

	public bool isCity(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.CITY];
	}

	public bool isCity(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.CITY];
	}

	public bool isRad(int x, int y)
	{
		return arrayOfHexes [x, y][hexType.RAD];
	}

	public bool isRad(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.RAD];
	}

	public bool isMountain(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.MOUNTAIN];
	}

	public bool isMountain(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.MOUNTAIN];
	}

	public bool isPlains(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.PLAINS];
	}

	public bool isPlains(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.PLAINS];
	}

	public bool isWater(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.WATER];
	}

	public bool isWater(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.WATER];
	}

	public bool isFactionBase(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.BASE];
	}

	public bool isFactionBase(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.BASE];
	}

	public bool isRandomNumber(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.RAND_LOC];
	}

	public bool isRandomLocation(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.RAND_LOC];
	}

	public bool isResource(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.RESOURCE];
	}

	public bool isResource(Coordinates coords)
	{
		return arrayOfHexes[coords.GetX(), coords.GetY()][hexType.RESOURCE];
	}

	public abstract void InitializeMapOfHexes();
}
