using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using FallenLand;

namespace Tests
{
	public class DefaultSpecialSpoilsCardsTests
	{
		private List<SpoilsCard> SpecialSpoilsCards;

		[SetUp]
		public void Setup()
		{
			DefaultSpecialSpoilsCards defaultSpecial = new DefaultSpecialSpoilsCards();
			SpecialSpoilsCards = defaultSpecial.GetSpoilsCards();
		}

		[TearDown]
		public void Teardown()
		{
			SpecialSpoilsCards = null;
		}

		[UnityTest]
		public IEnumerator TestDefaultSpecialSpoilsCards()
		{
			const int EXPECTED_NUM_DEFAULT_SPECIAL_SPOILS_CARDS = 1;
			Assert.AreEqual(EXPECTED_NUM_DEFAULT_SPECIAL_SPOILS_CARDS, SpecialSpoilsCards.Count);

			yield return null;
		}
	}
}