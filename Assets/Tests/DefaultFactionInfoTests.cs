using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Tests
{
	public class DefaultFactionInfoTests
	{
		private List<Faction> DefaultFactions;

		[SetUp]
		public void Setup()
		{
			DefaultFactionInfo defaultFactionInfo = new DefaultFactionInfo();
			DefaultFactions = defaultFactionInfo.GetDefaultFactionList();
		}

		[TearDown]
		public void Teardown()
		{
			DefaultFactions = null;
		}

		[UnityTest]
		public IEnumerator TestDefaultFactionInfo()
		{
			const int EXPECTED_NUM_DEFAULT_FACTIONS = 10;
			Assert.AreEqual(EXPECTED_NUM_DEFAULT_FACTIONS, DefaultFactions.Count);

			for (int i = 0; i < EXPECTED_NUM_DEFAULT_FACTIONS; i++)
			{
				Assert.AreNotEqual("", DefaultFactions[0].GetBaseLocationString());
				Assert.AreNotEqual("", DefaultFactions[0].GetName());
				Assert.AreNotEqual("", DefaultFactions[0].GetLore());
				Assert.AreEqual(4, DefaultFactions[0].GetPerks().Count);
				Assert.AreEqual(2, DefaultFactions[0].GetStartingTownTechs().Count);
				Assert.Positive(DefaultFactions[0].GetId());
			}

			yield return null;
		}
	}
}