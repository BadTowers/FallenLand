using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class DefaultActionCards
	{
		private Dictionary<string, int> multiples = new Dictionary<string, int>()
		{
			{"Reversal", 2}
		};

		private List<ActionCard> ActionCards;

		public DefaultActionCards()
		{
			ActionCards = new List<ActionCard>();

			ActionCard curCard;
			int curID = 0;

			Debug.Log("Instantiating action cards...");

			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Interrogation");
			curCard.SetSellValue(5);
			//TODO phase
			//TODO actions
			curCard.SetId(curID);
			curID++;
			ActionCards.Add(curCard); //Add the card to the list of all cards


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Reversal");
			curCard.SetSellValue(6);
			//TODO phase
			//TODO actions
			curCard.SetId(curID);
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Just Plain Ugly");
			curCard.SetId(curID);
			curCard.SetSellValue(7);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Propaganda Corps");
			curCard.SetId(curID);
			curCard.SetSellValue(8);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Subterfuge");
			curCard.SetId(curID);
			curCard.SetSellValue(6);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("A Cunning Trap");
			curCard.SetId(curID);
			curCard.SetSellValue(5);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Enlightenment");
			curCard.SetId(curID);
			curCard.SetSellValue(7);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Genocide");
			curCard.SetId(curID);
			curCard.SetSellValue(5);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Extremist Cult Influx");
			curCard.SetId(curID);
			curCard.SetSellValue(6);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Break Down");
			curCard.SetId(curID);
			curCard.SetSellValue(5);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Mechanically Inclined");
			curCard.SetId(curID);
			curCard.SetSellValue(1);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Survival Instincts");
			curCard.SetId(curID);
			curCard.SetSellValue(1);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Spy Master");
			curCard.SetId(curID);
			curCard.SetSellValue(14);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Safe Haven");
			curCard.SetId(curID);
			curCard.SetSellValue(6);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("The Gamble");
			curCard.SetId(curID);
			curCard.SetSellValue(3);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Retribution");
			curCard.SetId(curID);
			curCard.SetSellValue(5);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("An Act of Terror");
			curCard.SetId(curID);
			curCard.SetSellValue(5);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Mysterious Serum");
			curCard.SetId(curID);
			curCard.SetSellValue(6);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Unscrupulous Bargain");
			curCard.SetId(curID);
			curCard.SetSellValue(5);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Town Technology");
			curCard.SetId(curID);
			curCard.SetSellValue(25);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Heinous Atrocities");
			curCard.SetId(curID);
			curCard.SetSellValue(9);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new ActionCard("Heist");
			curCard.SetId(curID);
			curCard.SetSellValue(3);
			//TODO phase
			//TODO actions
			curID++;
			ActionCards.Add(curCard);
		}

		public List<ActionCard> GetActionCards()
		{
			return ActionCards;
		}
	}
}
