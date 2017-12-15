using System.Collections;
using System.Collections.Generic;

public static class DefaultRandomNumberLocations {

	public static Dictionary<int, Coordinates> RAND_NUM_LOCATIONS = new Dictionary<int, Coordinates>()
	{
		{1, new Coordinates(2,20)},
		{2, new Coordinates(3,21)},
		{58, new Coordinates(0,13)},
		{73, new Coordinates(1, 10)},
		{-1, new Coordinates(-1,-1)} //An invalid location
	};

}
