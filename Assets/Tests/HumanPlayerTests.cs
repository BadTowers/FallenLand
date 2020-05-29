using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;

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
			HumanPlayerInstance.AddCharacterCardToTownRoster(new CharacterCard("test card"));
			Assert.AreEqual(1, HumanPlayerInstance.GetTownRoster().Count);
			HumanPlayerInstance.AddCharacterCardToTownRoster(new CharacterCard("test card 1"));
			Assert.AreEqual(2, HumanPlayerInstance.GetTownRoster().Count);
			HumanPlayerInstance.AddCharacterCardToTownRoster(null);
			Assert.AreEqual(2, HumanPlayerInstance.GetTownRoster().Count);

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

			HumanPlayerInstance.AddCharacterToParty(CHARACTER_1_INDEX, character1);
			Assert.IsNotNull(HumanPlayerInstance.GetActiveCharacters()[CHARACTER_1_INDEX]);
			Assert.AreEqual(1, HumanPlayerInstance.GetNumberOfCharactersActive());

			HumanPlayerInstance.AddCharacterToParty(CHARACTER_1_INDEX, null);
			Assert.IsNotNull(HumanPlayerInstance.GetActiveCharacters()[CHARACTER_1_INDEX]);
			Assert.AreEqual(1, HumanPlayerInstance.GetNumberOfCharactersActive());

			HumanPlayerInstance.AddCharacterToParty(CHARACTER_2_INDEX, null);
			Assert.IsNull(HumanPlayerInstance.GetActiveCharacters()[CHARACTER_2_INDEX]);
			Assert.AreEqual(1, HumanPlayerInstance.GetNumberOfCharactersActive());

			HumanPlayerInstance.AddCharacterToParty(CHARACTER_2_INDEX, character2);
			Assert.IsNotNull(HumanPlayerInstance.GetActiveCharacters()[CHARACTER_2_INDEX]);
			Assert.AreEqual(2, HumanPlayerInstance.GetNumberOfCharactersActive());

			HumanPlayerInstance.AddCharacterToParty(CHARACTER_1_INDEX, character2);
			Assert.AreEqual(character1, HumanPlayerInstance.GetActiveCharacters()[CHARACTER_1_INDEX]);
			Assert.AreEqual(2, HumanPlayerInstance.GetNumberOfCharactersActive());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestAddingSpoilsToActiveCharacters()
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

			yield return null;
		}
	}
}