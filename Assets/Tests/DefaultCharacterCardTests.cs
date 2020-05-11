using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using FallenLand;

namespace Tests
{
	public class DefaultCharacterCardTests
	{
		private List<CharacterCard> CharacterCards;

		[SetUp]
		public void Setup()
		{
			DefaultCharacterCards defaultCharacterCards = new DefaultCharacterCards();
			CharacterCards = defaultCharacterCards.GetCharacterCards();
		}

		[TearDown]
		public void Teardown()
		{
			CharacterCards = null;
		}

		[UnityTest]
		public IEnumerator TestDefaultCharacterCards()
		{
			const int EXPECTED_NUM_DEFAULT_CHARACTER_CARDS = 80;
			Assert.AreEqual(EXPECTED_NUM_DEFAULT_CHARACTER_CARDS, CharacterCards.Count);

			yield return null;
		}
	}
}