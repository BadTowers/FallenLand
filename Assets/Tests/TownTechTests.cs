using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Tests
{
	public class TownTechTests
	{
		private TownTech TownTech;

		[SetUp]
		public void Setup()
		{
			TownTech = new TownTech("Tech Name Constructor");
		}

		[TearDown]
		public void Teardown()
		{
		}

		[UnityTest]
		public IEnumerator TestTechName()
		{
			Assert.AreEqual("Tech Name Constructor", TownTech.GetTechName());
			TownTech.SetTechName("New Tech Setter");
			Assert.AreEqual("New Tech Setter", TownTech.GetTechName());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestId()
		{
			TownTech.SetId(10);
			Assert.AreEqual(10, TownTech.GetId());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestStartingTech()
		{
			TownTech.SetIsStartingTech(true);
			Assert.IsTrue(TownTech.GetIsStartingTech());
			TownTech.SetIsStartingTech(false);
			Assert.IsFalse(TownTech.GetIsStartingTech());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestPurchaseCost()
		{
			TownTech.SetPurchaseCost(10);
			Assert.AreEqual(10, TownTech.GetPurchaseCost());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestUpgradeCost()
		{
			TownTech.SetUpgradeCost(20);
			Assert.AreEqual(20, TownTech.GetUpgradeCost());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestTier()
		{
			TownTech.SetTier(2);
			Assert.AreEqual(2, TownTech.GetTier());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSellCost()
		{
			TownTech.SetSellCost(5);
			Assert.AreEqual(5, TownTech.GetSellCost());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestConditionalGains()
		{
			Dictionary<Gains, int> gains = new Dictionary<Gains, int>() { { Gains.Gain_Spoils_Cards, 2 } };
			TownTech.SetConditionalGains(gains);
			Assert.AreEqual(1, TownTech.GetConditionalGains().Count);
			Assert.AreEqual(Gains.Gain_Spoils_Cards, TownTech.GetConditionalGains().ElementAt(0).Key);
			Assert.AreEqual(2, TownTech.GetConditionalGains().ElementAt(0).Value);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestTimes()
		{
			List<Times> times = new List<Times>() { Times.After_Successful_Mission_Or_Encounter };
			TownTech.SetTimes(times);
			Assert.AreEqual(1, TownTech.GetTimes().Count);
			Assert.AreEqual(Times.After_Successful_Mission_Or_Encounter, TownTech.GetTimes()[0]);

			yield return null;
		}
	}
}