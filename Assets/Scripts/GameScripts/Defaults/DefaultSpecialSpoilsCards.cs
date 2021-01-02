using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class DefaultSpecialSpoilsCards
	{
		private List<SpoilsCard> SpecialSpoilsCardsDeck;

		public DefaultSpecialSpoilsCards()
		{
			//Initialize the lists for the cards
			SpecialSpoilsCardsDeck = new List<SpoilsCard>();

			//Add the cards to the list
			SpoilsCard curCard;
			int curID = 1000; //Special cards will start here

			Debug.Log("Instantiating special spoils cards...");


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Alpha Centauri Armor");
			curCard.SetSpoilsTypes(SpoilsTypes.Armor, SpoilsTypes.Special);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 4},
				{Skills.Diplomacy, 4},
				{Skills.Mechanical, 4},
				{Skills.Technical, 10},
				{Skills.Medical, 4}
			});
			//Add one armor when equipped
			//lose one armor when unequipped
			curCard.SetId(curID);
			curID++;
			SpecialSpoilsCardsDeck.Add(curCard); //Add the card to the list of all cards
		}


		public List<SpoilsCard> GetSpoilsCards()
		{
			return SpecialSpoilsCardsDeck;
		}
	}
}