using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using FallenLand;

namespace Tests
{
	public class FactionTests
	{
		private Faction FactionInstance;

		[SetUp]
		public void Setup()
		{
			FactionInstance = new Faction("Faction Name Constructor", new Coordinates(10, 20));
		}

		[TearDown]
		public void Teardown()
		{
			FactionInstance = null;
		}

		[UnityTest]
		public IEnumerator TestFactionName()
		{
			Assert.AreEqual("Faction Name Constructor", FactionInstance.GetName());
			FactionInstance.SetName("New Faction Setter");
			Assert.AreEqual("New Faction Setter", FactionInstance.GetName());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestPerks()
		{
			List<Perk> perks = new List<Perk>() {new Perk("Perk 1"), new Perk("Perk 2")};
			FactionInstance.SetPerks(perks);
			Assert.AreEqual(2, FactionInstance.GetPerks().Count);

			FactionInstance.AddPerk(new Perk("Perk 3"));
			Assert.AreEqual(3, FactionInstance.GetPerks().Count);

			FactionInstance.SetPerks(null);
			Assert.IsNotNull(FactionInstance.GetPerks());
			Assert.AreEqual(3, FactionInstance.GetPerks().Count);

			FactionInstance.AddPerk(null);
			Assert.AreEqual(3, FactionInstance.GetPerks().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestCoordinate()
		{
			Assert.IsNotNull(FactionInstance.GetBaseLocation());
			FactionInstance.SetBaseLocation(new Coordinates(20, 30));
			Assert.IsNotNull(FactionInstance.GetBaseLocation());
			FactionInstance.SetBaseLocation(null);
			Assert.IsNotNull(FactionInstance.GetBaseLocation());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestBaseLocationString()
		{
			FactionInstance.SetBaseLocationString("Base string");
			Assert.AreEqual("Base string", FactionInstance.GetBaseLocationString());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestLoreString()
		{
			FactionInstance.SetLore("Lore string");
			Assert.AreEqual("Lore string", FactionInstance.GetLore());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestStartingTownTechs()
		{
			List<TownTech> townTechs = new List<TownTech>() {new TownTech("tech 1"), new TownTech("tech 2"), new TownTech("tech 3")};
			TownTech townTech = new TownTech("Tech 4");

			Assert.IsNotNull(FactionInstance.GetStartingTownTechs());
			Assert.IsEmpty(FactionInstance.GetStartingTownTechs());

			FactionInstance.SetStartingTownTechs(townTechs);
			Assert.AreEqual(3, FactionInstance.GetStartingTownTechs().Count);

			FactionInstance.AddStartingTownTech(townTech);
			Assert.AreEqual(4, FactionInstance.GetStartingTownTechs().Count);

			FactionInstance.SetStartingTownTechs(null);
			Assert.IsNotNull(FactionInstance.GetStartingTownTechs());
			Assert.AreEqual(4, FactionInstance.GetStartingTownTechs().Count);

			FactionInstance.SetStartingTownTechs(new List<TownTech>());
			Assert.IsEmpty(FactionInstance.GetStartingTownTechs());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestId()
		{
			FactionInstance.SetId(2);
			Assert.AreEqual(2, FactionInstance.GetId());

			yield return null;
		}
	}
}