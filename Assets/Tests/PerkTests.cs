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
		public IEnumerator TestTimesWhenUsable()
		{
			Assert.IsNotNull(PerkInstance.GetTimes());

			List<Times> times = new List<Times>(){Times.After_Action_House_Subphase, Times.During_Deal_Subphase};
			PerkInstance.SetTimes(times);
			Assert.AreEqual(2, PerkInstance.GetTimes().Count);
			Assert.AreEqual(Times.After_Action_House_Subphase, PerkInstance.GetTimes()[0]);
			Assert.AreEqual(Times.During_Deal_Subphase, PerkInstance.GetTimes()[1]);

			PerkInstance.SetTimes(null);
			Assert.IsNotNull(PerkInstance.GetTimes());
			Assert.AreEqual(2, PerkInstance.GetTimes().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestStaticGains()
		{
			Assert.IsNotNull(PerkInstance.GetStaticGains());

			Dictionary<Gains, int> staticGains = new Dictionary<Gains, int>() { { Gains.Add_To_Roll, 2}};
			PerkInstance.SetStaticGains(staticGains);
			Assert.AreEqual(1, PerkInstance.GetStaticGains().Count);
			Assert.AreEqual(Gains.Add_To_Roll, PerkInstance.GetStaticGains().ElementAt(0).Key);
			Assert.AreEqual(2, PerkInstance.GetStaticGains().ElementAt(0).Value);

			PerkInstance.SetStaticGains(null);
			Assert.IsNotNull(PerkInstance.GetStaticGains());
			Assert.AreEqual(1, PerkInstance.GetStaticGains().Count);

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
		public IEnumerator TestNumberOfUses()
		{
			Assert.IsNotNull(PerkInstance.GetUses());

			List<Uses> numUses = new List<Uses>() { Uses.None, Uses.Once_Per_Game, Uses.Once_Per_PvP };
			PerkInstance.SetUses(numUses);
			Assert.AreEqual(3, PerkInstance.GetUses().Count);
			Assert.AreEqual(Uses.None, PerkInstance.GetUses()[0]);
			Assert.AreEqual(Uses.Once_Per_Game, PerkInstance.GetUses()[1]);
			Assert.AreEqual(Uses.Once_Per_PvP, PerkInstance.GetUses()[2]);

			PerkInstance.SetUses(null);
			Assert.IsNotNull(PerkInstance.GetUses());
			Assert.AreEqual(3, PerkInstance.GetUses().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestConditionalGains()
		{
			Assert.IsNotNull(PerkInstance.GetConditionalGains());

			Dictionary<Gains, int> conditionalGains = new Dictionary<Gains, int>() { { Gains.Gain_Spoils_Cards, 3 } };
			PerkInstance.SetConditionalGains(conditionalGains);
			Assert.AreEqual(1, PerkInstance.GetConditionalGains().Count);
			Assert.AreEqual(Gains.Gain_Spoils_Cards, PerkInstance.GetConditionalGains().ElementAt(0).Key);
			Assert.AreEqual(3, PerkInstance.GetConditionalGains().ElementAt(0).Value);

			PerkInstance.SetConditionalGains(null);
			Assert.IsNotNull(PerkInstance.GetConditionalGains());
			Assert.AreEqual(1, PerkInstance.GetConditionalGains().Count);

			yield return null;
		}
	}
}