using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System;

public abstract class Card
{
	/*
							     Cards
				   			   /       \
					Encounters  		 Nonencounters
				  /	|	 \     \			  |		\
				 /	|	  \	    \			  |	 	 \
				/	|	   \	 \			  |		  \
			   /    |      	\ 	  \ 		  |		   \
	 	Mission	  	Plains	Rad	  Mountain 	 Party		Nonparty
	 										 |   |		    |
	 								Character    Spoils   	Action
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
		RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
		byte[] byteArray1 = new byte[1];
		byte[] byteArray2 = new byte[1];

		for(int i = 0; i < 10; i++) { //do the shuffle algorithm this many times
			for(int j = 0; j < cards.Count; j++) {
				provider.GetBytes(byteArray1); //Get a byte from the RNG service
				provider.GetBytes(byteArray2); //Get a byte from the RNG service
				int randInt1 = Convert.ToInt32(byteArray1[0]); //Convert the byte to an integer
				int randInt2 = Convert.ToInt32(byteArray2[0]); //Convert the byte to an integer
				randInt1 = Math.Abs(randInt1 % cards.Count); //Put it within the bounds of the deck
				randInt2 = Math.Abs(randInt2 % cards.Count); //Put it within the bounds of the deck
				//Swap the two cards
				T temp = cards[randInt1];
				cards[randInt1] = cards[randInt2];
				cards[randInt2] = temp;
			}
		}

		return cards;
	}

}
