using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Linq;
using FallenLand;

namespace Tests
{
	public class ComputerPlayerTests
	{
		private ComputerPlayer ComputerPlayerInstance;

		[SetUp]
		public void Setup()
		{
			ComputerPlayerInstance = new ComputerPlayer(new Faction("Faction name", new Coordinates(1, 2)), 10);
		}

		[TearDown]
		public void Teardown()
		{
			ComputerPlayerInstance = null;
		}

		[UnityTest]
		public IEnumerator TestConstructors()
		{
			Assert.IsNotNull(ComputerPlayerInstance.GetPlayerFaction());
			Assert.AreEqual(10, ComputerPlayerInstance.GetSalvageAmount());
			Assert.IsNotNull(ComputerPlayerInstance.GetAuctionHouseCards());
			Assert.IsNotNull(ComputerPlayerInstance.GetActionCards());
			Assert.IsNotNull(ComputerPlayerInstance.GetTownRoster());
			Assert.IsNotNull(ComputerPlayerInstance.GetActiveCharacters());
			Assert.IsNotNull(ComputerPlayerInstance.GetTownTechs());

			HumanPlayer humanPlayer1 = new HumanPlayer(null, -5);
			Assert.IsNotNull(humanPlayer1.GetPlayerFaction());
			Assert.AreEqual(0, humanPlayer1.GetSalvageAmount());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSpoilsCardsInAuctionHouse()
		{
			ComputerPlayerInstance.AddSpoilsCardToAuctionHouse(new SpoilsCard("test card"));
			Assert.AreEqual(1, ComputerPlayerInstance.GetAuctionHouseCards().Count);
			ComputerPlayerInstance.AddSpoilsCardToAuctionHouse(new SpoilsCard("test card 2"));
			Assert.AreEqual(2, ComputerPlayerInstance.GetAuctionHouseCards().Count);
			ComputerPlayerInstance.AddSpoilsCardToAuctionHouse(null);
			Assert.AreEqual(2, ComputerPlayerInstance.GetAuctionHouseCards().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestCharactersInTownRoster()
		{
			ComputerPlayerInstance.AddCharacterCardToTownRoster(new CharacterCard("test card"));
			Assert.AreEqual(1, ComputerPlayerInstance.GetTownRoster().Count);
			ComputerPlayerInstance.AddCharacterCardToTownRoster(new CharacterCard("test card 1"));
			Assert.AreEqual(2, ComputerPlayerInstance.GetTownRoster().Count);
			ComputerPlayerInstance.AddCharacterCardToTownRoster(null);
			Assert.AreEqual(2, ComputerPlayerInstance.GetTownRoster().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestActionCardsInHand()
		{
			ComputerPlayerInstance.AddActionCardToHand(new ActionCard("test card"));
			Assert.AreEqual(1, ComputerPlayerInstance.GetActionCards().Count);
			ComputerPlayerInstance.AddActionCardToHand(new ActionCard("test card 1"));
			Assert.AreEqual(2, ComputerPlayerInstance.GetActionCards().Count);
			ComputerPlayerInstance.AddActionCardToHand(null);
			Assert.AreEqual(2, ComputerPlayerInstance.GetActionCards().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestPlayerFaction()
		{
			Assert.AreEqual("Faction name", ComputerPlayerInstance.GetPlayerFaction().GetName());
			ComputerPlayerInstance.SetPlayerFaction(new Faction("Faction 2", new Coordinates(1, 2)));
			Assert.AreEqual("Faction 2", ComputerPlayerInstance.GetPlayerFaction().GetName());
			ComputerPlayerInstance.SetPlayerFaction(null);
			Assert.IsNotNull(ComputerPlayerInstance.GetPlayerFaction());
			Assert.AreEqual("Faction 2", ComputerPlayerInstance.GetPlayerFaction().GetName());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestAddingSalvageToPlayer()
		{
			Assert.AreEqual(10, ComputerPlayerInstance.GetSalvageAmount());
			ComputerPlayerInstance.AddSalvageToPlayer(9);
			Assert.AreEqual(19, ComputerPlayerInstance.GetSalvageAmount());
			ComputerPlayerInstance.AddSalvageToPlayer(-5);
			Assert.AreEqual(19, ComputerPlayerInstance.GetSalvageAmount());
			ComputerPlayerInstance.AddSalvageToPlayer(0);
			Assert.AreEqual(19, ComputerPlayerInstance.GetSalvageAmount());
			ComputerPlayerInstance.AddSalvageToPlayer(1);
			Assert.AreEqual(20, ComputerPlayerInstance.GetSalvageAmount());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestRemovingSalvageFromPlayer()
		{
			Assert.AreEqual(10, ComputerPlayerInstance.GetSalvageAmount());
			ComputerPlayerInstance.RemoveSalvageFromPlayer(5);
			Assert.AreEqual(5, ComputerPlayerInstance.GetSalvageAmount());
			ComputerPlayerInstance.RemoveSalvageFromPlayer(0);
			Assert.AreEqual(5, ComputerPlayerInstance.GetSalvageAmount());
			ComputerPlayerInstance.RemoveSalvageFromPlayer(-90);
			Assert.AreEqual(5, ComputerPlayerInstance.GetSalvageAmount());
			ComputerPlayerInstance.RemoveSalvageFromPlayer(10);
			Assert.AreEqual(0, ComputerPlayerInstance.GetSalvageAmount());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestAddingTownTechs()
		{
			int numStartingTownTechs = ComputerPlayerInstance.GetTownTechs().Count;

			ComputerPlayerInstance.AddTownTech(new TownTech("tech1"));
			Assert.AreEqual(numStartingTownTechs + 1, ComputerPlayerInstance.GetTownTechs().Count);
			ComputerPlayerInstance.AddTownTech(new TownTech("tech2"));
			Assert.AreEqual(numStartingTownTechs + 2, ComputerPlayerInstance.GetTownTechs().Count);
			ComputerPlayerInstance.AddTownTech(null);
			Assert.AreEqual(numStartingTownTechs + 2, ComputerPlayerInstance.GetTownTechs().Count);

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

			ComputerPlayerInstance.SetPlayerFaction(faction);
			Assert.IsNotNull(ComputerPlayerInstance.GetTownTechs());
			Assert.AreEqual(2, ComputerPlayerInstance.GetTownTechs().Count);

			Faction faction1 = new Faction("Faction1", new Coordinates(1, 2));
			faction.AddStartingTownTech(null);
			ComputerPlayerInstance.SetPlayerFaction(faction1);
			Assert.IsNotNull(ComputerPlayerInstance.GetTownTechs());
			Assert.AreEqual(0, ComputerPlayerInstance.GetTownTechs().Count);

			yield return null;
		}
	}
}