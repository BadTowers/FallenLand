using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;

namespace Tests
{
	public class CharacterCardTests
	{
		CharacterCard CharacterCardInstance;

		[SetUp]
		public void Setup()
		{
			CharacterCardInstance = new CharacterCard("Character card constructor");
		}

		[TearDown]
		public void Teardown()
		{
			CharacterCardInstance = null;
		}

		[UnityTest]
		public IEnumerator TestCharacterCardName()
		{
			Assert.AreEqual("Character card constructor", CharacterCardInstance.GetTitle());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSubstring()
		{
			CharacterCardInstance.SetTitleSubString("title substring");
			Assert.AreEqual("title substring", CharacterCardInstance.GetTitleSubString());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestMaxHp()
		{
			Assert.AreEqual(0, CharacterCardInstance.GetMaxHp());
			CharacterCardInstance.SetMaxHp(10);
			Assert.AreEqual(10, CharacterCardInstance.GetMaxHp());
			CharacterCardInstance.SetMaxHp(-1);
			Assert.AreEqual(10, CharacterCardInstance.GetMaxHp());
			CharacterCardInstance.SetMaxHp(0);
			Assert.AreEqual(10, CharacterCardInstance.GetMaxHp());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestPsychResistance()
		{
			Assert.AreEqual(0, CharacterCardInstance.GetPsychResistance());
			CharacterCardInstance.SetPsychResistance(7);
			Assert.AreEqual(7, CharacterCardInstance.GetPsychResistance());
			CharacterCardInstance.SetPsychResistance(-5);
			Assert.AreEqual(7, CharacterCardInstance.GetPsychResistance());
			CharacterCardInstance.SetPsychResistance(0);
			Assert.AreEqual(7, CharacterCardInstance.GetPsychResistance());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestCarryCapacity()
		{
			Assert.AreEqual(0, CharacterCardInstance.GetCarryCapacity());
			CharacterCardInstance.SetCarryCapacity(3);
			Assert.AreEqual(3, CharacterCardInstance.GetCarryCapacity());
			CharacterCardInstance.SetCarryCapacity(-5);
			Assert.AreEqual(3, CharacterCardInstance.GetCarryCapacity());
			CharacterCardInstance.SetCarryCapacity(0);
			Assert.AreEqual(0, CharacterCardInstance.GetCarryCapacity());

			CharacterCardInstance.SetCarryCapacity(4);
			CharacterCardInstance.AddCarryCapacity(3);
			Assert.AreEqual(7, CharacterCardInstance.GetCarryCapacity());
			CharacterCardInstance.SubtractCarryCapacity(2);
			Assert.AreEqual(5, CharacterCardInstance.GetCarryCapacity());
			CharacterCardInstance.AddCarryCapacity(-2);
			Assert.AreEqual(5, CharacterCardInstance.GetCarryCapacity());
			CharacterCardInstance.SubtractCarryCapacity(-2);
			Assert.AreEqual(5, CharacterCardInstance.GetCarryCapacity());
			CharacterCardInstance.SubtractCarryCapacity(10);
			Assert.AreEqual(0, CharacterCardInstance.GetCarryCapacity());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestAttachAndRemoveSpoilsCards()
		{
			SpoilsCard card1 = new SpoilsCard("Card1");

			Assert.AreEqual(0, CharacterCardInstance.GetEquippedSpoils().Count);
			CharacterCardInstance.AttachSpoilsCard(card1);
			Assert.AreEqual(1, CharacterCardInstance.GetEquippedSpoils().Count);
			CharacterCardInstance.AttachSpoilsCard(null);
			Assert.AreEqual(1, CharacterCardInstance.GetEquippedSpoils().Count);

			SpoilsCard card2 = new SpoilsCard("Card2");
			CharacterCardInstance.RemoveSpoilsCard(card2);
			Assert.AreEqual(1, CharacterCardInstance.GetEquippedSpoils().Count);
			CharacterCardInstance.RemoveSpoilsCard(card1);
			Assert.AreEqual(0, CharacterCardInstance.GetEquippedSpoils().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestFirstStrike()
		{
			Assert.IsFalse(CharacterCardInstance.GetHasFirstStrike());
			CharacterCardInstance.SetHasFirstStrike(true);
			Assert.IsTrue(CharacterCardInstance.GetHasFirstStrike());
			CharacterCardInstance.SetHasFirstStrike(false);
			Assert.IsFalse(CharacterCardInstance.GetHasFirstStrike());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsMaster()
		{
			Assert.IsFalse(CharacterCardInstance.GetIsMaster());
			CharacterCardInstance.SetIsMaster(true);
			Assert.IsTrue(CharacterCardInstance.GetIsMaster());
			CharacterCardInstance.SetIsMaster(false);
			Assert.IsFalse(CharacterCardInstance.GetIsMaster());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSerializeAndDeserialize()
		{
			byte[] byteArray = CharacterCard.SerializeCharacterCard(CharacterCardInstance);
			CharacterCard newCharacterCard = (CharacterCard)CharacterCard.DeserializeCharacterCard(byteArray);
			Assert.AreEqual(newCharacterCard.GetTitle(), CharacterCardInstance.GetTitle());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestClearAllSpoils()
		{
			SpoilsCard card1 = new SpoilsCard("Card1");
			SpoilsCard card2 = new SpoilsCard("Card2");
			SpoilsCard card3 = new SpoilsCard("Card3");

			CharacterCardInstance.AttachSpoilsCard(card1);
			CharacterCardInstance.AttachSpoilsCard(card2);
			CharacterCardInstance.AttachSpoilsCard(card3);

			Assert.AreEqual(3, CharacterCardInstance.GetEquippedSpoils().Count);

			CharacterCardInstance.ClearAllSpoils();

			Assert.AreEqual(0, CharacterCardInstance.GetEquippedSpoils().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestHp()
		{
			CharacterCardInstance.SetMaxHp(10);

			Assert.AreEqual(10, CharacterCardInstance.GetMaxHp());
			Assert.AreEqual(10, CharacterCardInstance.GetHpRemaining());
			Assert.AreEqual(10, CharacterCardInstance.GetMaxPhysicalHp());
			Assert.AreEqual(10, CharacterCardInstance.GetMaxInfectedHp());
			Assert.AreEqual(10, CharacterCardInstance.GetMaxRadiationHp());

			CharacterCardInstance.AddPhysicalDamage(2);
			Assert.AreEqual(8, CharacterCardInstance.GetHpRemaining());
			Assert.AreEqual(10, CharacterCardInstance.GetMaxPhysicalHp());

			CharacterCardInstance.AddInfectedDamage(2);
			Assert.AreEqual(6, CharacterCardInstance.GetHpRemaining());
			Assert.AreEqual(8, CharacterCardInstance.GetMaxPhysicalHp());
			Assert.AreEqual(8, CharacterCardInstance.GetMaxInfectedHp());

			CharacterCardInstance.AddRadiationDamage(2);
			Assert.AreEqual(4, CharacterCardInstance.GetHpRemaining());
			Assert.AreEqual(6, CharacterCardInstance.GetMaxPhysicalHp());
			Assert.AreEqual(6, CharacterCardInstance.GetMaxInfectedHp());
			Assert.AreEqual(6, CharacterCardInstance.GetMaxRadiationHp());

			CharacterCardInstance.RemovePhysicalDamage(1);
			Assert.AreEqual(5, CharacterCardInstance.GetHpRemaining());
			Assert.AreEqual(6, CharacterCardInstance.GetMaxPhysicalHp());
			Assert.AreEqual(7, CharacterCardInstance.GetMaxInfectedHp());
			Assert.AreEqual(7, CharacterCardInstance.GetMaxRadiationHp());

			CharacterCardInstance.RemoveInfectedDamage(2);
			Assert.AreEqual(7, CharacterCardInstance.GetHpRemaining());
			Assert.AreEqual(8, CharacterCardInstance.GetMaxPhysicalHp());
			Assert.AreEqual(7, CharacterCardInstance.GetMaxInfectedHp());
			Assert.AreEqual(9, CharacterCardInstance.GetMaxRadiationHp());

			CharacterCardInstance.RemoveRadiationDamage(2);
			Assert.AreEqual(9, CharacterCardInstance.GetHpRemaining());
			Assert.AreEqual(10, CharacterCardInstance.GetMaxPhysicalHp());
			Assert.AreEqual(9, CharacterCardInstance.GetMaxInfectedHp());
			Assert.AreEqual(9, CharacterCardInstance.GetMaxRadiationHp());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestPsych()
		{
			CharacterCardInstance.SetPsychResistance(5);
			Assert.AreEqual(5, CharacterCardInstance.GetPsychResistance());
			Assert.AreEqual(3, CharacterCardInstance.GetPsychRemaning());
			CharacterCardInstance.SetPsychResistance(-5);
			Assert.AreEqual(5, CharacterCardInstance.GetPsychResistance());

			CharacterCardInstance.SetPsychResistance(5);
			CharacterCardInstance.AddPsychResistance(1);
			Assert.AreEqual(6, CharacterCardInstance.GetPsychResistance());
			CharacterCardInstance.SubtractPsychResistance(2);
			Assert.AreEqual(4, CharacterCardInstance.GetPsychResistance());

			CharacterCardInstance.SetPsychRemaining(2);
			Assert.AreEqual(2, CharacterCardInstance.GetPsychRemaning());
			CharacterCardInstance.SetPsychRemaining(-1);
			Assert.AreEqual(0, CharacterCardInstance.GetPsychRemaning());
			CharacterCardInstance.SetPsychRemaining(10);
			Assert.AreEqual(3, CharacterCardInstance.GetPsychRemaning());
			CharacterCardInstance.SetPsychRemaining(0);
			Assert.AreEqual(0, CharacterCardInstance.GetPsychRemaning());
			CharacterCardInstance.SetPsychRemaining(3);
			Assert.AreEqual(3, CharacterCardInstance.GetPsychRemaning());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestCardImages()
		{
			CharacterCardInstance.SetId(0);
			Assert.IsNotNull(CharacterCardInstance.GetCardImage());
			Assert.IsNotNull(CharacterCardInstance.GetCardPortrait());

			yield return null;
		}
	}
}