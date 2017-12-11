
public class FactionsExtension {

	string getName(Factions faction)
	{
		switch (faction) {
		case Factions.COALITION:
			return "Coalition of the Black Angels";
		case Factions.ENCLAVE:
			return "Enclave of Terra";
		case Factions.SYNDICATE:
			return "Syndicate";
		case Factions.SWAMP_RUNNERS:
			return "Swamp Runners";
		case Factions.NEW_FEDERALISTS:
			return "New Federalists";
		case Factions.REGULATORS:
			return "Regulators";
		case Factions.HIGHWAYMEN:
			return "The Highwaymen";
		case Factions.BROTHERHOOD:
			return "The Brotherhood";
		case Factions.SONS_OF_NEPTUNE:
			return "Sons of Neptune";
		case Factions.SIGMA:
			return "Sigma Corporation";
		default:
			return "Error";
		}
	}
}
