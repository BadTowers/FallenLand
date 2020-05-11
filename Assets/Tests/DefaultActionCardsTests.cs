using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using FallenLand;

namespace Tests
{
	public class DefaultActionCardsTests
	{
		private List<ActionCard> ActionCards;

		[SetUp]
		public void Setup()
		{
			DefaultActionCards defaultActionCards = new DefaultActionCards();
			ActionCards = defaultActionCards.GetActionCards();
		}

		[TearDown]
		public void Teardown()
		{
			ActionCards = null;
		}

		[UnityTest]
		public IEnumerator TestDefaultActionCards()
		{
			const int EXPECTED_NUM_DEFAULT_ACTION_CARDS = 80;
			Assert.AreEqual(EXPECTED_NUM_DEFAULT_ACTION_CARDS, ActionCards.Count);

			yield return null;
		}
	}
}