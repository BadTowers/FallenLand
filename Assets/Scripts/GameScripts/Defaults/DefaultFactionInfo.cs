﻿using System.Collections;
using System.Collections.Generic;

namespace FallenLand
{
	public class DefaultFactionInfo
	{
		private readonly List<Faction> Factions;

		public DefaultFactionInfo()
		{
			Factions = new List<Faction>();
			Faction curFac;
			Perk curPerk;
			string lore;
			int tempID = 1;
			TownTech curTech;
			ConditionalGain conditionalGain;
			Reward rewardChoice;

			/***************************************************/
			curFac = new Faction("Coalition of the Black Angels", new Coordinates(19, 13));
			curFac.SetBaseLocationString("Iowa City, Iowa");
			curPerk = new Perk("Combat Medic");
			curPerk.SetPerkDescription("Begin the game with the PARAMEDIC MED KIT spoils card");
			conditionalGain = new ConditionalGain();
			rewardChoice = new GainParamedicMedKit();
			conditionalGain.AddRewardChoice(new List<Reward>() { rewardChoice });
			conditionalGain.SetWhenRewardCanBeClaimed(new DuringGameStartSetup());
			curPerk.SetConditionalGain(conditionalGain);
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Information Crossroads");
			curPerk.SetPerkDescription("Once per turn, during the TOWN BUSINESS PHASE, you may pay 5 salvage coins to draw 1 action card");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>() {
		//	{Gains.Gain_Action_Cards, 1},
		//	{Gains.Optional_Pay_Salvage, 5}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Town_Business_Phase
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Turn
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Fight Club");
			curPerk.SetPerkDescription("During party MELEE WEAPONS ONLY encounter cards, you receive 1 additional combat success");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>() {
		//	{Gains.Gain_Party_Combat_Skill_Check_Successes, 1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Melee_Weapons_Only
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Encounter
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Midwestern Charm");
			curPerk.SetPerkDescription("Perform the HEALING DEED in any neutral starting town without having to pay the bank");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>() {
		//	{Gains.Healing_Deed_Salvage_Coin_Cost, 0}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.In_Neutral_Starting_Town
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Unlimited
		//});
			curFac.AddPerk(curPerk);
			lore = "The residents of Iowa City panicked with the onset of the Great War, as many feared they would be targeted in the nuclear exchanged because of defense contractors, hospitals, " +
				"and colleges. However, the anticipated hammer stroke never fell. Even when Des Moines was dusted and the ashen fallout drifted down like snow, Iowa City was again spared. " +
				"But their luck eventually ran out.\n\nAs a crossroads in the Midwest, the city was quickly inundated with fleeing refugees during the Maddening. Iowa City residents were thoroughly " +
				"unprepared for the many horrors the outsiders brought with them, especially those afflicted by the biological weapons used during the war. Disease and starvation also struck hard, " +
				"followed by rioting that destroyed the city east of the river. As chaos and desperation increased, so did the interest from roving bands of armed marauders, who staged a series of " +
				"devastating raids. Out of options, a large group of survivors retreated into the ruinous hospital sprawl near the stadium. Working together, they fortified the buildings and created a " +
				"new town--one they could defend. Once the area was secure, the survivors formed the Coalition of the Black Angel. Throughout the Emergence, the town has continued to prosper. It now features " +
				"both learning and medical centers and an intricate array of rooftop conservatories. It is also considered one of the last remaining intellectual bastions in the Fallen Lands.\n\nLed by " +
				"the Grand Mayor, who is elected from a council of elites, the Coalition of the Black Angel has made the preservation of pre-war knowledge a priority as they continue to expand and reclaim " +
				"buildings. Priding themselves in maintaining strong diplomatic ties with the other factions, the Coalition of the Black Angel is often at the forefront of the decision making within the Council " +
				"of the Ten Towns. Frequently playing the role of peacekeeper and brokering deals among the other Factions, they prefer to assert themselves through the use of soft power. While they " +
				"are considered less militant than the other factions, as they have proven many times, their militia is efficient and well-trained.\n";
			curFac.SetLore(lore);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Medical Center"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Learning Center"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curFac.SetId(tempID);
			tempID++;
			Factions.Add(curFac);


			/***************************************************/
			curFac = new Faction("Enclave of Terra", new Coordinates(10, 20));
			curFac.SetBaseLocationString("Great Falls, Montana");
			curPerk = new Perk("Hunter's Instinct");
			curPerk.SetPerkDescription("Begin the game with the COMPOUND HUNTING BOW spoils card.");
			conditionalGain = new ConditionalGain();
			rewardChoice = new GainCompoundHuntingBow();
			conditionalGain.AddRewardChoice(new List<Reward>() { rewardChoice });
			conditionalGain.SetWhenRewardCanBeClaimed(new DuringGameStartSetup());
			curPerk.SetConditionalGain(conditionalGain);
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Diplomatic Connections");
			curPerk.SetPerkDescription("Each time you are the first player, SUBTRACT 2 FROM TOWN EVENTS ROLL.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Subtract_From_Roll, 2}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Town_Events_Chart_Subphase
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Turn
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Wiley");
			curPerk.SetPerkDescription("Your party GAINS +1 DURING FLIGHT ROLLS.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Add_To_Roll, 1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Encounter_Flight
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Encounter
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Kismet");
			curPerk.SetPerkDescription("Once per turn, during a solo encounter card, REROLL A FAILED SKILL CHECK.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Reroll_Failed_Skill_Check, 1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Solo_Encounter
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Turn
		//});
			curFac.AddPerk(curPerk);
			lore = "The remote location of Great Falls spared it from the nuclear exchange that destroyed civilization. However, as supplies became scarce during the dark years of the Maddening, many " +
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
			curFac.SetLore(lore);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Energy Production"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Water and Supplies"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curFac.SetId(tempID);
			tempID++;
			Factions.Add(curFac);


			/***************************************************/
			curFac = new Faction("Syndicate", new Coordinates(4, 15));
			curFac.SetBaseLocationString("Battle Mountain, Nevada");
			curPerk = new Perk("Natural Defenses");
			curPerk.SetPerkDescription("Begin the game with 1 TOWN DEFENSE CHIP.");
			conditionalGain = new ConditionalGain();
			//rewardChoice = new Reward();
			conditionalGain.AddRewardChoice(new List<Reward>() { rewardChoice });
			conditionalGain.SetWhenRewardCanBeClaimed(new DuringGameStartSetup());
			curPerk.SetConditionalGain(conditionalGain);
			curFac.AddPerk(curPerk);
			curPerk = new Perk("High Rollers");
			curPerk.SetPerkDescription("During the TOWN EVENTS PHASE, you must roll 1d6. On a 1-3, receive 5 salvage coins from the bank. However, on a 6, you lose 7 salvage coins or its equivilent in spoils cards.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Roll_D6, 1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Town_Events_Chart_Subphase
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Turn
		//});
		//	curPerk.AddD6Option(new Dictionary<Gains, int>(){ //1
		//	{Gains.Gain_Salvage, 5}
		//});
		//	curPerk.AddD6Option(new Dictionary<Gains, int>(){ //2
		//	{Gains.Gain_Salvage, 5}
		//});
		//	curPerk.AddD6Option(new Dictionary<Gains, int>(){ //3
		//	{Gains.Gain_Salvage, 5}
		//});
		//	curPerk.AddD6Option(null); //4
		//	curPerk.AddD6Option(null); //5
		//	curPerk.AddD6Option(new Dictionary<Gains, int>(){ //6
		//	{Gains.Lose_Salvage, 7}
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Mountaineering");
			curPerk.SetPerkDescription("Each MOVEMENT DEED, the 1st mountain hex your party passes through costs 1 movement instead of two.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Mountain_Hexes_Cost, 1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.First_Move_Into_Mountain_Hex
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Movement_Deed
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("The Mineshaft Gap");
			curPerk.SetPerkDescription("Once per turn, if your town roster is empty, you may draw a character card and place it there.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Draw_Character_Cards, 1},
		//	{Gains.Place_Into_Town_Roster, -1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.Anytime
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Turn
		//});
			curFac.AddPerk(curPerk);
			lore = "The local warning sirens wailed across the mining community as death rained from the skies. Only the residents that fled to the mines survived. Within its depths, the survivors found " +
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
			curFac.SetLore(lore);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Energy Production"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Machinist Shop"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curFac.SetId(tempID);
			tempID++;
			Factions.Add(curFac);


			/***************************************************/
			curFac = new Faction("Swamp Runners", new Coordinates(20, 4));
			curFac.SetBaseLocationString("Shreveport, Louisiana");
			curPerk = new Perk("Connected");
			curPerk.SetPerkDescription("Begin the game with a resource location of your choosing.");
			conditionalGain = new ConditionalGain();
			//rewardChoice = new Reward();
			conditionalGain.AddRewardChoice(new List<Reward>() { rewardChoice });
			conditionalGain.SetWhenRewardCanBeClaimed(new DuringGameStartSetup());
			curPerk.SetConditionalGain(conditionalGain);
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Southern Ingenuity");
			curPerk.SetPerkDescription("Once per turn, during the effects phase, you may DISCARD AN ACTION CARD TO DRAW A SPOILS CARD for your auction house.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Discard_Action_Cards, 1},
		//	{Gains.Draw_Spoils_Cards, 1},
		//	{Gains.Place_Into_Auction_House, -1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Effects_Phase
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Turn
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Smugglers Network");
			curPerk.SetPerkDescription("Each time you sell a spoils card from your auction house to another player, receive 3 salvage coin from the bank.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Gain_Salvage, 3}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.After_Sell_Spoils_Card_From_Auction_House_To_Another_Player
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Unlimited
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Born on the Bayou");
			curPerk.SetPerkDescription("Your party gains +2 FLIGHT during PVP.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Add_To_Roll, 2}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_PVP_Flight
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Encounter
		//});
			curFac.AddPerk(curPerk);
			lore = "Shreveport sustained mass casualties from the biological weapons used in the Great War. Many residents suffered horrible deaths, while others looted and pillaged the city gripped by " +
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
			curFac.SetLore(lore);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Medical Center"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Communication Center"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curFac.SetId(tempID);
			tempID++;
			Factions.Add(curFac);


			/***************************************************/
			curFac = new Faction("New Federalists", new Coordinates(25, 7));
			curFac.SetBaseLocationString("Albany, Georgia");
			curPerk = new Perk("Armory Cache");
			curPerk.SetPerkDescription("Begin the game with the MILITIA RIFLE spoils card.");
			conditionalGain = new ConditionalGain();
			rewardChoice = new GainMilitiaRifle();
			conditionalGain.AddRewardChoice(new List<Reward>() { rewardChoice });
			conditionalGain.SetWhenRewardCanBeClaimed(new DuringGameStartSetup());
			curPerk.SetConditionalGain(conditionalGain);
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Weapons Bazaar");
			curPerk.SetPerkDescription("During the town business phase, roll 1d6. On 1-2, remove first weapons spoils card (top to bottom) from discard pile and place into auction house.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Roll_D6, 1},
		//	{Gains.Place_Into_Auction_House, -1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Town_Business_Phase
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Turn
		//});
		//	curPerk.AddD6Option(new Dictionary<Gains, int>(){ //1
		//	{Gains.Gain_First_Weapon_Spoils_From_Discard, 1}
		//});
		//	curPerk.AddD6Option(new Dictionary<Gains, int>(){ //2
		//	{Gains.Gain_First_Weapon_Spoils_From_Discard, 1}
		//});
		//	curPerk.AddD6Option(null); //3
		//	curPerk.AddD6Option(null); //4
		//	curPerk.AddD6Option(null); //5
		//	curPerk.AddD6Option(null); //6
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Navigators");
			curPerk.SetPerkDescription("City and radiation hexes cost 2 movement instead of 3.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.CityRad_Hexes_Cost, 2}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.Anytime
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Unlimited
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Mercenary Haven");
			curPerk.SetPerkDescription("Pay 2 salvage coins less to hire an NPCM action card or ALLY spoils card.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.NPCM_Hire_Cost_Less, 2},
		//	{Gains.Ally_Hire_Cost_Less, 2}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.Anytime
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Unlimited
		//});
			curFac.AddPerk(curPerk);
			lore = "In the early hours of the Great War, Albany braced for attack. Washington D.C. was already gone, and the long list of dusted cities just kept growing. The first missiles targeting " +
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
			curFac.SetLore(lore);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Garrison"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Learning Center"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curFac.SetId(tempID);
			tempID++;
			Factions.Add(curFac);


			/***************************************************/
			curFac = new Faction("Regulators", new Coordinates(14, 8));
			curFac.SetBaseLocationString("Amarillo, Texas");
			curPerk = new Perk("The Cownboy Way");
			curPerk.SetPerkDescription("Begin the game with the SIX FAST HORSES spoils card.");
			conditionalGain = new ConditionalGain();
			rewardChoice = new GainSixFastHorses();
			conditionalGain.AddRewardChoice(new List<Reward>() { rewardChoice });
			conditionalGain.SetWhenRewardCanBeClaimed(new DuringGameStartSetup());
			curPerk.SetConditionalGain(conditionalGain);
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Cattle Drivers");
			curPerk.SetPerkDescription("Each town business phase, choose another faction. You each receive 3 salvage coins.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Pick_Other_Factions_Share_Gains, 1},
		//	{Gains.Gain_Salvage, 3}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Town_Business_Phase
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Turn
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Into the Wild");
			curPerk.SetPerkDescription("During End Turn Phase, you may move your STARTING TOWN LOCATION up to 2 hexes by paying 3 salvage coins. Cannot occupy hex containing another town, resource, radiation, or water. Mission locations are rerolled.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Optional_Pay_Salvage, 3},
		//	{Gains.Move_Town_Location_Number_Hexes, 2}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_End_Turn_Phase
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Turn
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Rangers");
			curPerk.SetPerkDescription("You may purchase the tier 1 LAW AND ORDER TOWN TECHNOLOGY for 30 salvage coins.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Town_Tech_Law_And_Order_Tier_One_Cost, 30},
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Purchase_Subphase
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Unlimited
		//});
			curFac.AddPerk(curPerk);
			lore = "By the time the radioactive fallout drifted across the plains, the US government was already gone and the country’s infrastructure had collapsed. No help was coming. The " +
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
			curFac.SetLore(lore);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Machinist Shop"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Water and Supplies"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curFac.SetId(tempID);
			tempID++;
			Factions.Add(curFac);


			/***************************************************/
			curFac = new Faction("The Highwaymen", new Coordinates(16, 16));
			curFac.SetBaseLocationString("Sturgis, South Dakota");
			curPerk = new Perk("Motorcycle Culture");
			curPerk.SetPerkDescription("Begin the game with the AMERICAN IRON CUSTOM CHOPPERS spoils card. Cannot be sold or traded.");
			conditionalGain = new ConditionalGain();
			rewardChoice = new GainAmericanIronCustomChoppers();
			conditionalGain.AddRewardChoice(new List<Reward>() { rewardChoice });
			conditionalGain.SetWhenRewardCanBeClaimed(new DuringGameStartSetup());
			curPerk.SetConditionalGain(conditionalGain);
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Caravan Escort");
			curPerk.SetPerkDescription("Each town business phase, select another faction. You each gain 2 salvage coins.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Pick_Other_Factions_Share_Gains, 1},
		//	{Gains.Gain_Salvage, 2}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Town_Business_Phase
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Turn
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("The Riddle of Steel");
			curPerk.SetPerkDescription("If your party returns to town without a vehicle, immediately retrieve the AMERICAN IRON CUSTOM CHOPPERS spoils card.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Gain_Spoils_Card_American_Iron_Custom_Choppers, 1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.Return_To_Town_Location,
		//	Times.Has_No_Vehicle
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Unlimited
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Road Warriors");
			curPerk.SetPerkDescription("Each time a VEHICLE COMBAT or BIKER GANG ENCOUNTER CARD is drawn by any player, you GAIN 1 PRESTIGE.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Gain_Prestige, 1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.Vehicle_Combat_Or_Biker_Gang_Encounter_Drawn,
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Encounter
		//});
			curFac.AddPerk(curPerk);
			lore = "After the bombs fells, the motorcycle clubs that survived were forced to rely on mobility and safety in numbers. Those that escaped the gridlock and chaos made the pilgrimage to " +
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
			curFac.SetLore(lore);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Machinist Shop"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Garrison"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curFac.SetId(tempID);
			tempID++;
			Factions.Add(curFac);


			/***************************************************/
			curFac = new Faction("The Brotherhood", new Coordinates(7, 11));
			curFac.SetBaseLocationString("Saint George, Utah");
			curPerk = new Perk("Blade Cult");
			curPerk.SetPerkDescription("Begin the game with the VENDETTA DAGGERS spoils card.");
			conditionalGain = new ConditionalGain();
			rewardChoice = new GainVendettaDaggers();
			conditionalGain.AddRewardChoice(new List<Reward>() { rewardChoice });
			conditionalGain.SetWhenRewardCanBeClaimed(new DuringGameStartSetup());
			curPerk.SetConditionalGain(conditionalGain);
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Wasteland Scavengers");
			curPerk.SetPerkDescription("Each TOWN BUSINESS PHASE, roll 1d6 and gain that many salvage coins.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Roll_D6, 1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Town_Business_Phase
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Turn
		//});
		//	curPerk.AddD6Option(new Dictionary<Gains, int>(){ //1
		//	{Gains.Gain_Salvage, 1}
		//});
		//	curPerk.AddD6Option(new Dictionary<Gains, int>(){ //2
		//	{Gains.Gain_Salvage, 2}
		//});
		//	curPerk.AddD6Option(new Dictionary<Gains, int>(){ //3
		//	{Gains.Gain_Salvage, 3}
		//});
		//	curPerk.AddD6Option(new Dictionary<Gains, int>(){ //4
		//	{Gains.Gain_Salvage, 4}
		//});
		//	curPerk.AddD6Option(new Dictionary<Gains, int>(){ //5
		//	{Gains.Gain_Salvage, 5}
		//});
		//	curPerk.AddD6Option(new Dictionary<Gains, int>(){ //6
		//	{Gains.Gain_Salvage, 6}
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Down With the Sickness");
			curPerk.SetPerkDescription("When an opponent plays a \"negative\" action card against one of your characters or party, roll 1d6. On a 1, each of their party members suffers 1 radiation damage.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Roll_D6, 1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.Negative_Action_Card_Against_Player
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Card
		//});
		//	curPerk.AddD6Option(new Dictionary<Gains, int>(){ //1
		//	{Gains.Inflict_Rad_Damage_On_Opposing_Party, 1}
		//});
		//	curPerk.AddD6Option(null); //2
		//	curPerk.AddD6Option(null); //3
		//	curPerk.AddD6Option(null); //4
		//	curPerk.AddD6Option(null); //5
		//	curPerk.AddD6Option(null); //6
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Survival Instincts");
			curPerk.SetPerkDescription("Your party ignores all negative effects from ENVIRONMENTAL HAZARD encounter cards.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Ignore_Negatives_Of_Enoucnter_Failure, -1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Environmetal_Hazard_Encounter_Card
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Card
		//});
			curFac.AddPerk(curPerk);
			lore = "The red sandstone bluffs surrounding Saint George provided little reprieve from the fallout of the dusted West Coast cities. Isolated and forgotten, the windswept town of Saint George " +
				"was forced to turn inward and became more and more xenophobic of “out-dwellers”. For a while, the arid soil provided subsistence farming. When this failed, scouting parties were dispatched " +
				"to locate what they needed to survive. The mysterious Yucca Mountain facility was discovered during one such excursion. Stockpiled with decommissioned nuclear weapons and radioactive waste, " +
				"the massive complex had a profound effect on their society and things were never the same. Perhaps it was their prolonged exposure during its exploration. Perhaps it was something else " +
				"entirely. But it changed them; warped their minds. The once devout populace of Saint George began down a dark and sinister path that day when they formed their cult. With each passing " +
				"generation, the Brotherhood of the Apocalypse’s history and secrets became more shrouded in mystery.\n\nWherever they traveled, the Brotherhood attempts to spread their faith, which " +
				"frequently makes them targets and only serves to radicalize their ranks. Believing they are the “divine saviors” of the Great War and worshipping the Almighty Bomb (some whisper death itself), " +
				"most outsiders consider them a scourge and savage enigma. Often feared because of their appearance, they are recognizable by their long desert garb, hooded cloaks, and gas masks, which afford " +
				"them protection from the radioactive sandstorms common in their region. Leaders in their community carry the long-curved daggers displayed on their banner. Their town is cleverly designed to " +
				"blend in with its desert surroundings. Constructed out of sandstone slabs and junk, the insides of their buildings are the exact opposite; pristine sanctuaries illuminated by natural light " +
				"from stained glass windows made from scavenged glass.\n\nLed by their High Cleric, the Brotherhood demanded a place on the Council. When their initial request was ignored, they appealed to " +
				"the accepting natures of the Coalition of the Black Angel and Enclave of Terra. When this again failed, they threatened war. After much deliberation, the Council of the Ten Towns admitted them " +
				"to keep the peace, although the vote was later disputed. The Brotherhood has grand designs to establish clandestine cults within each of the factions. Eventually, they hope to bolster their " +
				"numbers until they can overthrow each faction’s leadership and establishing an overarching theocracy.\n";
			curFac.SetLore(lore);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Energy Production"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Water and Supplies"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curFac.SetId(tempID);
			tempID++;
			Factions.Add(curFac);


			/***************************************************/
			curFac = new Faction("Sons of Neptune", new Coordinates(23, 15));
			curFac.SetBaseLocationString("Grand Haven, Michigan");
			curPerk = new Perk("Hidden Agenda");
			curPerk.SetPerkDescription("Begin the game with TWO ADDITIONAL ACTION CARDS.");
			conditionalGain = new ConditionalGain();
			//rewardChoice = new Reward();
			conditionalGain.AddRewardChoice(new List<Reward>() { rewardChoice });
			conditionalGain.SetWhenRewardCanBeClaimed(new DuringGameStartSetup());
			curPerk.SetConditionalGain(conditionalGain);
			curFac.AddPerk(curPerk);
			curPerk = new Perk("River Traders");
			curPerk.SetPerkDescription("Each EFFECTS PHASE, you may draw a spoils card. To keep it, pay a random player 1/2 its value in salvage (rounded up).");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Draw_Spoils_Cards, 1},
		//	{Gains.Pay_Random_Player_Half_Salvage_Value_To_Keep, -1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Effects_Phase
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Turn
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Anchors Aweigh");
			curPerk.SetPerkDescription("When your town is the target of an action card or world card effect, roll 1d6. On a 1, ignore the effects.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Roll_D6, 1},
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.Town_Target_Of_Action_Card_Or_World_Card
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Card
		//});
		//	curPerk.AddD6Option(new Dictionary<Gains, int>(){ //1
		//	{Gains.Ignore_Negative_Effects_Of_Card, 1}
		//});
		//	curPerk.AddD6Option(null); //2
		//	curPerk.AddD6Option(null); //3
		//	curPerk.AddD6Option(null); //4
		//	curPerk.AddD6Option(null); //5
		//	curPerk.AddD6Option(null); //6
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Amphibious");
			curPerk.SetPerkDescription("Your party may MOVE THROUGH THE GREAT LAKES. Each lake costs 1 salvage and 1 movement. Cannot end movement deed in water hex.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Move_Through_Great_Lakes, 1},
		//	{Gains.Optional_Pay_Salvage, 1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Movement_Deed
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Unlimited
		//});
			curFac.AddPerk(curPerk);
			lore = "In the early hours of the Great War, Chicago and Detroit were hit simultaneously by multiple ICBMs. But above them on the peninsula, a last-minute shift in the winds saved Grand " +
				"Haven, “Coast Guard City USA”. Still, many people with boards fled to the water of the Great Lakes to survive. The old adage “safety in numbers” proved true during the Maddening, " +
				"which resulted in the survivors forming flotillas, only returning to shore to scavenge supplies. Eventually, the two largest flotillas on the lakes combined forces to form the Sons " +
				"of Neptune. Within months, the remaining groups united under the blue trident banner. Hardened sailors, their new society was one born of the waves.\n\nTheir territory and reach " +
				"continued to grow, as did their fleet, scavenging abilities, and economic influence. As the second faction to establish themselves within the Fallen Land, the Sons of Neptune’s rise " +
				"to power signaled the end of the Maddening and the beginning of a new era called the Emergence. Inspired by their many successes, the next few years saw eight other factions step " +
				"forward. Seizing this opportunity, the Sons of Neptune created a trade and economic forum. Capping its membership at ten, they only invited the largest survivor groups, called " +
				"factions, to join. Over time, the council expanded its authority and power to become the Council of the Ten Towns.\n\nFocusing on trade, Grand Haven is often the middleman when " +
				"it comes to commodities within the Ten Towns. Specializing in trade and logistics, they often lord the knowledge they have gained from old technologies looted from the ruinous " +
				"metropolitan areas over the other factions. Their economic success has also fueled many inter-faction rivalries and competition for scant resources. Always bustling with activity, " +
				"their town is comprised of three massive cargo ships that are tethered together and serviced by a unique menagerie of other watercraft.\n\nGrand Haven is a representative " +
				"democracy, guided by the Council of Captains, but steered by the Admiral. Preferring logical policies achieved by subtlety and discipline, the Admiral’s map for the future " +
				"includes the restoration of social order by any and all means necessary. Grand Haven intends to become the premier economic power in the Fallen Lands and hopes to eventually " +
				"reestablish overseas trade. The other factions will then have no choice but to unite under the Sons of Neptune.\n";
			curFac.SetLore(lore);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Communication Center"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Water and Supplies"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curFac.SetId(tempID);
			tempID++;
			Factions.Add(curFac);
			/***************************************************/
			curFac = new Faction("Sigma Corporation", new Coordinates(28, 14));
			curFac.SetBaseLocationString("Emporium, Pennsylvania");
			curPerk = new Perk("The Long Walk");
			curPerk.SetPerkDescription("Begin the game with the 6.8mm ADVANCED RIFLE spoils card.");
			conditionalGain = new ConditionalGain();
			rewardChoice = new Gain68mmAdvancedRifle();
			conditionalGain.AddRewardChoice(new List<Reward>() { rewardChoice });
			conditionalGain.SetWhenRewardCanBeClaimed(new DuringGameStartSetup());
			curPerk.SetConditionalGain(conditionalGain);
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Veritable Fortress");
			curPerk.SetPerkDescription("Begin the game with 2 TOWN DEFENSE CHIPS. All other town defense chips cost 4 extra salvage coins.");
			//
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Excavation");
			curPerk.SetPerkDescription("If any player draws a mission card with the word SIGMA IN THE TITLE, YOU GAIN 3 TOWN HEALTH.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Gain_Town_Health, 3}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Mission_Card_Sigma_In_Title_Any_Player
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Card
		//});
			curFac.AddPerk(curPerk);
			curPerk = new Perk("Black Ops");
			curPerk.SetPerkDescription("Once per game, during your party exploits phase, move your party to any mission location on the map.");
		//	curPerk.SetConditionalGains(new Dictionary<Gains, int>(){
		//	{Gains.Move_To_Any_Mission_Chip, 1}
		//});
		//	curPerk.SetTimes(new List<Times>(){
		//	Times.During_Party_Exploits_Phase
		//});
		//	curPerk.SetUses(new List<Uses>(){
		//	Uses.Once_Per_Game
		//});
			curFac.AddPerk(curPerk);
			lore = "After 9/11 and the ensuing \"war on terror\", Emporium, Pennsylvania found itself the thirteenth site of the U.S. government’s top-secret Sigma Series program. Fearing " +
				"a catastrophe loomed on the horizon, these new state-of-the-art bunkers were designed to survive a nuclear war, biological catastrophe, or extinction level event. A vast " +
				"improvement over their obsolete predecessors from the Cold War, they were created to safeguard government institutions. The Emporium Bunker’s primary mission was to harbor " +
				"members of Congress. Its secondary mission was to preserve a digital copy of the Library of Congress and the files for the mysterious project God’s Hammer. The private " +
				"security firm that landed this superfluous contract was Sigma Corporation. Dominating the industry, they absorbed their rivals Darkwater Security and Holli-Barton. " +
				"Everything was on schedule until the Great War began.\n\nThe massive EMP strike near Albany that knocked out the power and electronics across the Eastern Seaboard also " +
				"corrupted the data download from the Library of Congress and the bunker’s main communication array. In a desperate act of self-preservation, the technicians inside sealed " +
				"the blast door prematurely. Helicopters continued to arrive low on fuel with members of Congress. As ICBMs struck nearby, those trapped outside perished. However, those " +
				"who had made it inside enjoyed the bunker’s safety during the long, dark years of the Maddening; two hundred feet below the surface encased in solid bedrock. Later, when " +
				"supplies ran low, the bunker’s Security Chief seized power. Implementing a host of authoritarian policies, he took on the title Illuminarious and quickly and quietly silenced " +
				"his opposition. It was only recently during the Emergence that the mysterious Sigma Corporation came out of the shadows. When it did, the bunker grew into a small town " +
				"with a state-of-the-art learning facility and a revamped communication array that is unparalleled within the Ten Towns. As the smallest of the Ten Towns, many of its " +
				"citizens still distrust outsiders, who are still denied access to the lower levels.\n\nBecause Sigma Corporation purposefully remained hidden for so long, no one really " +
				"trusts them, and they remain at the apex of conspiracy theories within the Ten Towns. As the last faction to join the council, they have had to skillfully expand their sphere " +
				"of influence through a series of backroom dealings, which only perpetuates the general distrust of Sigma Corporation. As long as the Illuminarious can continue to influence " +
				"the Council of the Ten Towns, it remains useful. Their clandestine agenda is to locate the other Sigma Series Bunkers and consolidate their own power. From there, they hope " +
				"to rebuild the military industrial complex, seek out the enemies of the former United States, and eliminate them and anyone else who stands in their way with extreme prejudice.\n";
			curFac.SetLore(lore);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Communication Center"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curTech = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName("Learning Center"));
			curTech.SetIsStartingTech(true);
			curFac.AddStartingTownTech(curTech);
			curFac.SetId(tempID);
			tempID++;
			Factions.Add(curFac);
		}

		public List<Faction> GetDefaultFactionList()
		{
			return Factions;
		}

		public Faction GetFactionFromName(string name)
		{
			Faction faction = null;
			for (int i = 0; i < Factions.Count; i++)
			{
				if (Factions[i].GetName() == name)
				{
					faction = Factions[i];
					break;
				}
			}
			return faction;
		}
	}
}
