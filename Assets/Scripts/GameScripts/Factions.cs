
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

	public static string getName(Factions.name faction)
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

	public static Factions.name getFaction(int num){
		switch (num) {
		case 1:
			return name.COALITION;
		case 2:
			return name.ENCLAVE;
		case 3:
			return name.SYNDICATE;
		case 4:
			return name.SWAMP_RUNNERS;
		case 5:
			return name.NEW_FEDERALISTS;
		case 6:
			return name.REGULATORS;
		case 7:
			return name.HIGHWAYMEN;
		case 8:
			return name.BROTHERHOOD;
		case 9:
			return name.SONS_OF_NEPTUNE;
		case 10:
			return name.SIGMA;
		default:
			return name.NULL;
		}
	}

	public static string getPerk1Title(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return "Combat Medic";
		case name.ENCLAVE:
			return "Hunter's Instincts";
		case name.SYNDICATE:
			return "Natural Defenses";
		case name.SWAMP_RUNNERS:
			return "Connected";
		case name.NEW_FEDERALISTS:
			return "Armory Cache";
		case name.REGULATORS:
			return "The Cowboy Way";
		case name.HIGHWAYMEN:
			return "Motorcycle Culture";
		case name.BROTHERHOOD:
			return "Blade Cult";
		case name.SONS_OF_NEPTUNE:
			return "Hidden Agenda";
		case name.SIGMA:
			return "The Long Walk";
		case name.NULL:
			return "NULL";
		default:
			return "Error";
		}
	}

	public static string getPerk1Text(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return "Begin the game with the PARAMEDIC MED KIT spoils card";
		case name.ENCLAVE:
			return "Begin the game with the COMPOUND HUNTING BOW spoils card";
		case name.SYNDICATE:
			return "Begin the game with 1 TOWN DEFENSE CHIP";
		case name.SWAMP_RUNNERS:
			return "Begin the game with a RESOURCE LOCATION of your choosing. Place your faction chip there to claim it";
		case name.NEW_FEDERALISTS:
			return "Begin the game with the MILITIA RIFLE spoils card";
		case name.REGULATORS:
			return "Being the game with the SIX FAST HORSES spoils card";
		case name.HIGHWAYMEN:
			return "Begin the game with the AMERICAN IRON CUSTOM CHOPPERS spoils card. Can never be sold or traded";
		case name.BROTHERHOOD:
			return "Begin the game with the VENDETTA DAGGERS spoils card";
		case name.SONS_OF_NEPTUNE:
			return "Begin the game with 2 additional ACTION CARDS";
		case name.SIGMA:
			return "Begin the game with the 6.8MM ADVANCED RIFLE spoils card";
		case name.NULL:
			return "NULL";
		default:
			return "Error";
		}
	}

	public static string getPerk2Title(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return "Information Crossroads";
		case name.ENCLAVE:
			return "Diplomatic Connections";
		case name.SYNDICATE:
			return "High Rollers";
		case name.SWAMP_RUNNERS:
			return "Southern Ingenuity";
		case name.NEW_FEDERALISTS:
			return "Weapons Bazaar";
		case name.REGULATORS:
			return "Cattle Drivers";
		case name.HIGHWAYMEN:
			return "Caravan Escort";
		case name.BROTHERHOOD:
			return "Wasteland Scavengers";
		case name.SONS_OF_NEPTUNE:
			return "River Traders";
		case name.SIGMA:
			return "Veritable Fortress";
		case name.NULL:
			return "NULL";
		default:
			return "Error";
		}
	}

	public static string getPerk2Text(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return "Once per turn, during the TOWN BUSINESS PHASE, you may pay 5 salvage coins to draw one action card";
		case name.ENCLAVE:
			return "Each time you are the first player, subtract 2 from your TOWN EVENTS roll";
		case name.SYNDICATE:
			return "During the TOWN EVENTS PHASE, you must roll 1d6. 1-3: receive 5 salvage coins from the bank. 6: you must disvard 7 salvage coins or its equivilent value in spoils cards";
		case name.SWAMP_RUNNERS:
			return "Once per turn, during the EFFECTS PHASE, you may discard an action card to draw a spoils card for your auction house";
		case name.NEW_FEDERALISTS:
			return "During the TOWN BUSINESS PHASE, roll 1d6. 1-2: remove the first WEAPON spoils card from the discard pile into your auction house";
		case name.REGULATORS:
			return "Each TOWN BUSINESS PHASE, choose another faction. You each receive 3 SALVAGE COINS";
		case name.HIGHWAYMEN:
			return "Each TOWN BUSINESS PHASE< you receive 4 salvage coins. You must give 2 of them to another player";
		case name.BROTHERHOOD:
			return "Each TOWN BUSINESS PHASE roll 1d6 and receive that many salvage coins";
		case name.SONS_OF_NEPTUNE:
			return "Each EFFECTS PHASE, you may draw a spoils card. Pay a random player 1/2 its value (round up) in salvage coins";
		case name.SIGMA:
			return "Begin the game with 2 TOWN DEFENSE CHIPS. All other TD chips purchased cost 4 extra salvage coins";
		case name.NULL:
			return "NULL";
		default:
			return "Error";
		}
	}

	public static string getPerk3Title(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return "Fight Club";
		case name.ENCLAVE:
			return "Wiley";
		case name.SYNDICATE:
			return "Mountaineering";
		case name.SWAMP_RUNNERS:
			return "Smugglers Network";
		case name.NEW_FEDERALISTS:
			return "Navigators";
		case name.REGULATORS:
			return "Into the Wild";
		case name.HIGHWAYMEN:
			return "The Riddle of Steel";
		case name.BROTHERHOOD:
			return "Down with The Sickness";
		case name.SONS_OF_NEPTUNE:
			return "Anchors Aweigh";
		case name.SIGMA:
			return "Excavation";
		case name.NULL:
			return "NULL";
		default:
			return "Error";
		}
	}

	public static string getPerk3Text(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return "During party MELEE WEAPONS ONLY encounter cards, you receive 1 additional combat success";
		case name.ENCLAVE:
			return "Your party gains +1 during FLIGHT ROLLS";
		case name.SYNDICATE:
			return "Each MOVEMENT DEED, the 1st mountain hex your party passes through costs 1 movement instead of 2";
		case name.SWAMP_RUNNERS:
			return "Each time you SELL A SPOILS CARD from your auction house to another player, receive 3 salvage coins from the bank";
		case name.NEW_FEDERALISTS:
			return "City and radiation hexes COST 2 MOVEMENT instead of 3";
		case name.REGULATORS:
			return "During the END TURN PHASE, your can move your STARTING TOWN LOCATION up to 2 hexes by paying 3 salvage coins. Can't occupy other cities, resources, radiation, or water. Reroll mission locations";
		case name.HIGHWAYMEN:
			return "If your party returns to town without a vehicle, immediately retrieve the AMERICAN IRON CUSTOM CHOPPERS spoils card";
		case name.BROTHERHOOD:
			return "When an opponent lays a negative action card on you, roll 1d6. 1: each of their characters sustain 1 radiation damage";
		case name.SONS_OF_NEPTUNE:
			return "When your town is the target of an action card or world card effect, you may roll 1d6. 1: ignore its effects";
		case name.SIGMA:
			return "If any players draws a mission card with the word \"Sigma\" in its title, you gain 3 town health";
		case name.NULL:
			return "NULL";
		default:
			return "Error";
		}
	}

	public static string getPerk4Title(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return "Midwestern Charm";
		case name.ENCLAVE:
			return "Kismet";
		case name.SYNDICATE:
			return "The Mineshaft Gap";
		case name.SWAMP_RUNNERS:
			return "Born on the Bayou";
		case name.NEW_FEDERALISTS:
			return "Mercenary Haven";
		case name.REGULATORS:
			return "Rangers";
		case name.HIGHWAYMEN:
			return "Road Warriors";
		case name.BROTHERHOOD:
			return "Survival Instincts";
		case name.SONS_OF_NEPTUNE:
			return "Amphibious";
		case name.SIGMA:
			return "Black Ops";
		case name.NULL:
			return "NULL";
		default:
			return "Error";
		}
	}

	public static string getPerk4Text(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return "Perform the HEALING DEED in any neutral starting town without having to pay the bank";
		case name.ENCLAVE:
			return "Once per turn, during a SOLO ENCOUNTER CARD, re-roll a failed skill check";
		case name.SYNDICATE:
			return "Once per turn, if your TOWN ROSTER IS EMPTY, you may draw a character card and place it there";
		case name.SWAMP_RUNNERS:
			return "Your party gains +2 FLIGHT during PVP";
		case name.NEW_FEDERALISTS:
			return "PAY 2 SALVAGE COINS LESS to hire an NPCM action card or ally spoils card";
		case name.REGULATORS:
			return "You may purchase the tier 1 LAW AND ORDER town technology for 30 salvage coins";
		case name.HIGHWAYMEN:
			return "Each time a VEHICLE COMBAT or BIKER GANG encounters card is drawn by any player, you gain 1 prestige";
		case name.BROTHERHOOD:
			return "Your party ignores all negative effects from ENVIRONMENTAL HAZARD encounter cards";
		case name.SONS_OF_NEPTUNE:
			return "Your party may move through the Great Lakes. Each lake costs 1 salvage and 1 movement. Cannot end movement in an all water hex";
		case name.SIGMA:
			return "Once per game, during your PARTY EXPLOITS PHASE, move your party to any mission location chip on the map";
		case name.NULL:
			return "NULL";
		default:
			return "Error";
		}
	}

	public static string getStartingLocation(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return "Iowa City, Iowa";
		case name.ENCLAVE:
			return "Great Falls, Montana";
		case name.SYNDICATE:
			return "Battle Mountain, Nevada";
		case name.SWAMP_RUNNERS:
			return "Shreveport, Louisiana";
		case name.NEW_FEDERALISTS:
			return "Albany, Georgia";
		case name.REGULATORS:
			return "Amarillo, Texas";
		case name.HIGHWAYMEN:
			return "Sturgis, South Dakota";
		case name.BROTHERHOOD:
			return "Saint George, Utah";
		case name.SONS_OF_NEPTUNE:
			return "Grand Haven, Michigan";
		case name.SIGMA:
			return "Emporium, Pennsylvania";
		case name.NULL:
			return "NULL";
		default:
			return "Error";
		}
	}

	//TODO
	public static string getLore(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return "The residents of Iowa City panicked with the onset of the Great War, as many feared they would be targeted in the nuclear exchanged, because of defense contractors, hospitals, and colleges. However, the anticipated hammer stroke never fell. Even when Des Moines was dusted and the ashen fallout drift down like snow, Iowa City was again spared. But their luck eventually ran out.\n\n" +
					"As a crossroads in the Midwest, the city was quickly inundated with fleeing refugees during the Maddening. Iowa City residents were thoroughly unprepared for the many horrors the outsiders brought with them, especially those afflicted by the biological weapons used during the war. Disease and starvation also struck hard, followed by rioting that destroyed the city east of the river. As chaos and desperation increased, so did the interest from robing bands of armed marauders, who staged a series of devastating raids. Out of options, a large group of survivors retreated into the ruinous hospital sprawl near the stadium. Working together, they fortified the buildings and created a new town--one they could defend. Once the area was secure, the survivors formed Coalition of the Black Angel. Throughout the Emergence, the town has continued to prosper. It now features both learning and medical centers and an intricate array of rooftop conservatories. It is also considered one of the last remaining intellectual bastions in the Fallen Lands.\n\n" +
					"Led by the Grand Mayor, who is elected from a council of elites, Coalition of the Black Angel has made the preservation of pre-war knowledge a priority as they continue to expand and reclaim buildings. Priding themselves in maintaining strong diplomatic ties with the other factions, Coalition of the Black Angel is often at the foregront of the devision making within the Council of the Ten Towns. Frequently playing the role of peackeeper and brokering deals among the other Factions; they prefer to assert themselves through the use of soft power. While they are considered less militant than the other factions, as they have proven many times, their militia is efficient and well-trained.";
		case name.ENCLAVE:
			return "LORE\n\nLORE";
		case name.SYNDICATE:
			return "LORE\n\nLORE";
		case name.SWAMP_RUNNERS:
			return "LORE\n\nLORE";
		case name.NEW_FEDERALISTS:
			return "LORE\n\nLORE";
		case name.REGULATORS:
			return "LORE\n\nLORE";
		case name.HIGHWAYMEN:
			return "LORE\n\nLORE";
		case name.BROTHERHOOD:
			return "LORE\n\nLORE";
		case name.SONS_OF_NEPTUNE:
			return "LORE\n\nLORE";
		case name.SIGMA:
			return "LORE\n\nLORE";
		case name.NULL:
			return "NULL";
		default:
			return "Error";
		}
	}

	//TODO
	public static string getTownTech1(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return "";
		case name.ENCLAVE:
			return "";
		case name.SYNDICATE:
			return "";
		case name.SWAMP_RUNNERS:
			return "";
		case name.NEW_FEDERALISTS:
			return "";
		case name.REGULATORS:
			return "";
		case name.HIGHWAYMEN:
			return " ";
		case name.BROTHERHOOD:
			return " ";
		case name.SONS_OF_NEPTUNE:
			return "";
		case name.SIGMA:
			return "";
		case name.NULL:
			return "NULL";
		default:
			return "Error";
		}
	}

	//TODO
	public static string getTownTech2(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return "";
		case name.ENCLAVE:
			return "";
		case name.SYNDICATE:
			return "";
		case name.SWAMP_RUNNERS:
			return "";
		case name.NEW_FEDERALISTS:
			return "";
		case name.REGULATORS:
			return "";
		case name.HIGHWAYMEN:
			return " ";
		case name.BROTHERHOOD:
			return " ";
		case name.SONS_OF_NEPTUNE:
			return "";
		case name.SIGMA:
			return "";
		case name.NULL:
			return "NULL";
		default:
			return "Error";
		}
	}
}
