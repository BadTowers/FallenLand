using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class DefaultCharacterCards
	{
		private List<CharacterCard> CharacterCards;

		public DefaultCharacterCards()
		{
			CharacterCards = new List<CharacterCard>();
			int curID = 0;

			//Add the cards to the list
			CharacterCard curCard;
			LinkCommon currentLink;

			Debug.Log("Instantiating character cards...");


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Addison Morley");
			curCard.SetTitleSubString("Veteran Park Ranger");
			curCard.SetQuote("It's way too quiet. Something's not right.");
			curCard.SetCarryCapacity(11);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 9},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 6}
			});
			currentLink = new Link("Axe or Compass and Maps Equipped", new AxeOrCompassAndMapsEquipped());
			currentLink.AddRewardOnActivate(new GainSurvival(1));
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseSurvival(1));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			curCard.SetCharacterLink(currentLink);
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard); //Add the card to the list of all cards


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Joseph Young Wolf");
			curCard.SetTitleSubString("Big Game Hunter");
			curCard.SetQuote("Sure, I've trained town scouts. But I'm a tracker and prefer the open road.");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(4);
			curCard.SetIsMaster(true);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 10},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 6},
				{Skills.Technical, 5},
				{Skills.Medical, 6}
			});
			currentLink = new Link("Rifle or Shotgun", new RifleOrShotgunEquipped());
			currentLink.AddRewardOnActivate(new GainBonusMovement(1));
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseBonusMovement(1));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			curCard.SetCharacterLink(currentLink);
			//curCard.AddPassiveGain(Gains.Gain_Party_Survival_Skill_Check_Successes, 1);
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Norton Carlin");
			curCard.SetTitleSubString("Outrageous Comedian");
			curCard.SetQuote("I mean c'mon, you Eaters don't want me. I know your mothers. In fact, (althought this seems like the wrong time), I'm your father.");
			curCard.SetCarryCapacity(10);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 6},
				{Skills.Technical, 6},
				{Skills.Medical, 6}
			});
			currentLink = new Link("Rifle or Shotgun", new IndestructibleTennisRacquetOrSledgeHammerOrSockMonkeyPuppetEquipped());
			currentLink.AddRewardOnActivate(new GainDiplomacy(2));
			currentLink.AddPunishmentOnDeactivate(new LoseDiplomacy(2));
			curCard.SetCharacterLink(currentLink);
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Martha Mother Trucker");
			curCard.SetTitleSubString("Matron of the I-80 Caravaners");
			curCard.SetQuote("Since the Maddening, I've been to both coasts and everywhere in between.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 9},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			//No link
			curCard.AddPassiveGain(Gains.Gain_Movement, 1);
            curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Ashton Campbell");
			curCard.SetTitleSubString("Resourceful Scavenger");
			curCard.SetQuote("As a salvager, I can find just about anything.");
			curCard.SetCarryCapacity(17);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 5},
				{Skills.Technical, 6},
				{Skills.Medical, 6}
			});
			//Link adds active
            curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Peter Kelsey");
			curCard.SetTitleSubString("Chatty Repairman");
			curCard.SetQuote("I've been told I'm best in small doses.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 4},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 8},
				{Skills.Technical, 9},
				{Skills.Medical, 5}
			});
			//Link doubles technical skill bonus
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("SSG Carter Neil");
			curCard.SetTitleSubString("Veteran Town Scout");
			curCard.SetQuote("They won't even see us coming, until it's too late.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(9);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 5},
				{Skills.Technical, 6},
				{Skills.Medical, 7}
			});
			currentLink = new Link("Assault Rifle", new AssaultRifleEquipped());
			currentLink.AddRewardOnActivate(new GainSurvival(1));
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseSurvival(1));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Orison Lech");
			curCard.SetTitleSubString("Faction Bureaucrat");
			curCard.SetQuote("Believe me. I'll always find a way to make our enemies pay.");
			curCard.SetCarryCapacity(11);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 9},
				{Skills.Mechanical, 6},
				{Skills.Technical, 6},
				{Skills.Medical, 5}
			});
			//No link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Bruce Stephens");
			curCard.SetTitleSubString("Exile");
			curCard.SetQuote("My last group sent me out here to die... I didn't...");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 4},
				{Skills.Mechanical, 9},
				{Skills.Technical, 6},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Any 4 Wheel Vehicle In Party", new Any4WheelVehicleInParty());
			currentLink.AddRewardOnActivate(new GainBonusMovement(2));
			currentLink.AddPunishmentOnDeactivate(new LoseBonusMovement(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add passive gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Wade Marlow");
			curCard.SetTitleSubString("Friendly Iowan");
			curCard.SetQuote("You've heard of Midwestern charm, right?");
			curCard.SetCarryCapacity(11);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 5},
				{Skills.Technical, 6},
				{Skills.Medical, 6}
			});
			currentLink = new Link("Shotgun", new ShotgunEquipped());
			currentLink.AddRewardOnActivate(new GainSurvival(1));
			currentLink.AddRewardOnActivate(new GainDiplomacy(2));
			currentLink.AddPunishmentOnDeactivate(new LoseSurvival(1));
			currentLink.AddPunishmentOnDeactivate(new LoseDiplomacy(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Max Gibson");
			curCard.SetTitleSubString("Wasteland Vigilante");
			curCard.SetQuote("I've seen a few road wars. It's a nasty business.");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(9);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 7},
				{Skills.Technical, 5},
				{Skills.Medical, 4}
			});
			currentLink = new Link("Sawed-off Shotgun or Handgun", new SawedOffShotgunOrHandgunEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Quinn Rubins");
			curCard.SetTitleSubString("Dexterous Sniper");
			curCard.SetQuote("I was a sniper with the Death's Head Mercs, but now I've found my true calling.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 9},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 6}
			});
			currentLink = new Link("Rifle", new RifleEquipped());
			currentLink.AddRewardOnActivate(new GainSurvival(2));
			currentLink.AddRewardOnActivate(new GainDiplomacy(2));
			currentLink.AddPunishmentOnDeactivate(new LoseSurvival(2));
			currentLink.AddPunishmentOnDeactivate(new LoseDiplomacy(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Alan Deacon");
			curCard.SetTitleSubString("Seasoned INvestigator");
			curCard.SetQuote("Don't ever lie to me. I'll always find out the truth.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 5},
				{Skills.Technical, 7},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Handgun", new HandgunEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddRewardOnActivate(new GainDiplomacy(2));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseDiplomacy(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Sensei Tonaka");
			curCard.SetTitleSubString("Ninjutsu Sensei");
			curCard.SetQuote("You must become one with the shadows.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(9);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 10},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 6}
			});
			curCard.SetHasFirstStrike(true);
			curCard.SetIsMaster(true);
			currentLink = new Link("Melee Weapon or Bow", new MeleeWeaponOrBowEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Ivory Pace");
			curCard.SetTitleSubString("Fiery Flight Nurse");
			curCard.SetQuote("You kill the slavers. I'll help the refugees.");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 4},
				{Skills.Technical, 6},
				{Skills.Medical, 8}
			});
			//Link doubles medical skill bonuses and medical equipment can be used twice instead of once before discarding
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Dylan Mackenzie");
			curCard.SetTitleSubString("Intense Survival Guide");
			curCard.SetQuote("Well? WHat are you all waiting for? Let's do this!");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 9},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 7},
				{Skills.Technical, 6},
				{Skills.Medical, 8}
			});
			currentLink = new Link("Camping Gear or Knife", new CampingGearOrKnifeEquipped());
			currentLink.AddRewardOnActivate(new GainSurvival(2));
			currentLink.AddPunishmentOnDeactivate(new LoseSurvival(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Captain Washington");
			curCard.SetTitleSubString("Caravan Officer");
			curCard.SetQuote("I'll get us there alive. Just put me behind the wheel and give me that hand-cannon.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 10},
				{Skills.Technical, 6},
				{Skills.Medical, 6}
			});
			curCard.SetIsMaster(true);
			currentLink = new Link("Motorized Vehicle in Party", new MotorizedVehicleInParty());
			currentLink.AddRewardOnActivate(new GainBonusMovement(2));
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseBonusMovement(2));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Miles Krakauer");
			curCard.SetTitleSubString("Energetic Paramedic");
			curCard.SetQuote("I've seen a lot of actiom. Sure it was rough, but it honed my mad skills.");
			curCard.SetCarryCapacity(12);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 5},
				{Skills.Technical, 6},
				{Skills.Medical, 7}
			});
			//Link doubles medical skill bonus and may use med equip twice before discarding
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Charlton Hallaway");
			curCard.SetTitleSubString("Paranoid Arms Dealer");
			curCard.SetQuote("Charlton don't take no shit! You feel me?");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 4},
				{Skills.Technical, 4},
				{Skills.Medical, 6}
			});
			//No link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Sean Cahill");
			curCard.SetTitleSubString("Skill Tactician");
			curCard.SetQuote("This is a war game and someone's feelings are getting hurt.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 7},
				{Skills.Technical, 7},
				{Skills.Medical, 6}
			});
			currentLink = new Link("Melee Weapon", new MeleeWeaponEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Almiah Bitar");
			curCard.SetTitleSubString("Acrobatic Thief");
			curCard.SetQuote("Hurry! Over the fence, they're coming.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 4},
				{Skills.Technical, 6},
				{Skills.Medical, 4}
			});
			//No link
			//TODO add conditional gain (choose 1)
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Norris Blake");
			curCard.SetTitleSubString("Inventor");
			curCard.SetQuote("Shut it. Can't you see I'm working? C'mon!");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 8},
				{Skills.Technical, 7},
				{Skills.Medical, 4}
			});
			currentLink = new Link("Ultimate Set of Tools", new UltimateSetOfToolsEquipped());
			currentLink.AddRewardOnActivate(new GainMechanical(2));
			currentLink.AddRewardOnActivate(new GainTechnical(2));
			currentLink.AddPunishmentOnDeactivate(new LoseMechanical(2));
			currentLink.AddPunishmentOnDeactivate(new LoseTechnical(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Deforest Tanner MD");
			curCard.SetTitleSubString("Caustic Trauma Surgeon");
			curCard.SetQuote("I may be an elitist, but unlike you, I've actually been out there--in the chaos.");
			curCard.SetCarryCapacity(12);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 6},
				{Skills.Technical, 6},
				{Skills.Medical, 10}
			});
			curCard.SetIsMaster(true);
			//Link doubles medical equipment bonuses. Can use twice before discarding
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Preston Wayne Ascott");
			curCard.SetTitleSubString("Eater posing as an Anesthesiologist");
			curCard.SetQuote("(Smiling) You know I love you all to pieces.");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(9);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 4},
				{Skills.Technical, 4},
				{Skills.Medical, 6}
			});
			currentLink = new Link("The Industrial Chainsaw, Extra Rusty Cleaver, or Scary Hockey Mask", new IndustrialChainSawOrExtraRustyCleaverOrScaryHockeyMaskEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Monica Pitcher");
			curCard.SetTitleSubString("Baker Street Bootlegger");
			curCard.SetQuote("Some people think I am spiteful, but I have a whimsical side, too.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 7},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Sock Monkey, Shotgun, or Alcohol", new SockMonkeyOrShotgunOrAlcoholEquipped());
			currentLink.AddRewardOnActivate(new GainDiplomacy(2));
			currentLink.AddPunishmentOnDeactivate(new LoseDiplomacy(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Laroy Jenkinz");
			curCard.SetTitleSubString("Grifter");
			curCard.SetQuote("Life's a game. And I'm ALWAYS on top.");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 4},
				{Skills.Technical, 4},
				{Skills.Medical, 4}
			});
			//No link
			//TODO add conditional gain
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Guy Turner");
			curCard.SetTitleSubString("Professional Prize Fighter");
			curCard.SetQuote("How about a friendly wager on our fight?");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 6},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Kempo Gloves or Brass Knuckles", new KempoKnucklesOrBrassKnucklesEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Jane Doe");
			curCard.SetTitleSubString("Amnesiac with a Dark Past");
			curCard.SetQuote("I don't remember anything before the accident. But since then, I've been places you'd never even dream of going.");
			curCard.SetCarryCapacity(11);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 7},
				{Skills.Technical, 9},
				{Skills.Medical, 7}
			});
			currentLink = new Link("Top Secret Weapon", new TopSecretWeaponEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Samuel Young");
			curCard.SetTitleSubString("Orphan and Party Mascot");
			curCard.SetQuote("I may be young, but I can get places you can't. Especially when things get bad...");
			curCard.SetCarryCapacity(10);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 4},
				{Skills.Technical, 6},
				{Skills.Medical, 4}
			});
			currentLink = new Link("Fang", new FangEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddRewardOnActivate(new GainSurvival(2));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseSurvival(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Sheila Axler");
			curCard.SetTitleSubString("Precocious Runaway");
			curCard.SetQuote("My folks were the lucky ones. They died from some super plague. I'm just stuck here with all of you.");
			curCard.SetCarryCapacity(12);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 4},
				{Skills.Mechanical, 8},
				{Skills.Technical, 8},
				{Skills.Medical, 6}
			});
			currentLink = new Link("Multi-tool or Knife", new MultiToolOrKnifeEquipped());
			currentLink.AddRewardOnActivate(new GainMechanical(1));
			currentLink.AddRewardOnActivate(new GainTechnical(2));
			currentLink.AddPunishmentOnDeactivate(new LoseMechanical(1));
			currentLink.AddPunishmentOnDeactivate(new LoseTechnical(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Bonz");
			curCard.SetTitleSubString("Purveyor of Ill-Gotten Goods");
			curCard.SetQuote("Hurray for me. Screw you!");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 7},
				{Skills.Technical, 7},
				{Skills.Medical, 7}
			});
			//No link
			//curCard.AddPassiveGain(Gains.Gain_Movement, 1);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Annabelle");
			curCard.SetTitleSubString("Cybernetic A.I. and Sleep Agent");
			curCard.SetQuote("I'm smarter, stronger, faster, and dealier.");
			curCard.SetCarryCapacity(17);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 11},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 9},
				{Skills.Technical, 9},
				{Skills.Medical, 8}
			});
			//No link
			//curCard.AddPassiveGain(Gains.Gain_Armor, 2);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Dmitri the Cleaner");
			curCard.SetTitleSubString("Faction Hitman");
			curCard.SetQuote("Show me the target, my friend.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 9},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			currentLink = new CumulativeLink("Handguns - Cumulative", new HandgunEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddRewardOnActivate(new GainSurvival(1));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseSurvival(1));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Kurtis Wyatt");
			curCard.SetTitleSubString("Redneck Salvager");
			curCard.SetQuote("Whatcha' lookin' at? You think I'm purty?");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 4},
				{Skills.Mechanical, 7},
				{Skills.Technical, 7},
				{Skills.Medical, 4}
			});
			//No link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Sheldon Benson");
			curCard.SetTitleSubString("Wannabe Bad Ass");
			curCard.SetQuote("You got the goods? I got connections.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			//Link gives 2 free spoils cards when Luxury SUV in party
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Clayton Pitt");
			curCard.SetTitleSubString("Conniving Grease Monkey");
			curCard.SetQuote("This here's a BRAND NEW alternator.");
			curCard.SetCarryCapacity(11);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 8},
				{Skills.Technical, 6},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Mechanical Equipment", new MechanicalEquipmentEquipped());
			currentLink.AddRewardOnActivate(new GainMechanical(3));
			currentLink.AddRewardOnActivate(new GainTechnical(1));
			currentLink.AddPunishmentOnDeactivate(new LoseMechanical(3));
			currentLink.AddPunishmentOnDeactivate(new LoseTechnical(1));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Steven Cartwright PhD");
			curCard.SetTitleSubString("Insightful U.S. History Professor");
			curCard.SetQuote("The human experience can be thoroughly understood by examining the past.");
			curCard.SetCarryCapacity(12);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 7},
				{Skills.Technical, 7},
				{Skills.Medical, 4}
			});
			//curCard.AddPassiveGain(Gains.Gain_Prestige, 1);
			currentLink = new Link("Pristine American Flag", new PristineAmericanFlagEquipped());
			currentLink.AddRewardOnActivate(new GainDiplomacy(3));
			currentLink.AddPunishmentOnDeactivate(new LoseDiplomacy(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Joshua Dean");
			curCard.SetTitleSubString("Malevolent Teenager");
			curCard.SetQuote("I'll make them Pay. Check THIS out...");
			curCard.SetCarryCapacity(12);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 7},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Wrist Rocker Slingshot, Flare Gun Pistol, or Sporting Goods", new WristRockerSlingshotOrFlareGunOrSportingGoodsEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Juan Upton");
			curCard.SetTitleSubString("Construction Foreman");
			curCard.SetQuote("Get outta' here. The whole place is rigger.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 8},
				{Skills.Technical, 5},
				{Skills.Medical, 4}
			});
			currentLink = new Link("Sledge Hammer", new SledgeHammerEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddRewardOnActivate(new GainMechanical(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseMechanical(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Randall Davis");
			curCard.SetTitleSubString("Disgruntled Postal Worker");
			curCard.SetQuote("You really don't want to keep pissing me off. I've freaked out on pricks like you for less...");
			curCard.SetCarryCapacity(17);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 4},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 7},
				{Skills.Technical, 6},
				{Skills.Medical, 4}
			});
			currentLink = new Link("Backpack", new BackpackEquipped());
			currentLink.AddRewardOnActivate(new GainCarryCapacity(4));
			currentLink.AddPunishmentOnDeactivate(new LoseCarryCapacity(4));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Dante Slade");
			curCard.SetTitleSubString("Heroic Biker");
			curCard.SetQuote("I used to lead The Highwaymen, but I just wanted to get back on the open road.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 8},
				{Skills.Technical, 6},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Two Wheeled Vehicle in Party", new Any2WheelVehicleInParty());
			currentLink.AddRewardOnActivate(new GainBonusMovement(1));
			currentLink.AddRewardOnActivate(new GainCarryCapacity(6));
			currentLink.AddPunishmentOnDeactivate(new LoseBonusMovement(1));
			currentLink.AddPunishmentOnDeactivate(new LoseCarryCapacity(6));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Augustus Vinventia");
			curCard.SetTitleSubString("Insightful Chaplain");
			curCard.SetQuote("Too late, I uncovered the truth about the Z-666 project. I was cryogenically frozen as the bombs behan to fall.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 9},
				{Skills.Mechanical, 5},
				{Skills.Technical, 7},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Clothing", new ClothingEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Bill Pitcher");
			curCard.SetTitleSubString("Faction Engineer");
			curCard.SetQuote("Change is unavoidable. I ensure it's in our favor.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 7},
				{Skills.Technical, 7},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Laptop Computer, Knife, or Nifty Multi-Tool", new LaptopComputerOrKnifeOrMultitoolEquipped());
			currentLink.AddRewardOnActivate(new GainMechanical(2));
			currentLink.AddRewardOnActivate(new GainTechnical(2));
			currentLink.AddPunishmentOnDeactivate(new LoseMechanical(2));
			currentLink.AddPunishmentOnDeactivate(new LoseTechnical(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Ignatius Eckersley");
			curCard.SetTitleSubString("Self-Righteous Preacher");
			curCard.SetQuote("The end times are upon us. The evil doers must burn. BURN!");
			curCard.SetCarryCapacity(11);
			curCard.SetMaxHp(9);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 3},
				{Skills.Mechanical, 6},
				{Skills.Technical, 8},
				{Skills.Medical, 7}
			});
			currentLink = new Link("Flame Thrower", new FlamethrowerEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(6));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(6));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Buck Liddell");
			curCard.SetTitleSubString("MMA Berserker");
			curCard.SetQuote("I was raised fighting in the gladiator pits. There's no such thing as a fair fight.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 9},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 4},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Melee Weapon", new MeleeWeaponEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Bennie Ocean");
			curCard.SetTitleSubString("Holistic Hippie M.D.");
			curCard.SetQuote("Just relax and trust me, man. I'm a real doctor, man.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 4},
				{Skills.Technical, 5},
				{Skills.Medical, 9}
			});
			//Link doubles medical skill bonuses. May use twice before discarding
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Lt. \"Red\" Naxela");
			curCard.SetTitleSubString("Glowing Navy Hero");
			curCard.SetQuote("It takes two to the chest and one in the head to touch the hearts and minds of your enemy.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 6},
				{Skills.Technical, 7},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Ranged Weapon", new RangedWeaponEquipped());
			currentLink.AddRewardOnActivate(new GainDiplomacy(1));
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseDiplomacy(1));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Evander Stuart");
			curCard.SetTitleSubString("Militia Guardsman");
			curCard.SetQuote("Count me in. I'm way overdue for an adventure.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 6},
				{Skills.Technical, 6},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Assault Rife", new AssaultRifleEquipped());
			currentLink.AddRewardOnActivate(new GainSurvival(1));
			currentLink.AddRewardOnActivate(new GainDiplomacy(2));
			currentLink.AddPunishmentOnDeactivate(new LoseSurvival(1));
			currentLink.AddPunishmentOnDeactivate(new LoseDiplomacy(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Monty Reese");
			curCard.SetTitleSubString("Gamer");
			curCard.SetQuote("Awww... Do I get a saving throw?");
			curCard.SetCarryCapacity(17);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 4},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 7},
				{Skills.Technical, 8},
				{Skills.Medical, 6}
			});
			currentLink = new Link("Melee Weapon", new MeleeWeaponEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Paul Bailey");
			curCard.SetTitleSubString("Bootlegger");
			curCard.SetQuote("This is my shot to make amends for my past. I won't ever fail you.");
			curCard.SetCarryCapacity(12);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 6},
				{Skills.Technical, 6},
				{Skills.Medical, 5}
			});
			//No link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Jon Lonngren");
			curCard.SetTitleSubString("Leader of a Secret Organization");
			curCard.SetQuote("Damn right this will work. We need to move forward with the plan.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 9},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 9},
				{Skills.Mechanical, 5},
				{Skills.Technical, 6},
				{Skills.Medical, 4}
			});
			curCard.SetHasFirstStrike(true);
			currentLink = new Link("Assault Rifle or Submachine Gun", new AssaultRifleOrSubmachineGunEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Patrick Phillips");
			curCard.SetTitleSubString("Social Butterfly");
			curCard.SetQuote("Let's roll.");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 7}
			});
			currentLink = new Link("Espressor Van, Knife, or Sword", new EspressoVanInPartyOrKnifeOrSwordEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddRewardOnActivate(new GainSurvival(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseSurvival(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Sifu Khan");
			curCard.SetTitleSubString("Kung Fu Instructor");
			curCard.SetQuote("You wish to fight me? A harmless old traveler? Then let this be your first lesson.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 9},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 4},
				{Skills.Technical, 4},
				{Skills.Medical, 6}
			});
			currentLink = new Link("Melee Weapon", new MeleeWeaponEquipped());
			currentLink.AddRewardOnActivate(new GainSurvival(1));
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseSurvival(1));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Madison Hall");
			curCard.SetTitleSubString("Self-Centered Business Woman");
			curCard.SetQuote("I'm a survivor. Plain and simple.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 5},
				{Skills.Technical, 8},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Designer Suit or Sunglasses", new DesignerSuitOrSunglassesEquipped());
			currentLink.AddRewardOnActivate(new GainDiplomacy(2));
			currentLink.AddRewardOnActivate(new GainMedical(1));
			currentLink.AddPunishmentOnDeactivate(new LoseDiplomacy(2));
			currentLink.AddPunishmentOnDeactivate(new LoseMedical(1));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Ryan Vincent");
			curCard.SetTitleSubString("Bygone Sports Hero");
			curCard.SetQuote("Yeah, I'm here for the glory. What else the hell is there?");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 5},
				{Skills.Technical, 6},
				{Skills.Medical, 5}
			});
			currentLink = new CumulativeLink("Sporting Goods - Cumulative", new SportingGoodsEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Dickie Bobby");
			curCard.SetTitleSubString("Long-Winded Salvage Mechanic");
			curCard.SetQuote("I always find the best salvage. Just get me in and out of there in one piece. I'll do the rest.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 9},
				{Skills.Technical, 6},
				{Skills.Medical, 5}
			});
			//Link Macho Tow Truck, roll D6, on a 1-4, salvage a vehicle
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Alton Goldwater");
			curCard.SetTitleSubString("Weathered Old Farmer");
			curCard.SetQuote("Without me, you couldn't survive. Seriously.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 6},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			//No link
			//TODO add conditional gain
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Antoine Bordeaux");
			curCard.SetTitleSubString("Renown Vacationing Chef");
			curCard.SetQuote("Have you ever noticed the chef is ALWAYS the last one standing?");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 6},
				{Skills.Technical, 6},
				{Skills.Medical, 6}
			});
			currentLink = new Link("Knife or Sword", new KnifeOrSwordEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Laura Winborn");
			curCard.SetTitleSubString("Faction Recruiter");
			curCard.SetQuote("What can I do to convince you to join us?");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 4},
				{Skills.Technical, 8},
				{Skills.Medical, 6}
			});
			currentLink = new Link("Leather Bull Whip or Top O' The Line Stun Gun", new LeatherBullwhipOrStungun());
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddRewardOnActivate(new GainDiplomacy(1));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseDiplomacy(1));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Erik Stuart");
			curCard.SetTitleSubString("Philosophic Barfly and Smuggler");
			curCard.SetQuote("Don't pretend like you know the odds.");
			curCard.SetCarryCapacity(10);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 6},
				{Skills.Technical, 6},
				{Skills.Medical, 4}
			});
			//No link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Vera Hollis");
			curCard.SetTitleSubString("Renown Computer Programmer");
			curCard.SetQuote("Listen. I've dedicated my life to researching mysterious pre-war tech. I totally got this.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 7},
				{Skills.Technical, 10},
				{Skills.Medical, 6}
			});
			curCard.SetIsMaster(true);
			currentLink = new Link("Technical Equipment", new TechnicalEquipmentEquipped());
			currentLink.AddRewardOnActivate(new GainTechnical(2));
			currentLink.AddRewardOnActivate(new GainMechanical(1));
			currentLink.AddPunishmentOnDeactivate(new LoseTechnical(2));
			currentLink.AddPunishmentOnDeactivate(new LoseMechanical(1));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Meifeung Hsu");
			curCard.SetTitleSubString("CPU Guru");
			curCard.SetQuote("Cover me. I almost have root.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 4},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 7},
				{Skills.Technical, 9},
				{Skills.Medical, 4}
			});
			currentLink = new Link("Laptop Computer", new LaptopComputerEquipped());
			currentLink.AddRewardOnActivate(new GainMechanical(2));
			currentLink.AddRewardOnActivate(new GainTechnical(2));
			currentLink.AddPunishmentOnDeactivate(new LoseMechanical(2));
			currentLink.AddPunishmentOnDeactivate(new LoseTechnical(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Cam Toretto");
			curCard.SetTitleSubString("Wheelman");
			curCard.SetQuote("Hell no! Ain't no one gonna' stop us.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 4},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 8},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Any 4 Wheeled Vehicle in Party", new Any4WheelVehicleInParty());
			currentLink.AddRewardOnActivate(new GainBonusMovement(2));
			currentLink.AddPunishmentOnDeactivate(new LoseBonusMovement(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Cassie Reardon");
			curCard.SetTitleSubString("Adventurous Artist");
			curCard.SetQuote("Does this mean I don't have to pay off my student loans?");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 5},
				{Skills.Technical, 7},
				{Skills.Medical, 7}
			});
			//No link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Kennedy Abbot");
			curCard.SetTitleSubString("Security Analyst");
			curCard.SetQuote("Don't get in my way. I'm here to promote our faction's agenda by any means necessary.");
			curCard.SetCarryCapacity(10);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 10},
				{Skills.Mechanical, 6},
				{Skills.Technical, 8},
				{Skills.Medical, 5}
			});
			curCard.SetIsMaster(true);
			currentLink = new Link("Alcohol", new AlcoholEquipped());
			currentLink.AddRewardOnActivate(new GainDiplomacy(3));
			currentLink.AddPunishmentOnDeactivate(new LoseDiplomacy(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Booker Gray");
			curCard.SetTitleSubString("Weapons Expert");
			curCard.SetQuote("Sonny, I may be ornery, but there ain't a DAMN thing I don't know about weapons.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 10},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 8},
				{Skills.Technical, 6},
				{Skills.Medical, 4}
			});
			curCard.SetIsMaster(true);
			currentLink = new Link("Ranged Weapon", new RangedWeaponEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddRewardOnActivate(new GainDiplomacy(2));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseDiplomacy(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Mack Luther");
			curCard.SetTitleSubString("Soldier of Fortune");
			curCard.SetQuote("Frickin' amateurs. I don't die that easily.");
			curCard.SetCarryCapacity(17);
			curCard.SetMaxHp(9);
			curCard.SetPsychResistance(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 9},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 4},
				{Skills.Technical, 6},
				{Skills.Medical, 7}
			});
			//curCard.AddPassiveGain(Gains.Gain_Armor, 1);
			currentLink = new Link("Heavy Weapons", new HeavyWeaponEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(1));
			currentLink.AddRewardOnActivate(new GainSurvival(2));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(1));
			currentLink.AddPunishmentOnDeactivate(new LoseSurvival(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);

			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Dominic Sinclair");
			curCard.SetTitleSubString("Herculean Bouncer");
			curCard.SetQuote("(Raising an eyebrow) Seriously? Don't even think about it, tool bag.");
			curCard.SetCarryCapacity(17);
			curCard.SetMaxHp(9);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Melee Weapons", new MeleeWeaponEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Michael Conrad");
			curCard.SetTitleSubString("Veteran of Three Wars");
			curCard.SetQuote("I've seen war. And I am a survivor.");
			curCard.SetCarryCapacity(17);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 4},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 6}
			});
			currentLink = new Link("Heavy Weapons", new HeavyWeaponEquipped());
			currentLink.AddRewardOnActivate(new GainSurvival(3));
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseSurvival(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Nina Saxon");
			curCard.SetTitleSubString("Catty Veterinarian");
			curCard.SetQuote("My passion is studying creatures in their natural environment.");
			curCard.SetCarryCapacity(11);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 4},
				{Skills.Technical, 8},
				{Skills.Medical, 8}
			});
			//Link double medical bonuses. Use medical cards twice before discarding
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Lorenzo Escobar");
			curCard.SetTitleSubString("Famous Scientist");
			curCard.SetQuote("I'm a scientist. I solve problems.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 5},
				{Skills.Technical, 7},
				{Skills.Medical, 9}
			});
			//Link may use medical equipment twice before discarding
			//TODO add passive gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Gabriel Card");
			curCard.SetTitleSubString("Daredevil Stunt Driver");
			curCard.SetQuote("I've got a reputation with the caravan guilds for running interference.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 8},
				{Skills.Technical, 5},
				{Skills.Medical, 6}
			});
			//Link motorized vehicle. After each round of pvp, gain +1 flight or deal 1d6 physical damage
			//curCard.AddPassiveGain(Gains.Gain_Movement, 1);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Gysgt Ryan Defoe");
			curCard.SetTitleSubString("Militia Drill Instructor");
			curCard.SetQuote("I've seen plenty of combat. You're gonna' get us all killed. START LISTENING!");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Assault Rifle", new AssaultRifleEquipped());
			currentLink.AddRewardOnActivate(new GainDiplomacy(1));
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseDiplomacy(1));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Lee Watts");
			curCard.SetTitleSubString("Sheriff");
			curCard.SetQuote("We need to bring law and order to the chaos out there. The people deserve justice.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 4},
				{Skills.Technical, 5},
				{Skills.Medical, 7}
			});
			currentLink = new Link("Blunt Weapon or Handgun", new BluntWeaponOrHandgunEquipped());
			currentLink.AddRewardOnActivate(new GainSurvival(2));
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseSurvival(2));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			curCard.SetCharacterLink(currentLink);
			//curCard.AddPassiveGain(Gains.Gain_Prestige, 1);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Warren Ripley");
			curCard.SetTitleSubString("Jack of All Trades");
			curCard.SetQuote("I'm a resourceful jack of all trades.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 7},
				{Skills.Technical, 7},
				{Skills.Medical, 7}
			});
			currentLink = new CumulativeLink("Top Secret Weapons - Cumulative", new TopSecretWeaponEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddRewardOnActivate(new GainPrestige(1));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LosePrestige(1));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Leeland Voorhees");
			curCard.SetTitleSubString("Extreme Sports Enthusiast");
			curCard.SetQuote("If there's a way out of here, I'll find it.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 6},
				{Skills.Technical, 5},
				{Skills.Medical, 7}
			});
			currentLink = new Link("Camping Gear", new CampingGearEquipped());
			currentLink.AddRewardOnActivate(new GainSurvival(2));
			currentLink.AddRewardOnActivate(new GainMedical(1));
			currentLink.AddPunishmentOnDeactivate(new LoseSurvival(2));
			currentLink.AddPunishmentOnDeactivate(new LoseMedical(1));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Samsara Chakroborty");
			curCard.SetTitleSubString("Rogue Cabbie");
			curCard.SetQuote("Just don't ever underestimate me.");
			curCard.SetCarryCapacity(11);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 5},
				{Skills.Technical, 7},
				{Skills.Medical, 5}
			});
			currentLink = new Link("Handgun", new HandgunEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			curCard.SetCharacterLink(currentLink);
			//curCard.AddPassiveGain(Gains.Gain_Movement, 1);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Chance Perry");
			curCard.SetTitleSubString("Traumatized Drifter");
			curCard.SetQuote("Yeah, I know the place well. I'll make sure we get in quietly and hit the jackpot.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 6},
				{Skills.Technical, 6},
				{Skills.Medical, 6}
			});
			currentLink = new Link("Melee Weapons", new MeleeWeaponEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(2));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(2));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Beatrice Kendall");
			curCard.SetTitleSubString("Pessimistic Nurse");
			curCard.SetQuote("This is REALLY going to hurt.");
			curCard.SetCarryCapacity(10);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 5},
				{Skills.Technical, 6},
				{Skills.Medical, 8}
			});
			//Link medical equipment. Double bonuses and use twice before discarding
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Sierra Storm");
			curCard.SetTitleSubString("Wandering Environmentalist");
			curCard.SetQuote("Mother Earth is just reclaiming what's hers.");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 9},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 7}
			});
			currentLink = new Link("Bow", new BowEquipped());
			currentLink.AddRewardOnActivate(new GainCombat(3));
			currentLink.AddPunishmentOnDeactivate(new LoseCombat(3));
			curCard.SetCharacterLink(currentLink);
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);
		}

		public List<CharacterCard> GetCharacterCards()
		{
			return CharacterCards;
		}
	}

}