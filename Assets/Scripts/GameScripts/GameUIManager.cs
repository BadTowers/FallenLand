using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FallenLand
{
    public class GameUIManager : UIManager
    {

        public enum GameMenuStates { Pause, Options, Resume, Save };
        public GameObject GameManagerGameObject;
        public GameObject ImageGameObject;
        public GameObject gameCamera;

        private bool EscapePressed;
        private bool DebugOverlayShowing;
        private int CurrentViewedID; //Current ID of player's stuff UI is displaying
        private GameManager GameManagerInstance;
        private GameObject CharacterAndSpoilsScreen;
        private GameObject AuctionHouseScrollContent;
        private GameObject TownRosterScrollContent;
        private GameObject DebugOverlay;
        private GameObject MainOverlay;
        private GameObject PauseMenu;
        private List<GameObject> ActiveCharactersScrollContent;
        private bool CardIsDragging;
        private GameMenuStates CurrentState;

        #region UnityFunctions
        void Awake()
        {
            CurrentState = GameMenuStates.Resume;

            //Initialize vars
            EscapePressed = false;
            DebugOverlayShowing = false;
            CurrentState = GameMenuStates.Resume;

            GameManagerInstance = GameManagerGameObject.GetComponentInChildren<GameManager>();
            PauseMenu = GameObject.Find("PauseMenu");
            CharacterAndSpoilsScreen = GameObject.Find("CharacterAndSpoilsAssigningPanel");
            DebugOverlay = GameObject.Find("DebugOverlay");
            MainOverlay = GameObject.Find("MainOverlay");

            ActiveCharactersScrollContent = new List<GameObject>();

            AuctionHouseScrollContent = GameObject.Find("AuctionHouseScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
            TownRosterScrollContent = GameObject.Find("TownRosterScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
            for (int i = 0; i < 5; i++) //TODO don't hardcode to give in the party
            {
                ActiveCharactersScrollContent.Add(GameObject.Find("CharacterSlotScrollView" + (i + 1).ToString()).transform.Find("Viewport").transform.Find("Content").gameObject);
            }
        }

        void Start()
        {
            PauseMenu.SetActive(false);
            DebugOverlay.SetActive(false);
            MainOverlay.SetActive(false);
            CharacterAndSpoilsScreen.SetActive(true);
        }

        void Update()
        {
            //TODO refactor to a function that returns a list of buttons pressed. That list can then later be passed to an interpretter
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EscapePressed = true;
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                DebugOverlayShowing = !DebugOverlayShowing;
            }

            checkCurrentMenuState();

            DebugOverlay.SetActive(DebugOverlayShowing);

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
            redrawCharacterSpoilsScreen();
        }

        public bool CardIsAllowedToMoveHere(Image cardImage, GameObject panelMovingInto)
        {
            bool isAllowed = true;
            if (cardImage.GetComponentInChildren<MonoCard>().CardPtr is SpoilsCard)
            {
                isAllowed = isSpoilsCardAllowedToMoveHere(cardImage, panelMovingInto);
            }
            else if (cardImage.GetComponentInChildren<MonoCard>().CardPtr is CharacterCard)
            {
                isAllowed = isCharacterCardAllowedToMoveHere(cardImage, panelMovingInto);
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

        public void OnOpenCharacterAndSpoilsScreenPress()
        {
            CharacterAndSpoilsScreen.SetActive(true);
            MainOverlay.SetActive(false);
            redrawCharacterSpoilsScreen();
        }

        public void OnDoneInCharacterAndSpoilsScreenPress()
        {
            CharacterAndSpoilsScreen.SetActive(false);
            MainOverlay.SetActive(true);
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
            Text[] textComponenetsInDebugOverlay = DebugOverlay.GetComponentsInChildren<Text>();
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
                    updateUiOnPause();
                    if (EscapePressed)
                    {
                        CurrentState = GameMenuStates.Resume;
                    }
                    break;
                case GameMenuStates.Resume:
                    updateUiOnUnpuase();
                    if (EscapePressed)
                    {
                        CurrentState = GameMenuStates.Pause;
                    }
                    break;
                default:
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
            updateAuctionHouseUi(false);
            updateTownRosterUi(false);
        }

        private void redrawCharacterSpoilsScreen()
        {
            updateTownRosterUi(true);
            updateAuctionHouseUi(true);
            updateCharacterPanels(true);
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
                if (panelMovingInto.name.Contains("CharacterSlotScrollView"))
                {
                    int characterIndex = int.Parse(panelMovingInto.name.Substring(panelMovingInto.name.Length - 1)) - 1;
                    GameManagerInstance.RemoveCardFromPlayerAuctionHouse(playerIndex, foundInAuctionHouse);
                    GameManagerInstance.AssignSpoilsCardToCharacter(playerIndex, characterIndex, foundInAuctionHouse);
                }
            }
            else if (foundInTownRoster != null)
            {
                if (panelMovingInto.name.Contains("CharacterSlotScrollView"))
                {
                    int characterIndex = int.Parse(panelMovingInto.name.Substring(panelMovingInto.name.Length - 1)) - 1;
                    GameManagerInstance.RemoveCardFromPlayerTownRoster(playerIndex, foundInTownRoster);
                    GameManagerInstance.AssignCharacterToParty(playerIndex, characterIndex, foundInTownRoster);
                }
            }
            else
            {
                
                int characterSlotFoundIn = findCardInActiveCharacters(cardImage);
                
                if (characterSlotFoundIn != -1)
                {
                    if (cardImage.GetComponentInChildren<MonoCard>().CardPtr is SpoilsCard)
                    {
                        SpoilsCard card = (SpoilsCard)cardImage.GetComponentInChildren<MonoCard>().CardPtr;
                        GameManagerInstance.RemoveSpoilsCardFromPlayerActiveParty(playerIndex, characterSlotFoundIn, card);
                        if (panelMovingInto.name.Contains("AuctionHouseScrollView"))
                        {
                            GameManagerInstance.AddSpoilsToAuctionHouse(playerIndex, card);
                        }
                        else
                        {
                            int characterIndex = int.Parse(panelMovingInto.name.Substring(panelMovingInto.name.Length - 1)) - 1;
                            GameManagerInstance.AssignSpoilsCardToCharacter(playerIndex, characterIndex, card);
                        }
                    }
                    else if (cardImage.GetComponentInChildren<MonoCard>().CardPtr is CharacterCard)
                    {
                        CharacterCard card = (CharacterCard)cardImage.GetComponentInChildren<MonoCard>().CardPtr;
                        //Move all spoils back to the auction house
                        for (int i = card.GetEquippedSpoils().Count - 1; i >= 0 ; i--)
                        {
                            SpoilsCard spoilsCardToMove = card.GetEquippedSpoils()[i];
                            GameManagerInstance.RemoveSpoilsCardFromPlayerActiveParty(playerIndex, characterSlotFoundIn, spoilsCardToMove);
                            GameManagerInstance.AddSpoilsToAuctionHouse(playerIndex, spoilsCardToMove);
                        }

                        GameManagerInstance.RemoveCharacterFromActiveParty(playerIndex, characterSlotFoundIn, card);
                        if (panelMovingInto.name.Contains("TownRosterScrollView"))
                        {
                            GameManagerInstance.AddCharacterToTownRoster(playerIndex, card);
                        }
                        else
                        {
                            int characterIndex = int.Parse(panelMovingInto.name.Substring(panelMovingInto.name.Length - 1)) - 1;
                            GameManagerInstance.AssignCharacterToParty(playerIndex, characterIndex, card);
                        }
                    }
                }
                else
                {
                    Debug.LogError("Failed to find the card... " + cardImage.GetComponentInChildren<MonoCard>().CardPtr.GetTitle());
                    wasUpdated = false;
                }
            }

            return wasUpdated;
        }

        private void updateAuctionHouseUi(bool forceRedraw)
        {
            const float OFFSET_X = 125;
            const float OFFSET_Y = 85;
            int playerIndex = GameManagerInstance.GetIndexForMyPlayer();

            List<SpoilsCard> auctionHouse = GameManagerInstance.GetAuctionHouse(playerIndex);
            if ((AuctionHouseScrollContent.transform.childCount < auctionHouse.Count || forceRedraw) && !CardIsDragging)
            {
                //Clear old
                foreach (Transform child in AuctionHouseScrollContent.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }

                //Add new
                for (int i = 0; i < auctionHouse.Count; i++)
                {
                    GameObject imageObj = Instantiate(ImageGameObject) as GameObject;
                    Image image = imageObj.GetComponent<Image>();
                    string fileName = "Cards/SpoilsCards/SpoilsCard" + auctionHouse[i].GetId().ToString();
                    Sprite curSprite = Resources.Load<Sprite>(fileName);
                    image.sprite = curSprite;
                    imageObj.name = "SpoilsCard" + auctionHouse[i].GetId().ToString();
                    image.transform.SetParent(AuctionHouseScrollContent.transform);
                    image.transform.localPosition = new Vector3(82f + (i % 4 * OFFSET_X), -42f - (i / 4 * OFFSET_Y), 0f);
                    image.transform.localScale = new Vector3(1f, 1f, 1f);
                    image.rectTransform.sizeDelta = new Vector2(75, 100);
                    image.transform.eulerAngles = new Vector3(0f, 0f, 90f);

                    imageObj.GetComponentInChildren<MonoCard>().CardPtr = auctionHouse[i];
                }
            }
        }

        private void updateTownRosterUi(bool forceRedraw)
        {
            const float OFFSET_X = 125;
            const float OFFSET_Y = 85;
            int playerIndex = GameManagerInstance.GetIndexForMyPlayer();

            List<CharacterCard> townRoster = GameManagerInstance.GetTownRoster(playerIndex);
            if ((TownRosterScrollContent.transform.childCount < townRoster.Count || forceRedraw) && !CardIsDragging)
            {
                //Clear old
                foreach (Transform child in TownRosterScrollContent.transform)
                {
                    Debug.Log("Deleting old town roster cards");
                    GameObject.Destroy(child.gameObject);
                }

                //Add new
                for (int i = 0; i < townRoster.Count; i++)
                {
                    GameObject imageObj = Instantiate(ImageGameObject) as GameObject;
                    Image image = imageObj.GetComponent<Image>();
                    string fileName = "Cards/CharacterCards/CharacterCard" + townRoster[i].GetId().ToString();
                    Sprite curSprite = Resources.Load<Sprite>(fileName);
                    image.sprite = curSprite;
                    imageObj.name = "CharacterCard" + townRoster[i].GetId().ToString();
                    image.transform.SetParent(TownRosterScrollContent.transform);
                    image.transform.localPosition = new Vector3(82f + (i % 4 * OFFSET_X), -42f - (i / 4 * OFFSET_Y), 0f);
                    image.transform.localScale = new Vector3(1f, 1f, 1f);
                    image.rectTransform.sizeDelta = new Vector2(75, 100);
                    image.transform.eulerAngles = new Vector3(0f, 0f, 90f);

                    imageObj.GetComponentInChildren<MonoCard>().CardPtr = townRoster[i];
                }
            }
        }

        private void updateCharacterPanels(bool forceRedraw)
        {
            const float OFFSET_Y = 24.5f;
            int playerIndex = GameManagerInstance.GetIndexForMyPlayer();

            List<CharacterCard> activeCharacters = GameManagerInstance.GetActiveCharacterCards(playerIndex);
            for (int activeIndex = 0; activeIndex < activeCharacters.Count; activeIndex++)
            {
                if ((ActiveCharactersScrollContent[activeIndex].transform.childCount < activeCharacters.Count || forceRedraw) && !CardIsDragging)
                {
                    //Clear old
                    foreach (Transform child in ActiveCharactersScrollContent[activeIndex].transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }

                    if (activeCharacters[activeIndex] != null)
                    {
                        //Add character back to slot
                        GameObject imageObj = Instantiate(ImageGameObject) as GameObject;
                        Image image = imageObj.GetComponent<Image>();
                        string fileName = "Cards/CharacterCards/CharacterCard" + activeCharacters[activeIndex].GetId().ToString();
                        Sprite curSprite = Resources.Load<Sprite>(fileName);
                        image.sprite = curSprite;
                        imageObj.name = "CharacterCard" + activeCharacters[activeIndex].GetId().ToString();
                        image.transform.SetParent(ActiveCharactersScrollContent[activeIndex].transform);
                        image.transform.localPosition = new Vector3(90f, -40f, 0f);
                        image.transform.localScale = new Vector3(1f, 1f, 1f);
                        image.rectTransform.sizeDelta = new Vector2(75, 100);
                        image.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                        imageObj.GetComponentInChildren<MonoCard>().CardPtr = activeCharacters[activeIndex];

                        //Add spoils back to slot
                        List<SpoilsCard> curSlotSpoils = activeCharacters[activeIndex].GetEquippedSpoils();
                        for (int curSpoilIndex = 0; curSpoilIndex < curSlotSpoils.Count; curSpoilIndex++)
                        {
                            GameObject imageObj2 = Instantiate(ImageGameObject) as GameObject;
                            Image image2 = imageObj2.GetComponent<Image>();
                            string fileName2 = "Cards/SpoilsCards/SpoilsCard" + curSlotSpoils[curSpoilIndex].GetId().ToString();
                            Sprite curSprite2 = Resources.Load<Sprite>(fileName2);
                            image2.sprite = curSprite2;
                            imageObj2.name = "SpoilsCard" + curSlotSpoils[curSpoilIndex].GetId().ToString();
                            image2.transform.SetParent(ActiveCharactersScrollContent[activeIndex].transform);
                            image2.transform.localPosition = new Vector3(90f, -40f - ((curSpoilIndex + 1) * OFFSET_Y), 0f);
                            image2.transform.localScale = new Vector3(1f, 1f, 1f);
                            image2.rectTransform.sizeDelta = new Vector2(75, 100);
                            image2.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                            imageObj2.GetComponentInChildren<MonoCard>().CardPtr = curSlotSpoils[curSpoilIndex];
                            image2.transform.SetAsFirstSibling(); //move to the back (on parent)
                        }
                    }
                }
            }
        }

        private bool isSpoilsCardAllowedToMoveHere(Image cardImage, GameObject panelMovingInto)
        {
            bool isAllowed = true;

            int myIndex = (GameManagerInstance != null) ? GameManagerInstance.GetIndexForMyPlayer() : 0;
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
            return isAllowed;
        }

        private bool isCharacterCardAllowedToMoveHere(Image cardImage, GameObject panelMovingInto)
        {
            bool isAllowed = true;

            int myIndex = (GameManagerInstance != null) ? GameManagerInstance.GetIndexForMyPlayer() : 0;
            CharacterCard card = (CharacterCard)cardImage.GetComponentInChildren<MonoCard>().CardPtr;
            if (panelMovingInto.name.Contains("AuctionHouseScrollView"))
            {
                isAllowed = false;
            }
            try
            {
                int characterIndex = int.Parse(panelMovingInto.name.Substring(panelMovingInto.name.Length - 1)) - 1;
                if (!GameManagerInstance.IsAllowedToApplyCharacterToCharacterSlot(myIndex, characterIndex))
                {
                    isAllowed = false;
                    Debug.Log("Can't put a character card on a non-empty character slot");
                }
            }
            catch
            {
                Debug.Log("Wasn't over a character card. No need to check that part");
            }
            return isAllowed;
        }

        private int findCardInActiveCharacters(Image cardImage)
        {
            int characterIndexFoundOn = -1;

            int playerIndex = GameManagerInstance.GetIndexForMyPlayer();
            List<CharacterCard> activeCharacters = GameManagerInstance.GetActiveCharacterCards(playerIndex);
            SpoilsCard foundSpoilsOnCharacter = null;
            CharacterCard foundCharaterInParty = null;
            for (int characterSlot = 0; characterSlot < activeCharacters.Count; characterSlot++)
            {
                if (activeCharacters[characterSlot] != null)
                {
                    if (cardImage.GetComponentInChildren<MonoCard>().CardPtr == activeCharacters[characterSlot])
                    {
                        foundCharaterInParty = activeCharacters[characterSlot];
                        characterIndexFoundOn = characterSlot;
                        break;
                    }

                    List<SpoilsCard> activeSpoilsOnCurrentCharacter = activeCharacters[characterSlot].GetEquippedSpoils();
                    foundSpoilsOnCharacter = activeSpoilsOnCurrentCharacter.Find(x => x == cardImage.GetComponentInChildren<MonoCard>().CardPtr);
                    if (foundSpoilsOnCharacter != null)
                    {
                        characterIndexFoundOn = characterSlot;
                        break;
                    }
                }
            }

            return characterIndexFoundOn;
        }

        private void updateUiOnPause()
        {
            MainOverlay.SetActive(false);
            PauseMenu.SetActive(true);
        }

        private void updateUiOnUnpuase()
        {
            MainOverlay.SetActive(true);
            PauseMenu.SetActive(false);
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
