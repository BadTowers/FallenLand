using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Tests
{
	public class DefaultTownTechTests
	{
		private List<TownTech> DefaultTownTechs;

		[SetUp]
		public void Setup()
		{
			DefaultTownTechs defaultTownTechs = new DefaultTownTechs();
			DefaultTownTechs = defaultTownTechs.GetDefaultTownTechList();
		}

		[TearDown]
		public void Teardown()
		{
			DefaultTownTechs = null;
		}

		[UnityTest]
		public IEnumerator TestDefaultTownTechInfo()
		{
			const int EXPECTED_NUM_DEFAULT_TOWN_TECHS = 9;
			Assert.AreEqual(EXPECTED_NUM_DEFAULT_TOWN_TECHS, DefaultTownTechs.Count);

			for (int i = 0; i < EXPECTED_NUM_DEFAULT_TOWN_TECHS; i++)
			{
				Assert.AreEqual(25, DefaultTownTechs[i].GetSellCost());
				Assert.IsTrue(DefaultTownTechs[i].GetPurchaseCost() == 30 || DefaultTownTechs[i].GetPurchaseCost() == 40);
				Assert.IsTrue(DefaultTownTechs[i].GetUpgradeCost() == 30 || DefaultTownTechs[i].GetUpgradeCost() == 40);
				Assert.AreNotEqual("", DefaultTownTechs[i].GetTechName());
				Assert.Positive(DefaultTownTechs[i].GetId());
				Assert.AreEqual(1, DefaultTownTechs[i].GetConditionalGains().Count);
				Assert.AreEqual(1, DefaultTownTechs[i].GetTimes().Count);
			}

			yield return null;
		}
	}
}