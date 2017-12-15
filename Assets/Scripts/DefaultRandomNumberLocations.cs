using System.Collections;
using System.Collections.Generic;

public static class DefaultRandomNumberLocations {

	public static Dictionary<int, Coordinates> RAND_NUM_LOCATIONS = new Dictionary<int, Coordinates>()
	{
		{1, new Coordinates(2,20)},
		{2, new Coordinates(3,21)},
		{3, new Coordinates(5,20)},
		{4, new Coordinates(6,19)},
		{5, new Coordinates(8,20)},
		{23, new Coordinates(1,18)},
		{24, new Coordinates(3,17)},
		{25, new Coordinates(5,17)},
		{26, new Coordinates(8,16)},
		{27, new Coordinates(9,15)},
		{41, new Coordinates(1,16)},
		{42, new Coordinates(2,15)},
		{43, new Coordinates(5,15)},
		{44, new Coordinates(6,13)},
		{45, new Coordinates(9,13)},
		{58, new Coordinates(0,13)},
		{59, new Coordinates(2,12)},
		{60, new Coordinates(4,12)},
		{61, new Coordinates(5,11)},
		{62, new Coordinates(8,12)},
		{63, new Coordinates(9, 10)},
		{64, new Coordinates(10,11)},
		{73, new Coordinates(1,10)},
		{74, new Coordinates(4,10)},
		{75, new Coordinates(6,9)},
		{76, new Coordinates(8,8)},
		{77, new Coordinates(9,7)},
		{89, new Coordinates(2,8)},
		{90, new Coordinates(6,6)},
		{91, new Coordinates(10,5)},
		{-1, new Coordinates(-1,-1)} //An invalid location
	};

}
