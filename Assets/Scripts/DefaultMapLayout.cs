using System.Collections.Generic;

public class DefaultMapLayout : MapLayout {

	//Default constructor
	public DefaultMapLayout()
	{
		InitializeMapOfHexes();
	}
		
	public override void InitializeMapOfHexes()
	{
		/**************** COLUMN 0 ****************/
		// (0, 0)
		setHexOutOfMapBounds(0, 0);
		// (0, 1)
		setHexOutOfMapBounds(0, 1);
		// (0, 2)
		setHexOutOfMapBounds(0, 2);
		// (0, 3)
		setHexOutOfMapBounds(0, 3);
		// (0, 4)
		setHexOutOfMapBounds(0, 4);
		// (0, 5)
		setHexOutOfMapBounds(0, 5);
		// (0, 6)
		setHexOutOfMapBounds(0, 6);
		// (0, 7)
		setHexOutOfMapBounds(0, 7);
		// (0, 8)
		setHexOutOfMapBounds(0, 8);
		// (0, 9)
		setHexOutOfMapBounds(0, 9);
		// (0, 10)
		setHexOutOfMapBounds(0, 10);
		// (0, 11)
		arrayOfHexes[0, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (0, 12)
		setHexOutOfMapBounds(0, 12);
		// (0, 13)
		arrayOfHexes[0, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (0, 14)
		arrayOfHexes[0, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (0, 15)
		arrayOfHexes[0, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (0, 16)
		arrayOfHexes[0, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (0, 17)
		arrayOfHexes[0, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (0, 18)
		setHexOutOfMapBounds(0, 18);
		// (0, 19)
		setHexOutOfMapBounds(0, 19);
		// (0, 20)
		setHexOutOfMapBounds(0, 20);
		// (0, 21)
		setHexOutOfMapBounds(0, 21);
		// (0, 22)
		setHexOutOfMapBounds(0, 22);

		/**************** COLUMN 1 ****************/
		// (1, 0)
		setHexOutOfMapBounds(1, 0);
		// (1, 1)
		setHexOutOfMapBounds(1, 1);
		// (1, 2)
		setHexOutOfMapBounds(1, 2);
		// (1, 3)
		setHexOutOfMapBounds(1, 3);
		// (1, 4)
		setHexOutOfMapBounds(1, 4);
		// (1, 5)
		setHexOutOfMapBounds(1, 5);
		// (1, 6)
		setHexOutOfMapBounds(1, 6);
		// (1, 7)
		setHexOutOfMapBounds(1, 7);
		// (1, 8)
		setHexOutOfMapBounds(1, 8);
		// (1, 9)
		arrayOfHexes[1, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 10)
		arrayOfHexes[1, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 11)
		arrayOfHexes[1, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 12)
		arrayOfHexes[1, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 13)
		arrayOfHexes[1, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 14)
		arrayOfHexes[1, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 15)
		arrayOfHexes[1, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 16)
		arrayOfHexes[1, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 17)
		arrayOfHexes[1, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 18)
		arrayOfHexes[1, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 19)
		arrayOfHexes[1, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 20)
		setHexOutOfMapBounds(1, 20);
		// (1, 21)
		arrayOfHexes[1, 21] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 22)
		setHexOutOfMapBounds(1, 22);

		/**************** COLUMN 2 ****************/
		// (2, 0)
	}

	private void setHexOutOfMapBounds(int x, int y)
	{
		arrayOfHexes[x, y] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, false}
		};
	}
}
