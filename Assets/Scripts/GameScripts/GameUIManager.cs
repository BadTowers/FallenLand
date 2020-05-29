using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FallenLand
{
    public class GameUIManager : UIManager
    {

        public enum GameMenuStates { Pause, Options, Resume, Save };
        public GameObject PauseMenu;
        public GameObject SaveMenu;
        public GameObject OptionsMenu;
        public GameObject debugOverlay; //Not a menu, it's an overlay, so it doesn't have to be added to the menu panels list
        public GameObject GameManagerGameObject;
        public GameObject ImageGameObject;
        public GameObject gameCamera;

        private bool EscapePressed;
        private bool DebugOverlayShowing;
        private float PanSpeed;
        private float ZoomSpeed;
        private int CurrentViewedID; //Current ID of player's stuff UI is displaying
        private GameManager GameManagerInstance;
        private GameObject CharacterAndSpoilsScreen;
        private GameObject AuctionHouseScrollContent;
        private bool CardIsDragging;
        private GameMenuStates CurrentState;

        #region UnityFunctions
        void Start()
        {
            //Initialize vars
            EscapePressed = false;
            DebugOverlayShowing = false;
            CurrentState = GameMenuStates.Resume;

            //Add all of the menu game objects to the array list (ADD NEW MENU PANELS HERE)
            addToMenuList(PauseMenu);
            addToMenuList(OptionsMenu);
            addToMenuList(SaveMenu);

            GameManagerInstance = GameManagerGameObject.GetComponentInChildren<GameManager>();
            CharacterAndSpoilsScreen = GameObject.Find("CharacterAndSpoilsAssigningPanel");
            CharacterAndSpoilsScreen.SetActive(true); //temporary for debugging

            AuctionHouseScrollContent = GameObject.Find("AuctionHouseScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
        }

        void Awake()
        {
            CurrentState = GameMenuStates.Resume;
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

            updateCharacterSpoilsScreen();

            EscapePressed = false;
        }
        #endregion

        #region PublicFunctions
        public void SetCardIsDragging(bool isDragging)
        {
            CardIsDragging = isDragging;
        }

        public bool GetCardIsDragging()
        {
            return CardIsDragging;
        }

        public void UpdateAfterCardWasMoved(Image cardImage, GameObject panelMovingInto)
        {
            updateStoredData(cardImage, panelMovingInto);
            updateCharacterSpoilsScreen();
        }

        //if (panelMovingInto.name.Contains("CharacterPanel") || panelMovingInto.name.Contains("AuctionHouseScrollView") || panelMovingInto.name.Contains("TownRosterScrollView"))
        public bool CardIsAllowedToMoveHere(Image cardImage, GameObject panelMovingInto)
        {
            bool isAllowed = true;
            int myIndex = (GameManagerInstance != null) ? GameManagerInstance.GetIndexForMyPlayer() : 0;
            if (cardImage.GetComponentInChildren<MonoCard>().CardPtr is SpoilsCard)
            {
                SpoilsCard card = (SpoilsCard)cardImage.GetComponentInChildren<MonoCard>().CardPtr;
                if (panelMovingInto.name.Contains("TownRosterScrollView"))
                {
                    isAllowed = false;
                }
                try
                {
                    int characterIndex = int.Parse(panelMovingInto.name.Substring(panelMovingInto.name.Length - 1)) - 1;
                    if (!GameManagerInstance.IsAllowedToApplySpoilsToCharacterSlot(myIndex, card, characterIndex))
                    {
                        isAllowed = false;
                        Debug.Log("Can't put a spoils card on an empty character slot");
                    }
                }
                catch
                {
                    Debug.Log("Wasn't over a character card. No need to check that part");
                }
            }

            return isAllowed;
        }
        #endregion

        #region UICallbacks
        public void OnResume()
        {
            CurrentState = GameMenuStates.Resume;
            Debug.Log("Resume");
        }

        public void OnOptions()
        {
            CurrentState = GameMenuStates.Options;
            Debug.Log("Options");
        }

        public void OnSave()
        {
            CurrentState = GameMenuStates.Save;
            Debug.Log("Save");
        }

        public void OnQuit()
        {
            //TODO make quit
            //TODO warn to save
            Debug.Log("Quit");
        }
        #endregion

        #region HelperFunctions
        //A function to grab all the required information from the game manager to display it here
        private void updateDebugOverlay()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();

            //Retrieve information
            int salvage = GameManagerInstance.GetSalvage(myIndex);
            Faction faction = GameManagerInstance.GetFaction(myIndex);
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
            switch (CurrentState)
            {
                case GameMenuStates.Pause:
                    if (EscapePressed)
                    {
                        CurrentState = GameMenuStates.Resume;
                    }
                    else
                    {
                        setActiveMenu(PauseMenu);
                        //Time.timeScale = 0; //Pause any physics
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
                        CurrentState = GameMenuStates.Pause;
                    }
                    else
                    {
                        setActiveMenu(null);
                        //Time.timeScale = 1; //Resume any physics
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
                        CurrentState = GameMenuStates.Pause;
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
                        CurrentState = GameMenuStates.Pause;
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
            List<SpoilsCard> auctionHouse = GameManagerInstance.GetAuctionHouse(playerIndex);
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
            List<TownTech> townTechs = GameManagerInstance.GetTownTechs(playerIndex);
            string townTechString = "";
            for (int i = 0; i < townTechs.Count; i++)
            {
                townTechString += townTechs[i].GetTechName();
                townTechString += ", ";
            }
            return townTechString;
        }

        private void updateCharacterSpoilsScreen()
        {
            const float OFFSET_X = 125;
            const float OFFSET_Y = 85;
            int playerIndex = GameManagerInstance.GetIndexForMyPlayer();

            List<SpoilsCard> auctionHouse = GameManagerInstance.GetAuctionHouse(playerIndex);
            if (AuctionHouseScrollContent.transform.childCount < auctionHouse.Count && !CardIsDragging)
            {
                Debug.Log("Count not the same");
                //Clear old
                foreach (Transform child in AuctionHouseScrollContent.transform)
                {
                    Debug.Log("Deleting old");
                    GameObject.Destroy(child.gameObject);
                }

                //Add new
                for (int i = 0; i < auctionHouse.Count; i++)
                {
                    Debug.Log("Adding card");
                    GameObject imageObj = Instantiate(ImageGameObject) as GameObject;
                    Image image = imageObj.GetComponent<Image>();
                    string fileName = "Cards/SpoilsCards/SpoilsCard" + auctionHouse[i].GetId().ToString();
                    Sprite curSprite = Resources.Load<Sprite>(fileName);
                    image.sprite = curSprite;
                    imageObj.name = "SpoilsCard" + auctionHouse[i].GetId().ToString();
                    image.transform.SetParent(AuctionHouseScrollContent.transform);
                    image.transform.localPosition = new Vector3(82f + (i%4 * OFFSET_X), -42f - (i/4 * OFFSET_Y), 0f);
                    image.transform.localScale = new Vector3(1f, 1f, 1f);
                    image.rectTransform.sizeDelta = new Vector2(75, 100);
                    image.transform.eulerAngles = new Vector3(0f, 0f, 90f);

                    imageObj.GetComponentInChildren<MonoCard>().CardPtr = auctionHouse[i];
                }
            }
        }

        private bool updateStoredData(Image cardImage, GameObject panelMovingInto)
        {
            bool wasUpdated = true;

            int playerIndex = GameManagerInstance.GetIndexForMyPlayer();
            List<SpoilsCard> auctionHouse = GameManagerInstance.GetAuctionHouse(playerIndex);
            List<CharacterCard> townRoster = GameManagerInstance.GetTownRoster(playerIndex);
            SpoilsCard foundInAuctionHouse = auctionHouse.Find(x => x == cardImage.GetComponentInChildren<MonoCard>().CardPtr);
            CharacterCard foundInTownRoster = townRoster.Find(x => x == cardImage.GetComponentInChildren<MonoCard>().CardPtr);

            if (foundInAuctionHouse != null)
            {
                Debug.Log("Was in auction house");
                if (panelMovingInto.name.Contains("CharacterPanel"))
                {
                    int characterIndex = int.Parse(panelMovingInto.name.Substring(panelMovingInto.name.Length - 1)) - 1;
                    Debug.Log("Applying to character " + characterIndex);
                    GameManagerInstance.RemoveCardFromPlayerAuctionHouse(playerIndex, foundInAuctionHouse);
                    GameManagerInstance.AssignSpoilsCardToCharacter(playerIndex, characterIndex, foundInAuctionHouse);
                }
            }
            else if (foundInTownRoster != null)
            {
                Debug.Log("Was in town roster");
            }
            else
            {
                Debug.LogError("Failed to find the card... " + cardImage.GetComponentInChildren<MonoCard>().CardPtr.GetTitle());
                wasUpdated = false;
            }

            return wasUpdated;
        }
        #endregion
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
