using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : UIManager {

	public enum GameMenuStates {Pause, Options, Resume, Save};

	//UI Objects
	public GameObject pauseMenu;
	public GameObject saveMenu;
	public GameObject optionsMenu;
    public GameObject debugOverlay; //Not a menu, it's an overlay, so it doesn't have to be added to the menu panels list
    public Image spoilsCard1; //TODO rework so this is maybe a container that can dynamically be populated with cards

    //Game camera
    public GameObject gameCamera;

	public GameMenuStates currentState;
	private bool escapePressed;
    private bool debugOverlayShowing;
	private float panSpeed;
	private float zoomSpeed;
    private List<int> listOfPlayerIDs; //List of all player IDs the UI could display
    private int currentViewedID; //Current ID of player's stuff UI is displaying


	void Start(){
		//Initialize vars
		escapePressed = false;
        debugOverlayShowing = false;
        currentState = GameMenuStates.Resume;

		//Add all of the menu game objects to the array list (ADD NEW MENU PANELS HERE)
		addToMenuList(pauseMenu);
		addToMenuList(optionsMenu);
		addToMenuList(saveMenu);
	}

	//When script first starts
	void Awake(){
		currentState = GameMenuStates.Resume;
		//Get the move speeds from the camera so we can freeze and unfreeze for pauses and resumes
		panSpeed = gameCamera.GetComponent<CameraManager>().PanSpeed;
		zoomSpeed = gameCamera.GetComponent<CameraManager>().ZoomSpeed;
	}


	void Update(){
        //TODO refactor to a function that returns a list of buttons pressed. That list can then later be passed to an interpretter
		//See if the escape button is being pressed
		if(Input.GetKeyDown(KeyCode.Escape)){
			escapePressed = true;
			Debug.Log("Escape pressed");
		}
        //See if the F3 button is being pressed
        if(Input.GetKeyDown(KeyCode.F3))
        {
            debugOverlayShowing = !debugOverlayShowing; //Flip if the debug screen is showing or not
            Debug.Log("F3 pressed");
        }

        //Checks current menu state
        checkCurrentMenuState();

        //Toggle debug overlay
		debugOverlay.SetActive(debugOverlayShowing);

        //Update debug overlay
        updateDebugOverlay();

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



    //A function to grab all the required information from the game manager to display it here
    private void updateDebugOverlay()
    {
        //Retrieve information
        int salvage = GameObject.Find("GameManager").GetComponentInChildren<GameManager>().getSalvageByID(0); //TODO this shouldnt be a hardcoded 0. Needs to be retrieved from game manager
        Faction faction = GameObject.Find("GameManager").GetComponentInChildren<GameManager>().getFactionByID(0);

        //Display information in the debug overlay
        Text[] textComponenetsInDebugOverlay = debugOverlay.GetComponentsInChildren<Text>();
        foreach (Text curText in textComponenetsInDebugOverlay) {
            switch (curText.name) {
                case "DebugSpoilsCardText":
                    //TODO
                    break;
                case "DebugAuctionHouseText":
                    //todo
                    break;
                case "DebugCharacterCardText":
                    //todo
                    break;
                case "DebugTownRosterText":
                    //todo
                    break;
                case "DebugActionCardText":
                    //TODO
                    break;
                case "DebugTownTechText":
                    //TODO
                    break;
                case "DebugSalvageText":
                    curText.text = "Salvage: " + salvage.ToString();
                    break;
            }
        }
    }

    //A function to display and hide menus as needed
    private void checkCurrentMenuState() {
        switch (currentState) {
            case GameMenuStates.Pause:
                if (escapePressed) {
                    currentState = GameMenuStates.Resume;
                } else {
                    setActiveMenu(pauseMenu);
                    Time.timeScale = 0; //Pause any physics
                                        //Freeze the game camera from moving
                    gameCamera.GetComponent<CameraManager>().PanSpeed = 0;
                    gameCamera.GetComponent<CameraManager>().ZoomSpeed = 0;
                }
                break;
            case GameMenuStates.Resume:
                if (escapePressed) {
                    //If on options screen and escape pressed, go back to pause menu
                    setActiveMenu(pauseMenu);
                    currentState = GameMenuStates.Pause;
                } else {
                    setActiveMenu(null);
                    Time.timeScale = 1; //Resume any physics
                                        //Unfreeze the game camera
                    gameCamera.GetComponent<CameraManager>().PanSpeed = this.panSpeed;
                    gameCamera.GetComponent<CameraManager>().ZoomSpeed = this.zoomSpeed;
                }
                break;
            case GameMenuStates.Options:
                if (escapePressed) {
                    //If on options screen and escape pressed, go back to pause menu
                    setActiveMenu(pauseMenu);
                    currentState = GameMenuStates.Pause;
                } else {
                    setActiveMenu(optionsMenu);
                }
                break;
            case GameMenuStates.Save:
                if (escapePressed) {
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
    }
}


//Code for displaying one card in one specific image GameObject
/*
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
*/
