using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class DefaultSpoilsCards
	{
		private Dictionary<string, int> multiples = new Dictionary<string, int>()
		{
		{"Basic Med Kit", 2},
		{"Swat Body Armor", 2},
		{"First Aid Kit", 2}
		};
		private List<SpoilsCard> SpoilsCardsDeck;

		public DefaultSpoilsCards()
		{
			//Initialize the lists for the cards
			SpoilsCardsDeck = new List<SpoilsCard>();

			//Add the cards to the list
			SpoilsCard curCard;
			int curID = 0;

			Debug.Log("Instantiating spoils cards...");


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("A Case of the Finest Champagne");
			curCard.SetSpoilsTypes(SpoilsTypes.Stowable, SpoilsTypes.Alcohol, SpoilsTypes.Equipment);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Diplomacy, 3},
				{Skills.Medical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard); //Add the card to the list of all cards


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("6 Armored War Horses");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Horse);
			curCard.SetCarryWeight(12);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 2},
				{Skills.Diplomacy, 2}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(1));
			//Todo reward -- all hexes cost 1 movement
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(1));
			//Todo punishment -- all hexes cost normal movements
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Fernando the Chauffer");
			curCard.SetSpoilsTypes(SpoilsTypes.Ally, SpoilsTypes.Vehicle_Equipment, SpoilsTypes.PayToKeep, SpoilsTypes.CannotBeSold); //He must be equipped to a vehicle
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2},
				{Skills.Survival, 1},
				{Skills.Diplomacy, 3},
				{Skills.Mechanical, 4},
				{Skills.Medical, 2}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(2));
			curCard.AddRewardWhenEquipped(new GainCarryCapacity(4));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(2));
			curCard.AddPunishmentWhenUnequipped(new LoseCarryCapacity(4));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Portable Generator");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle_Equipment);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(16);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Survival, 2},
				{Skills.Mechanical, 3},
				{Skills.Technical, 5}
			});
			curCard.AddPunishmentWhenEquipped(new LoseBonusMovement(1));
			curCard.AddRewardWhenUnequipped(new GainBonusMovement(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Genuine Sock Monkey Puppet");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Diplomacy, 1},
				{Skills.Medical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Matching Baja Buggies");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(8);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 3},
				{Skills.Diplomacy, 1},
				{Skills.Mechanical, 1},
				{Skills.Medical, 1}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(2));
			//Todo reward -- all hexes cost 1 movement
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(2));
			//Todo punishment -- all hexes cost normal movements
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("5.56mm Military Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7}
			});

			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Silenced 9mm Submachine Gun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Submachine_Gun);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5}
			});
			//todo reward on add -- gain first strike on character
			//todo punishment on remove -- remove first strike on character
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);



			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Mercenary Armor");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Survival, 1},
				{Skills.Diplomacy, 1}
			});
			//todo reward on add -- gain one armor
			//todo punishment on remove -- lose one armor
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Semi Truck");
			curCard.SetTitleSubString("With Trailer");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(20);
			curCard.SetSellValue(26);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 2},
				{Skills.Diplomacy, 2},
				{Skills.Mechanical, 1},
				{Skills.Medical, 3}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(1));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Conscription");
			curCard.SetSpoilsTypes(SpoilsTypes.Event);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				//No skills since it's an event
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Survival Knife");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Knife);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2},
				{Skills.Survival, 2},
				{Skills.Medical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("9mm Submachine Gun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Submachine_Gun);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Computer Technical Manual");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Mechanical, 2},
				{Skills.Technical, 4}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Cordless Power Drill");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Mechanical, 4},
				{Skills.Technical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Arnold Schwartz's");
			curCard.SetTitleSubString("Kronan the Barbarian Sword");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Sword, SpoilsTypes.Relic);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Medical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Pre-War Diaster Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(11);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Survival, 2},
				{Skills.Diplomacy, 2},
				{Skills.Mechanical, 2},
				{Skills.Technical, 2},
				{Skills.Medical, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Biomedical Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(15);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Diplomacy, 1},
				{Skills.Technical, 4},
				{Skills.Medical, 4}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Crate of Medical Supplies");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(7);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Diplomacy, 2},
				{Skills.Medical, 5}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Extra Rusty Cleaver");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Wrist Rocker Slingshot");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Top o' the Line Stun Gun");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Technical, 1},
				{Skills.Medical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Sniper Scope Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Permenant);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2},
				{Skills.Survival, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Snub Nose .357 Revolver");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Sawed Off Double Barreled");
			curCard.SetTitleSubString("12 Gauge Breech Loading Shotgun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Melee_Weapon, SpoilsTypes.Shotgun);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Indestructible Tennis Racquet");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Sporting_Goods);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(1);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Diplomacy, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Armored Humvee");
			curCard.SetTitleSubString("With .50 Caliber MG Turret");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(12);
			curCard.SetSellValue(29);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 9},
				{Skills.Survival, 1},
				{Skills.Diplomacy, 2},
				{Skills.Mechanical, 1},
				{Skills.Medical, 2}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(2));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(2));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("The Motherload");
			curCard.SetTitleSubString("You have discovered a secret room!");
			curCard.SetSpoilsTypes(SpoilsTypes.Event);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				//No skills since it's an event
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Retro Mini Camper");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle_Equipment);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3},
				{Skills.Survival, 3},
				{Skills.Diplomacy, 3},
				{Skills.Mechanical, 3},
				{Skills.Medical, 3}
			});
			curCard.AddPunishmentWhenEquipped(new LoseBonusMovement(1));
			curCard.AddRewardWhenEquipped(new GainCarryCapacity(8));
			curCard.AddRewardWhenUnequipped(new GainBonusMovement(1));
			curCard.AddPunishmentWhenUnequipped(new LoseCarryCapacity(8));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Chris the Trophy Spouse");
			curCard.SetSpoilsTypes(SpoilsTypes.Ally, SpoilsTypes.PayToKeep);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Survival, 1},
				{Skills.Diplomacy, 3},
				{Skills.Medical, 3}
			});
			curCard.AddRewardWhenEquipped(new GainCarryCapacity(4));
			curCard.AddRewardWhenEquipped(new GainPsychResistance(1));
			curCard.AddRewardWhenEquipped(new GainPrestige(1));
			curCard.AddPunishmentWhenUnequipped(new LoseCarryCapacity(4));
			curCard.AddPunishmentWhenUnequipped(new LosePsychResistance(1));
			curCard.AddPunishmentWhenUnequipped(new LosePrestige(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Alien Plasma Pistol");
			curCard.SetSpoilsTypes(SpoilsTypes.Top_Secret, SpoilsTypes.Ranged_Weapon, SpoilsTypes.Relic);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(19);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Diplomacy, 2},
				{Skills.Technical, 3}
			});
			curCard.AddRewardWhenEquipped(new GainPrestige(1));
			curCard.AddPunishmentWhenUnequipped(new LosePrestige(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Sledge Hammer");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Blunt);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3},
				{Skills.Mechanical, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Combat Welding & Cutting Torch");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Mechanical, 2},
				{Skills.Technical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Designer Biker Leathers");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor, SpoilsTypes.Clothing);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				//No base skills
			});
			//TODO reward when equipped - gain 1 armor
			//TODO punishment when unequipped - lose 1 armor
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Dork Squad");
			curCard.SetTitleSubString("Computer Repair Car");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(10);
			curCard.SetSellValue(17);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Survival, 1},
				{Skills.Diplomacy, 1},
				{Skills.Mechanical, 3},
				{Skills.Technical, 5},
				{Skills.Medical, 1}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(2));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(2));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Heavy Rocket Launcher");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Heavy, SpoilsTypes.Relic);
			curCard.SetCarryWeight(8);
			curCard.SetSellValue(21);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 10}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Case of Excellent Whiskey");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Alcohol, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Diplomacy, 3},
				{Skills.Medical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Experimental Laser Rifle");
			curCard.SetTitleSubString("Top Secret Weapon");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Top_Secret, SpoilsTypes.Heavy);
			curCard.SetCarryWeight(7);
			curCard.SetSellValue(24);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 1},
				{Skills.Diplomacy, 2},
				{Skills.Mechanical, 1},
				{Skills.Technical, 2},
				{Skills.Medical, 1}
			});
			curCard.AddRewardWhenEquipped(new GainPrestige(1));
			curCard.AddPunishmentWhenUnequipped(new LosePrestige(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("9mm Semi Automatic Pistol");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("7.62mm Assault Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Masamune Crafted Katana");
			curCard.SetQuote("A 14th century masterpiece created by Japan's greatest sword maker.");
			curCard.SetSpoilsTypes(SpoilsTypes.Relic, SpoilsTypes.Melee_Weapon, SpoilsTypes.Sword);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(16);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 2},
				{Skills.Diplomacy, 1}
			});
			//TODO reward first strike
			curCard.AddRewardWhenEquipped(new GainPsychResistance(1));
			curCard.AddPunishmentWhenUnequipped(new LosePsychResistance(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Basic Med Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Medical, 3}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Special Forces Manual");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Survival, 3},
				{Skills.Medical, 1}
			});
			curCard.AddRewardWhenEquipped(new GainPsychResistance(1));
			curCard.AddPunishmentWhenUnequipped(new LosePsychResistance(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Unlimited Stash of Duct Tape");
			curCard.SetSpoilsTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Mechanical);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Mechanical, 3},
				{Skills.Technical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Practically New Ambulance");
			curCard.SetTitleSubString("With Obnoxiously Loud Sirens");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Relic, SpoilsTypes.Four_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(14);
			curCard.SetSellValue(29);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3},
				{Skills.Survival, 2},
				{Skills.Diplomacy, 2},
				{Skills.Technical, 2},
				{Skills.Medical, 9}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(3));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(3));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Five Machetes");
			curCard.SetSpoilsTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Melee_Weapon, SpoilsTypes.Sword);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2},
				{Skills.Survival, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Bars of Gold");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(10);
			curCard.SetSellValue(25);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Diplomacy, 4}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Fred Rodgers' Sweater");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor, SpoilsTypes.Clothing, SpoilsTypes.Relic);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(16);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Diplomacy, 2},
				{Skills.Technical, 1},
				{Skills.Medical, 1}
			});
			//TODO gain 1 armor when equipped
			//todo lose 1 armor when unequipped
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Water Purification Canteens");
			curCard.SetSpoilsTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Medical, SpoilsTypes.Camping_Gear);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Survival, 1},
				{Skills.Medical, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Grenades");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Heavy);
			curCard.SetCarryWeight(7);
			curCard.SetSellValue(16);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 9}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Police Interceptor");
			curCard.SetTitleSubString("With Hypnotic Lights");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(10);
			curCard.SetSellValue(19);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Diplomacy, 4},
				{Skills.Medical, 3}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(3));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(3));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Finders Keepers");
			curCard.SetQuote("You have found the item of your dreams...");
			curCard.SetSpoilsTypes(SpoilsTypes.Event);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				//No base skills because event
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Swat Body Armor");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor, SpoilsTypes.Clothing);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Diplomacy, 1}
			});
			//TODO reward add 1 armor
			//todo punish lose 1 armor
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("9mm Pistol");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Paramedic Medical Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Diplomacy, 2},
				{Skills.Medical, 5}
			});
			curCard.SetIsStartingCard(true);
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("First Aid Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Diplomacy, 1},
				{Skills.Medical, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Classic All American");
			curCard.SetTitleSubString("Performance Muscle Car");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(10);
			curCard.SetSellValue(19);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3},
				{Skills.Diplomacy, 3},
				{Skills.Mechanical, 2},
				{Skills.Medical, 1}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(4));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(4));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Macho Tow Truck");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Six_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(13);
			curCard.SetSellValue(19);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Diplomacy, 3},
				{Skills.Mechanical, 5},
				{Skills.Technical, 3}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(2));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(2));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Five Classic .45 Pistols");
			curCard.SetSpoilsTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(30);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Contact Truck");
			curCard.SetTitleSubString("With Matching Yellow Hardhats");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(12);
			curCard.SetSellValue(18);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3},
				{Skills.Survival, 1},
				{Skills.Diplomacy, 2},
				{Skills.Mechanical, 4},
				{Skills.Technical, 4},
				{Skills.Medical, 1}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(2));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(2));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Jackpot");
			curCard.SetSpoilsTypes(SpoilsTypes.Event);
			curCard.SetQuote("You have stumbled upon a concealed compartment!");
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				//No base skills because event
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Heavy Armor Plating");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle_Equipment, SpoilsTypes.Permenant);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3}
			});
			curCard.AddPunishmentWhenEquipped(new LoseBonusMovement(1));
			curCard.AddRewardWhenUnequipped(new GainBonusMovement(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("5 Matching Pink Mopeds");
			curCard.SetQuote("At least the thieves had a sense of humor...");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Jinxed, SpoilsTypes.Two_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(10);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Survival, 1},
				{Skills.Diplomacy, 1},
				{Skills.Mechanical, 1},
				{Skills.Technical, 1},
				{Skills.Medical, 1}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(1));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Badass Socket Set");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Mechanical, 3},
				{Skills.Technical, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Jugs O'Moonshine");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Alcohol, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Survival, 1},
				{Skills.Diplomacy, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Militia Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7}
			});
			curCard.SetIsStartingCard(true);
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("High Tech Utility Belt");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Backpack);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Survival, 2},
				{Skills.Mechanical, 2},
				{Skills.Technical, 2},
				{Skills.Medical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("5.56mm Assault Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Patton");
			curCard.SetSpoilsTypes(SpoilsTypes.Ally);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3},
				{Skills.Survival, 1}
			});
			curCard.AddRewardWhenEquipped(new GainPsychResistance(1));
			curCard.AddRewardWhenEquipped(new GainCarryCapacity(2));
			curCard.AddPunishmentWhenUnequipped(new LosePsychResistance(1));
			curCard.AddPunishmentWhenUnequipped(new LoseCarryCapacity(2));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Compound Hunting Bow");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Bow);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3},
				{Skills.Survival, 2}
			});
			curCard.SetIsStartingCard(true);
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Classic .45 Pistol");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("William H Bonnie's");
			curCard.SetTitleSubString("Matching .45 Revolvers");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun, SpoilsTypes.Relic);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(20);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 3},
				{Skills.Diplomacy, 2}
			});
			curCard.AddRewardWhenEquipped(new GainPsychResistance(1));
			curCard.AddPunishmentWhenUnequipped(new LosePsychResistance(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Cheap Mountain Bikes");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Two_Wheeled);
			curCard.SetCarryWeight(10);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2},
				{Skills.Survival, 2},
				{Skills.Diplomacy, 1},
				{Skills.Mechanical, 1},
				{Skills.Medical, 1}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(1));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Ram Plate");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle_Equipment, SpoilsTypes.Permenant);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3}
			});
			curCard.AddPunishmentWhenEquipped(new LoseBonusMovement(1));
			curCard.AddRewardWhenEquipped(new GainBonusMovement(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Espresso Van");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(10);
			curCard.SetSellValue(23);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 3},
				{Skills.Diplomacy, 4},
				{Skills.Mechanical, 1},
				{Skills.Technical, 1},
				{Skills.Medical, 1}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(4));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(4));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Experimental Battle Suit");
			curCard.SetTitleSubString("Top Secret Weapon");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor, SpoilsTypes.Relic);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(23);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 2},
				{Skills.Diplomacy, 1},
				{Skills.Mechanical, 1},
				{Skills.Technical, 2},
				{Skills.Medical, 1}
			});
			curCard.AddRewardWhenEquipped(new GainPrestige(1));
			//TODO gain 2 armor when equipped
			curCard.AddPunishmentWhenUnequipped(new LosePrestige(1));
			//TODO lose 2 armor when unequipped
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard(".45 Semi Automatic Pistol");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Expired Pre-War Library Card");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2},
				{Skills.Survival, 2},
				{Skills.Diplomacy, 2},
				{Skills.Mechanical, 2},
				{Skills.Technical, 2},
				{Skills.Medical, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("The President's Football");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Technical, SpoilsTypes.Relic);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(20);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Survival, 1},
				{Skills.Diplomacy, 3},
				{Skills.Mechanical, 2},
				{Skills.Technical, 4},
				{Skills.Medical, 1}
			});
			curCard.AddRewardWhenEquipped(new GainPrestige(1));
			curCard.AddPunishmentWhenUnequipped(new LosePrestige(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Titanium Softball Bat");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Blunt, SpoilsTypes.Sporting_Goods);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard(".50 Caliber Sniper Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Heavy, SpoilsTypes.Relic);
			curCard.SetCarryWeight(6);
			curCard.SetSellValue(22);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 2},
				{Skills.Diplomacy, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Soldering Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Technical, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Mechanical, 2},
				{Skills.Technical, 3}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Lock Pick Guide and Tools");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Mechanical, 2},
				{Skills.Technical, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Lead Filled Kempo Gloves");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Fist);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Scary Hockey Mask");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Relic);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2}
			});
			//TODO reward when equipped -- gain 1 HP stat
			//TODO punishment when removed -- lose 1 HP stat
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Firefighter's Axe");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Axe);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3},
				{Skills.Survival, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("68mm Advanced Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(15);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 1}
			});
			curCard.SetIsStartingCard(true);
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Elite Camping Backpack");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Backpack, SpoilsTypes.Camping_Gear);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Survival, 2},
				{Skills.Medical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Flare Gun Pistol");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Survival, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Vendetta Daggers");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Knife, SpoilsTypes.Relic);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(13);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 4}
			});
			curCard.SetIsStartingCard(true);
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Dear Old Ma's Repair Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Survival, 1},
				{Skills.Mechanical, 2},
				{Skills.Technical, 2},
				{Skills.Medical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Ultimate Set of Tools");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(8);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Mechanical, 5},
				{Skills.Technical, 3}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("A History of World Diplomacy");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Diplomacy, 4}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard(".223 Sniper Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Rifle);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 2}
			});
			//First strike when equipped
			//lose first strike when unequipped
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Trunk of Unlimited Disguises");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Diplomacy, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Fallen Land Board Game");
			curCard.SetQuote("A strange pre-war board game about the apocalypse...");
			curCard.SetSpoilsTypes(SpoilsTypes.Stowable);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(13);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				//No base skills
			});
			curCard.AddRewardWhenEquipped(new GainPrestige(2));
			curCard.AddPunishmentWhenUnequipped(new LosePrestige(2));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Blower or Supercharger");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle_Equipment, SpoilsTypes.Permenant);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(1));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("The War Wagon");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Relic, SpoilsTypes.Six_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(16);
			curCard.SetSellValue(40);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 10},
				{Skills.Survival, 3},
				{Skills.Diplomacy, 4},
				{Skills.Mechanical, 3},
				{Skills.Technical, 2},
				{Skills.Medical, 4}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(2));
			curCard.AddRewardWhenEquipped(new GainPrestige(2));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(2));
			curCard.AddPunishmentWhenUnequipped(new LosePrestige(2));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard(".22 Small Bore Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Rifle);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2},
				{Skills.Survival, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Lumberjack Axe");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Axe);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Nifty Multi-Tool");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical, SpoilsTypes.Melee_Weapon);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Mechanical, 2},
				{Skills.Technical, 1},
				{Skills.Medical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Vintage .45 Submachine Gun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Submachine_Gun);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(13);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Brass Knuckles");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Fist);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Luxurious Designer Suit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Clothing);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Diplomacy, 5}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Heavy Duty Flashlight");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Blunt, SpoilsTypes.Melee_Weapon);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Survival, 2},
				{Skills.Mechanical, 2},
				{Skills.Technical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Combat Medic Satchel");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Diplomacy, 2},
				{Skills.Medical, 7}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Ultimate Laptop");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Technical);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(18);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1},
				{Skills.Survival, 1},
				{Skills.Diplomacy, 1},
				{Skills.Mechanical, 3},
				{Skills.Technical, 5},
				{Skills.Medical, 3}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(1));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("12 Guage Pump Shotgun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Shotgun);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Rocket Launcher");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Heavy, SpoilsTypes.Relic);
			curCard.SetCarryWeight(7);
			curCard.SetSellValue(18);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 9}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Camping Gear");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Camping_Gear, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Survival, 3},
				{Skills.Medical, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Ol' Rusty");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2},
				{Skills.Survival, 2},
				{Skills.Diplomacy, 1},
				{Skills.Mechanical, 2},
				{Skills.Technical, 1},
				{Skills.Medical, 1}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(1));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Chopper and Pilot");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Zero_Wheeled, SpoilsTypes.PayToKeep);
			curCard.SetCarryWeight(16);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 3},
				{Skills.Diplomacy, 3},
				{Skills.Mechanical, 3},
				{Skills.Technical, 3},
				{Skills.Medical, 3}
			});
			//Gain all hexes cost 1
			curCard.AddRewardWhenEquipped(new GainBonusMovement(8));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(8));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Industrial Chainsaw");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(11);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 2},
				{Skills.Mechanical, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Gyrocopter");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Relic, SpoilsTypes.Zero_Wheeled); //May not be a zero wheel vehicle?
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(25);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2},
				{Skills.Survival, 1},
				{Skills.Mechanical, 4}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(1));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Nifty Chemistry Set");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Technical, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Technical, 4},
				{Skills.Medical, 3}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Luxury SUV");
			curCard.SetTitleSubString("With Spinner Rims and Hydraulics");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(12);
			curCard.SetSellValue(19);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 2},
				{Skills.Diplomacy, 1},
				{Skills.Mechanical, 1},
				{Skills.Medical, 3}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(2));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(2));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Geiger Counter");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(9);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Technical, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Cache of Military Body Armor");
			curCard.SetSpoilsTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Armor);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(25);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2},
				{Skills.Diplomacy, 2}
			});
			//add 1 armor
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Enigma Van");
			curCard.SetTitleSubString("With Custom 60's Paint Job");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Relic, SpoilsTypes.Four_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(20);
			curCard.SetSellValue(24);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3},
				{Skills.Survival, 3},
				{Skills.Diplomacy, 1},
				{Skills.Mechanical, 3},
				{Skills.Technical, 3},
				{Skills.Medical, 2}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(2));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(2));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Pro Fishing Gear & Tackle");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Camping_Gear, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Survival, 3}
			});
			curCard.AddRewardWhenEquipped(new GainPsychResistance(1));
			curCard.AddPunishmentWhenUnequipped(new LosePsychResistance(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("6 Fast Horses");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Horse);
			curCard.SetCarryWeight(14);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3},
				{Skills.Survival, 3},
				{Skills.Diplomacy, 1},
				{Skills.Medical, 1}
			});
			//all hexes cost 1 when equipped
			curCard.AddRewardWhenEquipped(new GainBonusMovement(2));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(2));
			curCard.SetIsStartingCard(true);
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Henry's Guide to Repairs");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Mechanical, 3},
				{Skills.Technical, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Roadkill Cookbook");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Survival, 3},
				{Skills.Diplomacy, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("High Tech Body Armor");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(15);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3},
				{Skills.Diplomacy, 2}
			});
			//Gain two armor when equipped
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Larry's Guide to Civil War Surgery");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Medical, 3}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Flame Thrower");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Melee_Weapon, SpoilsTypes.Heavy_Weapon, SpoilsTypes.Relic);
			curCard.SetCarryWeight(7);
			curCard.SetSellValue(24);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 10}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("4.6mm Submachine Gun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Submachine_Gun);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(17);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Radiation and Biohazard Suits");
			curCard.SetSpoilsTypes(SpoilsTypes.Party_Equipment);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, -1},
				{Skills.Survival, 1}
			});
			curCard.AddPunishmentWhenEquipped(new LoseBonusMovement(1));
			curCard.AddRewardWhenUnequipped(new GainBonusMovement(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard(".44 Semi Automatic Pistol");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("High Tech Crossbow");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Bow);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 3},
				{Skills.Survival, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Autographed Bat");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Blunt, SpoilsTypes.Sporting_Goods, SpoilsTypes.Relic);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(15);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Diplomacy, 1}
			});
			curCard.AddRewardWhenEquipped(new GainPsychResistance(1));
			curCard.AddPunishmentWhenUnequipped(new LosePsychResistance(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("10 Gauge Pump Shotgun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Shotgun);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 2}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Leather Bull Whip");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Blunt);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 1}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("5.56mm Bolt Action Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Rifle);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(15);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 1}
			});

			//first strike when equipped
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("12 Gauge Bullpup Shotgun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Shotgun);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5}
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("The Duke's Cowboy Outfit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Clothing, SpoilsTypes.Relic);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2},
				{Skills.Survival, 4},
				{Skills.Diplomacy, 1}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(1));
			curCard.AddRewardWhenEquipped(new GainPsychResistance(1));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(1));
			curCard.AddPunishmentWhenUnequipped(new LosePsychResistance(1));
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("American Iron Custom Choppers");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Two_Wheeled, SpoilsTypes.Motorized);
			curCard.SetCarryWeight(12);
			curCard.SetSellValue(13);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2},
				{Skills.Survival, 1},
				{Skills.Diplomacy, 1},
				{Skills.Mechanical, 3},
				{Skills.Medical, 1}
			});
			curCard.AddRewardWhenEquipped(new GainBonusMovement(2));
			curCard.AddPunishmentWhenUnequipped(new LoseBonusMovement(2));
			curCard.SetIsStartingCard(true);
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);






			//Now that all cards are added, let's ID them all and account for duplicates that need to be added
			int count = SpoilsCardsDeck.Count;
			for (int i = 0; i < count; i++)
			{
				SpoilsCardsDeck[i].SetId(i); //ID current one

				//See if this card is a duplicate
				if (multiples.ContainsKey(SpoilsCardsDeck[i].GetTitle()))
				{ //If the name of this card is a name in the multiples dictionary
					for (int j = 1; j < multiples[SpoilsCardsDeck[i].GetTitle()]; j++)
					{ //For the number of multiples to add
						SpoilsCard newCard = SpoilsCardsDeck[i].DeepCopy();
						SpoilsCardsDeck.Add(newCard); //add the multiple
													  //Debug.Log("Adding multiple for " + spoilsCards[i].getTitle());
					}
				}
			}
		}


		public List<SpoilsCard> GetSpoilsCards()
		{
			return SpoilsCardsDeck;
		}
	}
}