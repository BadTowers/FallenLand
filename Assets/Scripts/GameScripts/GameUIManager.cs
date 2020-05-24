using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FallenLand
{
    public class GameUIManager : UIManager
    {

        public enum GameMenuStates { Pause, Options, Resume, Save };

        //UI Objects
        public GameObject PauseMenu;
        public GameObject SaveMenu;
        public GameObject OptionsMenu;
        public GameObject debugOverlay; //Not a menu, it's an overlay, so it doesn't have to be added to the menu panels list
        public GameObject GameManagerGameObject;
        private GameManager GameMangerInstance;

        //Game camera
        public GameObject gameCamera;

        public GameMenuStates currentState;
        private bool EscapePressed;
        private bool DebugOverlayShowing;
        private float PanSpeed;
        private float ZoomSpeed;
        private int currentViewedID; //Current ID of player's stuff UI is displaying


        void Start()
        {
            //Initialize vars
            EscapePressed = false;
            DebugOverlayShowing = false;
            currentState = GameMenuStates.Resume;

            //Add all of the menu game objects to the array list (ADD NEW MENU PANELS HERE)
            addToMenuList(PauseMenu);
            addToMenuList(OptionsMenu);
            addToMenuList(SaveMenu);

            GameMangerInstance = GameManagerGameObject.GetComponentInChildren<GameManager>();

        }

        //When script first starts
        void Awake()
        {
            currentState = GameMenuStates.Resume;
            //Get the move speeds from the camera so we can freeze and unfreeze for pauses and resumes
            PanSpeed = gameCamera.GetComponent<CameraManager>().PanSpeed;
            ZoomSpeed = gameCamera.GetComponent<CameraManager>().ZoomSpeed;
        }


        void Update()
        {
            //TODO refactor to a function that returns a list of buttons pressed. That list can then later be passed to an interpretter
            //See if the escape button is being pressed
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EscapePressed = true;
                Debug.Log("Escape pressed");
            }
            //See if the F3 button is being pressed
            if (Input.GetKeyDown(KeyCode.F3))
            {
                DebugOverlayShowing = !DebugOverlayShowing; //Flip if the debug screen is showing or not
                Debug.Log("F3 pressed");
            }

            //Checks current menu state
            checkCurrentMenuState();

            //Toggle debug overlay
            debugOverlay.SetActive(DebugOverlayShowing);

            //Update debug overlay
            updateDebugOverlay();

            EscapePressed = false;
        }

        public void OnResume()
        {
            currentState = GameMenuStates.Resume;
            Debug.Log("Resume");
        }

        public void OnOptions()
        {
            currentState = GameMenuStates.Options;
            Debug.Log("Options");
        }

        public void OnSave()
        {
            currentState = GameMenuStates.Save;
            Debug.Log("Save");
        }

        public void OnQuit()
        {
            //TODO make quit
            //TODO warn to save
            Debug.Log("Quit");
        }



        //A function to grab all the required information from the game manager to display it here
        private void updateDebugOverlay()
        {
            int myIndex = GameMangerInstance.GetIndexForMyPlayer();

            //Retrieve information
            int salvage = GameMangerInstance.GetSalvage(myIndex);
            Faction faction = GameMangerInstance.GetFaction(myIndex);
            string spoilsCardString = getSpoilsCardString(myIndex);
            string townTechString = getTownTechString(myIndex);
            //List<ActionCard> actionCards = GameMangerInstance.GetActionCards(0);
            //List <CharacterCard> townRoster = GameMangerInstance.GetTownRoster(0);
            //List<CharacterCard> townRoster = GameObject.Find("GameManager").GetComponentInChildren<GameManager>().GetTownRoster(0);

            //Display information in the debug overlay
            Text[] textComponenetsInDebugOverlay = debugOverlay.GetComponentsInChildren<Text>();
            foreach (Text curText in textComponenetsInDebugOverlay)
            {
                switch (curText.name)
                {
                    case "DebugSpoilsCardText":
                        curText.text = "Spoils: " + spoilsCardString;
                        break;
                    case "DebugAuctionHouseText":
                        //todo
                        break;
                    case "DebugCharacterCardText":
                        //todo
                        break;
                    case "DebugTownRosterText":
                        //curText.text = "Characters: " + characterCardsString;
                        break;
                    case "DebugActionCardText":
                        //TODO
                        break;
                    case "DebugTownTechText":
                        curText.text = "TTs: " + townTechString;
                        break;
                    case "DebugSalvageText":
                        curText.text = "Salvage: " + salvage.ToString();
                        break;
                    case "DebugFactionText":
                        curText.text = "Faction name: " + faction.GetName();
                        break;
                }
            }
        }

        //A function to display and hide menus as needed
        private void checkCurrentMenuState()
        {
            switch (currentState)
            {
                case GameMenuStates.Pause:
                    if (EscapePressed)
                    {
                        currentState = GameMenuStates.Resume;
                    }
                    else
                    {
                        setActiveMenu(PauseMenu);
                        Time.timeScale = 0; //Pause any physics
                                            //Freeze the game camera from moving
                        gameCamera.GetComponent<CameraManager>().PanSpeed = 0;
                        gameCamera.GetComponent<CameraManager>().ZoomSpeed = 0;
                    }
                    break;
                case GameMenuStates.Resume:
                    if (EscapePressed)
                    {
                        //If on options screen and escape pressed, go back to pause menu
                        setActiveMenu(PauseMenu);
                        currentState = GameMenuStates.Pause;
                    }
                    else
                    {
                        setActiveMenu(null);
                        Time.timeScale = 1; //Resume any physics
                                            //Unfreeze the game camera
                        gameCamera.GetComponent<CameraManager>().PanSpeed = this.PanSpeed;
                        gameCamera.GetComponent<CameraManager>().ZoomSpeed = this.ZoomSpeed;
                    }
                    break;
                case GameMenuStates.Options:
                    if (EscapePressed)
                    {
                        //If on options screen and escape pressed, go back to pause menu
                        setActiveMenu(PauseMenu);
                        currentState = GameMenuStates.Pause;
                    }
                    else
                    {
                        setActiveMenu(OptionsMenu);
                    }
                    break;
                case GameMenuStates.Save:
                    if (EscapePressed)
                    {
                        //If on save screen and escape pressed, go back to pause menu
                        setActiveMenu(PauseMenu);
                        currentState = GameMenuStates.Pause;
                    }
                    else
                    {
                        setActiveMenu(SaveMenu);
                    }
                    break;
                default:
                    //Default will be to show no menus
                    setActiveMenu(null);
                    break;
            }
        }

        private string getSpoilsCardString(int playerIndex)
        {
            List<SpoilsCard> auctionHouse = GameMangerInstance.GetAuctionHouse(playerIndex);
            string spoilsCardString = "";
            for (int i = 0; i < auctionHouse.Count; i++)
            {
                spoilsCardString += auctionHouse[i].GetTitle();
                spoilsCardString += ", ";
            }
            return spoilsCardString;
        }

        private string getTownTechString(int playerIndex)
        {
            List<TownTech> townTechs = GameMangerInstance.GetTownTechs(playerIndex);
            string townTechString = "";
            for (int i = 0; i < townTechs.Count; i++)
            {
                townTechString += townTechs[i].GetTechName();
                townTechString += ", ";
            }
            return townTechString;
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
