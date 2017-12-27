using System.Collections;
using System.Collections.Generic;

public static class DefaultFactionLocations {

	public static Dictionary<Factions.name, Coordinates> FACTION_LOCATIONS = new Dictionary<Factions.name, Coordinates>()
	{
		{Factions.name.COALITION, new Coordinates(14,18)},
		{Factions.name.ENCLAVE, new Coordinates(10,20)},
		{Factions.name.SYNDICATE, new Coordinates(4,15)},
		{Factions.name.SWAMP_RUNNERS, new Coordinates(20,4)},
		{Factions.name.NEW_FEDERALISTS, new Coordinates(25,7)},
		{Factions.name.REGULATORS, new Coordinates(14,8)},
		{Factions.name.HIGHWAYMEN, new Coordinates(16,16)},
		{Factions.name.BROTHERHOOD, new Coordinates(7,11)},
		{Factions.name.SONS_OF_NEPTUNE, new Coordinates(23,15)},
		{Factions.name.SIGMA, new Coordinates(28,14)},
		{Factions.name.NULL, new Coordinates(-1,-1)} //An invalid location
	};

}
