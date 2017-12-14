using System.Collections.Generic;

public class DefaultMapLayout : MapLayout {

	//Default constructor
	public DefaultMapLayout()
	{
		InitializeMapOfHexes();
	}
		
	public override void InitializeMapOfHexes()
	{
		Dictionary<hexType, bool> tempDict;

		tempDict = new Dictionary<hexType, bool> () {
			{hexType.CITY, false}, {hexType.RAD, false}, {hexType.MOUNTAIN, false}, {hexType.PLAINS, false}, {hexType.WATER, true}, 
			{hexType.BASE, true}, {hexType.RAND_NUM, false}, {hexType.RESOURCE, false}, {hexType.VALID, true}
		};

		for (int x = 0; x < MapCreation.width; x++) {
			for (int y = 0; y < MapCreation.height; y++) {
				arrayOfHexes [x, y] = tempDict;
			}
		}
	}
}
