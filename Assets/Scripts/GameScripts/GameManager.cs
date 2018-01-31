using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<SpoilsCard> spoilsCards;




	void Start(){
		//Get the game object from the main menu that knows the game mode, all the modifiers, and the factions picked
		GameObject newGameState = GameObject.Find("GameCreation");
		/* TODO actually do something with this information */
		//Debug.Log(newGameState.GetComponent<GameCreation>().gameMode);
		if (newGameState != null) {
			newGameState.GetComponent<GameCreation> ().wasRead = true; //Mark as read so the game object can be deleted
			Debug.Log(newGameState.GetComponent<GameCreation>().faction);
		} else {
			Debug.Log ("Game info not received from game setup");
		}

		//Create the map layout according to the game state that was passed in
		GameObject mapCreationGO = GameObject.Find("Map");
		MapCreation mapCreation = mapCreationGO.GetComponent<MapCreation>();
		mapCreation.ml = new DefaultMapLayout(); //For now, just do the default. Can be modified later
		mapCreation.createMap();

		//Create the deck of spoils cards
		DefaultSpoilsCards temp = new DefaultSpoilsCards();
		spoilsCards = temp.getSpoilsCards();
		temp = null; //Clear it for garbage collection

	}

}
