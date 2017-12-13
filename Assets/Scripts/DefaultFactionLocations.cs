using System.Collections;
using System.Collections.Generic;

public static class DefaultFactionLocations {

	public static Dictionary<Factions.name, Coordinates> FACTION_LOCATIONS = new Dictionary<Factions.name, Coordinates>()
	{
		{Factions.name.COALITION, new Coordinates(0,0)},
		{Factions.name.ENCLAVE, new Coordinates(0,0)},
		{Factions.name.SYNDICATE, new Coordinates(0,0)},
		{Factions.name.SWAMP_RUNNERS, new Coordinates(0,0)},
		{Factions.name.NEW_FEDERALISTS, new Coordinates(0,0)},
		{Factions.name.REGULATORS, new Coordinates(0,0)},
		{Factions.name.HIGHWAYMEN, new Coordinates(0,0)},
		{Factions.name.BROTHERHOOD, new Coordinates(0,0)},
		{Factions.name.SONS_OF_NEPTUNE, new Coordinates(0,0)},
		{Factions.name.SIGMA, new Coordinates(0,0)}
	};

}
