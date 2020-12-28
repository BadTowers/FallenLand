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
			Assert.IsNotNull(SpoilsCardInstance.GetSpoilsTypes());
			Assert.IsNotNull(SpoilsCardInstance.GetAttachments());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSpoilsCardTitle()
		{
			Assert.AreEqual("constructor spoils card title", SpoilsCardInstance.GetTitle());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestTypes()
		{
			Assert.IsNotNull(SpoilsCardInstance.GetSpoilsTypes());
			Assert.AreEqual(0, SpoilsCardInstance.GetSpoilsTypes().Count);
			SpoilsCardInstance.SetSpoilsTypes(new List<SpoilsTypes>() { SpoilsTypes.Ranged_Weapon });
			Assert.AreEqual(1, SpoilsCardInstance.GetSpoilsTypes().Count);
			Assert.AreEqual(SpoilsTypes.Ranged_Weapon, SpoilsCardInstance.GetSpoilsTypes()[0]);
			SpoilsCardInstance.AddSpoilsType(SpoilsTypes.Relic);
			Assert.AreEqual(2, SpoilsCardInstance.GetSpoilsTypes().Count);
			Assert.AreEqual(SpoilsTypes.Relic, SpoilsCardInstance.GetSpoilsTypes()[1]);

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

		[UnityTest]
		public IEnumerator TestDeepSet()
		{
			SpoilsCard cardToCopyFrom = new SpoilsCard("To copy");
			cardToCopyFrom.SetId(10);
			cardToCopyFrom.SetQuote("copy quote");

			SpoilsCardInstance.DeepSet(cardToCopyFrom);

			Assert.AreEqual(SpoilsCardInstance.GetId(), cardToCopyFrom.GetId());
			Assert.AreEqual(SpoilsCardInstance.GetTitle(), cardToCopyFrom.GetTitle());
			Assert.AreEqual(SpoilsCardInstance.GetQuote(), cardToCopyFrom.GetQuote());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestEqippedSpoils()
		{
			Assert.IsNotNull(SpoilsCardInstance.GetEquippedSpoils());
			Assert.AreEqual(0, SpoilsCardInstance.GetEquippedSpoils().Count);

			SpoilsCard spoils1 = new SpoilsCard("Spoils1");
			SpoilsCard spoils2 = new SpoilsCard("Spoils2");
			SpoilsCard spoils3 = new SpoilsCard("Spoils3");

			SpoilsCardInstance.AttachSpoilsCard(null);
			Assert.AreEqual(0, SpoilsCardInstance.GetEquippedSpoils().Count);
			SpoilsCardInstance.AttachSpoilsCard(spoils1);
			Assert.AreEqual(1, SpoilsCardInstance.GetEquippedSpoils().Count);
			SpoilsCardInstance.AttachSpoilsCard(spoils2);
			Assert.AreEqual(2, SpoilsCardInstance.GetEquippedSpoils().Count);

			SpoilsCardInstance.RemoveSpoilsCard(null);
			Assert.AreEqual(2, SpoilsCardInstance.GetEquippedSpoils().Count);
			SpoilsCardInstance.RemoveSpoilsCard(spoils2);
			Assert.AreEqual(1, SpoilsCardInstance.GetEquippedSpoils().Count);
			SpoilsCardInstance.RemoveSpoilsCard(spoils3);
			Assert.AreEqual(1, SpoilsCardInstance.GetEquippedSpoils().Count);
			SpoilsCardInstance.RemoveSpoilsCard(spoils1);
			Assert.AreEqual(0, SpoilsCardInstance.GetEquippedSpoils().Count);

			yield return null;
		}
	}
}