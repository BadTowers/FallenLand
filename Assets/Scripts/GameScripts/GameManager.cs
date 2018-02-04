﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<SpoilsCard> spoilsCards;
	public GameObject cardPrefab;
	private int numHumanPlayers;
	private int numComputerPlayers;
	private GameMode gameMode;
	private List<GameModifier> modifiers;
	private SoloII soloIIDifficulty;




	void Start(){
		//Get the game object from the main menu that knows the game mode, all the modifiers, and the factions picked
		GameObject newGameState = GameObject.Find("GameCreation");
		//Debug.Log(newGameState.GetComponent<GameCreation>().gameMode);
		if (newGameState != null) {
			newGameState.GetComponent<GameCreation> ().wasRead = true; //Mark as read so the game object can be deleted

			//Debug.Log(newGameState.GetComponent<GameCreation>().faction);

			//Grab the game mode
			gameMode = newGameState.GetComponent<GameCreation>().mode;

			//Extract the Solo II difficulty if needed
			if(gameMode == GameMode.SoloII) {
				soloIIDifficulty = newGameState.GetComponent<GameCreation>().soloIIDifficulty;
			}


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
		spoilsCards = Card.shuffleDeck(spoilsCards);

		for(int i = 0; i < spoilsCards.Count; i++) {
			Debug.Log(spoilsCards[i].getID());
		}


		//TODO create the deck of character cards


		//TODO create the deck of action cards


		//TODO create the deck of mission cards


		//TODO create the deck of plains cards


		//TODO create the deck of mountain cards


		//TODO create the deck of city/rad cards


		//TODO deal cards to player(s)

	}

}
