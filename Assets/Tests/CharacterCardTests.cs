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

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestAttachAndRemoveSpoilsCards()
		{
			SpoilsCard card1 = new SpoilsCard("Card1");
			Assert.IsTrue(CharacterCardInstance.AttachSpoilsCard(card1));

			SpoilsCard card2 = new SpoilsCard("Card2");
			Assert.IsFalse(CharacterCardInstance.RemoveSpoilsCard(card2));

			Assert.IsTrue(CharacterCardInstance.RemoveSpoilsCard(card1));

			yield return null;
		}
	}
}