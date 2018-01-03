
public class Factions {

	public enum name{
		COALITION,
		ENCLAVE,
		SYNDICATE,
		SWAMP_RUNNERS,
		NEW_FEDERALISTS,
		REGULATORS,
		HIGHWAYMEN,
		BROTHERHOOD,
		SONS_OF_NEPTUNE,
		SIGMA,
		NULL
	}

	string getName(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return "Coalition of the Black Angels";
		case name.ENCLAVE:
			return "Enclave of Terra";
		case name.SYNDICATE:
			return "Syndicate";
		case name.SWAMP_RUNNERS:
			return "Swamp Runners";
		case name.NEW_FEDERALISTS:
			return "New Federalists";
		case name.REGULATORS:
			return "Regulators";
		case name.HIGHWAYMEN:
			return "The Highwaymen";
		case name.BROTHERHOOD:
			return "The Brotherhood";
		case name.SONS_OF_NEPTUNE:
			return "Sons of Neptune";
		case name.SIGMA:
			return "Sigma Corporation";
		case name.NULL:
			return "NULL";
		default:
			return "Error";
		}
	}
}
