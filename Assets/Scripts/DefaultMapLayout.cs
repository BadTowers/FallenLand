using System.Collections.Generic;

public class DefaultMapLayout {

	private enum type{CITY, RAD, MOUNTAIN, PLAINS, WATER, BASE, RAND_NUM, RESOURCE, VISIBLE};

	private Dictionary<int, bool>[,] mapOfHexes = new Dictionary<int, bool>[MapCreation.width, MapCreation.height]; //2D array of dictionaries that map an int from the enum above -> boolean

	//Default constructor
	public DefaultMapLayout()
	{
		InitializeMapOfHexes();
	}

	public bool isHexInGame(int x, int y)
	{
		if (mapOfHexes == null) {
			return false;
		} else {
			return true;
		}
	}

	public bool isCity(int x, int y)
	{
		return mapOfHexes[x, y][type.CITY];
	}

	public bool isRad(int x, int y)
	{
		return mapOfHexes [x, y][type.RAD];
	}

	public bool isMountain(int x, int y)
	{
		return mapOfHexes[x, y][type.MOUNTAIN];
	}

	public bool isPlains(int x, int y)
	{
		return mapOfHexes[x, y][type.PLAINS];
	}

	public bool isWater(int x, int y)
	{
		return mapOfHexes[x, y][type.WATER];
	}

	public bool isFactionBase(int x, int y)
	{
		return mapOfHexes[x, y][type.BASE];
	}

	public bool isRandomNumber(int x, int y)
	{
		return mapOfHexes[x, y][type.RAND_NUM];
	}

	public bool isResource(int x, int y)
	{
		return mapOfHexes[x, y][type.RESOURCE];
	}

	//public Factions faction(int x, int y)
	//{
	//	return mapOfHexes[x, y][type.FACTION_NAME];
	//}

	public bool isVisible(int x, int y)
	{
		return mapOfHexes [x, y] [type.VISIBLE];
	}

	private void InitializeMapOfHexes()
	{
		foreach (var item in mapOfHexes) {
			item = new Dictionary<int, bool>();
			item.Add(type.CITY, true);
			item.Add(type.RAD, true);
			item.Add(type.MOUNTAIN, true);
			item.Add(type.PLAINS, true);
			item.Add(type.WATER, true);
			item.Add(type.BASE, true);
			item.Add(type.RAND_NUM, true);
			item.Add(type.RESOURCE, true);
			item.Add(type.VISIBLE, true);

		}
	}
}
