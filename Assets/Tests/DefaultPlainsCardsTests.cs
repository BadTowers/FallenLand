using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using FallenLand;

namespace Tests
{
	public class DefaultPlainsCardsTests
	{
		private List<PlainsCard> PlainsCards;

		[SetUp]
		public void Setup()
		{
			DefaultPlainsCards defaultPlains = new DefaultPlainsCards();
			PlainsCards = defaultPlains.GetPlainsCards();
		}

		[TearDown]
		public void Teardown()
		{
			PlainsCards = null;
		}

		[UnityTest]
		public IEnumerator TestDefaultPlainsCards()
		{
			const int EXPECTED_NUM_DEFAULT_PLAINS_CARDS = 39;
			Assert.AreEqual(EXPECTED_NUM_DEFAULT_PLAINS_CARDS, PlainsCards.Count);

			yield return null;
		}
	}
}