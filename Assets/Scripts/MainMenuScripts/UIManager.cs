using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public enum MenuStates {Main, Options, NewGame, ContinueGame, MultiplayerGame};
	public MenuStates currentState;

	public GameObject mainMenu;
	public GameObject optionsMenu;
	public GameObject newGameMenu;
	public GameObject continueGameMenu;
	public GameObject multiplayerMenu;

	public Image townPlayMatImage;
	public Image townMapImage;

	//For new game menu
	private int curTownPlayMatNum;
	private bool isFront;
	private bool wasChanged;
	public int numFactions;

	void Start() {
		curTownPlayMatNum = 1;
		isFront = true;
		wasChanged = true;
		updateTownPlayMatDisplay();
	}

	//When script first starts
	void Awake(){
		currentState = MenuStates.Main;
	}

	void Update() {
		//Checks current menu state
		switch (currentState) {
			case MenuStates.Main:
				mainMenu.SetActive(true);
				optionsMenu.SetActive(false);
				newGameMenu.SetActive(false);
				continueGameMenu.SetActive(false);
				multiplayerMenu.SetActive(false);
				break;
			case MenuStates.NewGame:
				mainMenu.SetActive (false);
				optionsMenu.SetActive (false);
				newGameMenu.SetActive (true);
				continueGameMenu.SetActive (false);
				multiplayerMenu.SetActive (false);
				if(wasChanged) updateTownPlayMatDisplay (); //Update which town play mat is currently displaying if changes were made
				break;
			case MenuStates.Options:
				mainMenu.SetActive(false);
				optionsMenu.SetActive(true);
				newGameMenu.SetActive(false);
				continueGameMenu.SetActive(false);
				multiplayerMenu.SetActive(false);
				break;
			case MenuStates.ContinueGame:
				mainMenu.SetActive(false);
				optionsMenu.SetActive(false);
				newGameMenu.SetActive(false);
				continueGameMenu.SetActive(true);
				multiplayerMenu.SetActive(false);
				break;
			case MenuStates.MultiplayerGame:
				mainMenu.SetActive(false);
				optionsMenu.SetActive(false);
				newGameMenu.SetActive(false);
				continueGameMenu.SetActive(false);
				multiplayerMenu.SetActive(true);
				break;
			default:
				//Default will be to show the main menu in case of error
				mainMenu.SetActive(true);
				optionsMenu.SetActive(false);
				newGameMenu.SetActive(false);
				continueGameMenu.SetActive(false);
				break;
		}
	}


	/*
	 * MAIN MENU METHODS
	 */
	// When new game button is pressed
	public void onNewGame(){
		Debug.Log ("New game");
		currentState = MenuStates.NewGame;
		//asyncSceneLoad("GameScene");
	}

	// When continue game button is pressed
	public void onContinueGame() {
		currentState = MenuStates.ContinueGame;
		Debug.Log ("Continue game");
	}

	// When options button is pressed
	public void onOptions() {
		currentState = MenuStates.Options;
		Debug.Log ("Options");
	}

	// When multiplayer button is pressed
	public void onMultiplayer() {
		currentState = MenuStates.MultiplayerGame;
		Debug.Log ("Multiplayer");
	}

	// When quit button is pressed
	public void onQuit() {
		Debug.Log ("Quit");
	}


	/*
	 * NEW GAME METHODS
	 */
	//When the previous town play mat arrow is pressed
	public void onPreviousTPM(){
		//Decrement the current mat number
		if (curTownPlayMatNum == 1) {
			curTownPlayMatNum = numFactions;
		} else {
			curTownPlayMatNum--;
		}
		isFront = true; //Show the front of the new card
		wasChanged = true; //Mark that changes were made
	}

	//When the next town play mat arrow is pressed
	public void onNextTPM() {
		//Increment the current mat number
		if (curTownPlayMatNum == numFactions) {
			curTownPlayMatNum = 1;
		} else {
			curTownPlayMatNum++;
		}
		isFront = true; //Show the front of the new card
		wasChanged = true; //NMark that changes were made
	}

	//When flip card button is pressed
	public void onFlip() {
		isFront = !isFront; //Flip the state
		wasChanged = true;
	}



	/*
	 * UNIVERSAL METHODS
	 */
	//When the back button is pressed
	public void onBack(){
		currentState = MenuStates.Main;
	}

	// Used to load a scene by name TODO: Put inside helper function file?
	private void asyncSceneLoad(string name){
		SceneManager.LoadSceneAsync(name);
	}

	// Used to load in new town play mat and display it
	public void updateTownPlayMatDisplay() {
		//Form string for play mat name
		string name = "TownPlayMats/TPM" + curTownPlayMatNum.ToString();
		if (isFront) {
			name += "Front";
		} else {
			name += "Back";
		}

		//Load it
		Sprite img = (Sprite)Resources.Load<Sprite>(name);

		//Apply it
		townPlayMatImage.sprite = img;

		//Form string for map image
		name = "FactionMapLocations/Map" + curTownPlayMatNum.ToString();

		//Load it
		img = (Sprite)Resources.Load<Sprite>(name);

		//Apply it
		townMapImage.sprite = img;

		//No more changes to account for
		wasChanged = false;
	}
}

