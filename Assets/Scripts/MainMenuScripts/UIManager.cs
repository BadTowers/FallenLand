﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public enum MenuStates {Main, Options, NewGame, ContinueGame, MultiplayerGame};
	public MenuStates currentState;

	//Menu game objects
	public GameObject mainMenu;
	public GameObject optionsMenu;
	public GameObject newGameMenu;
	public GameObject continueGameMenu;
	public GameObject multiplayerMenu;

	//List of all menu game objects
	private List<GameObject> menus;

	//For new game
	public Image townLogoImage;
	public Image townSymbolImage;
	public Image townMapImage;
	public Image townTech1Image;
	public Image townTech2Image;
	public int numFactions;
	public Text townNameAndLocation;
	public Text specificPerk1Text;
	public Text specificPerk2Text;
	public Text specificPerk3Text;
	public Text specificPerk4Text;
	public Text loreText;
	public const string FACTION_MAP_LOCATION_URI = "Factions/FactionMapLocations/";
	public const string FACTION_IMAGE_URI = "Factions/FactionImage/";
	public const string FACTION_SYMBOL_URI = "Factions/FactionSymbols/";
	private int curFactionNum;
	private bool wasChanged;

	void Start() {
		//Initialize default values
		curFactionNum = 1;
		wasChanged = true;
		menus = new List<GameObject>();

		//Add all of the menu game objects to the array list
		menus.Add(mainMenu);
		menus.Add(optionsMenu);
		menus.Add(newGameMenu);
		menus.Add(continueGameMenu);
		menus.Add(multiplayerMenu);

		//Set the display up
		updateFactionDisplay();
	}

	//When script first starts
	void Awake(){
		currentState = MenuStates.Main;
	}

	void Update() {
		//Checks current menu state
		switch (currentState) {
			case MenuStates.Main:
				setActiveMenu(mainMenu);
				break;
			case MenuStates.NewGame:
				setActiveMenu(newGameMenu);
				if(wasChanged) updateFactionDisplay (); //Update which town play mat is currently displaying if changes were made
				break;
			case MenuStates.Options:
				setActiveMenu(optionsMenu);
				break;
			case MenuStates.ContinueGame:
				setActiveMenu(continueGameMenu);
				break;
			case MenuStates.MultiplayerGame:
				setActiveMenu(multiplayerMenu);
				break;
			default:
				//Default will be to show the main menu in case of error
				setActiveMenu(mainMenu);
				break;
		}
	}

	private void setActiveMenu(GameObject go) {
		go.SetActive(true);
		foreach (GameObject other in menus) {
			if (!other.Equals(go)) {
				other.SetActive (false);
			}
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
	public void onPrevious(){
		//Decrement the current mat number
		if (curFactionNum == 1) {
			curFactionNum = numFactions;
		} else {
			curFactionNum--;
		}
		wasChanged = true; //Mark that changes were made
	}

	//When the next town play mat arrow is pressed
	public void onNext() {
		//Increment the current mat number
		if (curFactionNum == numFactions) {
			curFactionNum = 1;
		} else {
			curFactionNum++;
		}
		wasChanged = true; //NMark that changes were made
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

	// Used to load in new faction and display it
	public void updateFactionDisplay() {
		//Load it
		Sprite img = (Sprite)Resources.Load<Sprite>(FACTION_IMAGE_URI + "FactionImage" + curFactionNum.ToString());

		//Apply it
		if (townLogoImage != null) {
			townLogoImage.sprite = img;
		} else {
			Debug.Log ("Town logo image container not set");
		}

		//Load it
		img = (Sprite)Resources.Load<Sprite>(FACTION_SYMBOL_URI + "FactionSymbol" + curFactionNum.ToString());

		//Apply it
		if (townSymbolImage != null) {
			townSymbolImage.sprite = img;
		} else {
			Debug.Log ("Town symbol image container not set");
		}

		//Load it
		img = (Sprite)Resources.Load<Sprite>(FACTION_MAP_LOCATION_URI + "Map" + curFactionNum.ToString());

		//Apply it
		if (townMapImage != null) {
			townMapImage.sprite = img;
		} else {
			Debug.Log ("Town map image container not set");
		}

		Factions.name curFac = Factions.getFaction(curFactionNum);

		//Set up town name and location
		if (townNameAndLocation != null) {
			townNameAndLocation.text = Factions.getName(curFac) + "\n" + Factions.getStartingLocation(curFac);
		} else {
			Debug.Log("Town name and location container not set");
		}

		//Set up the perk texts
		if (specificPerk1Text != null) {
			specificPerk1Text.text = Factions.getPerk1Title(curFac) + ": " + Factions.getPerk1Text(curFac);
		} else {
			Debug.Log("Perk 1 text container not set");
		}
		if (specificPerk2Text != null) {
			specificPerk2Text.text = Factions.getPerk2Title(curFac) + ": " + Factions.getPerk2Text(curFac);
		} else {
			Debug.Log("Perk 2 text container not set");
		}
		if (specificPerk3Text != null) {
			specificPerk3Text.text = Factions.getPerk3Title(curFac) + ": " + Factions.getPerk3Text(curFac);
		} else {
			Debug.Log("Perk 3 text container not set");
		}
		if (specificPerk4Text != null) {
			specificPerk4Text.text = Factions.getPerk4Title(curFac) + ": " + Factions.getPerk4Text(curFac);
		} else {
			Debug.Log("Perk 4 text container not set");
		}

		//Set up town lore
		if (loreText != null) {
			loreText.text = Factions.getLore(curFac);
		} else {
			Debug.Log("Lore text container not set");
		}

		//No more changes to account for
		wasChanged = false;
	}
}
