using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIManager : UIManager {

	public enum MainMenuStates {Main, Options, SinglePlayer, SetUpNewGame, MultiplayerGame};
	public MainMenuStates currentState;

	//Menu game objects
	public GameObject mainMenu;
	public GameObject optionsMenu;
	public GameObject singlePlayerMenu;
	public GameObject setUpNewGameMenu;
	public GameObject multiplayerMenu;

	//List of all things to randomize

	//For set up new game
	public Image townLogoImage;
	public Image townSymbolImage;
	//public Image townMapImage; //Currently unused
	public Image townTech1Image;
	public Image townTech2Image;
	public int numFactions;
	public int numSinglePlayerGameModes;
	public int numSoloIIDifficulties;
	public Text townNameAndLocation;
	public Text specificPerk1Text;
	public Text specificPerk2Text;
	public Text specificPerk3Text;
	public Text specificPerk4Text;
	public Text loreText;
	public Scrollbar loreScrollBar;
	public const string FACTION_MAP_LOCATION_URI = "Factions/FactionMapLocations/";
	public const string FACTION_IMAGE_URI = "Factions/FactionImage/";
	public const string FACTION_SYMBOL_URI = "Factions/FactionSymbols/";
	public const string TOWN_TECH_IMAGE_URI = "Chips/TownTechs/";
	public GameObject gameModeToggleGroup;
	public Text gameModeInfoText;
	public GameObject soloIIDifficultyToggleGroup;
	public const int SOLO_I_BUTTON_NUM = 0;
	public const int SOLO_II_BUTTON_NUM = 1;
	public GameObject modifiersContainer;
	private int curFactionNum;
	private bool factionWasChanged;
	private bool gameModeWasChanged;

	void Start() {
		//Initialize default values
		curFactionNum = 1;
		factionWasChanged = true;
		gameModeWasChanged = true;

		//Add all of the menu game objects to the array list (ADD NEW MENU PANELS HERE)
		addToMenuList(mainMenu);
		addToMenuList(optionsMenu);
		addToMenuList(singlePlayerMenu);
		addToMenuList(setUpNewGameMenu);
		addToMenuList(multiplayerMenu);

		//Set the display up
		updateFactionDisplay();
	}

	//When script first starts
	void Awake(){
		currentState = MainMenuStates.Main;
	}

	void Update() {
		//Checks current menu state
		switch (currentState) {
			case MainMenuStates.Main:
				setActiveMenu(mainMenu);
				break;
			case MainMenuStates.SinglePlayer:
				setActiveMenu (singlePlayerMenu);
				break;
			case MainMenuStates.SetUpNewGame:
				setActiveMenu(setUpNewGameMenu);
				if(factionWasChanged){
					updateFactionDisplay (); //Update which faction is currently displaying if a new one was selected
				}
				if(gameModeWasChanged){
					updateGameModeDisplay(); //Update the game mode information if a different one was selected
				}
				break;
			case MainMenuStates.Options:
				setActiveMenu(optionsMenu);
				break;
			case MainMenuStates.MultiplayerGame:
				setActiveMenu(multiplayerMenu);
				break;
			default:
				//Default will be to show the main menu in case of error
				setActiveMenu(mainMenu);
				break;
		}
	}



	/*
	 * MAIN MENU METHODS
	 */
	// When new game button is pressed
	public void onSinglePlayer(){
		Debug.Log ("Single Player");
		currentState = MainMenuStates.SinglePlayer;
		//asyncSceneLoad("GameScene");
	}

	// When options button is pressed
	public void onOptions() {
		currentState = MainMenuStates.Options;
		Debug.Log ("Options");
	}

	// When multiplayer button is pressed
	public void onMultiplayer() {
		currentState = MainMenuStates.MultiplayerGame;
		Debug.Log ("Multiplayer");
	}

	// When quit button is pressed
	public void onQuit() {
		//TODO Make this actually quit lel
		Debug.Log ("Quit");
	}


	/*
	 * NEW GAME METHODS
	 */
	//When start default game button is pressed
	public void onStartDefault(){
		//TODO
		Debug.Log("Start default");
	}

	//When set up new game button is pressed
	public void onSetUpGame() {
		currentState = MainMenuStates.SetUpNewGame;
	}

	//When load game button is pressed
	public void onLoadGame() {
		//TODO
		Debug.Log ("Load game");
	}

	//When tutorial button is pressed
	public void onTutorial() {
		//TODO
		Debug.Log("Tutorial");
	}


	/*
	 * SET UP NEW GAME METHODS
	 */
	//When the previous town play mat arrow is pressed
	public void onPrevious(){
		//Decrement the current mat number
		if (curFactionNum == 1) {
			curFactionNum = numFactions;
		} else {
			curFactionNum--;
		}
		factionWasChanged = true; //Mark that changes were made
	}

	//When the next town play mat arrow is pressed
	public void onNext() {
		//Increment the current mat number
		if (curFactionNum == numFactions) {
			curFactionNum = 1;
		} else {
			curFactionNum++;
		}
		factionWasChanged = true; //NMark that changes were made
	}

	//When game mode toggle changes
	public void onGameModeChange(){
		gameModeWasChanged = true;
	}

	//When randomize button is pressed (on secure random numbers https://stackify.com/csharp-random-numbers/)
	public void onRandomize() {

		//Collect all the modifier toggles from the container
		Toggle[] modifierToggles = modifiersContainer.GetComponentsInChildren<Toggle> ();

		/* Randomly pick a faction */
		RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
		byte[] byteArray = new byte[1];
		provider.GetBytes (byteArray);
		int randInt = Convert.ToInt32(byteArray[0]);
		curFactionNum = Math.Abs(((randInt) % (numFactions)) + 1);
		//Debug.Log ("FAC: " + curFactionNum.ToString ());
		factionWasChanged = true;

		/* Randomly pick game mode */
		//Game mode first
		provider = new RNGCryptoServiceProvider();
		byteArray = new byte[1];
		provider.GetBytes (byteArray);
		randInt = Convert.ToInt32(byteArray[0]);
		int randNum = Math.Abs((randInt) % numSinglePlayerGameModes);
		//Debug.Log ("MODE: " + randNum.ToString ());
		gameModeToggleGroup.GetComponentsInChildren<Toggle>()[randNum].isOn = true;
		//Difficulty too (if not needed, it won't show up in the UI)
		//Turn them all off first
		foreach (Toggle diffToggle in soloIIDifficultyToggleGroup.GetComponentsInChildren<Toggle>()) {
			diffToggle.isOn = false;
		}
		byteArray = new byte[1];
		provider.GetBytes(byteArray);
		randInt = Convert.ToInt32(byteArray[0]);
		randNum = Math.Abs((randInt) % numSoloIIDifficulties);
		//Debug.Log("DIFF: " + randNum.ToString ());
		soloIIDifficultyToggleGroup.GetComponentsInChildren<Toggle>()[randNum].isOn = true;
		gameModeWasChanged = true;

		/* Randomly pick the modifiers */
		foreach(Toggle modifier in modifierToggles) {
			//First turn off the modifer
			modifier.isOn = false;

			//Generate a random number to determine if we should turn on a modifer
			provider = new RNGCryptoServiceProvider();
			byteArray = new byte[1];
			provider.GetBytes(byteArray);
			randInt = Convert.ToInt32(byteArray[0]);
			if(randInt % 2 == 0) {
				modifier.isOn = true;
				//If this modifier toggle is dependent on another, the checkIfParentActive method checks that the parent is on before turning the dependent child on
				if (modifier.GetComponentInChildren<ToggleDependency>() != null) {
					modifier.GetComponentInChildren<ToggleDependency>().checkIfParentActive ();
				}
			}
		}

		//Collect all dependent modifiers
	}

	//When start button is pressed
	public void onStartGameFromSetup() {
		/****** Pass all information from this screen into the game creation object ********/


		//Faction (Find the game creation object in the scene and then get the script from it
		GameObject.Find("GameCreation").GetComponentInChildren<GameCreation>().faction = Factions.getFactionName(curFactionNum);

		//Game mode
		foreach (Toggle curModeToggle in gameModeToggleGroup.GetComponentsInChildren<Toggle>()) {
			if (curModeToggle.isOn) {
				GameObject.Find("GameCreation").GetComponentInChildren<GameCreation>().mode = curModeToggle.GetComponentInChildren<ToggleInformation>().mode;
			}
		}

		//Solo II difficulty if needed
		foreach (Toggle curDiffToggle in soloIIDifficultyToggleGroup.GetComponentsInChildren<Toggle>()) {
			if (curDiffToggle.isOn) {
				GameObject.Find("GameCreation").GetComponentInChildren<GameCreation>().soloIIDifficulty = curDiffToggle.GetComponentInChildren<ToggleInformation>().soloIIDifficulty;
			}
		}

		//Game modifiers
		foreach (Toggle modifier in modifiersContainer.GetComponentsInChildren<Toggle>()) {
			if (modifier.isOn) {
				GameObject.Find("GameCreation").GetComponentInChildren<GameCreation>().modifiers.Add(modifier.GetComponentInChildren<ToggleInformation>().modifier);
			}
		}

		//Load the next scene to start the game
		asyncSceneLoad("GameScene");
	}


	/*
	 * UNIVERSAL METHODS
	 */
	//When the back button is pressed
	public void onBack(){
		currentState = MainMenuStates.Main;
	}

	// Used to load a scene by name TODO: Put inside helper function file?
	private void asyncSceneLoad(string name){
		SceneManager.LoadSceneAsync(name);
	}

	// Used to load in new faction and display it
	private void updateFactionDisplay() {
		//Set the current faction
		Factions.name curFac = Factions.getFactionName(curFactionNum);

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
		//Move the lore back to the top when the faction switches
		loreScrollBar.value = 1;

		//Set up town techs
		//Load tech 1
		img = (Sprite)Resources.Load<Sprite>(TOWN_TECH_IMAGE_URI + "TownTech" + TownTechs.getTownTechNumber(Factions.getTownTech1(curFac)).ToString());
		//Apply it
		if (townTech1Image != null) {
			townTech1Image.sprite = img;
		} else {
			Debug.Log ("Town tech image 1 container not set");
		}
		//Load tech 2
		img = (Sprite)Resources.Load<Sprite>(TOWN_TECH_IMAGE_URI + "TownTech" + TownTechs.getTownTechNumber(Factions.getTownTech2(curFac)).ToString());
		//Apply it
		if (townTech2Image != null) {
			townTech2Image.sprite = img;
		} else {
			Debug.Log ("Town tech image 2 container not set");
		}

		//No more changes to account for
		factionWasChanged = false;
	}

	private void updateGameModeDisplay() {
		//If solo I is selected
		if (gameModeToggleGroup.GetComponentsInChildren<Toggle>()[SOLO_I_BUTTON_NUM].isOn) {
			//Don't display the solo II difficulties
			soloIIDifficultyToggleGroup.SetActive (false);

			//Update the text to describe the game mode
			gameModeInfoText.text = GameCreation.getRules(GameInformation.GameModes.SoloI);
		}
		//If solo II is selected 
		else if (gameModeToggleGroup.GetComponentsInChildren<Toggle>()[SOLO_II_BUTTON_NUM].isOn) {
			//Display the solo II difficulties
			soloIIDifficultyToggleGroup.SetActive(true);

			//Update the text to describe the game mode
			gameModeInfoText.text = GameCreation.getRules(GameInformation.GameModes.SoloII);
		}

		//No more changes to account for
		gameModeWasChanged = false;
	}
}

