using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using System.Linq;
using FallenLand;

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
			TownTech = null;
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
			Assert.NotNull(TownTech.GetConditionalGains());

			Dictionary<Gains, int> gains = new Dictionary<Gains, int>() { { Gains.Gain_Spoils_Cards, 2 } };
			TownTech.SetConditionalGains(gains);
			Assert.AreEqual(1, TownTech.GetConditionalGains().Count);
			Assert.AreEqual(Gains.Gain_Spoils_Cards, TownTech.GetConditionalGains().ElementAt(0).Key);
			Assert.AreEqual(2, TownTech.GetConditionalGains().ElementAt(0).Value);

			TownTech.SetConditionalGains(null);
			Assert.NotNull(TownTech.GetConditionalGains());
			Assert.AreEqual(1, TownTech.GetConditionalGains().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestTimes()
		{
			Assert.NotNull(TownTech.GetTimes());

			List<Times> times = new List<Times>() { Times.After_Successful_Mission_Or_Encounter };
			TownTech.SetTimes(times);
			Assert.AreEqual(1, TownTech.GetTimes().Count);
			Assert.AreEqual(Times.After_Successful_Mission_Or_Encounter, TownTech.GetTimes()[0]);

			TownTech.SetTimes(null);
			Assert.NotNull(TownTech.GetTimes());
			Assert.AreEqual(1, TownTech.GetTimes().Count);

			yield return null;
		}
	}
}