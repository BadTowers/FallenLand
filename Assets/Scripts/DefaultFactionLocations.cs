using System.Collections;
using System.Collections.Generic;

public static class DefaultFactionLocations {

	public static Dictionary<Factions.name, Coordinates> FACTION_LOCATIONS = new Dictionary<Factions.name, Coordinates>()
	{
		{Factions.name.COALITION, new Coordinates(13,18)},
		{Factions.name.ENCLAVE, new Coordinates(20,9)},
		{Factions.name.SYNDICATE, new Coordinates(3,15)},
		{Factions.name.SWAMP_RUNNERS, new Coordinates(19,4)},
		{Factions.name.NEW_FEDERALISTS, new Coordinates(24,7)},
		{Factions.name.REGULATORS, new Coordinates(13,8)},
		{Factions.name.HIGHWAYMEN, new Coordinates(15,16)},
		{Factions.name.BROTHERHOOD, new Coordinates(6,11)},
		{Factions.name.SONS_OF_NEPTUNE, new Coordinates(22,15)},
		{Factions.name.SIGMA, new Coordinates(27,14)},
		{Factions.name.NULL, new Coordinates(-1,-1)} //An invalid location
	};

}
