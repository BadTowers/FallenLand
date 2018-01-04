using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public enum MenuStates {Main, Options, NewGame, ContinueGame, MultiplayerGame};
	public MenuStates currentState;

	public GameObject mainMenu;
	public GameObject optionsMenu;
	public GameObject newGameMenu;
	public GameObject continueGameMenu;
	public GameObject multiplayerMenu;

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
				mainMenu.SetActive(false);
				optionsMenu.SetActive(false);
				newGameMenu.SetActive(true);
				continueGameMenu.SetActive(false);
				multiplayerMenu.SetActive(false);
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

	// When new game button is pressed
	public void onNewGame(){
		Debug.Log ("New game");
	}

	// When continue game button is pressed
	public void onContinueGame() {
		Debug.Log ("Continue game");
	}

	// When options button is pressed
	public void onOptions() {
		Debug.Log ("Options");
	}

	// When multiplayer button is pressed
	public void onMultiplayer() {
		Debug.Log ("Multiplayer");
	}

	// When quit button is pressed
	public void OnQuit() {
		Debug.Log ("Quit");
	}



	// Used to load a scene by name TODO: Put inside helper function file?
	private void asyncSceneLoad(string name){
		SceneManager.LoadSceneAsync(name);
	}
}

