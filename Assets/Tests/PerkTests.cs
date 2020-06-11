using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using System.Linq;
using FallenLand;

namespace Tests
{
	public class PerkTests
	{
		private Perk PerkInstance;

		[SetUp]
		public void Setup()
		{
			PerkInstance = new Perk("Perk title constructor");
		}

		[TearDown]
		public void Teardown()
		{
			PerkInstance = null;
		}

		[UnityTest]
		public IEnumerator TestPerkName()
		{
			Assert.AreEqual("Perk title constructor", PerkInstance.GetPerkTitle());
			PerkInstance.SetPerkTitle("Perk title setter");
			Assert.AreEqual("Perk title setter", PerkInstance.GetPerkTitle());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestStaticGains()
		{
			Assert.IsNotNull(PerkInstance.GetPassiveGains());

			Dictionary<Gains, int> staticGains = new Dictionary<Gains, int>() { { Gains.Add_To_Roll, 2}};
			PerkInstance.SetPassiveGains(staticGains);
			Assert.AreEqual(1, PerkInstance.GetPassiveGains().Count);
			Assert.AreEqual(Gains.Add_To_Roll, PerkInstance.GetPassiveGains().ElementAt(0).Key);
			Assert.AreEqual(2, PerkInstance.GetPassiveGains().ElementAt(0).Value);

			PerkInstance.SetPassiveGains(null);
			Assert.IsNotNull(PerkInstance.GetPassiveGains());
			Assert.AreEqual(1, PerkInstance.GetPassiveGains().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestPerkDescription()
		{
			PerkInstance.SetPerkDescription("Description 1");
			Assert.AreEqual("Description 1", PerkInstance.GetPerkDescription());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestAddingD6Options()
		{
			Assert.IsNotNull(PerkInstance.GetD6Options());

			Dictionary<Gains, int> d6Option = new Dictionary<Gains, int>() { { Gains.Gain_Salvage, 10 } };
			PerkInstance.AddD6Option(d6Option);
			Assert.AreEqual(1, PerkInstance.GetD6Options().Count);
			Assert.AreEqual(Gains.Gain_Salvage, PerkInstance.GetD6Options()[0].ElementAt(0).Key);
			Assert.AreEqual(10, PerkInstance.GetD6Options()[0].ElementAt(0).Value);

			PerkInstance.AddD6Option(null);
			Assert.IsNotNull(PerkInstance.GetD6Options());
			Assert.AreEqual(1, PerkInstance.GetD6Options().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestConditionalGains()
		{
			Assert.IsNull(PerkInstance.GetConditionalGain());

			ConditionalGain conditionalGain = new ConditionalGain();
			Reward reward = new GainSpoilsCards(3);
			conditionalGain.AddRewardChoice(new List<Reward>() { reward });
			PerkInstance.SetConditionalGain(conditionalGain);
			Assert.IsTrue(PerkInstance.GetConditionalGain().GetRewardChoices()[0][0] is GainSpoilsCards);
			Assert.AreEqual(3, PerkInstance.GetConditionalGain().GetRewardChoices()[0][0].GetRewardAmount());

			PerkInstance.SetConditionalGain(null);
			Assert.IsNotNull(PerkInstance.GetConditionalGain());

			yield return null;
		}
	}
}