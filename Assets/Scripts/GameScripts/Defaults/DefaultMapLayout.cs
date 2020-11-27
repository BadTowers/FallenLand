using System.Collections.Generic;

namespace FallenLand
{
	public class DefaultMapLayout : MapLayout
	{
		public DefaultMapLayout()
		{
			InitializeMapOfHexes();
		}

		public override void InitializeMapOfHexes()
		{
			int x = -1;

			/**************** COLUMN 0 ****************/
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
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
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
				};
			// (1, 10)
			setHexOutOfMapBounds(x, y++);
			// (1, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
				};
			// (1, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (1, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (1, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (1, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (1, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (1, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
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
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (2, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (2, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (2, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (2, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (2, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (2, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (2, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (2, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (2, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (2, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (2, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (2, 21)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (2, 22)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};

			/**************** COLUMN 3 ****************/
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (3, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (3, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (3, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (3, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (3, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (3, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (3, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (3, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (3, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (3, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (3, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (3, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (3, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (3, 21)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (3, 22)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};

			/**************** COLUMN 4 ****************/
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, true}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 21)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (4, 22)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};

			/**************** COLUMN 5 ****************/
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (5, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (5, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (5, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (5, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (5, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (5, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (5, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (5, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (5, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (5, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (5, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (5, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (5, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (5, 21)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (5, 22)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};

			/**************** COLUMN 6 ****************/
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 21)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (6, 22)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};

			/**************** COLUMN 7 ****************/
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, true}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 21)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (7, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 8 ****************/
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (8, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 21)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (8, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 9 ****************/
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 21)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (9, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 10 ****************/
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (10, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, true}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 21)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (10, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 11 ****************/
			x++;
			y = 0;
			// (11, 0)
			setHexOutOfMapBounds(x, y++);
			// (11, 1)
			setHexOutOfMapBounds(x, y++);
			// (11, 2)
			setHexOutOfMapBounds(x, y++);
			// (11, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 21)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (11, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 12 ****************/
			x++;
			y = 0;
			// (12, 0)
			setHexOutOfMapBounds(x, y++);
			// (12, 1)
			setHexOutOfMapBounds(x, y++);
			// (12, 2)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 21)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (12, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 13 ****************/
			x++;
			y = 0;
			// (13, 0)
			setHexOutOfMapBounds(x, y++);
			// (13, 1)
			setHexOutOfMapBounds(x, y++);
			// (13, 2)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (13, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (13, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (13, 21)
			setHexOutOfMapBounds(x, y++);
			// (13, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 14 ****************/
			x++;
			y = 0;
			// (14, 0)
			setHexOutOfMapBounds(x, y++);
			// (14, 1)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 2)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, true}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (14, 21)
			setHexOutOfMapBounds(x, y++);
			// (14, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 15 ****************/
			x++;
			y = 0;
			// (15, 0)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 1)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 2)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (15, 21)
			setHexOutOfMapBounds(x, y++);
			// (15, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 16 ****************/
			x++;
			y = 0;
			// (16, 0)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 1)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 2)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (16, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, true}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (16, 21)
			setHexOutOfMapBounds(x, y++);
			// (16, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 17 ****************/
			x++;
			y = 0;
			// (17, 0)
			setHexOutOfMapBounds(x, y++);
			// (17, 1)
			setHexOutOfMapBounds(x, y++);
			// (17, 2)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (17, 21)
			setHexOutOfMapBounds(x, y++);
			// (17, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 18 ****************/
			x++;
			y = 0;
			// (18, 0)
			setHexOutOfMapBounds(x, y++);
			// (18, 1)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 2)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (18, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (18, 21)
			setHexOutOfMapBounds(x, y++);
			// (18, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 19 ****************/
			x++;
			y = 0;
			// (19, 0)
			setHexOutOfMapBounds(x, y++);
			// (19, 1)
			setHexOutOfMapBounds(x, y++);
			// (19, 2)
			setHexOutOfMapBounds(x, y++);
			// (19, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, true}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (19, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (19, 21)
			setHexOutOfMapBounds(x, y++);
			// (19, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 20 ****************/
			x++;
			y = 0;
			// (20, 0)
			setHexOutOfMapBounds(x, y++);
			// (20, 1)
			setHexOutOfMapBounds(x, y++);
			// (20, 2)
			setHexOutOfMapBounds(x, y++);
			// (20, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, true}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (20, 21)
			setHexOutOfMapBounds(x, y++);
			// (20, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 21 ****************/
			x++;
			y = 0;
			// (21, 0)
			setHexOutOfMapBounds(x, y++);
			// (21, 1)
			setHexOutOfMapBounds(x, y++);
			// (21, 2)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (21, 21)
			setHexOutOfMapBounds(x, y++);
			// (21, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 22 ****************/
			x++;
			y = 0;
			// (22, 0)
			setHexOutOfMapBounds(x, y++);
			// (22, 1)
			setHexOutOfMapBounds(x, y++);
			// (22, 2)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (22, 21)
			setHexOutOfMapBounds(x, y++);
			// (22, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 23 ****************/
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (23, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (23, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, true}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (23, 21)
			setHexOutOfMapBounds(x, y++);
			// (23, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 24 ****************/
			x++;
			y = 0;
			// (24, 0)
			setHexOutOfMapBounds(x, y++);
			// (24, 1)
			setHexOutOfMapBounds(x, y++);
			// (24, 2)
			setHexOutOfMapBounds(x, y++);
			// (24, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (24, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (24, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (24, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (24, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (24, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (24, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (24, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (24, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (24, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (24, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (24, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (24, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (24, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (24, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (24, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
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
			x++;
			y = 0;
			// (25, 0)
			setHexOutOfMapBounds(x, y++);
			// (25, 1)
			setHexOutOfMapBounds(x, y++);
			// (25, 2)
			setHexOutOfMapBounds(x, y++);
			// (25, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, true}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (25, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
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
			x++;
			y = 0;
			// (26, 0)
			setHexOutOfMapBounds(x, y++);
			// (26, 1)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 2)
			setHexOutOfMapBounds(x, y++);
			// (26, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 16)
			setHexOutOfMapBounds(x, y++);
			// (26, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (26, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
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
			x++;
			y = 0;
			// (27, 0)
			setHexOutOfMapBounds(x, y++);
			// (27, 1)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 2)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 3)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 4)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 5)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (27, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
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
			x++;
			y = 0;
			// (28, 0)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (28, 1)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (28, 2)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (28, 3)
			setHexOutOfMapBounds(x, y++);
			// (28, 4)
			setHexOutOfMapBounds(x, y++);
			// (28, 5)
			setHexOutOfMapBounds(x, y++);
			// (28, 6)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (28, 7)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (28, 8)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (28, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (28, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (28, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (28, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (28, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (28, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, true}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (28, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (28, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (28, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
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
			x++;
			y = 0;
			// (29, 0)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (29, 1)
			setHexOutOfMapBounds(x, y++);
			// (29, 2)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (29, 9)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (29, 10)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (29, 11)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (29, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (29, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (29, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (29, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (29, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (29, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (29, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
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
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (30, 11)
			setHexOutOfMapBounds(x, y++);
			// (30, 12)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (30, 13)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (30, 14)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, true}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (30, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (30, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (30, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (30, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
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
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (31, 15)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (31, 16)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (31, 17)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (31, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (31, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (31, 20)
			setHexOutOfMapBounds(x, y++);
			// (31, 21)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (31, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 32 ****************/
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, true}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (32, 17)
			setHexOutOfMapBounds(x, y++);
			// (32, 18)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (32, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, true}, {HexType.VALID, true}
			};
			// (32, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, true}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (32, 21)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (32, 22)
			setHexOutOfMapBounds(x, y++);

			/**************** COLUMN 33 ****************/
			x++;
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
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (33, 17)
			setHexOutOfMapBounds(x, y++);
			// (33, 18)
			setHexOutOfMapBounds(x, y++);
			// (33, 19)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (33, 20)
			ArrayOfHexes[x, y++] = new Dictionary<HexType, bool>() {
			{HexType.CITY, true}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, true}, {HexType.WATER, false},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, true}
			};
			// (33, 21)
			setHexOutOfMapBounds(x, y++);
			// (33, 22)
			setHexOutOfMapBounds(x, y++);
		}


		private void setHexOutOfMapBounds(int x, int y)
		{
			ArrayOfHexes[x, y] = new Dictionary<HexType, bool>() {
			{HexType.CITY, false}, {HexType.RAD, false}, {HexType.MOUNTAIN, false}, {HexType.PLAINS, false}, {HexType.WATER, true},
			{HexType.BASE, false}, {HexType.RAND_LOC, false}, {HexType.RESOURCE, false}, {HexType.VALID, false}
			};
		}
	}
}
