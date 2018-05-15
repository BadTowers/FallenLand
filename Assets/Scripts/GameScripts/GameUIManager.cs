using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : UIManager {

	public enum GameMenuStates {Pause, Options, Resume, Save};

	//UI Objects
	public GameObject pauseMenu;
	public GameObject saveMenu;
	public GameObject optionsMenu;

	public GameMenuStates currentState;
	private bool escapePressed;


	void Start(){
		//Initialize vars
		escapePressed = false;
		currentState = GameMenuStates.Resume;

		//Add all of the menu game objects to the array list (ADD NEW MENU PANELS HERE)
		addToMenuList(pauseMenu);
		addToMenuList(optionsMenu);
		addToMenuList(saveMenu);
	}

	//When script first starts
	void Awake(){
		currentState = GameMenuStates.Resume;
	}


	void Update(){
		//See if the escape button is being pressed
		if(Input.GetKeyDown(KeyCode.Escape)){
			escapePressed = true;
			Debug.Log("Escape pressed");
		}

		//Checks current menu state
		switch (currentState) {
			case GameMenuStates.Pause:
				if(escapePressed) {
					currentState = GameMenuStates.Resume;
				} else {
					setActiveMenu(pauseMenu);
				}
				break;
			case GameMenuStates.Resume:
				if(escapePressed) {
					//If on options screen and escape pressed, go back to pause menu
					setActiveMenu(pauseMenu);
					currentState = GameMenuStates.Pause;
				} else {
					setActiveMenu(null);
				}
				break;
			case GameMenuStates.Options:
				if(escapePressed) {
					//If on options screen and escape pressed, go back to pause menu
					setActiveMenu(pauseMenu);
					currentState = GameMenuStates.Pause;
				} else {
					setActiveMenu(optionsMenu);
				}
				break;
			case GameMenuStates.Save:
				if(escapePressed) {
					//If on save screen and escape pressed, go back to pause menu
					setActiveMenu(pauseMenu);
					currentState = GameMenuStates.Pause;
				} else {
					setActiveMenu(saveMenu);
				}
				break;
			default:
				//Default will be to show no menus
				setActiveMenu(null);
				break;
		}
		escapePressed = false;
	}

	public void onResume(){
		currentState = GameMenuStates.Resume;
		Debug.Log("Resume");
	}

	public void onOptions(){
		currentState = GameMenuStates.Options;
		Debug.Log("Options");
	}

	public void onSave(){
		currentState = GameMenuStates.Save;
		Debug.Log("Save");
	}

	public void onQuit(){
		//TODO make quit
		//TODO warn to save
		Debug.Log("Quit");
	}
}
