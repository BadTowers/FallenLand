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
		int x = 0;
		int y = 0;
		// (0, 0)
		setHexOutOfMapBounds(x, y++);
		// (0, 1)
		setHexOutOfMapBounds(x, y++);
		// (0, 2)
		setHexOutOfMapBounds(x, y++);
		// (0, 3)
		setHexOutOfMapBounds(x, y++);
		// (0, 4)
		setHexOutOfMapBounds(x, y++);
		// (0, 5)
		setHexOutOfMapBounds(x, y++);
		// (0, 6)
		setHexOutOfMapBounds(x, y++);
		// (0, 7)
		setHexOutOfMapBounds(x, y++);
		// (0, 8)
		setHexOutOfMapBounds(x, y++);
		// (0, 9)
		setHexOutOfMapBounds(x, y++);
		// (0, 10)
		setHexOutOfMapBounds(x, y++);
		// (0, 11)
		setHexOutOfMapBounds(x, y++);
		// (0, 12)
		setHexOutOfMapBounds(x, y++);
		// (0, 13)
		setHexOutOfMapBounds(x, y++);
		// (0, 14)
		setHexOutOfMapBounds(x, y++);
		// (0, 15)
		setHexOutOfMapBounds(x, y++);
		// (0, 16)
		setHexOutOfMapBounds(x, y++);
		// (0, 17)
		setHexOutOfMapBounds(x, y++);
		// (0, 18)
		setHexOutOfMapBounds(x, y++);
		// (0, 19)
		setHexOutOfMapBounds(x, y++);
		// (0, 20)
		setHexOutOfMapBounds(x, y++);
		// (0, 21)
		setHexOutOfMapBounds(x, y++);
		// (0, 22)
		setHexOutOfMapBounds(x, y++);


		/**************** COLUMN 1 ****************/
		x = 1;
		y = 0;
		// (1, 0)
		setHexOutOfMapBounds(x, y++);
		// (1, 1)
		setHexOutOfMapBounds(x, y++);
		// (1, 2)
		setHexOutOfMapBounds(x, y++);
		// (1, 3)
		setHexOutOfMapBounds(x, y++);
		// (1, 4)
		setHexOutOfMapBounds(x, y++);
		// (1, 5)
		setHexOutOfMapBounds(x, y++);
		// (1, 6)
		setHexOutOfMapBounds(x, y++);
		// (1, 7)
		setHexOutOfMapBounds(x, y++);
		// (1, 8)
		setHexOutOfMapBounds(x, y++);
		// (1, 9)
		setHexOutOfMapBounds(x, y++);
		// (1, 10)
		setHexOutOfMapBounds(x, y++);
		// (1, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 12)
		setHexOutOfMapBounds(x, y++);
		// (1, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (1, 18)
		setHexOutOfMapBounds(x, y++);
		// (1, 19)
		setHexOutOfMapBounds(x, y++);
		// (1, 20)
		setHexOutOfMapBounds(x, y++);
		// (1, 21)
		setHexOutOfMapBounds(x, y++);
		// (1, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 2 ****************/
		x = 2;
		y = 0;
		// (2, 0)
		setHexOutOfMapBounds(x, y++);
		// (2, 1)
		setHexOutOfMapBounds(x, y++);
		// (2, 2)
		setHexOutOfMapBounds(x, y++);
		// (2, 3)
		setHexOutOfMapBounds(x, y++);
		// (2, 4)
		setHexOutOfMapBounds(x, y++);
		// (2, 5)
		setHexOutOfMapBounds(x, y++);
		// (2, 6)
		setHexOutOfMapBounds(x, y++);
		// (2, 7)
		setHexOutOfMapBounds(x, y++);
		// (2, 8)
		setHexOutOfMapBounds(x, y++);
		// (2, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 20)
		setHexOutOfMapBounds(x, y++);
		// (2, 21)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 3 ****************/
		x = 3;
		y = 0;
		// (3, 0)
		setHexOutOfMapBounds(x, y++);
		// (3, 1)
		setHexOutOfMapBounds(x, y++);
		// (3, 2)
		setHexOutOfMapBounds(x, y++);
		// (3, 3)
		setHexOutOfMapBounds(x, y++);
		// (3, 4)
		setHexOutOfMapBounds(x, y++);
		// (3, 5)
		setHexOutOfMapBounds(x, y++);
		// (3, 6)
		setHexOutOfMapBounds(x, y++);
		// (3, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (3, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 21)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 22)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};

		/**************** COLUMN 4 ****************/
		x = 4;
		y = 0;
		// (4, 0)
		setHexOutOfMapBounds(x, y++);
		// (4, 1)
		setHexOutOfMapBounds(x, y++);
		// (4, 2)
		setHexOutOfMapBounds(x, y++);
		// (4, 3)
		setHexOutOfMapBounds(x, y++);
		// (4, 4)
		setHexOutOfMapBounds(x, y++);
		// (4, 5)
		setHexOutOfMapBounds(x, y++);
		// (4, 6)
		setHexOutOfMapBounds(x, y++);
		// (4, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 21)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 22)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};

		/**************** COLUMN 5 ****************/
		x = 5;
		y = 0;
		// (5, 0)
		setHexOutOfMapBounds(x, y++);
		// (5, 1)
		setHexOutOfMapBounds(x, y++);
		// (5, 2)
		setHexOutOfMapBounds(x, y++);
		// (5, 3)
		setHexOutOfMapBounds(x, y++);
		// (5, 4)
		setHexOutOfMapBounds(x, y++);
		// (5, 5)
		setHexOutOfMapBounds(x, y++);
		// (5, 6)
		setHexOutOfMapBounds(x, y++);
		// (5, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (5, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 21)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 22)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};

		/**************** COLUMN 6 ****************/
		x = 6;
		y = 0;
		// (6, 0)
		setHexOutOfMapBounds(x, y++);
		// (6, 1)
		setHexOutOfMapBounds(x, y++);
		// (6, 2)
		setHexOutOfMapBounds(x, y++);
		// (6, 3)
		setHexOutOfMapBounds(x, y++);
		// (6, 4)
		setHexOutOfMapBounds(x, y++);
		// (6, 5)
		setHexOutOfMapBounds(x, y++);
		// (6, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 21)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 22)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};

		/**************** COLUMN 7 ****************/
		x = 7;
		y = 0;
		// (7, 0)
		setHexOutOfMapBounds(x, y++);
		// (7, 1)
		setHexOutOfMapBounds(x, y++);
		// (7, 2)
		setHexOutOfMapBounds(x, y++);
		// (7, 3)
		setHexOutOfMapBounds(x, y++);
		// (7, 4)
		setHexOutOfMapBounds(x, y++);
		// (7, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 21)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 8 ****************/
		x = 8;
		y = 0;
		// (8, 0)
		setHexOutOfMapBounds(x, y++);
		// (8, 1)
		setHexOutOfMapBounds(x, y++);
		// (8, 2)
		setHexOutOfMapBounds(x, y++);
		// (8, 3)
		setHexOutOfMapBounds(x, y++);
		// (8, 4)
		setHexOutOfMapBounds(x, y++);
		// (8, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (8, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 21)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 9 ****************/
		x = 9;
		y = 0;
		// (9, 0)
		setHexOutOfMapBounds(x, y++);
		// (9, 1)
		setHexOutOfMapBounds(x, y++);
		// (9, 2)
		setHexOutOfMapBounds(x, y++);
		// (9, 3)
		setHexOutOfMapBounds(x, y++);
		// (9, 4)
		setHexOutOfMapBounds(x, y++);
		// (9, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 21)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 10 ****************/
		x = 10;
		y = 0;
		// (10, 0)
		setHexOutOfMapBounds(x, y++);
		// (10, 1)
		setHexOutOfMapBounds(x, y++);
		// (10, 2)
		setHexOutOfMapBounds(x, y++);
		// (10, 3)
		setHexOutOfMapBounds(x, y++);
		// (10, 4)
		setHexOutOfMapBounds(x, y++);
		// (10, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (10, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 21)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 11 ****************/
		x = 11;
		y = 0;
		// (11, 0)
		setHexOutOfMapBounds(x, y++);
		// (11, 1)
		setHexOutOfMapBounds(x, y++);
		// (11, 2)
		setHexOutOfMapBounds(x, y++);
		// (11, 3)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 21)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 12 ****************/
		x = 12;
		y = 0;
		// (12, 0)
		setHexOutOfMapBounds(x, y++);
		// (12, 1)
		setHexOutOfMapBounds(x, y++);
		// (12, 2)
		setHexOutOfMapBounds(x, y++);
		// (12, 3)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 21)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 13 ****************/
		x = 13;
		y = 0;
		// (13, 0)
		setHexOutOfMapBounds(x, y++);
		// (13, 1)
		setHexOutOfMapBounds(x, y++);
		// (13, 2)
		setHexOutOfMapBounds(x, y++);
		// (13, 3)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (13, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (13, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 21)
		setHexOutOfMapBounds(x, y++);
		// (13, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 14 ****************/
		x = 14;
		y = 0;
		// (14, 0)
		setHexOutOfMapBounds(x, y++);
		// (14, 1)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 2)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 3)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 21)
		setHexOutOfMapBounds(x, y++);
		// (14, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 15 ****************/
		x = 15;
		y = 0;
		// (15, 0)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 1)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 2)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 3)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 21)
		setHexOutOfMapBounds(x, y++);
		// (15, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 16 ****************/
		x = 16;
		y = 0;
		// (16, 0)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 1)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 2)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 3)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (16, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 21)
		setHexOutOfMapBounds(x, y++);
		// (16, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 17 ****************/
		x = 17;
		y = 0;
		// (17, 0)
		setHexOutOfMapBounds(x, y++);
		// (17, 1)
		setHexOutOfMapBounds(x, y++);
		// (17, 2)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 3)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 21)
		setHexOutOfMapBounds(x, y++);
		// (17, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 18 ****************/
		x = 18;
		y = 0;
		// (18, 0)
		setHexOutOfMapBounds(x, y++);
		// (18, 1)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 2)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 3)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (18, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 21)
		setHexOutOfMapBounds(x, y++);
		// (18, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 19 ****************/
		x = 19;
		y = 0;
		// (19, 0)
		setHexOutOfMapBounds(x, y++);
		// (19, 1)
		setHexOutOfMapBounds(x, y++);
		// (19, 2)
		setHexOutOfMapBounds(x, y++);
		// (19, 3)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (19, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 21)
		setHexOutOfMapBounds(x, y++);
		// (19, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 20 ****************/
		x = 20;
		y = 0;
		// (20, 0)
		setHexOutOfMapBounds(x, y++);
		// (20, 1)
		setHexOutOfMapBounds(x, y++);
		// (20, 2)
		setHexOutOfMapBounds(x, y++);
		// (20, 3)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 21)
		setHexOutOfMapBounds(x, y++);
		// (20, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 21 ****************/
		x = 21;
		y = 0;
		// (21, 0)
		setHexOutOfMapBounds(x, y++);
		// (21, 1)
		setHexOutOfMapBounds(x, y++);
		// (21, 2)
		setHexOutOfMapBounds(x, y++);
		// (21, 3)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 21)
		setHexOutOfMapBounds(x, y++);
		// (21, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 22 ****************/
		x = 22;
		y = 0;
		// (22, 0)
		setHexOutOfMapBounds(x, y++);
		// (22, 1)
		setHexOutOfMapBounds(x, y++);
		// (22, 2)
		setHexOutOfMapBounds(x, y++);
		// (22, 3)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (22, 21)
		setHexOutOfMapBounds(x, y++);
		// (22, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 23 ****************/
		x = 23;
		y = 0;
		// (23, 0)
		setHexOutOfMapBounds(x, y++);
		// (23, 1)
		setHexOutOfMapBounds(x, y++);
		// (23, 2)
		setHexOutOfMapBounds(x, y++);
		// (23, 3)
		setHexOutOfMapBounds(x, y++);
		// (23, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (23, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (23, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (23, 21)
		setHexOutOfMapBounds(x, y++);
		// (23, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 24 ****************/
		x = 24;
		y = 0;
		// (24, 0)
		setHexOutOfMapBounds(x, y++);
		// (24, 1)
		setHexOutOfMapBounds(x, y++);
		// (24, 2)
		setHexOutOfMapBounds(x, y++);
		// (24, 3)
		setHexOutOfMapBounds(x, y++);
		// (24, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (24, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (24, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (24, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (24, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (24, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (24, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (24, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (24, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (24, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (24, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (24, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (24, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (24, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (24, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (24, 19)
		setHexOutOfMapBounds(x, y++);
		// (24, 20)
		setHexOutOfMapBounds(x, y++);
		// (24, 21)
		setHexOutOfMapBounds(x, y++);
		// (24, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 25 ****************/
		x = 25;
		y = 0;
		// (25, 0)
		setHexOutOfMapBounds(x, y++);
		// (25, 1)
		setHexOutOfMapBounds(x, y++);
		// (25, 2)
		setHexOutOfMapBounds(x, y++);
		// (25, 3)
		setHexOutOfMapBounds(x, y++);
		// (25, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (25, 19)
		setHexOutOfMapBounds(x, y++);
		// (25, 20)
		setHexOutOfMapBounds(x, y++);
		// (25, 21)
		setHexOutOfMapBounds(x, y++);
		// (25, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 26 ****************/
		x = 26;
		y = 0;
		// (26, 0)
		setHexOutOfMapBounds(x, y++);
		// (26, 1)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 2)
		setHexOutOfMapBounds(x, y++);
		// (26, 3)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 16)
		setHexOutOfMapBounds(x, y++);
		// (26, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (26, 19)
		setHexOutOfMapBounds(x, y++);
		// (26, 20)
		setHexOutOfMapBounds(x, y++);
		// (26, 21)
		setHexOutOfMapBounds(x, y++);
		// (26, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 27 ****************/
		x = 27;
		y = 0;
		// (27, 0)
		setHexOutOfMapBounds(x, y++);
		// (27, 1)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 2)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 3)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 4)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 5)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (27, 18)
		setHexOutOfMapBounds(x, y++);
		// (27, 19)
		setHexOutOfMapBounds(x, y++);
		// (27, 20)
		setHexOutOfMapBounds(x, y++);
		// (27, 21)
		setHexOutOfMapBounds(x, y++);
		// (27, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 28 ****************/
		x = 28;
		y = 0;
		// (28, 0)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (28, 1)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (28, 2)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (28, 3)
		setHexOutOfMapBounds(x, y++);
		// (28, 4)
		setHexOutOfMapBounds(x, y++);
		// (28, 5)
		setHexOutOfMapBounds(x, y++);
		// (28, 6)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (28, 7)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (28, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (28, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (28, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (28, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (28, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (28, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (28, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (28, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (28, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (28, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (28, 18)
		setHexOutOfMapBounds(x, y++);
		// (28, 19)
		setHexOutOfMapBounds(x, y++);
		// (28, 20)
		setHexOutOfMapBounds(x, y++);
		// (28, 21)
		setHexOutOfMapBounds(x, y++);
		// (28, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 29 ****************/
		x = 29;
		y = 0;
		// (29, 0)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (29, 1)
		setHexOutOfMapBounds(x, y++);
		// (29, 2)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (29, 3)
		setHexOutOfMapBounds(x, y++);
		// (29, 4)
		setHexOutOfMapBounds(x, y++);
		// (29, 5)
		setHexOutOfMapBounds(x, y++);
		// (29, 6)
		setHexOutOfMapBounds(x, y++);
		// (29, 7)
		setHexOutOfMapBounds(x, y++);
		// (29, 8)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (29, 9)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (29, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (29, 11)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (29, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (29, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (29, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (29, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (29, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (29, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (29, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (29, 19)
		setHexOutOfMapBounds(x, y++);
		// (29, 20)
		setHexOutOfMapBounds(x, y++);
		// (29, 21)
		setHexOutOfMapBounds(x, y++);
		// (29, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 30 ****************/
		x = 30;
		y = 0;
		// (30, 0)
		setHexOutOfMapBounds(x, y++);
		// (30, 1)
		setHexOutOfMapBounds(x, y++);
		// (30, 2)
		setHexOutOfMapBounds(x, y++);
		// (30, 3)
		setHexOutOfMapBounds(x, y++);
		// (30, 4)
		setHexOutOfMapBounds(x, y++);
		// (30, 5)
		setHexOutOfMapBounds(x, y++);
		// (30, 6)
		setHexOutOfMapBounds(x, y++);
		// (30, 7)
		setHexOutOfMapBounds(x, y++);
		// (30, 8)
		setHexOutOfMapBounds(x, y++);
		// (30, 9)
		setHexOutOfMapBounds(x, y++);
		// (30, 10)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (30, 11)
		setHexOutOfMapBounds(x, y++);
		// (30, 12)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (30, 13)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (30, 14)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (30, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (30, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (30, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (30, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (30, 19)
		setHexOutOfMapBounds(x, y++);
		// (30, 20)
		setHexOutOfMapBounds(x, y++);
		// (30, 21)
		setHexOutOfMapBounds(x, y++);
		// (30, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 31 ****************/
		x = 31;
		y = 0;
		// (31, 0)
		setHexOutOfMapBounds(x, y++);
		// (31, 1)
		setHexOutOfMapBounds(x, y++);
		// (31, 2)
		setHexOutOfMapBounds(x, y++);
		// (31, 3)
		setHexOutOfMapBounds(x, y++);
		// (31, 4)
		setHexOutOfMapBounds(x, y++);
		// (31, 5)
		setHexOutOfMapBounds(x, y++);
		// (31, 6)
		setHexOutOfMapBounds(x, y++);
		// (31, 7)
		setHexOutOfMapBounds(x, y++);
		// (31, 8)
		setHexOutOfMapBounds(x, y++);
		// (31, 9)
		setHexOutOfMapBounds(x, y++);
		// (31, 10)
		setHexOutOfMapBounds(x, y++);
		// (31, 11)
		setHexOutOfMapBounds(x, y++);
		// (31, 12)
		setHexOutOfMapBounds(x, y++);
		// (31, 13)
		setHexOutOfMapBounds(x, y++);
		// (31, 14)
		setHexOutOfMapBounds(x, y++);
		// (31, 15)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (31, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (31, 17)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (31, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (31, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (31, 20)
		setHexOutOfMapBounds(x, y++);
		// (31, 21)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (31, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 32 ****************/
		x = 32;
		y = 0;
		// (32, 0)
		setHexOutOfMapBounds(x, y++);
		// (32, 1)
		setHexOutOfMapBounds(x, y++);
		// (32, 2)
		setHexOutOfMapBounds(x, y++);
		// (32, 3)
		setHexOutOfMapBounds(x, y++);
		// (32, 4)
		setHexOutOfMapBounds(x, y++);
		// (32, 5)
		setHexOutOfMapBounds(x, y++);
		// (32, 6)
		setHexOutOfMapBounds(x, y++);
		// (32, 7)
		setHexOutOfMapBounds(x, y++);
		// (32, 8)
		setHexOutOfMapBounds(x, y++);
		// (32, 9)
		setHexOutOfMapBounds(x, y++);
		// (32, 10)
		setHexOutOfMapBounds(x, y++);
		// (32, 11)
		setHexOutOfMapBounds(x, y++);
		// (32, 12)
		setHexOutOfMapBounds(x, y++);
		// (32, 13)
		setHexOutOfMapBounds(x, y++);
		// (32, 14)
		setHexOutOfMapBounds(x, y++);
		// (32, 15)
		setHexOutOfMapBounds(x, y++);
		// (32, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (32, 17)
		setHexOutOfMapBounds(x, y++);
		// (32, 18)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (32, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (32, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (32, 21)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (32, 22)
		setHexOutOfMapBounds(x, y++);

		/**************** COLUMN 33 ****************/
		x = 33;
		y = 0;
		// (33, 0)
		setHexOutOfMapBounds(x, y++);
		// (33, 1)
		setHexOutOfMapBounds(x, y++);
		// (33, 2)
		setHexOutOfMapBounds(x, y++);
		// (33, 3)
		setHexOutOfMapBounds(x, y++);
		// (33, 4)
		setHexOutOfMapBounds(x, y++);
		// (33, 5)
		setHexOutOfMapBounds(x, y++);
		// (33, 6)
		setHexOutOfMapBounds(x, y++);
		// (33, 7)
		setHexOutOfMapBounds(x, y++);
		// (33, 8)
		setHexOutOfMapBounds(x, y++);
		// (33, 9)
		setHexOutOfMapBounds(x, y++);
		// (33, 10)
		setHexOutOfMapBounds(x, y++);
		// (33, 11)
		setHexOutOfMapBounds(x, y++);
		// (33, 12)
		setHexOutOfMapBounds(x, y++);
		// (33, 13)
		setHexOutOfMapBounds(x, y++);
		// (33, 14)
		setHexOutOfMapBounds(x, y++);
		// (33, 15)
		setHexOutOfMapBounds(x, y++);
		// (33, 16)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (33, 17)
		setHexOutOfMapBounds(x, y++);
		// (33, 18)
		setHexOutOfMapBounds(x, y++);
		// (33, 19)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (33, 20)
		arrayOfHexes[x, y++] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (33, 21)
		setHexOutOfMapBounds(x, y++);
		// (33, 22)
		setHexOutOfMapBounds(x, y++);
	}
		

	private void setHexOutOfMapBounds(int x, int y)
	{
		arrayOfHexes[x, y] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, false}
		};
	}
}
