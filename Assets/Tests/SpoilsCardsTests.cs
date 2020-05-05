using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using UnityEngine;

namespace Tests
{
	public class SpoilsCardsTests
	{
		[UnityTest]
		public IEnumerator TestDefaultSpoilsCards()
		{
			/* Create an instance of the default cards deck */
			DefaultSpoilsCards dsc = new DefaultSpoilsCards();
			List<SpoilsCard> defaultCards = dsc.getSpoilsCards();

			yield return null; //Wait for one frame

			/* Check assertions */
			for(int i = 0; i < defaultCards.Count; i++) { //For all cards

				SpoilsCard curCard = defaultCards[i];
				Debug.Log("Card " + i + " title " + curCard.GetTitle());


				//Ensure all the lists in the class are not null
				Assert.IsNotNull(curCard.getAttachments());
				Assert.IsNotNull(curCard.getBaseSkills());
				Assert.IsNotNull(curCard.getConditionalGains());
				Assert.IsNotNull(curCard.getD10Options());
				Assert.IsNotNull(curCard.getD6Options());
				Assert.IsNotNull(curCard.getDiscard());
				Assert.IsNotNull(curCard.getNumberOfUses());
				Assert.IsNotNull(curCard.getRestrictions());
				Assert.IsNotNull(curCard.getStaticGains());
				Assert.IsNotNull(curCard.getTypes());
				Assert.IsNotNull(curCard.getWhenUsable());


				//There exists at least one type on the card
				Assert.IsTrue(defaultCards[i].getTypes().Count > 0);

				//If it isn't an event card, ensure all cards have at least one non-zero base skill
				if (curCard.GetTitle() != "Designer Biker Leathers" && curCard.GetTitle() != "Fallen Land Board Game") //These cards have no stats
				{
					if (!curCard.getTypes().Contains(SpoilsTypes.Event))
					{
						bool containsNonZero = false;
						foreach (int curValue in curCard.getBaseSkills().Values)
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
				int sizeOfConditionals = defaultCards[i].getConditionalGains().Count;
				Assert.AreEqual(sizeOfConditionals, curCard.getNumberOfUses().Count);
				Assert.AreEqual(sizeOfConditionals, curCard.getWhenUsable().Count);
				Assert.AreEqual(sizeOfConditionals, curCard.getDiscard().Count);
				//Assert.AreEqual(sizeOfConditionals, curCard.getRestrictions().Count);


				//Ensure that the d6 cards are either 0 or 6
				Assert.IsTrue(curCard.getD6Options().Count == 0  || curCard.getD6Options().Count == 6);


				//Ensure the d10 cards are either 0 or 10
				Assert.IsTrue(curCard.getD10Options().Count == 0  || curCard.getD10Options().Count == 10);


				//Ensure it has a non-negative sell value
				Assert.IsTrue(curCard.getSellValue() >= 0);


				//Ensure it has a non-negative carry weight
				Assert.IsTrue(curCard.getCarryWeight() >= 0);
			}
		}
	}
}