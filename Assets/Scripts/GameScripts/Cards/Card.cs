using System.Collections;
using System.Collections.Generic;

public abstract class Card {


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

	private string title;
	private int id;

	protected Card(string title){
		this.title = title;
	}

	public string getTitle(){
		return title;
	}

	public int getID(){
		return this.id;
	}

	public void setID(int id){
		this.id = id;
	}

	public List<SpoilsCard> shuffleDeck(){
		//TODO implement shuffle
	}

}
