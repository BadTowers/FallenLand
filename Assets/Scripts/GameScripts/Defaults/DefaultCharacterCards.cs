using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class DefaultCharacterCards
	{
		private List<CharacterCard> CharacterCards;

		public DefaultCharacterCards()
		{
			CharacterCards = new List<CharacterCard>();

			//Add the cards to the list
			CharacterCard curCard;

			Debug.Log("Instantiating character cards...");

			//TODO

			//placeholder. inserts a bunch of blanks DEBUG THINGY
			for (int i = 0; i < 80; i++)
			{
				curCard = new CharacterCard("test " + i.ToString());
				CharacterCards.Add(curCard);
			}
		}

		public List<CharacterCard> GetCharacterCards()
		{
			return CharacterCards;
		}
	}

}