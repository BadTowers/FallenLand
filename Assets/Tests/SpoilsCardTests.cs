using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using System.Linq;
using FallenLand;

namespace Tests
{
	public class SpoilsCardTests
	{
		private SpoilsCard SpoilsCardInstance;

		[SetUp]
		public void Setup()
		{
			SpoilsCardInstance = new SpoilsCard("constructor spoils card title");
		}

		[TearDown]
		public void Teardown()
		{
			SpoilsCardInstance = null;
		}

		[UnityTest]
		public IEnumerator TestSpoilsCardConstructors()
		{
			Assert.IsNotNull(SpoilsCardInstance.GetTypes());
			Assert.IsNotNull(SpoilsCardInstance.GetConditionalGains());
			Assert.IsNotNull(SpoilsCardInstance.GetStaticGains());
			Assert.IsNotNull(SpoilsCardInstance.GetRestrictions());
			Assert.IsNotNull(SpoilsCardInstance.GetWhenUsable());
			Assert.IsNotNull(SpoilsCardInstance.GetNumberOfUses());
			Assert.IsNotNull(SpoilsCardInstance.GetDiscard());
			Assert.IsNotNull(SpoilsCardInstance.GetD6Options());
			Assert.IsNotNull(SpoilsCardInstance.GetD10Options());
			Assert.IsNotNull(SpoilsCardInstance.GetAttachments());

			SpoilsCard spoilsCardListConstructor = new SpoilsCard("list constructor", new List<SpoilsTypes>() { SpoilsTypes.Alcohol });
			Assert.IsNotNull(spoilsCardListConstructor.GetTypes());
			Assert.AreEqual(1, spoilsCardListConstructor.GetTypes().Count);
			Assert.AreEqual(SpoilsTypes.Alcohol, spoilsCardListConstructor.GetTypes()[0]);
			Assert.IsNotNull(spoilsCardListConstructor.GetConditionalGains());
			Assert.IsNotNull(spoilsCardListConstructor.GetStaticGains());
			Assert.IsNotNull(spoilsCardListConstructor.GetRestrictions());
			Assert.IsNotNull(spoilsCardListConstructor.GetWhenUsable());
			Assert.IsNotNull(spoilsCardListConstructor.GetNumberOfUses());
			Assert.IsNotNull(spoilsCardListConstructor.GetDiscard());
			Assert.IsNotNull(spoilsCardListConstructor.GetD6Options());
			Assert.IsNotNull(spoilsCardListConstructor.GetD10Options());
			Assert.IsNotNull(spoilsCardListConstructor.GetAttachments());

			SpoilsCard spoilsCardParamConstructor = new SpoilsCard("param constructor", SpoilsTypes.Assault_Rifle, SpoilsTypes.Heavy_Weapon);
			Assert.IsNotNull(spoilsCardParamConstructor.GetTypes());
			Assert.AreEqual(2, spoilsCardParamConstructor.GetTypes().Count);
			Assert.AreEqual(SpoilsTypes.Assault_Rifle, spoilsCardParamConstructor.GetTypes()[0]);
			Assert.AreEqual(SpoilsTypes.Heavy_Weapon, spoilsCardParamConstructor.GetTypes()[1]);
			Assert.IsNotNull(spoilsCardParamConstructor.GetConditionalGains());
			Assert.IsNotNull(spoilsCardParamConstructor.GetStaticGains());
			Assert.IsNotNull(spoilsCardParamConstructor.GetRestrictions());
			Assert.IsNotNull(spoilsCardParamConstructor.GetWhenUsable());
			Assert.IsNotNull(spoilsCardParamConstructor.GetNumberOfUses());
			Assert.IsNotNull(spoilsCardParamConstructor.GetDiscard());
			Assert.IsNotNull(spoilsCardParamConstructor.GetD6Options());
			Assert.IsNotNull(spoilsCardParamConstructor.GetD10Options());
			Assert.IsNotNull(spoilsCardParamConstructor.GetAttachments());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSpoilsCardTitle()
		{
			Assert.AreEqual("constructor spoils card title", SpoilsCardInstance.GetTitle());

			SpoilsCard spoilsCardListConstructor = new SpoilsCard("list constructor", new List<SpoilsTypes>() { SpoilsTypes.Alcohol });
			Assert.AreEqual("list constructor", spoilsCardListConstructor.GetTitle());

			SpoilsCard spoilsCardParamConstructor = new SpoilsCard("param constructor", SpoilsTypes.Assault_Rifle, SpoilsTypes.Heavy_Weapon);
			Assert.AreEqual("param constructor", spoilsCardParamConstructor.GetTitle());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestTypes()
		{
			Assert.IsNotNull(SpoilsCardInstance.GetTypes());
			Assert.AreEqual(0, SpoilsCardInstance.GetTypes().Count);
			SpoilsCardInstance.SetTypes(new List<SpoilsTypes>() { SpoilsTypes.Ranged_Weapon });
			Assert.AreEqual(1, SpoilsCardInstance.GetTypes().Count);
			Assert.AreEqual(SpoilsTypes.Ranged_Weapon, SpoilsCardInstance.GetTypes()[0]);
			SpoilsCardInstance.AddType(SpoilsTypes.Relic);
			Assert.AreEqual(2, SpoilsCardInstance.GetTypes().Count);
			Assert.AreEqual(SpoilsTypes.Relic, SpoilsCardInstance.GetTypes()[1]);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSellValue()
		{
			Assert.AreEqual(0, SpoilsCardInstance.GetSellValue());
			SpoilsCardInstance.SetSellValue(10);
			Assert.AreEqual(10, SpoilsCardInstance.GetSellValue());
			SpoilsCardInstance.SetSellValue(-1);
			Assert.AreEqual(10, SpoilsCardInstance.GetSellValue());
			SpoilsCardInstance.SetSellValue(0);
			Assert.AreEqual(0, SpoilsCardInstance.GetSellValue());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestCarryWeight()
		{
			Assert.AreEqual(0, SpoilsCardInstance.GetCarryWeight());
			SpoilsCardInstance.SetCarryWeight(3);
			Assert.AreEqual(3, SpoilsCardInstance.GetCarryWeight());
			SpoilsCardInstance.SetCarryWeight(-1);
			Assert.AreEqual(3, SpoilsCardInstance.GetCarryWeight());
			SpoilsCardInstance.SetCarryWeight(0);
			Assert.AreEqual(0, SpoilsCardInstance.GetCarryWeight());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestRestrictions()
		{
			Assert.IsNotNull(SpoilsCardInstance.GetRestrictions());
			Assert.AreEqual(0, SpoilsCardInstance.GetRestrictions().Count);
			SpoilsCardInstance.SetRestrictions(new List<List<Restrictions>>() { new List<Restrictions>() { { Restrictions.Cannot_Be_Sold } } });
			Assert.AreEqual(Restrictions.Cannot_Be_Sold, SpoilsCardInstance.GetRestrictions()[0][0]);
			Assert.AreEqual(1, SpoilsCardInstance.GetRestrictions().Count);
			Assert.AreEqual(1, SpoilsCardInstance.GetRestrictions()[0].Count);
			SpoilsCardInstance.AddRestriction(new List<Restrictions>() { Restrictions.Cant_Be_Drawn_During_Setup, Restrictions.Equip_To_Rifle });
			Assert.AreEqual(2, SpoilsCardInstance.GetRestrictions().Count);
			Assert.AreEqual(Restrictions.Cant_Be_Drawn_During_Setup, SpoilsCardInstance.GetRestrictions()[1][0]);
			Assert.AreEqual(Restrictions.Equip_To_Rifle, SpoilsCardInstance.GetRestrictions()[1][1]);
			SpoilsCardInstance.AddRestriction(null);
			Assert.AreEqual(2, SpoilsCardInstance.GetRestrictions().Count);
			SpoilsCardInstance.SetRestrictions(new List<List<Restrictions>>() { });
			Assert.AreEqual(0, SpoilsCardInstance.GetRestrictions().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestStaticGains()
		{
			Assert.IsNotNull(SpoilsCardInstance.GetStaticGains());
			Assert.AreEqual(0, SpoilsCardInstance.GetStaticGains().Count);
			SpoilsCardInstance.SetStaticGains(new Dictionary<Gains, int>() { { Gains.Ally_Hire_Cost_More, 10 }, { Gains.All_Town_Defense_Chips_Cost_More, 200 } });
			Assert.AreEqual(2, SpoilsCardInstance.GetStaticGains().Count);
			Assert.AreEqual(Gains.Ally_Hire_Cost_More, SpoilsCardInstance.GetStaticGains().ElementAt(0).Key);
			Assert.AreEqual(10, SpoilsCardInstance.GetStaticGains().ElementAt(0).Value);
			Assert.AreEqual(Gains.All_Town_Defense_Chips_Cost_More, SpoilsCardInstance.GetStaticGains().ElementAt(1).Key);
			Assert.AreEqual(200, SpoilsCardInstance.GetStaticGains().ElementAt(1).Value);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestWhenUsable()
		{
			Assert.IsNotNull(SpoilsCardInstance.GetWhenUsable());
			Assert.AreEqual(0, SpoilsCardInstance.GetWhenUsable().Count);
			SpoilsCardInstance.SetWhenUsable(new List<List<Times>>(){ new List<Times>() {Times.After_Combat_Encounter_Success}});
			Assert.AreEqual(1, SpoilsCardInstance.GetWhenUsable().Count);
			Assert.AreEqual(1, SpoilsCardInstance.GetWhenUsable()[0].Count);
			Assert.AreEqual(Times.After_Combat_Encounter_Success, SpoilsCardInstance.GetWhenUsable()[0][0]);
			SpoilsCardInstance.SetWhenUsable(new List<List<Times>>() { });
			Assert.AreEqual(0, SpoilsCardInstance.GetWhenUsable().Count);
			SpoilsCardInstance.SetWhenUsable(new List<Times>() {Times.After_Deal_Subphase}, new List<Times>() {Times.After_Death});
			Assert.AreEqual(2, SpoilsCardInstance.GetWhenUsable().Count);
			Assert.AreEqual(1, SpoilsCardInstance.GetWhenUsable()[0].Count);
			Assert.AreEqual(Times.After_Deal_Subphase, SpoilsCardInstance.GetWhenUsable()[0][0]);
			Assert.AreEqual(1, SpoilsCardInstance.GetWhenUsable()[1].Count);
			Assert.AreEqual(Times.After_Death, SpoilsCardInstance.GetWhenUsable()[1][0]);
			SpoilsCardInstance.AddWhenUsable(new List<Times>() {Times.After_Diplomacy_Skill_Check_Failure});
			Assert.AreEqual(3, SpoilsCardInstance.GetWhenUsable().Count);
			Assert.AreEqual(1, SpoilsCardInstance.GetWhenUsable()[2].Count);
			Assert.AreEqual(Times.After_Diplomacy_Skill_Check_Failure, SpoilsCardInstance.GetWhenUsable()[2][0]);
			SpoilsCardInstance.AddWhenUsable(null);
			Assert.AreEqual(3, SpoilsCardInstance.GetWhenUsable().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestConditionalGains()
		{
			Assert.IsNotNull(SpoilsCardInstance.GetConditionalGains());
			Assert.AreEqual(0, SpoilsCardInstance.GetConditionalGains().Count);
			List<Dictionary<Gains, int>> listOfConditionalGains = new List<Dictionary<Gains, int>>() { };
			listOfConditionalGains.Add(new Dictionary<Gains, int>() { { Gains.Add_To_Roll, 1 }, { Gains.Ally_Hire_Cost_Less, 5 } });
			listOfConditionalGains.Add(new Dictionary<Gains, int>() { { Gains.All_Town_Defense_Chips_Cost_Less, 3 }});
			SpoilsCardInstance.SetConditionalGains(listOfConditionalGains);
			Assert.AreEqual(2, SpoilsCardInstance.GetConditionalGains().Count);
			Assert.AreEqual(2, SpoilsCardInstance.GetConditionalGains()[0].Count);
			Assert.AreEqual(Gains.Add_To_Roll, SpoilsCardInstance.GetConditionalGains()[0].ElementAt(0).Key);
			Assert.AreEqual(1, SpoilsCardInstance.GetConditionalGains()[0].ElementAt(0).Value);
			Assert.AreEqual(Gains.Ally_Hire_Cost_Less, SpoilsCardInstance.GetConditionalGains()[0].ElementAt(1).Key);
			Assert.AreEqual(5, SpoilsCardInstance.GetConditionalGains()[0].ElementAt(1).Value);
			Assert.AreEqual(Gains.All_Town_Defense_Chips_Cost_Less, SpoilsCardInstance.GetConditionalGains()[1].ElementAt(0).Key);
			Assert.AreEqual(3, SpoilsCardInstance.GetConditionalGains()[1].ElementAt(0).Value);
			Assert.AreEqual(1, SpoilsCardInstance.GetConditionalGains()[1].Count);

			SpoilsCardInstance.SetConditionalGains(new List<Dictionary<Gains, int>>() { });
			Assert.AreEqual(0, SpoilsCardInstance.GetConditionalGains().Count);

			SpoilsCardInstance.SetConditionalGains(new Dictionary<Gains, int>() { {Gains.Gain_Salvage, 10}, {Gains.Lost_Salvage, 20} });
			Assert.AreEqual(1, SpoilsCardInstance.GetConditionalGains().Count);
			Assert.AreEqual(Gains.Gain_Salvage, SpoilsCardInstance.GetConditionalGains()[0].ElementAt(0).Key);
			Assert.AreEqual(10, SpoilsCardInstance.GetConditionalGains()[0].ElementAt(0).Value);
			Assert.AreEqual(Gains.Lost_Salvage, SpoilsCardInstance.GetConditionalGains()[0].ElementAt(1).Key);
			Assert.AreEqual(20, SpoilsCardInstance.GetConditionalGains()[0].ElementAt(1).Value);

			SpoilsCardInstance.AddConditionalGain(new Dictionary<Gains, int>() { { Gains.Lose_Town_Health, 7} });
			Assert.AreEqual(2, SpoilsCardInstance.GetConditionalGains().Count);
			Assert.AreEqual(Gains.Lose_Town_Health, SpoilsCardInstance.GetConditionalGains()[1].ElementAt(0).Key);
			Assert.AreEqual(7, SpoilsCardInstance.GetConditionalGains()[1].ElementAt(0).Value);

			SpoilsCardInstance.AddConditionalGain(Gains.Gain_Spoils_Cards, 4);
			Assert.AreEqual(3, SpoilsCardInstance.GetConditionalGains().Count);
			Assert.AreEqual(Gains.Gain_Spoils_Cards, SpoilsCardInstance.GetConditionalGains()[2].ElementAt(0).Key);
			Assert.AreEqual(4, SpoilsCardInstance.GetConditionalGains()[2].ElementAt(0).Value);

			SpoilsCardInstance.AddConditionalGain(null);
			Assert.AreEqual(3, SpoilsCardInstance.GetConditionalGains().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestNumberOfUses()
		{
			Assert.IsNotNull(SpoilsCardInstance.GetNumberOfUses());
			Assert.AreEqual(0, SpoilsCardInstance.GetNumberOfUses().Count);
			SpoilsCardInstance.SetNumberOfUses(new List<Uses>() {Uses.Once_Per_Encounter, Uses.Once_Per_Game});
			Assert.AreEqual(2, SpoilsCardInstance.GetNumberOfUses().Count);
			Assert.AreEqual(Uses.Once_Per_Encounter, SpoilsCardInstance.GetNumberOfUses()[0]);
			Assert.AreEqual(Uses.Once_Per_Game, SpoilsCardInstance.GetNumberOfUses()[1]);

			SpoilsCardInstance.SetNumberOfUses(Uses.Once_Per_PvP, Uses.Unlimited, Uses.Once_Per_Turn);
			Assert.AreEqual(3, SpoilsCardInstance.GetNumberOfUses().Count);
			Assert.AreEqual(Uses.Once_Per_PvP, SpoilsCardInstance.GetNumberOfUses()[0]);
			Assert.AreEqual(Uses.Unlimited, SpoilsCardInstance.GetNumberOfUses()[1]);
			Assert.AreEqual(Uses.Once_Per_Turn, SpoilsCardInstance.GetNumberOfUses()[2]);

			SpoilsCardInstance.AddNumberOfUses(Uses.Once_Per_Game_Per_Player);
			Assert.AreEqual(4, SpoilsCardInstance.GetNumberOfUses().Count);
			Assert.AreEqual(Uses.Once_Per_Game_Per_Player, SpoilsCardInstance.GetNumberOfUses()[3]);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestDiscard()
		{
			Assert.IsNotNull(SpoilsCardInstance.GetDiscard());
			Assert.AreEqual(0, SpoilsCardInstance.GetDiscard().Count);
			SpoilsCardInstance.SetDiscard(new List<bool>() { true, false, false, true });
			Assert.AreEqual(4, SpoilsCardInstance.GetDiscard().Count);
			Assert.AreEqual(true, SpoilsCardInstance.GetDiscard()[0]);
			Assert.AreEqual(false, SpoilsCardInstance.GetDiscard()[1]);
			Assert.AreEqual(false, SpoilsCardInstance.GetDiscard()[2]);
			Assert.AreEqual(true, SpoilsCardInstance.GetDiscard()[3]);

			SpoilsCardInstance.SetDiscard(false, false, true);
			Assert.AreEqual(3, SpoilsCardInstance.GetDiscard().Count);
			Assert.AreEqual(false, SpoilsCardInstance.GetDiscard()[0]);
			Assert.AreEqual(false, SpoilsCardInstance.GetDiscard()[1]);
			Assert.AreEqual(true, SpoilsCardInstance.GetDiscard()[2]);

			SpoilsCardInstance.AddDiscard(false);
			Assert.AreEqual(4, SpoilsCardInstance.GetDiscard().Count);
			Assert.AreEqual(false, SpoilsCardInstance.GetDiscard()[3]);

			SpoilsCardInstance.SetDiscard(new List<bool>() {});
			Assert.IsNotNull(SpoilsCardInstance.GetDiscard());
			Assert.AreEqual(0, SpoilsCardInstance.GetDiscard().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestD6Options()
		{
			Assert.IsNotNull(SpoilsCardInstance.GetD6Options());
			Assert.AreEqual(0, SpoilsCardInstance.GetD6Options().Count);
			SpoilsCardInstance.SetD6Options(new List<SpoilsCard>() { new SpoilsCard("card1"), new SpoilsCard("card2"), null });
			Assert.AreEqual(3, SpoilsCardInstance.GetD6Options().Count);
			Assert.IsNotNull( SpoilsCardInstance.GetD6Options()[0]);
			Assert.IsNotNull(SpoilsCardInstance.GetD6Options()[1]);
			Assert.IsNull(SpoilsCardInstance.GetD6Options()[2]);

			SpoilsCardInstance.SetD6Options(new SpoilsCard("card1"), null, null, new SpoilsCard("card2"));
			Assert.AreEqual(4, SpoilsCardInstance.GetD6Options().Count);
			Assert.IsNotNull(SpoilsCardInstance.GetD6Options()[0]);
			Assert.IsNull(SpoilsCardInstance.GetD6Options()[1]);
			Assert.IsNull(SpoilsCardInstance.GetD6Options()[2]);
			Assert.IsNotNull(SpoilsCardInstance.GetD6Options()[3]);

			SpoilsCardInstance.AddD6Option(new SpoilsCard("card3"));
			Assert.AreEqual(5, SpoilsCardInstance.GetD6Options().Count);
			Assert.IsNotNull(SpoilsCardInstance.GetD6Options()[4]);

			SpoilsCardInstance.AddD6Option(null);
			Assert.AreEqual(6, SpoilsCardInstance.GetD6Options().Count);
			Assert.IsNull(SpoilsCardInstance.GetD6Options()[5]);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestD10Options()
		{
			Assert.IsNotNull(SpoilsCardInstance.GetD10Options());
			Assert.AreEqual(0, SpoilsCardInstance.GetD10Options().Count);
			SpoilsCardInstance.SetD10Options(new List<SpoilsCard>() { new SpoilsCard("card1"), null });
			Assert.AreEqual(2, SpoilsCardInstance.GetD10Options().Count);
			Assert.IsNotNull(SpoilsCardInstance.GetD10Options()[0]);
			Assert.IsNull(SpoilsCardInstance.GetD10Options()[1]);

			SpoilsCardInstance.SetD10Options(new SpoilsCard("card1"), new SpoilsCard("card2"), null, null, new SpoilsCard("card3"));
			Assert.AreEqual(5, SpoilsCardInstance.GetD10Options().Count);
			Assert.IsNotNull(SpoilsCardInstance.GetD10Options()[0]);
			Assert.IsNotNull(SpoilsCardInstance.GetD10Options()[1]);
			Assert.IsNull(SpoilsCardInstance.GetD10Options()[2]);
			Assert.IsNull(SpoilsCardInstance.GetD10Options()[3]);
			Assert.IsNotNull(SpoilsCardInstance.GetD10Options()[4]);

			SpoilsCardInstance.AddD10Option(null);
			Assert.AreEqual(6, SpoilsCardInstance.GetD10Options().Count);
			Assert.IsNull(SpoilsCardInstance.GetD10Options()[5]);

			SpoilsCardInstance.AddD10Option(new SpoilsCard("card4"));
			Assert.AreEqual(7, SpoilsCardInstance.GetD10Options().Count);
			Assert.IsNotNull(SpoilsCardInstance.GetD10Options()[6]);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsTemp()
		{
			Assert.IsFalse(SpoilsCardInstance.GetIsTemp());
			SpoilsCardInstance.SetIsTemp(true);
			Assert.IsTrue(SpoilsCardInstance.GetIsTemp());
			SpoilsCardInstance.SetIsTemp(false);
			Assert.IsFalse(SpoilsCardInstance.GetIsTemp());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestWhenTempEnds()
		{
			SpoilsCardInstance.SetWhenTempEnd(Times.After_Mechanical_Skill_Critical_Failure);
			Assert.AreEqual(Times.After_Mechanical_Skill_Critical_Failure, SpoilsCardInstance.GetWhenTempEnd());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestAttachments()
		{
			Assert.IsNotNull(SpoilsCardInstance.GetAttachments());
			Assert.AreEqual(0, SpoilsCardInstance.GetAttachments().Count);

			SpoilsCardInstance.AddAttachment(new SpoilsCard("Card1"));
			Assert.AreEqual(1, SpoilsCardInstance.GetAttachments().Count);

			SpoilsCardInstance.AddAttachment(null);
			Assert.AreEqual(1, SpoilsCardInstance.GetAttachments().Count);

			SpoilsCardInstance.AddAttachment(new SpoilsCard("Card2"));
			Assert.AreEqual(2, SpoilsCardInstance.GetAttachments().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestDiscardToTop()
		{
			Assert.IsTrue(SpoilsCardInstance.GetDiscardToTop());
			SpoilsCardInstance.SetDiscardToTop(false);
			Assert.IsFalse(SpoilsCardInstance.GetDiscardToTop());
			SpoilsCardInstance.SetDiscardToTop(true);
			Assert.IsTrue(SpoilsCardInstance.GetDiscardToTop());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestDeepCopy()
		{
			SpoilsCard tempSpoilsCardDeep;
			SpoilsCard tempSpoilsCardShallow;

			tempSpoilsCardDeep = SpoilsCardInstance.DeepCopy();
			Assert.AreNotEqual(tempSpoilsCardDeep, SpoilsCardInstance);

			tempSpoilsCardShallow = SpoilsCardInstance;
			Assert.AreEqual(tempSpoilsCardShallow, SpoilsCardInstance);

			yield return null;
		}
	}
}