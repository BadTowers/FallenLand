using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using UnityEngine;

namespace Tests
{
	public class DefaultSpoilsCardsTests
	{
		[UnityTest]
		public IEnumerator TestDefaultSpoilsCards()
		{
			/* Create an instance of the default cards deck */
			DefaultSpoilsCards dsc = new DefaultSpoilsCards();
			List<SpoilsCard> defaultCards = dsc.getSpoilsCards();

			yield return null;

			/* Check assertions */
			for(int i = 0; i < defaultCards.Count; i++) { //For all cards

				SpoilsCard curCard = defaultCards[i];
				Debug.Log("Testing card " + i + ": title " + curCard.GetTitle());


				//Ensure all the lists in the class are not null
				Assert.IsNotNull(curCard.GetAttachments());
				Assert.IsNotNull(curCard.GetBaseSkills());
				Assert.IsNotNull(curCard.GetConditionalGains());
				Assert.IsNotNull(curCard.GetD10Options());
				Assert.IsNotNull(curCard.GetD6Options());
				Assert.IsNotNull(curCard.GetDiscard());
				Assert.IsNotNull(curCard.GetNumberOfUses());
				Assert.IsNotNull(curCard.GetRestrictions());
				Assert.IsNotNull(curCard.GetStaticGains());
				Assert.IsNotNull(curCard.GetTypes());
				Assert.IsNotNull(curCard.GetWhenUsable());


				//There exists at least one type on the card
				Assert.IsTrue(defaultCards[i].GetTypes().Count > 0);

				//If it isn't an event card, ensure all cards have at least one non-zero base skill
				if (curCard.GetTitle() != "Designer Biker Leathers" && curCard.GetTitle() != "Fallen Land Board Game") //These cards have no stats
				{
					if (!curCard.GetTypes().Contains(SpoilsTypes.Event))
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


				//Ensure that for the # of conditional abilities, there are equal numbers of times, uses, restrictions, and discards.
				int sizeOfConditionals = defaultCards[i].GetConditionalGains().Count;
				Assert.AreEqual(sizeOfConditionals, curCard.GetNumberOfUses().Count);
				Assert.AreEqual(sizeOfConditionals, curCard.GetWhenUsable().Count);
				Assert.AreEqual(sizeOfConditionals, curCard.GetDiscard().Count);
				//Assert.AreEqual(sizeOfConditionals, curCard.getRestrictions().Count);


				//Ensure that the d6 cards are either 0 or 6
				Assert.IsTrue(curCard.GetD6Options().Count == 0  || curCard.GetD6Options().Count == 6);


				//Ensure the d10 cards are either 0 or 10
				Assert.IsTrue(curCard.GetD10Options().Count == 0  || curCard.GetD10Options().Count == 10);


				//Ensure it has a non-negative sell value
				Assert.IsTrue(curCard.GetSellValue() >= 0);


				//Ensure it has a non-negative carry weight
				Assert.IsTrue(curCard.GetCarryWeight() >= 0);
			}
		}
	}
}