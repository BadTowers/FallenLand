using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Tests
{
	public class HumanPlayerTests
	{
		private HumanPlayer HumanPlayerInstance;

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
			Assert.IsNotNull(HumanPlayerInstance.GetTownRosterCards());
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
			HumanPlayerInstance.AddSpoilsCardToAuctionHouse(new SpoilsCard("test card"));
			Assert.AreEqual(1, HumanPlayerInstance.GetAuctionHouseCards().Count);
			HumanPlayerInstance.AddSpoilsCardToAuctionHouse(new SpoilsCard("test card 2"));
			Assert.AreEqual(2, HumanPlayerInstance.GetAuctionHouseCards().Count);
			HumanPlayerInstance.AddSpoilsCardToAuctionHouse(null);
			Assert.AreEqual(2, HumanPlayerInstance.GetAuctionHouseCards().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestCharactersInTownRoster()
		{
			HumanPlayerInstance.AddCharacterCardToTownRoster(new CharacterCard("test card"));
			Assert.AreEqual(1, HumanPlayerInstance.GetTownRosterCards().Count);
			HumanPlayerInstance.AddCharacterCardToTownRoster(new CharacterCard("test card 1"));
			Assert.AreEqual(2, HumanPlayerInstance.GetTownRosterCards().Count);
			HumanPlayerInstance.AddCharacterCardToTownRoster(null);
			Assert.AreEqual(2, HumanPlayerInstance.GetTownRosterCards().Count);

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
	}
}