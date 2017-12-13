using System.Collections.Generic;

public abstract class MapLayout {

	protected enum hexType{CITY, RAD, MOUNTAIN, PLAINS, WATER, BASE, RAND_NUM, RESOURCE, VALID};

	protected Dictionary<hexType, bool>[,] arrayOfHexes = new Dictionary<hexType, bool>[MapCreation.width, MapCreation.height]; //2D array of dictionaries that map an int from the enum above -> boolean


	public bool isHexInGame(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.VALID];
	}

	public bool isHexInGame(Coordinates coords)
	{
		return arrayOfHexes [coords.getX(), coords.getY()] [hexType.VALID];
	}

	public bool isCity(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.CITY];
	}

	public bool isCity(Coordinates coords)
	{
		return arrayOfHexes[coords.getX(), coords.getY()][hexType.CITY];
	}

	public bool isRad(int x, int y)
	{
		return arrayOfHexes [x, y][hexType.RAD];
	}

	public bool isRad(Coordinates coords)
	{
		return arrayOfHexes[coords.getX(), coords.getY()][hexType.RAD];
	}

	public bool isMountain(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.MOUNTAIN];
	}

	public bool isMountain(Coordinates coords)
	{
		return arrayOfHexes[coords.getX(), coords.getY()][hexType.MOUNTAIN];
	}

	public bool isPlains(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.PLAINS];
	}

	public bool isPlains(Coordinates coords)
	{
		return arrayOfHexes[coords.getX(), coords.getY()][hexType.PLAINS];
	}

	public bool isWater(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.WATER];
	}

	public bool isWater(Coordinates coords)
	{
		return arrayOfHexes[coords.getX(), coords.getY()][hexType.WATER];
	}

	public bool isFactionBase(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.BASE];
	}

	public bool isFactionBase(Coordinates coords)
	{
		return arrayOfHexes[coords.getX(), coords.getY()][hexType.BASE];
	}

	public bool isRandomNumber(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.RAND_NUM];
	}

	public bool isRandomNumber(Coordinates coords)
	{
		return arrayOfHexes[coords.getX(), coords.getY()][hexType.RAND_NUM];
	}

	public bool isResource(int x, int y)
	{
		return arrayOfHexes[x, y][hexType.RESOURCE];
	}

	public bool isResource(Coordinates coords)
	{
		return arrayOfHexes[coords.getX(), coords.getY()][hexType.RESOURCE];
	}

	public abstract void InitializeMapOfHexes();
}
