using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System;
using UnityEngine;

namespace FallenLand
{
	public abstract class Card : MonoBehaviour
	{
		/*
									 Cards
								   /       \
						Encounters          Nonencounters
					  / |    \     \              |     \
					 /  |     \     \             |      \
					/   |      \     \            |       \
				   /    |       \     \           |        \
			 Mission   Plains   Rad   Mountain   Party      Nonparty
												 |   |          |
										 Character    Spoils    Action
		*/

		private string Title;
		private int Id;

		protected Card(string title)
		{
			this.Title = title;
		}

		public string GetTitle()
		{
			return Title;
		}

		public void SetTitle(string title)
		{
			Title = title;
		}

		public int GetId()
		{
			return this.Id;
		}

		public void SetId(int id)
		{
			this.Id = id;
		}

		public static List<T> ShuffleDeck<T>(List<T> cards)
		{
			List<T> cardsBefore = deepCopy(cards);
			RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
			byte[] byteArray1 = new byte[1];
			byte[] byteArray2 = new byte[1];
			bool isShuffled = false;

			while (!isShuffled)
			{
				for (int i = 0; i < 10; i++)
				{
					for (int j = 0; j < cards.Count; j++)
					{
						provider.GetBytes(byteArray1); //Get a byte from the RNG service
						provider.GetBytes(byteArray2);
						int randInt1 = Convert.ToInt32(byteArray1[0]); //Convert the byte to an integer
						int randInt2 = Convert.ToInt32(byteArray2[0]);
						randInt1 = Math.Abs(randInt1 % cards.Count); //Put it within the bounds of the deck
						randInt2 = Math.Abs(randInt2 % cards.Count);

						//Swap the two cards
						T temp = cards[randInt1];
						cards[randInt1] = cards[randInt2];
						cards[randInt2] = temp;
					}
				}
				if (cardsAreReordered(cardsBefore, cards))
				{
					isShuffled = true;
				}
			}

			return cards;
		}

		private static bool cardsAreReordered<T>(List<T> deck1, List<T> deck2)
		{
			bool areReordered = false;
			if (deck1.Count == deck2.Count)
			{
				for (int i = 0; i < deck1.Count; i++)
				{
					if (deck1[i].GetHashCode() != deck2[i].GetHashCode())
					{
						areReordered = true;
					}
				}
			}

			return areReordered;
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