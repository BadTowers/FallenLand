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
			Assert.Null(TownTech.GetConditionalGain());

			ConditionalGain conditionalGain = new ConditionalGain();
			TownTech.SetConditionalGains(conditionalGain);
			Assert.NotNull(TownTech.GetConditionalGain());

			TownTech.SetConditionalGains(null);
			Assert.NotNull(TownTech.GetConditionalGain());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestPassiveGains()
		{
			Assert.NotNull(TownTech.GetPassiveGains());

			TownTech.AddPassiveGain(Gains.Add_To_Roll, 2);
			Assert.AreEqual(1, TownTech.GetPassiveGains().Count);
			Assert.AreEqual(Gains.Add_To_Roll, TownTech.GetPassiveGains().Keys.ElementAt(0));
			Assert.AreEqual(2, TownTech.GetPassiveGains().Values.ElementAt(0));

			yield return null;
		}
	}
}