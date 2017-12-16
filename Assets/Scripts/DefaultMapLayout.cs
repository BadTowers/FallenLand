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
		setHexOutOfMapBounds(2, 0);
		// (2, 1)
		setHexOutOfMapBounds(2, 1);
		// (2, 2)
		setHexOutOfMapBounds(2, 2);
		// (2, 3)
		setHexOutOfMapBounds(2, 3);
		// (2, 4)
		setHexOutOfMapBounds(2, 4);
		// (2, 5)
		setHexOutOfMapBounds(2, 5);
		// (2, 6)
		setHexOutOfMapBounds(2, 6);
		// (2, 7)
		arrayOfHexes[2, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 8)
		arrayOfHexes[2, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 9)
		arrayOfHexes[2, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 10)
		arrayOfHexes[2, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 11)
		arrayOfHexes[2, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (2, 12)
		arrayOfHexes[2, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 13)
		arrayOfHexes[2, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 14)
		arrayOfHexes[2, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 15)
		arrayOfHexes[2, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 16)
		arrayOfHexes[2, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 17)
		arrayOfHexes[2, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 18)
		arrayOfHexes[2, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 19)
		arrayOfHexes[2, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 20)
		arrayOfHexes[2, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 21)
		arrayOfHexes[2, 21] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (2, 22)
		arrayOfHexes[2, 22] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};

		/**************** COLUMN 3 ****************/
		// (3, 0)
		setHexOutOfMapBounds(3, 0);
		// (3, 1)
		setHexOutOfMapBounds(3, 1);
		// (3, 2)
		setHexOutOfMapBounds(3, 2);
		// (3, 3)
		setHexOutOfMapBounds(3, 3);
		// (3, 4)
		setHexOutOfMapBounds(3, 4);
		// (3, 5)
		setHexOutOfMapBounds(3, 5);
		// (3, 6)
		setHexOutOfMapBounds(3, 6);
		// (3, 7)
		arrayOfHexes[3, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 8)
		arrayOfHexes[3, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 9)
		arrayOfHexes[3, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 10)
		arrayOfHexes[3, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 11)
		arrayOfHexes[3, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 12)
		arrayOfHexes[3, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 13)
		arrayOfHexes[3, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 14)
		arrayOfHexes[3, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 15)
		arrayOfHexes[3, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 16)
		arrayOfHexes[3, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 17)
		arrayOfHexes[3, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 18)
		arrayOfHexes[3, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 19)
		arrayOfHexes[3, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 20)
		arrayOfHexes[3, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 21)
		arrayOfHexes[3, 21] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (3, 22)
		arrayOfHexes[3, 22] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};

		/**************** COLUMN 4 ****************/
		// (4, 0)
		setHexOutOfMapBounds(4, 0);
		// (4, 1)
		setHexOutOfMapBounds(4, 1);
		// (4, 2)
		setHexOutOfMapBounds(4, 2);
		// (4, 3)
		setHexOutOfMapBounds(4, 3);
		// (4, 4)
		setHexOutOfMapBounds(4, 4);
		// (4, 5)
		setHexOutOfMapBounds(4, 5);
		// (4, 6)
		setHexOutOfMapBounds(4, 6);
		// (4, 7)
		arrayOfHexes[4, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 8)
		arrayOfHexes[4, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 9)
		arrayOfHexes[4, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 10)
		arrayOfHexes[4, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 11)
		arrayOfHexes[4, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 12)
		arrayOfHexes[4, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 13)
		arrayOfHexes[4, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 14)
		arrayOfHexes[4, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 15)
		arrayOfHexes[4, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 16)
		arrayOfHexes[4, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 17)
		arrayOfHexes[4, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 18)
		arrayOfHexes[4, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 19)
		arrayOfHexes[4, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (4, 20)
		arrayOfHexes[4, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 21)
		arrayOfHexes[4, 21] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (4, 22)
		arrayOfHexes[4, 22] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};

		/**************** COLUMN 5 ****************/
		// (5, 0)
		setHexOutOfMapBounds(5, 0);
		// (5, 1)
		setHexOutOfMapBounds(5, 1);
		// (5, 2)
		setHexOutOfMapBounds(5, 2);
		// (5, 3)
		setHexOutOfMapBounds(5, 3);
		// (5, 4)
		setHexOutOfMapBounds(5, 4);
		// (5, 5)
		setHexOutOfMapBounds(5, 5);
		// (5, 6)
		arrayOfHexes[5, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 7)
		arrayOfHexes[5, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 8)
		arrayOfHexes[5, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 9)
		arrayOfHexes[5, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 10)
		arrayOfHexes[5, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 11)
		arrayOfHexes[5, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 12)
		arrayOfHexes[5, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 13)
		arrayOfHexes[5, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 14)
		arrayOfHexes[5, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 15)
		arrayOfHexes[5, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 16)
		arrayOfHexes[5, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 17)
		arrayOfHexes[5, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 18)
		arrayOfHexes[5, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 19)
		arrayOfHexes[5, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 20)
		arrayOfHexes[5, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 21)
		arrayOfHexes[5, 21] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (5, 22)
		arrayOfHexes[5, 22] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};

		/**************** COLUMN 6 ****************/
		// (6, 0)
		setHexOutOfMapBounds(6, 0);
		// (6, 1)
		setHexOutOfMapBounds(6, 1);
		// (6, 2)
		setHexOutOfMapBounds(6, 2);
		// (6, 3)
		setHexOutOfMapBounds(6, 3);
		// (6, 4)
		setHexOutOfMapBounds(6, 4);
		// (6, 5)
		arrayOfHexes[6, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 6)
		arrayOfHexes[6, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 7)
		arrayOfHexes[6, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 8)
		arrayOfHexes[6, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 9)
		arrayOfHexes[6, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 10)
		arrayOfHexes[6, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 11)
		arrayOfHexes[6, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 12)
		arrayOfHexes[6, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 13)
		arrayOfHexes[6, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 14)
		arrayOfHexes[6, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 15)
		arrayOfHexes[6, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 16)
		arrayOfHexes[6, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 17)
		arrayOfHexes[6, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 18)
		arrayOfHexes[6, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 19)
		arrayOfHexes[6, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 20)
		arrayOfHexes[6, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 21)
		arrayOfHexes[6, 21] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (6, 22)
		setHexOutOfMapBounds(6, 22);

		/**************** COLUMN 7 ****************/
		// (7, 0)
		setHexOutOfMapBounds(7, 0);
		// (7, 1)
		setHexOutOfMapBounds(7, 1);
		// (7, 2)
		setHexOutOfMapBounds(7, 2);
		// (7, 3)
		setHexOutOfMapBounds(7, 3);
		// (7, 4)
		setHexOutOfMapBounds(7, 4);
		// (7, 5)
		arrayOfHexes[7, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 6)
		arrayOfHexes[7, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 7)
		arrayOfHexes[7, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 8)
		arrayOfHexes[7, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 9)
		arrayOfHexes[7, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 10)
		arrayOfHexes[7, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 11)
		arrayOfHexes[7, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 12)
		arrayOfHexes[7, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 13)
		arrayOfHexes[7, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 14)
		arrayOfHexes[7, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 15)
		arrayOfHexes[7, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (7, 16)
		arrayOfHexes[7, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 17)
		arrayOfHexes[7, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 18)
		arrayOfHexes[7, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 19)
		arrayOfHexes[7, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 20)
		arrayOfHexes[7, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 21)
		arrayOfHexes[7, 21] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (7, 22)
		setHexOutOfMapBounds(7, 22);

		/**************** COLUMN 8 ****************/
		// (8, 0)
		setHexOutOfMapBounds(8, 0);
		// (8, 1)
		setHexOutOfMapBounds(8, 1);
		// (8, 2)
		setHexOutOfMapBounds(8, 2);
		// (8, 3)
		setHexOutOfMapBounds(8, 3);
		// (8, 4)
		setHexOutOfMapBounds(8, 4);
		// (8, 5)
		arrayOfHexes[8, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 6)
		arrayOfHexes[8, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 7)
		arrayOfHexes[8, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 8)
		arrayOfHexes[8, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 9)
		arrayOfHexes[8, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 10)
		arrayOfHexes[8, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 11)
		arrayOfHexes[8, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 12)
		arrayOfHexes[8, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 13)
		arrayOfHexes[8, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 14)
		arrayOfHexes[8, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 15)
		arrayOfHexes[8, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 16)
		arrayOfHexes[8, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 17)
		arrayOfHexes[8, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 18)
		arrayOfHexes[8, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 19)
		arrayOfHexes[8, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 20)
		arrayOfHexes[8, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 21)
		arrayOfHexes[8, 21] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (8, 22)
		setHexOutOfMapBounds(8, 22);

		/**************** COLUMN 9 ****************/
		// (9, 0)
		setHexOutOfMapBounds(9, 0);
		// (9, 1)
		setHexOutOfMapBounds(9, 1);
		// (9, 2)
		setHexOutOfMapBounds(9, 2);
		// (9, 3)
		setHexOutOfMapBounds(9, 3);
		// (9, 4)
		setHexOutOfMapBounds(9, 4);
		// (9, 5)
		arrayOfHexes[9, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 6)
		arrayOfHexes[9, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (9, 7)
		arrayOfHexes[9, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 8)
		arrayOfHexes[9, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 9)
		arrayOfHexes[9, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 10)
		arrayOfHexes[9, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 11)
		arrayOfHexes[9, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 12)
		arrayOfHexes[9, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 13)
		arrayOfHexes[9, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 14)
		arrayOfHexes[9, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 15)
		arrayOfHexes[9, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 16)
		arrayOfHexes[9, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 17)
		arrayOfHexes[9, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 18)
		arrayOfHexes[9, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 19)
		arrayOfHexes[9, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 20)
		arrayOfHexes[9, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 21)
		arrayOfHexes[9, 21] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (9, 21)
		setHexOutOfMapBounds(9, 21);

		/**************** COLUMN 10 ****************/
		// (10, 0)
		setHexOutOfMapBounds(10, 0);
		// (10, 1)
		setHexOutOfMapBounds(10, 1);
		// (10, 2)
		setHexOutOfMapBounds(10, 2);
		// (10, 3)
		arrayOfHexes[10, 3] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 4)
		arrayOfHexes[10, 4] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 5)
		arrayOfHexes[10, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 6)
		arrayOfHexes[10, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 7)
		arrayOfHexes[10, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 8)
		arrayOfHexes[10, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 9)
		arrayOfHexes[10, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 10)
		arrayOfHexes[10, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 11)
		arrayOfHexes[10, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 12)
		arrayOfHexes[10, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 13)
		arrayOfHexes[10, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 14)
		arrayOfHexes[10, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 15)
		arrayOfHexes[10, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 16)
		arrayOfHexes[10, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 17)
		arrayOfHexes[10, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 18)
		arrayOfHexes[10, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 19)
		arrayOfHexes[10, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 20)
		arrayOfHexes[10, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (10, 21)
		setHexOutOfMapBounds(10, 21);
		// (10, 22)
		setHexOutOfMapBounds(10, 22);

		/**************** COLUMN 11 ****************/
		// (11, 0)
		setHexOutOfMapBounds(11, 0);
		// (11, 1)
		setHexOutOfMapBounds(11, 1);
		// (11, 2)
		setHexOutOfMapBounds(11, 2);
		// (11, 3)
		arrayOfHexes[11, 3] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 4)
		arrayOfHexes[11, 4] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 5)
		arrayOfHexes[11, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 6)
		arrayOfHexes[11, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 7)
		arrayOfHexes[11, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 8)
		arrayOfHexes[11, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 9)
		arrayOfHexes[11, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 10)
		arrayOfHexes[11, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 11)
		arrayOfHexes[11, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 12)
		arrayOfHexes[11, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, true}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 13)
		arrayOfHexes[11, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 14)
		arrayOfHexes[11, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 15)
		arrayOfHexes[11, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 16)
		arrayOfHexes[11, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 17)
		arrayOfHexes[11, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 18)
		arrayOfHexes[11, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 19)
		arrayOfHexes[11, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 20)
		arrayOfHexes[11, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (11, 21)
		setHexOutOfMapBounds(11, 21);
		// (11, 22)
		setHexOutOfMapBounds(11, 22);

		/**************** COLUMN 12 ****************/
		// (12, 0)
		setHexOutOfMapBounds(12, 0);
		// (12, 1)
		setHexOutOfMapBounds(12, 1);
		// (12, 2)
		setHexOutOfMapBounds(12, 2);
		// (12, 3)
		arrayOfHexes[12, 3] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 4)
		arrayOfHexes[12, 4] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 5)
		arrayOfHexes[12, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 6)
		arrayOfHexes[12, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 7)
		arrayOfHexes[12, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 8)
		arrayOfHexes[12, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 9)
		arrayOfHexes[12, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 10)
		arrayOfHexes[12, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 11)
		arrayOfHexes[12, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 12)
		arrayOfHexes[12, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 13)
		arrayOfHexes[12, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (12, 14)
		arrayOfHexes[12, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 15)
		arrayOfHexes[12, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 16)
		arrayOfHexes[12, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 17)
		arrayOfHexes[12, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 18)
		arrayOfHexes[12, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 19)
		arrayOfHexes[12, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (12, 20)
		arrayOfHexes[12, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (12, 21)
		setHexOutOfMapBounds(12, 21);
		// (12, 22)
		setHexOutOfMapBounds(12, 22);

		/**************** COLUMN 13 ****************/
		// (13, 0)
		setHexOutOfMapBounds(13, 0);
		// (13, 1)
		arrayOfHexes[13, 1] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 2)
		arrayOfHexes[13, 2] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 3)
		arrayOfHexes[13, 3] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 4)
		arrayOfHexes[13, 4] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 5)
		arrayOfHexes[13, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 6)
		arrayOfHexes[13, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 7)
		arrayOfHexes[13, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 8)
		arrayOfHexes[13, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 9)
		arrayOfHexes[13, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 10)
		arrayOfHexes[13, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 11)
		arrayOfHexes[13, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 12)
		arrayOfHexes[13, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 13)
		arrayOfHexes[13, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 14)
		arrayOfHexes[13, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 15)
		arrayOfHexes[13, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 16)
		arrayOfHexes[13, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 17)
		arrayOfHexes[13, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 18)
		arrayOfHexes[13, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 19)
		arrayOfHexes[13, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 20)
		arrayOfHexes[13, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (13, 21)
		setHexOutOfMapBounds(13, 21);
		// (13, 21)
		setHexOutOfMapBounds(13, 22);

		/**************** COLUMN 14 ****************/
		// (14, 0)
		arrayOfHexes[14, 0] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 1)
		arrayOfHexes[14, 1] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 2)
		arrayOfHexes[14, 2] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 3)
		arrayOfHexes[14, 3] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 4)
		arrayOfHexes[14, 4] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 5)
		arrayOfHexes[14, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 6)
		arrayOfHexes[14, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 7)
		arrayOfHexes[14, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 8)
		arrayOfHexes[14, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 9)
		arrayOfHexes[14, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 10)
		arrayOfHexes[14, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 11)
		arrayOfHexes[14, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 12)
		arrayOfHexes[14, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 13)
		arrayOfHexes[14, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 14)
		arrayOfHexes[14, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 15)
		arrayOfHexes[14, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 16)
		arrayOfHexes[14, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 17)
		arrayOfHexes[14, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 18)
		arrayOfHexes[14, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 19)
		arrayOfHexes[14, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 20)
		arrayOfHexes[14, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (14, 21)
		setHexOutOfMapBounds(14, 21);
		// (14, 22)
		setHexOutOfMapBounds(14, 22);

		/**************** COLUMN 15 ****************/
		// (15, 0)
		arrayOfHexes[15, 0] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 1)
		arrayOfHexes[15, 1] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 2)
		arrayOfHexes[15, 2] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 3)
		arrayOfHexes[15, 3] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 4)
		arrayOfHexes[15, 4] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (15, 5)
		arrayOfHexes[15, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 6)
		arrayOfHexes[15, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 7)
		arrayOfHexes[15, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 8)
		arrayOfHexes[15, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 9)
		arrayOfHexes[15, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 10)
		arrayOfHexes[15, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 11)
		arrayOfHexes[15, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 12)
		arrayOfHexes[15, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 13)
		arrayOfHexes[15, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 14)
		arrayOfHexes[15, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 15)
		arrayOfHexes[15, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 16)
		arrayOfHexes[15, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 17)
		arrayOfHexes[15, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 18)
		arrayOfHexes[15, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 19)
		arrayOfHexes[15, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 20)
		arrayOfHexes[15, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (15, 21)
		setHexOutOfMapBounds(15, 21);
		// (15, 22)
		setHexOutOfMapBounds(15, 22);

		//Col 16
		// (16, 0)
		setHexOutOfMapBounds(16, 0);
		// (16, 1)
		setHexOutOfMapBounds(16, 1);
		// (16, 2)
		arrayOfHexes[16, 2] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 3)
		arrayOfHexes[16, 3] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 4)
		arrayOfHexes[16, 4] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 5)
		arrayOfHexes[16, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 6)
		arrayOfHexes[16, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 7)
		arrayOfHexes[16, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 8)
		arrayOfHexes[16, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 9)
		arrayOfHexes[16, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 10)
		arrayOfHexes[16, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 11)
		arrayOfHexes[16, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 12)
		arrayOfHexes[16, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 13)
		arrayOfHexes[16, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 14)
		arrayOfHexes[16, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 15)
		arrayOfHexes[16, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 16)
		arrayOfHexes[16, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 17)
		arrayOfHexes[16, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 18)
		arrayOfHexes[16, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 19)
		arrayOfHexes[16, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 20)
		arrayOfHexes[16, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (16, 21)
		setHexOutOfMapBounds(16, 21);
		// (16, 22)
		setHexOutOfMapBounds(16, 22);

		//COL 17
		// (17, 0)
		setHexOutOfMapBounds(17, 0);
		// (17, 1)
		arrayOfHexes[17, 1] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 2)
		arrayOfHexes[17, 2] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 3)
		arrayOfHexes[17, 3] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 4)
		arrayOfHexes[17, 4] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 5)
		arrayOfHexes[17, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 6)
		arrayOfHexes[17, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 7)
		arrayOfHexes[17, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 8)
		arrayOfHexes[17, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 9)
		arrayOfHexes[17, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 10)
		arrayOfHexes[17, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (17, 11)
		arrayOfHexes[17, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 12)
		arrayOfHexes[17, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 13)
		arrayOfHexes[17, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 14)
		arrayOfHexes[17, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 15)
		arrayOfHexes[17, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 16)
		arrayOfHexes[17, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 17)
		arrayOfHexes[17, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 18)
		arrayOfHexes[17, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 19)
		arrayOfHexes[17, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 20)
		arrayOfHexes[17, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (17, 21)
		setHexOutOfMapBounds(17, 21);
		// (17, 22)
		setHexOutOfMapBounds(17, 22);

		//COL 18
		// (18, 0)
		setHexOutOfMapBounds(18, 0);
		// (18, 1)
		setHexOutOfMapBounds(18, 1);
		// (18, 2)
		setHexOutOfMapBounds(18, 2);
		// (18, 3)
		arrayOfHexes[18, 3] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 4)
		arrayOfHexes[18, 4] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 5)
		arrayOfHexes[18, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 6)
		arrayOfHexes[18, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 7)
		arrayOfHexes[18, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 8)
		arrayOfHexes[18, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 9)
		arrayOfHexes[18, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 10)
		arrayOfHexes[18, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 11)
		arrayOfHexes[18, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 12)
		arrayOfHexes[18, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 13)
		arrayOfHexes[18, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 14)
		arrayOfHexes[18, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 15)
		arrayOfHexes[18, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 16)
		arrayOfHexes[18, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 17)
		arrayOfHexes[18, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, true}, {hexType.VALID, true}
		};
		// (18, 18)
		arrayOfHexes[18, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 19)
		arrayOfHexes[18, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 20)
		arrayOfHexes[18, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (18, 21)
		setHexOutOfMapBounds(18, 21);
		// (18, 22)
		setHexOutOfMapBounds(18, 22);

		// COL 19
		// (19, 0)
		setHexOutOfMapBounds(19, 0);
		// (19, 1)
		setHexOutOfMapBounds(19, 1);
		// (19, 2)
		setHexOutOfMapBounds(19, 2);
		// (19, 3)
		arrayOfHexes[19, 3] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 4)
		arrayOfHexes[19, 4] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, true}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 5)
		arrayOfHexes[19, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 6)
		arrayOfHexes[19, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 7)
		arrayOfHexes[19, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 8)
		arrayOfHexes[19, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 9)
		arrayOfHexes[19, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 10)
		arrayOfHexes[19, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 11)
		arrayOfHexes[19, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 12)
		arrayOfHexes[19, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 13)
		arrayOfHexes[19, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 14)
		arrayOfHexes[19, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 15)
		arrayOfHexes[19, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 16)
		arrayOfHexes[19, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 17)
		arrayOfHexes[19, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 18)
		arrayOfHexes[19, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 19)
		arrayOfHexes[19, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (19, 20)
		setHexOutOfMapBounds(19, 20);
		// (19, 21)
		setHexOutOfMapBounds(19, 21);
		// (19, 22)
		setHexOutOfMapBounds(19, 22);

		// COL 20
		// (20, 0)
		setHexOutOfMapBounds(20, 0);
		// (20, 1)
		setHexOutOfMapBounds(20, 1);
		// (20, 2)
		setHexOutOfMapBounds(20, 2);
		// (20, 3)
		arrayOfHexes[20, 3] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 4)
		arrayOfHexes[20, 4] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 5)
		arrayOfHexes[20, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 6)
		arrayOfHexes[20, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 7)
		arrayOfHexes[20, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 8)
		arrayOfHexes[20, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 9)
		arrayOfHexes[20, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 10)
		arrayOfHexes[20, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 11)
		arrayOfHexes[20, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 12)
		arrayOfHexes[20, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 13)
		arrayOfHexes[20, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 14)
		arrayOfHexes[20, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 15)
		arrayOfHexes[20, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 16)
		arrayOfHexes[20, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 17)
		arrayOfHexes[20, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 18)
		arrayOfHexes[20, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 19)
		arrayOfHexes[20, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 20)
		arrayOfHexes[20, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (20, 21)
		setHexOutOfMapBounds(20, 21);
		// (20, 22)
		setHexOutOfMapBounds(20, 22);

		// COL 21
		// (21, 0)
		setHexOutOfMapBounds(21, 0);
		// (21, 1)
		setHexOutOfMapBounds(21, 1);
		// (21, 2)
		setHexOutOfMapBounds(21, 2);
		// (21, 3)
		arrayOfHexes[21, 3] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 4)
		arrayOfHexes[21, 4] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 5)
		arrayOfHexes[21, 5] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 6)
		arrayOfHexes[21, 6] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 7)
		arrayOfHexes[21, 7] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 8)
		arrayOfHexes[21, 8] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 9)
		arrayOfHexes[21, 9] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 10)
		arrayOfHexes[21, 10] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 11)
		arrayOfHexes[21, 11] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 12)
		arrayOfHexes[21, 12] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 13)
		arrayOfHexes[21, 13] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 14)
		arrayOfHexes[21, 14] = new Dictionary<hexType, bool> () {
			{hexType.CITY, true}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, true}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 15)
		arrayOfHexes[21, 15] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 16)
		arrayOfHexes[21, 16] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 17)
		arrayOfHexes[21, 17] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 18)
		arrayOfHexes[21, 18] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, true}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, true}, {hexType.WATER, false}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 19)
		arrayOfHexes[21, 19] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 20)
		arrayOfHexes[21, 20] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};
		// (21, 21)
		setHexOutOfMapBounds(21, 21);
		// (21, 22)
		setHexOutOfMapBounds(21, 22);'

		//COL 22
		// (22, 0)
	}
















	private void setHexOutOfMapBounds(int x, int y)
	{
		arrayOfHexes[x, y] = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, false}, {hexType.RAND_LOC, false}, {hexType.RESOURCE, false}, {hexType.VALID, false}
		};
	}
}
