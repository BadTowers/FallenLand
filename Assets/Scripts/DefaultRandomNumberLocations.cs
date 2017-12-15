using System.Collections;
using System.Collections.Generic;

public static class DefaultRandomNumberLocations {

	public static Dictionary<int, Coordinates> RAND_NUM_LOCATIONS = new Dictionary<int, Coordinates>()
	{
		{1, new Coordinates(2,20)},
		{2, new Coordinates(3,21)},
		{23, new Coordinates(1,18)},
		{41, new Coordinates(1, 16)},
		{58, new Coordinates(0,13)},
		{73, new Coordinates(1, 10)},
		{89, new Coordinates(2, 8)},
		{-1, new Coordinates(-1,-1)} //An invalid location
	};

}
