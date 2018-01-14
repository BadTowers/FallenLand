
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

	public static Factions.name getFactionName(int num){
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

	public static int getFactionNumber(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return 1;
		case name.ENCLAVE:
			return 2;
		case name.SYNDICATE:
			return 3;
		case name.SWAMP_RUNNERS:
			return 4;
		case name.NEW_FEDERALISTS:
			return 5;
		case name.REGULATORS:
			return 6;
		case name.HIGHWAYMEN:
			return 7;
		case name.BROTHERHOOD:
			return 8;
		case name.SONS_OF_NEPTUNE:
			return 9;
		case name.SIGMA:
			return 10;
		case name.NULL:
			return -1;
		default:
			return -1;
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
			return "The residents of Iowa City panicked with the onset of the Great War, as many feared they would be targeted in the nuclear exchanged because of defense contractors, hospitals, " +
				"and colleges. However, the anticipated hammer stroke never fell. Even when Des Moines was dusted and the ashen fallout drifted down like snow, Iowa City was again spared. " +
				"But their luck eventually ran out.\n\nAs a crossroads in the Midwest, the city was quickly inundated with fleeing refugees during the Maddening. Iowa City residents were thoroughly " +
				"unprepared for the many horrors the outsiders brought with them, especially those afflicted by the biological weapons used during the war. Disease and starvation also struck hard, " +
				"followed by rioting that destroyed the city east of the river. As chaos and desperation increased, so did the interest from roving bands of armed marauders, who staged a series of " +
				"devastating raids. Out of options, a large group of survivors retreated into the ruinous hospital sprawl near the stadium. Working together, they fortified the buildings and created a " +
				"new town--one they could defend. Once the area was secure, the survivors formed Coalition of the Black Angel. Throughout the Emergence, the town has continued to prosper. It now features " +
				"both learning and medical centers and an intricate array of rooftop conservatories. It is also considered one of the last remaining intellectual bastions in the Fallen Lands.\n\nLed by " +
				"the Grand Mayor, who is elected from a council of elites, Coalition of the Black Angel has made the preservation of pre-war knowledge a priority as they continue to expand and reclaim " +
				"buildings. Priding themselves in maintaining strong diplomatic ties with the other factions, Coalition of the Black Angel is often at the forefront of the decision making within the Council " +
				"of the Ten Towns. Frequently playing the role of peacekeeper and brokering deals among the other Factions, they prefer to assert themselves through the use of soft power. While they " +
				"are considered less militant than the other factions, as they have proven many times, their militia is efficient and well-trained.\n";
		case name.ENCLAVE:
			return "The remote location of Great Falls spared it from the nuclear exchange that destroyed civilization. However, as supplies became scarce during the dark years of the Maddening, many " +
				"militia groups in the region turned to raiding settlements. The raider’s swift attacks devastated and outgunned the small communities. To bring the fight to the raiders, the Blackfoot " +
				"and Sioux Nations rallied the small settlements to them. Utilizing guerrilla tactics to harass and punish the raiders for years, their decisive victory was finally achieved at Battle " +
				"Gorge. Most of the raiders were killed, but those that survived were scattered to the four winds. Talks soon turned to establishing a sage community where all participants could rebuild " +
				"and prosper. Being at one with the land and returning to the customs of their forefathers also resonated with the newly unified group.\n\nSurrounded by a sea of tall blue prairie grass, " +
				"the leaders of the two Indian Nations and the survivor groups met on a bluff overlooking the Great Falls Dam. It was there they vowed to work together and formed the Enclave of Terra. The " +
				"dam became the faction’s stronghold and provides them with electricity. Over the years, a massive frontier-style palisade has been built to protect the town, lending to the rustic old-world " +
				"atmosphere. Highlighted by the breathtaking backdrop of the giant dam, many visitors agree it is the most visually stunning view within the Ten Towns.\n\nThe enclave of Terra is led by the " +
				"High Elder, who is supported by a small council. With the best energy and water purification capabilities within the Ten Towns, their alliances and trade partners have continued to grow. As " +
				"strong proponents of expanding the power of the Council of the Ten Towns, they hope to create equality for all factions and broaden representation to include smaller settlements. For this to " +
				"happen, they will have to take a leadership role and share their wisdom with the other factions.\n";
		case name.SYNDICATE:
			return "The local warning sirens wailed across the mining community as death rained from the skies. Only the residents that fled to the mines survived. Within its depths, the survivors found " +
				"shelter and safety from the fallout. During the long, dark years of the Maddening, as chaos reigned in the wastes, the survivors that chose to reside in the mine continued to prosper. " +
				"However, the situation took a turn for the worse when a well-armed group calling themselves Syndicate arrived and demanded entry.\n\nA long and bloody battle for the mine ensued. When " +
				"the outsiders finally gained control, they rounded up the residents and publicly executed their leaders. After that, no one questioned their authority and the remaining survivors were " +
				"indoctrinated. Beginning salvage operations in Sacramento and Reno, they returned with truckload and truckload of gaming machines, artwork, and other pre-war treasures. As Syndicate grew, " +
				"so did their territory and reach. Still located in the deep underground labyrinth of the pre-war gold mine, the town has continued to grow, and work is always underway to expand its maze " +
				"of corridors and rooms. The town is unsurpassed in its exciting nightlife and entertainment within the Ten Towns. Unfortunately, it has become a haven for criminals and a den of vices. It " +
				"is often referred to by its nickname, Little Vegas. Nowhere in the Fallen Lands is gambling, alcohol, drugs, and prostitution more prevalent. Darker still are the rumors of people " +
				"disappearing and being sold to slavers…\n\nProne to violence, the descendants from the Mafia, Cartels, Yakuza, and Vory v Zakone familis that united during the Maddening to form Syndicate " +
				"remain volatile, clannish, and esoteric. Only allying out of desperation to survive the Maddening, each family now has a seat at the table and oversees a guild within the Faction: gaming, " +
				"drugs, security, or commerce. They also vote to elect the Commissioner, who they believe will best represent their financial and business interests. Although the Commissioner has the final " +
				"say in all matters, the families often jockey to consolidate their own power and influence. However, since the Emergence, Syndicate has been more united than ever and focused on the future. " +
				"Covertly purchasing businesses within the other nine Factions, they plot to overthrow the leadership of the other nine Factions from within and, by doing so, establish an overarching feudal " +
				"system.\n";
		case name.SWAMP_RUNNERS:
			return "Shreveport sustained mass casualties from the biological weapons used in the Great War. Many residents suffered horrible deaths, while others looted and pillaged the city gripped by " +
				"madness and set it ablaze. Other horrors followed, like radiation sickness and cannibalism. When several damns upriver failed, they unleased the power of the mighty Mississippi. Mother " +
				"Nature almost seemed to rejoice at the prospect of washing away the blight and pestilence, as countless river towns were smashed and washed downstream. When the unstoppable river torrent " +
				"finally crashed into Shreveport, much of the habitable area around the river basin was turned into a massive delta of swamp lands.\n\nDespite these challenges, many of the survivors in " +
				"Southern Louisiana made the grim pilgrimage north, settling in the abandoned husk of Shreveport. Forming clans of scavengers, they began to slowly rebuild. Over the years, these clans " +
				"merged until they united under the banner of the Swamp Runners. With their combined ingenuity and resourcefulness, they sank hundreds of wooden posts into the muck and constructed a town " +
				"on top of the water. Accessible only by fan boat, it features an impressive array of docks, fortified warehouses and buildings constructed out of metal cargo containers. The infrastructure " +
				"is connected by an intricate network of boardwalks, bridges, and ziplines.\n\nSurprisingly, the Swamp Runners control the largest territory of the Ten Towns, despite having the fewest " +
				"citizens. Notorious for their smuggling and spy networks, they specialize in acquisition and purvey hard to find items to the highest bidder. Commodities like fuel, medical supplies, " +
				"and drugs often top their list and it is whispered they even delve in human trafficking. The leader of the Swamp Runners has traditionally ben the Baroness. Favoring thugs and hired " +
				"guns over a large militia, she uses them to strike at her enemies, often in unique ways. Although many regard the Swamp Runners as unmanageable rogues, their services are utilized by " +
				"all. Their strategy is to continue to play the other Factions off of one another and establish dominance over the Ten Towns.\n";
		case name.NEW_FEDERALISTS:
			return "In the early hours of the Great War, Albany braced for attack. Washington D.C. was already gone, and the long list of dusted cities just kept growing. The first missiles targeting " +
				"Albany were destroyed by THAAD missile defense batteries. The next round was detonated in the atmosphere and caused a series of electromagnetic pulses that knocked out power and " +
				"electronics all across the Eastern seaboard. With the chain of command broken, the base commander panicked. Recalling troops and their families, the base was ordered on lockdown " +
				"and its defenses were reinforced. It remained closed to the outside during the Maddening, and when refugees arrived at the gates begging for assistance, they were turned away empty " +
				"handed. The situation often turned violent and the angry refugees eventually grew to outnumber the defenders. Forming a gang, these refugees eventually lay siege to the base. The " +
				"trapped defenders were forced to strike a deal with the consortium of Bounty Hunters called The Death’s Head Mercs. Their devastating counter-attack eliminated the threat and broke " +
				"the siege.\n\nOver the years, the defenders came to call themselves the New Federalists and a prosperous town grew inside their crumbling base. Protected by rusty chain link fences " +
				"and razor wire, the lichen-choked concrete is littered with jagged patina-covered buildings, fortified bunkers, and watchtowers. The New Federalists are considered the premier weapon " +
				"outfitters in the Fallen Land, and as a result, the town has become a haven for mercenaries and marauders. A hefty tax is collected from each of these visiting groups, which is paid " +
				"in pillaged supplies and scavenged tech. In return, they are granted access for R&R, trade, and to negotiate their mercenary contracts. Many powerful organizations come here to hire " +
				"them. Because these mercenaries are a rowdy and dangerous bunch, they must be kept in check by a large heavily-armed militia. However, despite these safeguards, the town has a " +
				"distinct Wild West feel to it, with nightly gunfights in the streets between rival mercenary outfits.\n\nUnlike many Factions, the New Federalists are not what they seem. Although " +
				"their banner resembles Old Glory and implies ties to the former United States, their leader The Colonel, is more of a ruthless warlord and autocrat than a force for order. Hoping to " +
				"unite the Ten Towns under an iron dictatorship, the New Federalists forces are always bolstering their militia through forced conscription from the outlying farmsteads. The New " +
				"Federalists are tolerated by the other Factions because they supply them with weapons—and for the right price, muscle. Often overshadowed by the pre-war military culture, a group " +
				"of citizens here hopes to promote change by rewriting old history books and reeducating the population of the Ten Towns with their hubris and propaganda.\n";
		case name.REGULATORS:
			return "By the time the radioactive fallout drifted across the plains, the US government was already gone and the country’s infrastructure had collapsed. No help was coming. The " +
				"nuclear and biological warheads used in The Great War had darkened the skies, and this lack of sunshine combined with unprecedented chaos and violence became known as The " +
				"Maddening. Most of the ranchers in the Texas Panhandle attempted to find safety by moving their cattle operations closer to Amarillo. The arduous journey claimed many lives, " +
				"but those that survived were bound together by hardship. Establishing Tent City near the ruins of Amarillo, the ranchers eked out a harsh existence. However, when a mass exodus " +
				"of survivors fleeing the nuked-out coastal cities arrived, life took a turn for the worse. The outsiders rioted over food shortages and Tent City was burned to the ground. The " +
				"tragic bloodshed that followed was dubbed the Canvas Massacre and had a profound impact on their future.\n\nHoping to reestablish security and order, the Regulators were formed. " +
				"Despite the many challenges, they had learned their hard lessons and strived to maintain their democratic roots. In the future, they knew they would have to work harder to integrate " +
				"newcomers into their rancher lifestyle. They also decided mobility was paramount to their safety and security. Scavenging campers and trucks from nearby factories, they repaired " +
				"and retrofitted their fleet with armor and supplies before hitting the road. Their mobile town is assembled by circling the RVs and other vehicles, which provides an outer wall of " +
				"defenses. The new Tent City is erected inside, with the most vital assets at its center. Their quick assemble tents, portable generators, and customized amenities allow them to " +
				"disassemble the town and relocate it within a few hours. However, despite their clever gadgets, The Regulators are renowned for their horsemanship and sharpshooter skills. Being a " +
				"culture of nomads, they have perfected the art of maintaining their herd of cattle on the go, which many Factions have come to rely on.\n\nThe Regulators’ core values are freedom, " +
				"self-sufficiency, integrity, and fair trade. Theft is the most egregious crime in their eyes and is punishable by death. The Regulators are led by The First Marshal, a spokesman for " +
				"the council of oligarchs—the heads of the Faction’s most prominent cattle families. Their vision of the future is to convert the other Factions to a more nomadic frontier lifestyle.\n";
		case name.HIGHWAYMEN:
			return "After the bombs fells, the motorcycle clubs that survived were forced to rely on mobility and safety in numbers. Those that escaped the gridlock and chaos made the pilgrimage to " +
				"the mecca of motorcycle culture, Sturgis, South Dakota. Many motorcycle clubs (MCs) were represented there and most put aside their long-standing rivalries. A vision emerged to unite " +
				"themselves into a single MC, the Highwaymen. Those that refused to join were cast out and formed the Outlaws. Comprised mostly of the criminal element, bounties were placed on their " +
				"heads. During the long, dark years of the Maddening, several bloody road wars were waged against the renegade Outlaw charters. Although the Highwaymen often prevailed, their victories " +
				"came at a steep cost. The Outlaws that escaped became even more cunning, and continue to wreak havoc on the roads, remaining a thorn in the side of the Council of the Ten Towns.\n\n" +
				"Historians agree that the Highwaymen were the first Faction to come into power as they already had the numbers, firepower, and MCs before the war. As their sphere of influence increased, " +
				"so did their power. As the most travelled of all the Factions, the Highwaymen are frequently consulted to plan caravan routes and, for the right price, will even provide an armed escort. " +
				"Although sheet metal fortifications have been constructed around the town for protection, much of Sturgis remains as it did before the war. The highwaymen often brag of their factory, " +
				"scavenged from the ruins of Milwaukee and meticulously reassembled in Sturgis. Although they specialize in the production and restoration of motorcycles, those with enough credits can " +
				"also order their custom road war vehicles. With travel being so dangerous, these tricked-out rides are in high demand, especially for merchant outfits like the famous I-80 Caravanners. " +
				"Featuring high-performance engines, armor, and a vast array of weaponry, this endeavor has proved incredibly lucrative. Their only real competition is Jackie’s Topless Garage, which " +
				"surpasses their ingenuity, but cannot match their production capabilities.\n\nThe Highwaymen are led by their President, a charismatic demagogue whose priorities are loyalty, profits, " +
				"and motorcycle culture. The President’s strategy when dealing with the other Factions has been to become indispensable. They are always gathering intelligence on their enemies and analyzing " +
				"their weaknesses. Unfortunately, many members of the Highwaymen believe “might makes right” and that they should meet violence with violence, which often stands in the way of progress.\n";
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
		
	public static TownTechs.name getTownTech1(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return TownTechs.name.MEDICAL_CENTER;
		case name.ENCLAVE:
			return TownTechs.name.ENERGY_PRODUCTION;
		case name.SYNDICATE:
			return TownTechs.name.ENERGY_PRODUCTION;
		case name.SWAMP_RUNNERS:
			return TownTechs.name.MEDICAL_CENTER;
		case name.NEW_FEDERALISTS:
			return TownTechs.name.GARRISON;
		case name.REGULATORS:
			return TownTechs.name.MACHINIST_SHOP;
		case name.HIGHWAYMEN:
			return TownTechs.name.MACHINIST_SHOP;
		case name.BROTHERHOOD:
			return TownTechs.name.ENERGY_PRODUCTION;
		case name.SONS_OF_NEPTUNE:
			return TownTechs.name.COMMUNICATION_CENTER;
		case name.SIGMA:
			return TownTechs.name.COMMUNICATION_CENTER;
		case name.NULL:
			return TownTechs.name.NULL;
		default:
			return TownTechs.name.NULL;
		}
	}
		
	public static TownTechs.name getTownTech2(Factions.name faction)
	{
		switch (faction) {
		case name.COALITION:
			return TownTechs.name.LEARNING_CENTER;
		case name.ENCLAVE:
			return TownTechs.name.WATER_AND_SUPPLIES;
		case name.SYNDICATE:
			return TownTechs.name.MACHINIST_SHOP;
		case name.SWAMP_RUNNERS:
			return TownTechs.name.COMMUNICATION_CENTER;
		case name.NEW_FEDERALISTS:
			return TownTechs.name.LEARNING_CENTER;
		case name.REGULATORS:
			return TownTechs.name.WATER_AND_SUPPLIES;
		case name.HIGHWAYMEN:
			return TownTechs.name.GARRISON;
		case name.BROTHERHOOD:
			return TownTechs.name.WATER_AND_SUPPLIES;
		case name.SONS_OF_NEPTUNE:
			return TownTechs.name.WATER_AND_SUPPLIES;
		case name.SIGMA:
			return TownTechs.name.LEARNING_CENTER;
		case name.NULL:
			return TownTechs.name.NULL;
		default:
			return TownTechs.name.NULL;
		}
	}
}
