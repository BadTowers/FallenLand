using System.Collections;
using System.Collections.Generic;

public static class DefaultRandomNumberLocations {

	public static Dictionary<int, Coordinates> RAND_NUM_LOCATIONS = new Dictionary<int, Coordinates>()
	{
		{1, new Coordinates(2,20)},
		{2, new Coordinates(3,21)},
		{23, new Coordinates(1,18)},
		{24, new Coordinates(3,17)},
		{41, new Coordinates(1, 16)},
		{42, new Coordinates(2,15)},
		{58, new Coordinates(0,13)},
		{59, new Coordinates(2,12)},
		{60, new Coordinates(4, 12)},
		{73, new Coordinates(1, 10)},
		{74, new Coordinates(4,10)},
		{89, new Coordinates(2, 8)},
		{-1, new Coordinates(-1,-1)} //An invalid location
	};

}
