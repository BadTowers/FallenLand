using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;
using System.Collections.Generic;

namespace Tests
{
	public class HumanPlayerTests
	{
		private HumanPlayer HumanPlayerInstance;
		private const int CHARACTER_1_INDEX = 0;
		private const int CHARACTER_2_INDEX = 1;
		private const int CHARACTER_3_INDEX = 2;
		private const int CHARACTER_4_INDEX = 3;
		private const int CHARACTER_5_INDEX = 4;

		[SetUp]
		public void Setup()
		{
			HumanPlayerInstance = new HumanPlayer(new Faction("Faction name", new Coordinates(1, 2)), 10);
		}

		[TearDown]
		public void Teardown()
		{
			HumanPlayerInstance = null;
		}

		[UnityTest]
		public IEnumerator TestConstructors()
		{
			Assert.IsNotNull(HumanPlayerInstance.GetPlayerFaction());
			Assert.AreEqual(10, HumanPlayerInstance.GetSalvageAmount());
			Assert.IsNotNull(HumanPlayerInstance.GetAuctionHouseCards());
			Assert.IsNotNull(HumanPlayerInstance.GetActionCards());
			Assert.IsNotNull(HumanPlayerInstance.GetTownRoster());
			Assert.IsNotNull(HumanPlayerInstance.GetActiveCharacters());
			Assert.IsNotNull(HumanPlayerInstance.GetTownTechs());

			HumanPlayer humanPlayer1 = new HumanPlayer(null, -5);
			Assert.IsNotNull(humanPlayer1.GetPlayerFaction());
			Assert.AreEqual(0, humanPlayer1.GetSalvageAmount());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSpoilsCardsInAuctionHouse()
		{
			SpoilsCard testCard1 = new SpoilsCard("test card");
			SpoilsCard testCard2 = new SpoilsCard("test card 2");
			SpoilsCard testCard3 = new SpoilsCard("3est card 3");

			//Adding
			HumanPlayerInstance.AddSpoilsCardToAuctionHouse(testCard1);
			Assert.AreEqual(1, HumanPlayerInstance.GetAuctionHouseCards().Count);
			HumanPlayerInstance.AddSpoilsCardToAuctionHouse(testCard2);
			Assert.AreEqual(2, HumanPlayerInstance.GetAuctionHouseCards().Count);
			HumanPlayerInstance.AddSpoilsCardToAuctionHouse(null);
			Assert.AreEqual(2, HumanPlayerInstance.GetAuctionHouseCards().Count);

			//Removing
			HumanPlayerInstance.RemoveSpoilsCardFromAuctionHouse(testCard1);
			Assert.AreEqual(1, HumanPlayerInstance.GetAuctionHouseCards().Count);
			HumanPlayerInstance.RemoveSpoilsCardFromAuctionHouse(null);
			Assert.AreEqual(1, HumanPlayerInstance.GetAuctionHouseCards().Count);
			HumanPlayerInstance.RemoveSpoilsCardFromAuctionHouse(testCard3);
			Assert.AreEqual(1, HumanPlayerInstance.GetAuctionHouseCards().Count);
			HumanPlayerInstance.RemoveSpoilsCardFromAuctionHouse(testCard2);
			Assert.AreEqual(0, HumanPlayerInstance.GetAuctionHouseCards().Count);


			yield return null;
		}

		[UnityTest]
		public IEnumerator TestCharactersInTownRoster()
		{
			CharacterCard card1 = new CharacterCard("char 1");
			CharacterCard card2 = new CharacterCard("char 2");

			HumanPlayerInstance.AddCharacterCardToTownRoster(card1);
			Assert.AreEqual(1, HumanPlayerInstance.GetTownRoster().Count);
			HumanPlayerInstance.AddCharacterCardToTownRoster(card2);
			Assert.AreEqual(2, HumanPlayerInstance.GetTownRoster().Count);
			HumanPlayerInstance.AddCharacterCardToTownRoster(null);
			Assert.AreEqual(2, HumanPlayerInstance.GetTownRoster().Count);

			HumanPlayerInstance.RemoveCharacterFromTownRoster(null);
			Assert.AreEqual(2, HumanPlayerInstance.GetTownRoster().Count);
			HumanPlayerInstance.RemoveCharacterFromTownRoster(card1);
			Assert.AreEqual(1, HumanPlayerInstance.GetTownRoster().Count);
			HumanPlayerInstance.RemoveCharacterFromTownRoster(card2);
			Assert.AreEqual(0, HumanPlayerInstance.GetTownRoster().Count);
			HumanPlayerInstance.RemoveCharacterFromTownRoster(card1);
			Assert.AreEqual(0, HumanPlayerInstance.GetTownRoster().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestActionCardsInHand()
		{
			HumanPlayerInstance.AddActionCardToHand(new ActionCard("test card"));
			Assert.AreEqual(1, HumanPlayerInstance.GetActionCards().Count);
			HumanPlayerInstance.AddActionCardToHand(new ActionCard("test card 1"));
			Assert.AreEqual(2, HumanPlayerInstance.GetActionCards().Count);
			HumanPlayerInstance.AddActionCardToHand(null);
			Assert.AreEqual(2, HumanPlayerInstance.GetActionCards().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestPlayerFaction()
		{
			Assert.AreEqual("Faction name", HumanPlayerInstance.GetPlayerFaction().GetName());
			HumanPlayerInstance.SetPlayerFaction(new Faction("Faction 2", new Coordinates(1, 2)));
			Assert.AreEqual("Faction 2", HumanPlayerInstance.GetPlayerFaction().GetName());
			HumanPlayerInstance.SetPlayerFaction(null);
			Assert.IsNotNull(HumanPlayerInstance.GetPlayerFaction());
			Assert.AreEqual("Faction 2", HumanPlayerInstance.GetPlayerFaction().GetName());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestAddingSalvageToPlayer()
		{
			Assert.AreEqual(10, HumanPlayerInstance.GetSalvageAmount());
			HumanPlayerInstance.AddSalvageToPlayer(9);
			Assert.AreEqual(19, HumanPlayerInstance.GetSalvageAmount());
			HumanPlayerInstance.AddSalvageToPlayer(-5);
			Assert.AreEqual(19, HumanPlayerInstance.GetSalvageAmount());
			HumanPlayerInstance.AddSalvageToPlayer(0);
			Assert.AreEqual(19, HumanPlayerInstance.GetSalvageAmount());
			HumanPlayerInstance.AddSalvageToPlayer(1);
			Assert.AreEqual(20, HumanPlayerInstance.GetSalvageAmount());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestRemovingSalvageFromPlayer()
		{
			Assert.AreEqual(10, HumanPlayerInstance.GetSalvageAmount());
			HumanPlayerInstance.RemoveSalvageFromPlayer(5);
			Assert.AreEqual(5, HumanPlayerInstance.GetSalvageAmount());
			HumanPlayerInstance.RemoveSalvageFromPlayer(0);
			Assert.AreEqual(5, HumanPlayerInstance.GetSalvageAmount());
			HumanPlayerInstance.RemoveSalvageFromPlayer(-90);
			Assert.AreEqual(5, HumanPlayerInstance.GetSalvageAmount());
			HumanPlayerInstance.RemoveSalvageFromPlayer(10);
			Assert.AreEqual(0, HumanPlayerInstance.GetSalvageAmount());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestAddingTownTechs()
		{
			int numStartingTownTechs = HumanPlayerInstance.GetTownTechs().Count;

			HumanPlayerInstance.AddTownTech(new TownTech("tech1"));
			Assert.AreEqual(numStartingTownTechs + 1, HumanPlayerInstance.GetTownTechs().Count);
			HumanPlayerInstance.AddTownTech(new TownTech("tech2"));
			Assert.AreEqual(numStartingTownTechs + 2, HumanPlayerInstance.GetTownTechs().Count);
			HumanPlayerInstance.AddTownTech(null);
			Assert.AreEqual(numStartingTownTechs + 2, HumanPlayerInstance.GetTownTechs().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestStartingTownTechs()
		{
			TownTech tech1 = new TownTech("Tech1");
			TownTech tech2 = new TownTech("Tech2");
			Faction faction = new Faction("Faction", new Coordinates(1, 2));
			faction.AddStartingTownTech(tech1);
			faction.AddStartingTownTech(tech2);

			HumanPlayerInstance.SetPlayerFaction(faction);
			Assert.IsNotNull(HumanPlayerInstance.GetTownTechs());
			Assert.AreEqual(2, HumanPlayerInstance.GetTownTechs().Count);

			Faction faction1 = new Faction("Faction1", new Coordinates(1, 2));
			faction.AddStartingTownTech(null);
			HumanPlayerInstance.SetPlayerFaction(faction1);
			Assert.IsNotNull(HumanPlayerInstance.GetTownTechs());
			Assert.AreEqual(0, HumanPlayerInstance.GetTownTechs().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestActiveCharacters()
		{
			CharacterCard character1 = new CharacterCard("char 1");
			CharacterCard character2 = new CharacterCard("char 2");

			Assert.AreEqual(5, HumanPlayerInstance.GetActiveCharacters().Count);
			for (int characterIndex = 0; characterIndex < HumanPlayerInstance.GetActiveCharacters().Count; characterIndex++)
			{
				Assert.IsNull(HumanPlayerInstance.GetActiveCharacters()[characterIndex]);
			}

			Assert.IsTrue(HumanPlayerInstance.IsAllowedToAddCharacterToParty(CHARACTER_1_INDEX, 0));
			HumanPlayerInstance.AddCharacterToParty(CHARACTER_1_INDEX, character1);
			Assert.IsNotNull(HumanPlayerInstance.GetActiveCharacters()[CHARACTER_1_INDEX]);
			Assert.AreEqual(1, HumanPlayerInstance.GetNumberOfCharactersActive());

			Assert.IsFalse(HumanPlayerInstance.IsAllowedToAddCharacterToParty(CHARACTER_1_INDEX, 0));
			HumanPlayerInstance.AddCharacterToParty(CHARACTER_1_INDEX, null);
			Assert.IsNotNull(HumanPlayerInstance.GetActiveCharacters()[CHARACTER_1_INDEX]);
			Assert.AreEqual(1, HumanPlayerInstance.GetNumberOfCharactersActive());

			Assert.IsTrue(HumanPlayerInstance.IsAllowedToAddCharacterToParty(CHARACTER_2_INDEX, 0));
			HumanPlayerInstance.AddCharacterToParty(CHARACTER_2_INDEX, null);
			Assert.IsNull(HumanPlayerInstance.GetActiveCharacters()[CHARACTER_2_INDEX]);
			Assert.AreEqual(1, HumanPlayerInstance.GetNumberOfCharactersActive());

			Assert.IsTrue(HumanPlayerInstance.IsAllowedToAddCharacterToParty(CHARACTER_2_INDEX, 0));
			HumanPlayerInstance.AddCharacterToParty(CHARACTER_2_INDEX, character2);
			Assert.IsNotNull(HumanPlayerInstance.GetActiveCharacters()[CHARACTER_2_INDEX]);
			Assert.AreEqual(2, HumanPlayerInstance.GetNumberOfCharactersActive());

			Assert.IsFalse(HumanPlayerInstance.IsAllowedToAddCharacterToParty(CHARACTER_1_INDEX, 0));
			HumanPlayerInstance.AddCharacterToParty(CHARACTER_1_INDEX, character2);
			Assert.AreEqual(character1, HumanPlayerInstance.GetActiveCharacters()[CHARACTER_1_INDEX]);
			Assert.AreEqual(2, HumanPlayerInstance.GetNumberOfCharactersActive());

			HumanPlayerInstance.RemoveCharacterFromParty(CHARACTER_3_INDEX);
			Assert.AreEqual(2, HumanPlayerInstance.GetNumberOfCharactersActive());
			HumanPlayerInstance.RemoveCharacterFromParty(CHARACTER_1_INDEX);
			Assert.AreEqual(1, HumanPlayerInstance.GetNumberOfCharactersActive());
			HumanPlayerInstance.RemoveCharacterFromParty(CHARACTER_2_INDEX);
			Assert.AreEqual(0, HumanPlayerInstance.GetNumberOfCharactersActive());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestAddingAndRemovingSpoilsFromActiveCharacters()
		{
			CharacterCard character1 = new CharacterCard("char 1");
			CharacterCard character2 = new CharacterCard("char 2");
			SpoilsCard spoils1 = new SpoilsCard("spoils 1");
			SpoilsCard spoils2 = new SpoilsCard("spoils 2");

			HumanPlayerInstance.AddCharacterToParty(CHARACTER_1_INDEX, character1);
			Assert.IsTrue(HumanPlayerInstance.IsAllowedToAddSpoilsCardToCharacter(CHARACTER_1_INDEX, spoils1));
			Assert.IsTrue(HumanPlayerInstance.IsAllowedToAddSpoilsCardToCharacter(CHARACTER_1_INDEX, spoils2));

			HumanPlayerInstance.AddSpoilsToCharacter(CHARACTER_1_INDEX, spoils1);
			Assert.AreEqual(1, HumanPlayerInstance.GetActiveCharacters()[CHARACTER_1_INDEX].GetEquippedSpoils().Count);
			Assert.IsFalse(HumanPlayerInstance.IsAllowedToAddSpoilsCardToCharacter(CHARACTER_2_INDEX, spoils1));
			Assert.IsFalse(HumanPlayerInstance.IsAllowedToAddSpoilsCardToCharacter(CHARACTER_2_INDEX, spoils2));
			
			HumanPlayerInstance.AddSpoilsToCharacter(CHARACTER_2_INDEX, spoils1);
			Assert.AreEqual(1, HumanPlayerInstance.GetNumberOfCharactersActive());

			HumanPlayerInstance.AddCharacterToParty(CHARACTER_2_INDEX, character2);
			Assert.IsTrue(HumanPlayerInstance.IsAllowedToAddSpoilsCardToCharacter(CHARACTER_2_INDEX, spoils1));
			Assert.IsTrue(HumanPlayerInstance.IsAllowedToAddSpoilsCardToCharacter(CHARACTER_2_INDEX, spoils2));
			Assert.IsFalse(HumanPlayerInstance.IsAllowedToAddSpoilsCardToCharacter(CHARACTER_3_INDEX, spoils1));
			Assert.IsFalse(HumanPlayerInstance.IsAllowedToAddSpoilsCardToCharacter(CHARACTER_4_INDEX, spoils1));
			Assert.IsFalse(HumanPlayerInstance.IsAllowedToAddSpoilsCardToCharacter(CHARACTER_5_INDEX, spoils1));

			HumanPlayerInstance.RemoveSpoilsCardFromActiveCharacter(CHARACTER_1_INDEX, spoils2);
			Assert.AreEqual(1, HumanPlayerInstance.GetActiveCharacters()[CHARACTER_1_INDEX].GetEquippedSpoils().Count);
			HumanPlayerInstance.RemoveSpoilsCardFromActiveCharacter(CHARACTER_1_INDEX, spoils1);
			Assert.AreEqual(0, HumanPlayerInstance.GetActiveCharacters()[CHARACTER_1_INDEX].GetEquippedSpoils().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestAddAndRemoveVehicleFromParty()
		{
			SpoilsCard vehicleSpoils = new SpoilsCard("Vehicle Spoils");
			vehicleSpoils.AddSpoilsType(SpoilsTypes.Vehicle);
			SpoilsCard notAVehicleSpoils = new SpoilsCard("Non-vehicle spoils");
			notAVehicleSpoils.AddSpoilsType(SpoilsTypes.Armor);

			Assert.True(HumanPlayerInstance.IsAllowedToEquipVehicleToSlot());
			HumanPlayerInstance.AddVehicleToParty(vehicleSpoils);
			Assert.False(HumanPlayerInstance.IsAllowedToEquipVehicleToSlot());
			Assert.AreEqual(1, HumanPlayerInstance.GetNumberOfActiveVehicles());
			Assert.AreEqual(vehicleSpoils, HumanPlayerInstance.GetActiveVehicle());

			HumanPlayerInstance.AddVehicleToParty(notAVehicleSpoils);
			Assert.AreEqual(1, HumanPlayerInstance.GetNumberOfActiveVehicles());
			Assert.AreEqual(vehicleSpoils, HumanPlayerInstance.GetActiveVehicle());

			HumanPlayerInstance.RemoveVehicleFromParty();
			Assert.AreEqual(0, HumanPlayerInstance.GetNumberOfActiveVehicles());
			Assert.AreEqual(null, HumanPlayerInstance.GetActiveVehicle());

			HumanPlayerInstance.AddVehicleToParty(notAVehicleSpoils);
			Assert.AreEqual(0, HumanPlayerInstance.GetNumberOfActiveVehicles());
			Assert.AreEqual(null, HumanPlayerInstance.GetActiveVehicle());

			HumanPlayerInstance.AddVehicleToParty(null);
			Assert.AreEqual(0, HumanPlayerInstance.GetNumberOfActiveVehicles());
			Assert.AreEqual(null, HumanPlayerInstance.GetActiveVehicle());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestAddRemoveStowablesToVehicle()
		{
			SpoilsCard vehicleSpoils = new SpoilsCard("Vehicle Spoils");
			vehicleSpoils.AddSpoilsType(SpoilsTypes.Vehicle);
			HumanPlayerInstance.AddVehicleToParty(vehicleSpoils);

			SpoilsCard stowableCard = new SpoilsCard("Stowable");
			stowableCard.AddSpoilsType(SpoilsTypes.Stowable);
			SpoilsCard nonstowableCard = new SpoilsCard("Not stowable");
			nonstowableCard.AddSpoilsType(SpoilsTypes.Rifle);

			Assert.IsTrue(HumanPlayerInstance.IsAllowedToEquipSpoilsToVehicle(stowableCard));
			Assert.IsFalse(HumanPlayerInstance.IsAllowedToEquipSpoilsToVehicle(nonstowableCard));
			Assert.IsFalse(HumanPlayerInstance.IsAllowedToEquipSpoilsToVehicle(null));

			HumanPlayerInstance.AddSpoilsToActiveVehicle(stowableCard);
			Assert.AreEqual(1, HumanPlayerInstance.GetActiveVehicle().GetEquippedSpoils().Count);
			Assert.AreEqual(stowableCard, HumanPlayerInstance.GetActiveVehicle().GetEquippedSpoils()[0]);
			HumanPlayerInstance.AddSpoilsToActiveVehicle(nonstowableCard);
			Assert.AreEqual(1, HumanPlayerInstance.GetActiveVehicle().GetEquippedSpoils().Count);
			HumanPlayerInstance.AddSpoilsToActiveVehicle(null);
			Assert.AreEqual(1, HumanPlayerInstance.GetActiveVehicle().GetEquippedSpoils().Count);

			HumanPlayerInstance.RemoveStowableFromActiveVehicle(nonstowableCard);
			Assert.AreEqual(1, HumanPlayerInstance.GetActiveVehicle().GetEquippedSpoils().Count);
			HumanPlayerInstance.RemoveStowableFromActiveVehicle(stowableCard);
			Assert.AreEqual(0, HumanPlayerInstance.GetActiveVehicle().GetEquippedSpoils().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestVehicleStatsAndCarryWeight()
		{
			Dictionary<Skills, int> vehicleExpected = new Dictionary<Skills, int>
			{
				{ Skills.Mechanical, 3 },
				{ Skills.Diplomacy, 0 },
				{ Skills.Technical, 2 },
				{ Skills.Combat, 0 },
				{ Skills.Survival, 1 },
				{ Skills.Medical, 8 }
			};

			Dictionary<Skills, int> stowableExpected = new Dictionary<Skills, int>
			{
				{ Skills.Mechanical, 2 },
				{ Skills.Diplomacy, 2 },
				{ Skills.Technical, 1 },
				{ Skills.Combat, 5 },
				{ Skills.Survival, 4 },
				{ Skills.Medical, 0 }
			};

			Dictionary<Skills, int> totalExpected = new Dictionary<Skills, int>
			{
				{ Skills.Mechanical, vehicleExpected[Skills.Mechanical] + stowableExpected[Skills.Mechanical] },
				{ Skills.Diplomacy, vehicleExpected[Skills.Diplomacy] + stowableExpected[Skills.Diplomacy]  },
				{ Skills.Technical, vehicleExpected[Skills.Technical] + stowableExpected[Skills.Technical]  },
				{ Skills.Combat, vehicleExpected[Skills.Combat] + stowableExpected[Skills.Combat]  },
				{ Skills.Survival, vehicleExpected[Skills.Survival] + stowableExpected[Skills.Survival]  },
				{ Skills.Medical, vehicleExpected[Skills.Medical] + stowableExpected[Skills.Medical]  }
			};

			SpoilsCard vehicleSpoils = new SpoilsCard("Vehicle Spoils");
			vehicleSpoils.AddSpoilsType(SpoilsTypes.Vehicle);
			vehicleSpoils.SetBaseSkills(vehicleExpected);
			vehicleSpoils.SetCarryWeight(10);
			SpoilsCard stowableSpoil = new SpoilsCard("Stowable spoils");
			stowableSpoil.AddSpoilsType(SpoilsTypes.Stowable);
			stowableSpoil.SetBaseSkills(stowableExpected);
			stowableSpoil.SetCarryWeight(9);

			HumanPlayerInstance.AddVehicleToParty(vehicleSpoils);
			CollectionAssert.AreEquivalent(vehicleExpected, HumanPlayerInstance.GetActiveVehicleStats());
			Assert.AreEqual(10, HumanPlayerInstance.GetActiveVehicleRemainingCarryWeight());

			HumanPlayerInstance.AddSpoilsToActiveVehicle(stowableSpoil);
			CollectionAssert.AreEquivalent(totalExpected, HumanPlayerInstance.GetActiveVehicleStats());
			Assert.AreEqual(10-9, HumanPlayerInstance.GetActiveVehicleRemainingCarryWeight());

			HumanPlayerInstance.RemoveStowableFromActiveVehicle(stowableSpoil);
			CollectionAssert.AreEquivalent(vehicleExpected, HumanPlayerInstance.GetActiveVehicleStats());
			Assert.AreEqual(10, HumanPlayerInstance.GetActiveVehicleRemainingCarryWeight());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestCharacterSlotStatsAndCarryWeight()
		{
			const int CHARACTER_INDEX = 0;

			Dictionary<Skills, int> spoils1Expected = new Dictionary<Skills, int>
			{
				{ Skills.Mechanical, 3 },
				{ Skills.Diplomacy, 0 },
				{ Skills.Technical, 2 },
				{ Skills.Combat, 0 },
				{ Skills.Survival, 1 },
				{ Skills.Medical, 8 }
			};

			Dictionary<Skills, int> spoils2Expected = new Dictionary<Skills, int>
			{
				{ Skills.Mechanical, 2 },
				{ Skills.Diplomacy, 2 },
				{ Skills.Technical, 1 },
				{ Skills.Combat, 5 },
				{ Skills.Survival, 4 },
				{ Skills.Medical, 0 }
			};

			Dictionary<Skills, int> totalExpected = new Dictionary<Skills, int>
			{
				{ Skills.Mechanical, spoils1Expected[Skills.Mechanical] + spoils2Expected[Skills.Mechanical] },
				{ Skills.Diplomacy, spoils1Expected[Skills.Diplomacy] + spoils2Expected[Skills.Diplomacy]  },
				{ Skills.Technical, spoils1Expected[Skills.Technical] + spoils2Expected[Skills.Technical]  },
				{ Skills.Combat, spoils1Expected[Skills.Combat] + spoils2Expected[Skills.Combat]  },
				{ Skills.Survival, spoils1Expected[Skills.Survival] + spoils2Expected[Skills.Survival]  },
				{ Skills.Medical, spoils1Expected[Skills.Medical] + spoils2Expected[Skills.Medical]  }
			};

			CharacterCard character = new CharacterCard("character");
			character.SetCarryCapacity(10);
			SpoilsCard spoils1 = new SpoilsCard("Spoils1");
			spoils1.AddSpoilsType(SpoilsTypes.Vehicle);
			spoils1.SetBaseSkills(spoils1Expected);
			spoils1.SetCarryWeight(2);
			SpoilsCard spoils2 = new SpoilsCard("Spoils2");
			spoils2.AddSpoilsType(SpoilsTypes.Stowable);
			spoils2.SetBaseSkills(spoils2Expected);
			spoils2.SetCarryWeight(5);

			HumanPlayerInstance.AddCharacterToParty(CHARACTER_INDEX, character);
			CollectionAssert.AreEquivalent(Constants.ALL_SKILLS_ZERO, HumanPlayerInstance.GetActiveCharacterStats(CHARACTER_INDEX));
			Assert.AreEqual(10, HumanPlayerInstance.GetActiveCharacterRemainingCarryWeight(CHARACTER_INDEX));

			HumanPlayerInstance.AddSpoilsToCharacter(CHARACTER_INDEX, spoils1);
			CollectionAssert.AreEquivalent(spoils1Expected, HumanPlayerInstance.GetActiveCharacterStats(CHARACTER_INDEX));
			Assert.AreEqual(10-2, HumanPlayerInstance.GetActiveCharacterRemainingCarryWeight(CHARACTER_INDEX));

			HumanPlayerInstance.AddSpoilsToCharacter(CHARACTER_INDEX, spoils2);
			CollectionAssert.AreEquivalent(totalExpected, HumanPlayerInstance.GetActiveCharacterStats(CHARACTER_INDEX));
			Assert.AreEqual(10-2-5, HumanPlayerInstance.GetActiveCharacterRemainingCarryWeight(CHARACTER_INDEX));

			HumanPlayerInstance.RemoveSpoilsCardFromActiveCharacter(CHARACTER_INDEX, spoils1);
			CollectionAssert.AreEquivalent(spoils2Expected, HumanPlayerInstance.GetActiveCharacterStats(CHARACTER_INDEX));
			Assert.AreEqual(10-5, HumanPlayerInstance.GetActiveCharacterRemainingCarryWeight(CHARACTER_INDEX));

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestOwnedResources()
		{
			Coordinates loc1 = new Coordinates(1, 2);
			Coordinates loc2 = new Coordinates(2, 3);
			Resource resource1 = new Resource(loc1);
			Resource resource2 = new Resource(loc2);

			Assert.IsNotNull(HumanPlayerInstance.GetAllResourcesOwned());
			Assert.AreEqual(0, HumanPlayerInstance.GetAllResourcesOwned().Count);

			HumanPlayerInstance.AddResourceOwned(resource1);
			Assert.AreEqual(1, HumanPlayerInstance.GetAllResourcesOwned().Count);
			Assert.AreEqual(loc1, HumanPlayerInstance.GetAllResourcesOwned()[0].GetLocation());

			HumanPlayerInstance.RemoveResourceOwned(resource2);
			Assert.AreEqual(1, HumanPlayerInstance.GetAllResourcesOwned().Count);
			Assert.AreEqual(loc1, HumanPlayerInstance.GetAllResourcesOwned()[0].GetLocation());

			HumanPlayerInstance.RemoveResourceOwned(resource1);
			Assert.AreEqual(0, HumanPlayerInstance.GetAllResourcesOwned().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestTownHealth()
		{
			Assert.AreEqual(1, HumanPlayerInstance.GetTownHealth()); //Default to 1 TH

			HumanPlayerInstance.SetTownHealth(20);
			Assert.AreEqual(20, HumanPlayerInstance.GetTownHealth());

			HumanPlayerInstance.SetTownHealth(-10);
			Assert.AreEqual(1, HumanPlayerInstance.GetTownHealth());

			HumanPlayerInstance.SetTownHealth(0);
			Assert.AreEqual(1, HumanPlayerInstance.GetTownHealth()); //Cannot set TH below 1

			HumanPlayerInstance.AddTownHealth(0);
			Assert.AreEqual(1, HumanPlayerInstance.GetTownHealth());

			HumanPlayerInstance.AddTownHealth(8);
			Assert.AreEqual(9, HumanPlayerInstance.GetTownHealth());

			HumanPlayerInstance.AddTownHealth(-5);
			Assert.AreEqual(9, HumanPlayerInstance.GetTownHealth());

			HumanPlayerInstance.AddTownHealth(2);
			Assert.AreEqual(11, HumanPlayerInstance.GetTownHealth());

			HumanPlayerInstance.SubtractTownHealth(2);
			Assert.AreEqual(9, HumanPlayerInstance.GetTownHealth());

			HumanPlayerInstance.SubtractTownHealth(0);
			Assert.AreEqual(9, HumanPlayerInstance.GetTownHealth());

			HumanPlayerInstance.SubtractTownHealth(-11);
			Assert.AreEqual(9, HumanPlayerInstance.GetTownHealth());

			HumanPlayerInstance.SubtractTownHealth(7);
			Assert.AreEqual(2, HumanPlayerInstance.GetTownHealth());

			HumanPlayerInstance.SubtractTownHealth(8);
			Assert.AreEqual(1, HumanPlayerInstance.GetTownHealth()); //Minimum TH is 1

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestPrestige()
		{
			Assert.AreEqual(1, HumanPlayerInstance.GetPrestige()); //Default to 1 prestige

			HumanPlayerInstance.SetPrestige(20);
			Assert.AreEqual(20, HumanPlayerInstance.GetPrestige());

			HumanPlayerInstance.SetPrestige(-10);
			Assert.AreEqual(1, HumanPlayerInstance.GetPrestige());

			HumanPlayerInstance.SetPrestige(0);
			Assert.AreEqual(1, HumanPlayerInstance.GetPrestige()); //Cannot set prestige below 1

			HumanPlayerInstance.AddPrestige(0);
			Assert.AreEqual(1, HumanPlayerInstance.GetPrestige());

			HumanPlayerInstance.AddPrestige(8);
			Assert.AreEqual(9, HumanPlayerInstance.GetPrestige());

			HumanPlayerInstance.AddPrestige(-5);
			Assert.AreEqual(9, HumanPlayerInstance.GetPrestige());

			HumanPlayerInstance.AddPrestige(2);
			Assert.AreEqual(11, HumanPlayerInstance.GetPrestige());

			HumanPlayerInstance.SubtractPrestige(2);
			Assert.AreEqual(9, HumanPlayerInstance.GetPrestige());

			HumanPlayerInstance.SubtractPrestige(0);
			Assert.AreEqual(9, HumanPlayerInstance.GetPrestige());

			HumanPlayerInstance.SubtractPrestige(-11);
			Assert.AreEqual(9, HumanPlayerInstance.GetPrestige());

			HumanPlayerInstance.SubtractPrestige(7);
			Assert.AreEqual(2, HumanPlayerInstance.GetPrestige());

			HumanPlayerInstance.SubtractPrestige(8);
			Assert.AreEqual(1, HumanPlayerInstance.GetPrestige()); //Minimum prestige is 1

			yield return null;
		}
	}
}