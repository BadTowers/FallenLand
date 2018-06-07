using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	//UI containers
	public Image spoilsCard1; //TODO delete/rework. Just for testing. MOVE TO GAME UI MANAGER

	private List<SpoilsCard> spoilsDeck = new List<SpoilsCard>();
	private List<SpoilsCard> discardSpoilsDeck = new List<SpoilsCard>();
	private List<CharacterCard> characterDeck = new List<CharacterCard>();
	private List<CharacterCard> discardCharacterDeck = new List<CharacterCard>();
	private List<ActionCard> actionDeck = new List<ActionCard>();
	private List<ActionCard> discardActionDeck = new List<ActionCard>();
	public GameObject cardPrefab;
	private int numHumanPlayers;
	private int numComputerPlayers;
	private GameInformation.GameModes gameMode;
	private List<GameInformation.GameModifier> modifiers = new List<GameInformation.GameModifier>();
	private GameInformation.SoloII soloIIDifficulty;
	private List<Player> players = new List<Player>();
	private int startingActionCards = 3;
	private int startingCharacterCards = 6;
	private int startingSpoilsCards = 10;
	private int maxActionCards = 7;
	private int maxCharacterCards = -1;
	private int maxSpoilsCards = -1;
	private List<TownTech> techs;
	private List<int> techsUsed;
	private int maxOfEachTech = 5;



	void Start(){
		//Get the game object from the main menu that knows the game mode, all the modifiers, and the factions picked
		GameObject newGameState = GameObject.Find("GameCreation");

		//Debug.Log(newGameState.GetComponent<GameCreation>().gameMode); //Debug thingy

		if (newGameState != null) {
			//Mark as read so the game object can be deleted
			newGameState.GetComponent<GameCreation> ().wasRead = true;

			//Debug.Log(newGameState.GetComponent<GameCreation>().faction); //Debug thingy

			//Grab the game mode
			gameMode = newGameState.GetComponent<GameCreation>().mode;

			//Extract the Solo II difficulty if needed
			if(gameMode == GameInformation.GameModes.SoloII) {
				soloIIDifficulty = newGameState.GetComponent<GameCreation>().soloIIDifficulty;
			}

			//Set the number of human and computer players
			numHumanPlayers = GameInformation.getHumanPlayerCount(gameMode);
			numComputerPlayers = GameInformation.getComputerPlayerCount(gameMode);

			//Add the players to the list (TODO: Change so later these are added in the order players will go (after dice roll or something))
			for(int i = 0; i < numHumanPlayers; i++) {
				players.Add(new HumanPlayer());
			}
			for(int i = 0; i < numComputerPlayers; i++) {
				players.Add(new ComputerPlayer());
			}

			//Interpret any modifiers
			//TODO


		} else {
			Debug.Log ("Game info not received from game setup.");
			//TODO remove debug thing
			players.Add(new HumanPlayer());
		}


		//Create the map layout according to the game state that was passed in
		GameObject mapCreationGO = GameObject.Find("Map");
		MapCreation mapCreation = mapCreationGO.GetComponent<MapCreation>();
		mapCreation.ml = new DefaultMapLayout(); //For now, just do the default. Can be modified later. TODO account for modifiers
		mapCreation.createMap();


		//Create the deck of spoils cards
		DefaultSpoilsCards tempSpoils = new DefaultSpoilsCards();
		spoilsDeck = tempSpoils.getSpoilsCards();
		tempSpoils = null; //Clear it for garbage collection
		spoilsDeck = Card.shuffleDeck(spoilsDeck);

		/*
		//Proof of shuffle
		for(int i = 0; i < spoilsCards.Count; i++) {
			Debug.Log(spoilsCards[i].getID());
		}
		*/


		//Create the deck of character cards
		DefaultCharacterCards tempCharacters = new DefaultCharacterCards();
		characterDeck = tempCharacters.getCharacterCards();
		tempCharacters = null; //Clear it for garbage collection
		characterDeck = Card.shuffleDeck(characterDeck);


		//Create the deck of action cards
		DefaultActionCards tempActions = new DefaultActionCards();
		actionDeck = tempActions.getActionCards();
		tempActions = null; //Clear it for garbage collection
		actionDeck = Card.shuffleDeck(actionDeck);


		//TODO create the deck of mission cards


		//TODO create the deck of plains cards


		//TODO create the deck of mountain cards


		//TODO create the deck of city/rad cards


		//TODO deal cards to player(s)
		//Spoils
		for(int i = 0; i < startingSpoilsCards; i++) {
			for(int j = 0; j < players.Count; j++) {
				players[j].addSpoilsCard(spoilsDeck[0]); //Add the first card to the next player's hand
				spoilsDeck.RemoveAt(0); //Remove that card from the deck of cards
			}
		}
		//Character
		for(int i = 0; i < startingCharacterCards; i++) {
			for(int j = 0; j < players.Count; j++) {
				players[j].addCharacterCard(characterDeck[0]);
				characterDeck.RemoveAt(0);
			}
		}
		//Action
		for(int i = 0; i < startingActionCards; i++) {
			for(int j = 0; j < players.Count; j++) {
				players[j].addActionCard(actionDeck[0]);
				actionDeck.RemoveAt(0);
			}
		}
			
		//DEBUG THINGY TODO
		//Display cards
		Debug.Log(players[0].getActiveSpoilsCards().Count);
		//for(int i = 0; i < startingActionCards; i++) {
			string fileName = "Cards/SpoilsCards/SpoilsCard" + players[0].getActiveSpoilsCard(0).getID().ToString(); //TODO don't hardcode to player[0]
		Debug.Log(fileName);
		Sprite curSprite = Resources.Load<Sprite>(fileName);
		if(curSprite == null) {
			Debug.Log("null");
		}
		spoilsCard1.sprite = curSprite;
		//}

		//TODO get a list of all town techs and count how many are in play based on which ones each playing faction has
		techs = (new DefaultTownTechs()).getDefaultTownTechList();
		techsUsed = new List<int>();
		for(int i = 0; i < techs.Count; i++){
			techsUsed.Add(0);
		}
	}


	void Update(){

	}

}
