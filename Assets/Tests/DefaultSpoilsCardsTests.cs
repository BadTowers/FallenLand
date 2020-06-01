using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using UnityEngine;
using FallenLand;

namespace Tests
{
	public class DefaultSpoilsCardsTests
	{
		private List<SpoilsCard> DefaultSpoilsDeck;

		[SetUp]
		public void Setup()
		{
			DefaultSpoilsCards dsc = new DefaultSpoilsCards();
			DefaultSpoilsDeck = dsc.GetSpoilsCards();
		}

		[TearDown]
		public void Teardown()
		{
			DefaultSpoilsDeck = null;
		}

		[UnityTest]
		public IEnumerator TestDefaultSpoilsCards()
		{
			for (int i = 0; i < DefaultSpoilsDeck.Count; i++)
			{
				SpoilsCard curCard = DefaultSpoilsDeck[i];
				Debug.Log("Testing card " + i + ": title " + curCard.GetTitle());

				Assert.IsNotNull(curCard.GetAttachments());
				Assert.IsNotNull(curCard.GetBaseSkills());
				Assert.IsNotNull(curCard.GetConditionalGains());
				Assert.IsNotNull(curCard.GetD10Options());
				Assert.IsNotNull(curCard.GetD6Options());
				Assert.IsNotNull(curCard.GetDiscard());
				Assert.IsNotNull(curCard.GetNumberOfUses());
				Assert.IsNotNull(curCard.GetRestrictions());
				Assert.IsNotNull(curCard.GetStaticGains());
				Assert.IsNotNull(curCard.GetSpoilsTypes());
				Assert.IsNotNull(curCard.GetWhenUsable());

				Assert.IsTrue(DefaultSpoilsDeck[i].GetSpoilsTypes().Count > 0);

				//If it isn't an event card, ensure all cards have at least one non-zero base skill
				if (curCard.GetTitle() != "Designer Biker Leathers" && curCard.GetTitle() != "Fallen Land Board Game") //These cards have no stats
				{
					if (!curCard.GetSpoilsTypes().Contains(SpoilsTypes.Event))
					{
						bool containsNonZero = false;
						foreach (int curValue in curCard.GetBaseSkills().Values)
						{
							if (curValue != 0)
							{
								containsNonZero = true;
							}
						}
						Assert.IsTrue(containsNonZero);
					}
				}

				//Ensure that for the # of conditional abilities, there are equal numbers of times, uses, and discards.
				int sizeOfConditionals = DefaultSpoilsDeck[i].GetConditionalGains().Count;
				Assert.AreEqual(sizeOfConditionals, curCard.GetNumberOfUses().Count);
				Assert.AreEqual(sizeOfConditionals, curCard.GetWhenUsable().Count);
				Assert.AreEqual(sizeOfConditionals, curCard.GetDiscard().Count);

				Assert.IsTrue(curCard.GetD6Options().Count == 0 || curCard.GetD6Options().Count == 6);

				Assert.IsTrue(curCard.GetD10Options().Count == 0 || curCard.GetD10Options().Count == 10);

				Assert.IsTrue(curCard.GetSellValue() >= 0);

				Assert.IsTrue(curCard.GetCarryWeight() >= 0);
			}

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestShuffleOnDefaultSpoilsDeck()
		{
			bool areShuffled = false;
			List<SpoilsCard> deckBeforeShuffle = deepCopy(DefaultSpoilsDeck);
			Card.ShuffleDeck(DefaultSpoilsDeck);

			for (int i = 0; i < deckBeforeShuffle.Count; i++)
			{
				if (deckBeforeShuffle[i].GetTitle() != DefaultSpoilsDeck[i].GetTitle())
				{
					areShuffled = true;
				}
			}
			Assert.IsTrue(areShuffled);

			yield return null;
		}



		private static List<T> deepCopy<T>(List<T> cards)
		{
			List<T> cardsCopy = new List<T>();
			for (int i = 0; i < cards.Count; i++)
			{
				cardsCopy.Add(cards[i]);
			}

			return cardsCopy;
		}
	}
}