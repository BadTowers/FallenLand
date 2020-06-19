using Photon.Pun;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FallenLand
{
    public class GameUIManager : UIManager
    {
        public enum GameMenuStates { Pause, Options, Resume, Save };
        public GameObject GameManagerGameObject;
        public GameObject ImageGameObject;
        public GameObject ImageNoDragGameObject;
        public GameObject gameCamera;

        private bool EscapePressed;
        private bool DebugOverlayShowing;
        private int CurrentViewedID; //Current ID of player's stuff UI is displaying
        private GameManager GameManagerInstance;
        private GameObject CharacterAndSpoilsScreen;
        private GameObject AuctionHouseScrollContent;
        private GameObject TownRosterScrollContent;
        private GameObject VehicleSlotScrollContent;
        private GameObject ActionCardsScreen;
        private GameObject ActionCardsScrollContent;
        private List<GameObject> ActiveCharactersScrollContent;
        private List<List<GameObject>> ActiveCharactersStatsText;
        private List<GameObject> ActiveCharactersCarryWeightsText;
        private List<GameObject> ActiveVehicleStatsText;
        private GameObject ActiveVehicleCarryWeightsText;
        private GameObject DebugOverlay;
        private GameObject MainOverlay;
        private GameObject PauseMenu;
        private List<GameObject> PlayerPanels;
        private Text ActualTurnNumberText;
        private Text ActualTurnPhaseText;
        private Button EndPhaseButton;
        private Button ActionCardsButton;
        private bool CardIsDragging;
        private GameMenuStates CurrentState;
        private Phases CurrentPhase;

        #region UnityFunctions
        void Awake()
        {
            EscapePressed = false;
            DebugOverlayShowing = false;
            CurrentState = GameMenuStates.Resume;
            CurrentPhase = Phases.Invalid;

            GameManagerInstance = GameManagerGameObject.GetComponentInChildren<GameManager>();
            PauseMenu = GameObject.Find("PauseMenu");
            CharacterAndSpoilsScreen = GameObject.Find("CharacterAndSpoilsAssigningPanel");
            ActionCardsScreen = GameObject.Find("ActionCardsPanel");
            DebugOverlay = GameObject.Find("DebugOverlay");
            MainOverlay = GameObject.Find("MainOverlay");

            ActiveCharactersScrollContent = new List<GameObject>();

            AuctionHouseScrollContent = GameObject.Find("AuctionHouseScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
            TownRosterScrollContent = GameObject.Find("TownRosterScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
            ActionCardsScrollContent = GameObject.Find("ActionCardsScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
            for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
            {
                ActiveCharactersScrollContent.Add(GameObject.Find("CharacterSlotScrollView" + (i + 1).ToString()).transform.Find("Viewport").transform.Find("Content").gameObject);
            }
            VehicleSlotScrollContent = GameObject.Find("VehicleSlotScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;

            ActiveCharactersStatsText = new List<List<GameObject>>();
            ActiveCharactersCarryWeightsText = new List<GameObject>();
            for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
            {
                ActiveCharactersStatsText.Add(new List<GameObject>());
                ActiveCharactersStatsText[i].Add(GameObject.Find("CombatSum" + (i + 1).ToString()));
                ActiveCharactersStatsText[i].Add(GameObject.Find("SurvivalSum" + (i + 1).ToString()));
                ActiveCharactersStatsText[i].Add(GameObject.Find("DiplomacySum" + (i + 1).ToString()));
                ActiveCharactersStatsText[i].Add(GameObject.Find("MechanicalSum" + (i + 1).ToString()));
                ActiveCharactersStatsText[i].Add(GameObject.Find("TechnicalSum" + (i + 1).ToString()));
                ActiveCharactersStatsText[i].Add(GameObject.Find("MedicalSum" + (i + 1).ToString()));
                ActiveCharactersCarryWeightsText.Add(GameObject.Find("CarryWeightSum" + (i + 1).ToString()));

                foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
                {
                    ActiveCharactersStatsText[i][(int)skill].GetComponentInChildren<Text>().text = "0";
                }
                ActiveCharactersCarryWeightsText[i].GetComponentInChildren<Text>().text = "0";
            }

            ActiveVehicleStatsText = new List<GameObject>
            {
                GameObject.Find("CombatSumV"),
                GameObject.Find("SurvivalSumV"),
                GameObject.Find("DiplomacySumV"),
                GameObject.Find("MechanicalSumV"),
                GameObject.Find("TechnicalSumV"),
                GameObject.Find("MedicalSumV")
            };
            ActiveVehicleCarryWeightsText = GameObject.Find("CarryWeightSumV");
            foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
            {
                ActiveVehicleStatsText[(int)skill].GetComponentInChildren<Text>().text = "0";
            }
            ActiveVehicleCarryWeightsText.GetComponentInChildren<Text>().text = "0";

            ActualTurnNumberText = GameObject.Find("ActualTurnNumberText").GetComponent<Text>();
            ActualTurnPhaseText = GameObject.Find("ActualTurnPhaseText").GetComponent<Text>();

            EndPhaseButton = GameObject.Find("EndPhaseButton").GetComponent<Button>();
            EndPhaseButton.interactable = false;

            ActionCardsButton = GameObject.Find("ActionCardsButton").GetComponent<Button>();

            PlayerPanels = new List<GameObject>();
            for (int i = 0; i < Constants.MAX_NUM_PLAYERS; i++)
            {
                PlayerPanels.Add(GameObject.Find("PlayerPanel" + (i + 1).ToString()));
            }
        }

        void Start()
        {
            PauseMenu.SetActive(false);
            DebugOverlay.SetActive(false);
            MainOverlay.SetActive(false);
            ActionCardsScreen.SetActive(true);
            CharacterAndSpoilsScreen.SetActive(true);

            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            {
                if (PhotonNetwork.PlayerList[i].IsLocal)
                {
                    CurrentViewedID = i;
                    break;
                }
            }
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

            updateActionButton();

            updateCharacterSpoilsScreen();

            updateTurnInformation();

            updateEndPhaseButton();

            updatePlayerPanels();

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
            updateStoredVehicleCharacterAndSpoilsData(cardImage, panelMovingInto);
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

        public void ForceRedrawCharacterScreen()
        {
            redrawCharacterSpoilsScreen();
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
            Debug.Log("Quit");
        }

        public void OnOpenCharacterAndSpoilsScreenPress()
        {
            CharacterAndSpoilsScreen.SetActive(true);
            MainOverlay.SetActive(false);
            redrawCharacterSpoilsScreen();
        }

        public void OnOpenActionCardsScreenPress()
        {
            ActionCardsScreen.SetActive(true);
            MainOverlay.SetActive(false);
            redrawActionCardsScreen(true);
        }

        public void OnDoneInCharacterAndSpoilsScreenPress()
        {
            CharacterAndSpoilsScreen.SetActive(false);
            ActionCardsScreen.SetActive(false);
            MainOverlay.SetActive(true);
        }

        public void OnDoneInActionCardsScreenPress()
        {
            ActionCardsScreen.SetActive(false);
            MainOverlay.SetActive(true);
        }

        public void OnEndPhasePress()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            GameManagerInstance.EndPhase(myIndex);
            EndPhaseButton.interactable = false;
            EndPhaseButton.GetComponentInChildren<Text>().text = "Waiting...";
        }

        public void OnPlayerPanelClicked()
        {
            string parentName = EventSystem.current.currentSelectedGameObject.transform.parent.name;
            string panelNumberString = parentName.Substring(parentName.Length - 1);
            int panelNumber = Int32.Parse(panelNumberString);
            CurrentViewedID = panelNumber-1;
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
            if (CurrentViewedID != GameManagerInstance.GetIndexForMyPlayer())
            {
                updateCharacterPanels(false);
                updateVehiclePanel(false);
            }
        }

        private void redrawCharacterSpoilsScreen()
        {
            updateTownRosterUi(true);
            updateAuctionHouseUi(true);
            updateCharacterPanels(true);
            updateVehiclePanel(true);
        }

        private void redrawActionCardsScreen(bool forceRedraw)
        {
            const float OFFSET_X = 200;
            const float OFFSET_Y = 300;
            int playerIndex = GameManagerInstance.GetIndexForMyPlayer();

            List<ActionCard> actionHand = GameManagerInstance.GetActionCards(playerIndex);
            if ((ActionCardsScrollContent.transform.childCount < actionHand.Count || forceRedraw) && !CardIsDragging)
            {
                //Clear old
                foreach (Transform child in ActionCardsScrollContent.transform)
                {
                    Debug.Log("Deleting old action cards");
                    GameObject.Destroy(child.gameObject);
                }

                //Add new
                for (int i = 0; i < actionHand.Count; i++)
                {
                    GameObject imageObj = Instantiate(ImageNoDragGameObject) as GameObject;
                    Image image = imageObj.GetComponent<Image>();
                    string fileName = "Cards/ActionCards/ActionCard" + actionHand[i].GetId().ToString();
                    Sprite curSprite = Resources.Load<Sprite>(fileName);
                    image.sprite = curSprite;
                    imageObj.name = "ActionCard" + actionHand[i].GetId().ToString();
                    image.transform.SetParent(ActionCardsScrollContent.transform);
                    image.transform.localPosition = new Vector3(150f + (i % 5 * OFFSET_X), -200f - (i / 5 * OFFSET_Y), 0f);
                    image.transform.localScale = new Vector3(1f, 1f, 1f);
                    image.rectTransform.sizeDelta = new Vector2(180, 280);
                    image.transform.eulerAngles = new Vector3(0f, 0f, 0f);

                    imageObj.GetComponentInChildren<MonoCard>().CardPtr = actionHand[i];
                }
            }
        }

        private void updateStoredVehicleCharacterAndSpoilsData(Image cardImage, GameObject panelMovingInto)
        {
            int playerIndex = GameManagerInstance.GetIndexForMyPlayer();
            List<SpoilsCard> auctionHouse = GameManagerInstance.GetAuctionHouse(playerIndex);
            List<CharacterCard> townRoster = GameManagerInstance.GetTownRoster(playerIndex);
            SpoilsCard activeVehicle = GameManagerInstance.GetActiveVehicle(playerIndex);
            List<SpoilsCard> attachedToVehicle = null;

            SpoilsCard foundInAuctionHouse = auctionHouse.Find(x => x == cardImage.GetComponentInChildren<MonoCard>().CardPtr);
            CharacterCard foundInTownRoster = townRoster.Find(x => x == cardImage.GetComponentInChildren<MonoCard>().CardPtr);
            SpoilsCard foundAsVehicle = null;
            SpoilsCard foundOnVehicle = null;
            if (activeVehicle != null)
            {
                attachedToVehicle = activeVehicle.GetEquippedSpoils();
                if (activeVehicle == cardImage.GetComponentInChildren<MonoCard>().CardPtr)
                {
                    foundAsVehicle = activeVehicle;
                }
            }
            if (attachedToVehicle != null)
            {
                foundOnVehicle = attachedToVehicle.Find(x => x == cardImage.GetComponentInChildren<MonoCard>().CardPtr);
            }

            //See where the card is coming from
            if (foundInAuctionHouse != null)
            {
                handleCardComingFromAuctionHouse(panelMovingInto, foundInAuctionHouse);
            }
            else if (foundInTownRoster != null)
            {
                if (panelMovingInto.name.Contains("CharacterSlotScrollView"))
                {
                    int characterIndex = int.Parse(panelMovingInto.name.Substring(panelMovingInto.name.Length - 1)) - 1;
                    GameManagerInstance.RemoveCharacterFromTownRoster(playerIndex, foundInTownRoster);
                    GameManagerInstance.AssignCharacterToParty(playerIndex, characterIndex, foundInTownRoster);
                }
            }
            else if (foundAsVehicle != null)
            {
                if (panelMovingInto.name.Contains("AuctionHouseScrollView"))
                {
                    //Move all spoils back to the auction house
                    for (int i = foundAsVehicle.GetEquippedSpoils().Count - 1; i >= 0; i--)
                    {
                        SpoilsCard spoilsCardToMove = foundAsVehicle.GetEquippedSpoils()[i];
                        GameManagerInstance.RemoveSpoilsCardFromActiveVehicle(playerIndex, spoilsCardToMove);
                        GameManagerInstance.AddSpoilsToAuctionHouse(playerIndex, spoilsCardToMove);
                    }
                    GameManagerInstance.RemoveActiveVehicle(playerIndex);
                    GameManagerInstance.AddSpoilsToAuctionHouse(playerIndex, foundAsVehicle);
                }
            }
            else if (foundOnVehicle != null)
            {
                if (panelMovingInto.name.Contains("AuctionHouseScrollView"))
                {
                    GameManagerInstance.RemoveSpoilsCardFromActiveVehicle(playerIndex, foundOnVehicle);
                    GameManagerInstance.AddSpoilsToAuctionHouse(playerIndex, foundOnVehicle);
                }
                else if (panelMovingInto.name.Contains("CharacterSlotScrollView"))
                {
                    int characterIndex = int.Parse(panelMovingInto.name.Substring(panelMovingInto.name.Length - 1)) - 1;
                    GameManagerInstance.RemoveSpoilsCardFromActiveVehicle(playerIndex, foundOnVehicle);
                    GameManagerInstance.AssignSpoilsCardToCharacter(playerIndex, characterIndex, foundOnVehicle);
                }
            }
            else
            {
                handleCardComingFromCharacterSlot(cardImage, panelMovingInto);
            }
        }

        private void updateAuctionHouseUi(bool forceRedraw)
        {
            const float OFFSET_X = 125;
            const float OFFSET_Y = 85;
            int playerIndex = GameManagerInstance.GetIndexForMyPlayer();

            List<SpoilsCard> auctionHouse = GameManagerInstance.GetAuctionHouse(CurrentViewedID);
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
                    if (playerIndex != CurrentViewedID)
                    {
                        Destroy(imageObj.GetComponent<CardMovementHandler>());
                    }
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
            if (playerIndex != CurrentViewedID)
            {
                //Clear old
                foreach (Transform child in TownRosterScrollContent.transform)
                {
                    Debug.Log("Deleting old town roster cards");
                    GameObject.Destroy(child.gameObject);
                }
            }
            else if ((TownRosterScrollContent.transform.childCount < townRoster.Count || forceRedraw) && !CardIsDragging)
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

            List<CharacterCard> activeCharacters = GameManagerInstance.GetActiveCharacterCards(CurrentViewedID);
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
                        if (CurrentViewedID != playerIndex)
                        {
                            Destroy(imageObj.GetComponent<CardMovementHandler>());
                        }
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
                            if (CurrentViewedID != playerIndex)
                            {
                                Destroy(imageObj2.GetComponent<CardMovementHandler>());
                            }
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

                    //Update stats
                    Dictionary<Skills, int> curCharacterSlotStats = GameManagerInstance.GetActiveCharacterStats(CurrentViewedID, activeIndex);
                    foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
                    {
                        ActiveCharactersStatsText[activeIndex][(int)skill].GetComponentInChildren<Text>().text = curCharacterSlotStats[skill].ToString();
                    }
                    ActiveCharactersCarryWeightsText[activeIndex].GetComponentInChildren<Text>().text = GameManagerInstance.GetActiveCharacterCarryWeight(CurrentViewedID, activeIndex).ToString();
                }
            }
        }

        private void updateVehiclePanel(bool forceRedraw)
        {
            const float OFFSET_Y = 24.5f;
            int playerIndex = GameManagerInstance.GetIndexForMyPlayer();

            SpoilsCard activeVehicle = GameManagerInstance.GetActiveVehicle(CurrentViewedID);
            if (((activeVehicle != null && VehicleSlotScrollContent.transform.childCount < activeVehicle.GetEquippedSpoils().Count + 1) || forceRedraw) && !CardIsDragging)
            {
                //Clear old
                foreach (Transform child in VehicleSlotScrollContent.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }

                if (activeVehicle != null)
                {
                    //Add vehicle back to slot
                    GameObject imageObj = Instantiate(ImageGameObject) as GameObject;
                    if (CurrentViewedID != playerIndex)
                    {
                        Destroy(imageObj.GetComponent<CardMovementHandler>());
                    }
                    Image image = imageObj.GetComponent<Image>();
                    string fileName = "Cards/SpoilsCards/SpoilsCard" + activeVehicle.GetId().ToString();
                    Sprite curSprite = Resources.Load<Sprite>(fileName);
                    image.sprite = curSprite;
                    imageObj.name = "SpoilsCard" + activeVehicle.GetId().ToString();
                    image.transform.SetParent(VehicleSlotScrollContent.transform);
                    image.transform.localPosition = new Vector3(90f, -40f, 0f);
                    image.transform.localScale = new Vector3(1f, 1f, 1f);
                    image.rectTransform.sizeDelta = new Vector2(75, 100);
                    image.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                    imageObj.GetComponentInChildren<MonoCard>().CardPtr = activeVehicle;

                    //Add spoils back to slot
                    List<SpoilsCard> curSlotSpoils = activeVehicle.GetEquippedSpoils();
                    Debug.Log("There are currently " + curSlotSpoils.Count + " spoils attached to the vehicle");
                    for (int curSpoilIndex = 0; curSpoilIndex < curSlotSpoils.Count; curSpoilIndex++)
                    {
                        GameObject imageObj2 = Instantiate(ImageGameObject) as GameObject;
                        if (CurrentViewedID != playerIndex)
                        {
                            Destroy(imageObj2.GetComponent<CardMovementHandler>());
                        }
                        Image image2 = imageObj2.GetComponent<Image>();
                        string fileName2 = "Cards/SpoilsCards/SpoilsCard" + curSlotSpoils[curSpoilIndex].GetId().ToString();
                        Sprite curSprite2 = Resources.Load<Sprite>(fileName2);
                        image2.sprite = curSprite2;
                        imageObj2.name = "SpoilsCard" + curSlotSpoils[curSpoilIndex].GetId().ToString();
                        image2.transform.SetParent(VehicleSlotScrollContent.transform);
                        image2.transform.localPosition = new Vector3(90f, -40f - ((curSpoilIndex + 1) * OFFSET_Y), 0f);
                        image2.transform.localScale = new Vector3(1f, 1f, 1f);
                        image2.rectTransform.sizeDelta = new Vector2(75, 100);
                        image2.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                        imageObj2.GetComponentInChildren<MonoCard>().CardPtr = curSlotSpoils[curSpoilIndex];
                        image2.transform.SetAsFirstSibling(); //move to the back (on parent)
                    }
                }

                //Update stats
                Dictionary<Skills, int> vehicleStats = GameManagerInstance.GetActiveVehicleStats(CurrentViewedID);
                foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
                {
                    ActiveVehicleStatsText[(int)skill].GetComponentInChildren<Text>().text = vehicleStats[skill].ToString();
                }
                ActiveVehicleCarryWeightsText.GetComponentInChildren<Text>().text = GameManagerInstance.GetActiveVehicleCarryWeight(CurrentViewedID).ToString();
            }
        }

        private void updateTurnInformation()
        {
            ActualTurnNumberText.text = GameManagerInstance.GetTurn().ToString();
            ActualTurnPhaseText.text = GameManagerInstance.GetPhase().ToString();
        }

        private void updateEndPhaseButton()
        {
            if (shouldEnableEndPhaseButton())
            {
                EndPhaseButton.interactable = true;
                CurrentPhase = GameManagerInstance.GetPhase();
                EndPhaseButton.GetComponentInChildren<Text>().text = "End Phase";
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
            else if (panelMovingInto.name.Contains("VehicleSlotScrollView"))
            {
                Debug.Log("Is a spoils trying to move into a vehicle slot");
                isAllowed = GameManagerInstance.IsAllowedToApplySpoilsToVehicleSlot(myIndex, card);
            }
            else
            {
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

        private bool isCharacterCardAllowedToMoveHere(Image cardImage, GameObject panelMovingInto)
        {
            bool isAllowed = true;

            int myIndex = (GameManagerInstance != null) ? GameManagerInstance.GetIndexForMyPlayer() : 0;
            CharacterCard card = (CharacterCard)cardImage.GetComponentInChildren<MonoCard>().CardPtr;
            if (panelMovingInto.name.Contains("AuctionHouseScrollView") || panelMovingInto.name.Contains("VehicleSlotScrollView"))
            {
                isAllowed = false;
            }
            else
            {
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

        private void handleCardComingFromAuctionHouse(GameObject panelMovingInto, SpoilsCard cardFromAuctionHouse)
        {
            int playerIndex = GameManagerInstance.GetIndexForMyPlayer();
            if (panelMovingInto.name.Contains("CharacterSlotScrollView"))
            {
                int characterIndex = int.Parse(panelMovingInto.name.Substring(panelMovingInto.name.Length - 1)) - 1;
                GameManagerInstance.RemoveSpoilFromAuctionHouse(playerIndex, cardFromAuctionHouse);
                GameManagerInstance.AssignSpoilsCardToCharacter(playerIndex, characterIndex, cardFromAuctionHouse);
            }
            else if (panelMovingInto.name.Contains("VehicleSlotScrollView"))
            {
                GameManagerInstance.RemoveSpoilFromAuctionHouse(playerIndex, cardFromAuctionHouse);
                if (cardFromAuctionHouse.GetSpoilsTypes().Contains(SpoilsTypes.Vehicle))
                {
                    GameManagerInstance.AddVehicleToActiveParty(playerIndex, cardFromAuctionHouse);
                }
                else
                {
                    GameManagerInstance.AddSpoilsToActiveVehicle(playerIndex, cardFromAuctionHouse);
                }
            }
        }

        private void handleCardComingFromCharacterSlot(Image cardImage, GameObject panelMovingInto)
        {
            int characterSlotFoundIn = findCardInActiveCharacters(cardImage);
            int playerIndex = GameManagerInstance.GetIndexForMyPlayer();

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
                        if (panelMovingInto.name.Contains("VehicleSlotScrollView"))
                        {
                            GameManagerInstance.AddSpoilsToActiveVehicle(playerIndex, card);
                        }
                        else
                        {
                            int characterIndex = int.Parse(panelMovingInto.name.Substring(panelMovingInto.name.Length - 1)) - 1;
                            GameManagerInstance.AssignSpoilsCardToCharacter(playerIndex, characterIndex, card);
                        }
                    }
                }
                else if (cardImage.GetComponentInChildren<MonoCard>().CardPtr is CharacterCard)
                {
                    CharacterCard card = (CharacterCard)cardImage.GetComponentInChildren<MonoCard>().CardPtr;
                    //Move all spoils back to the auction house
                    for (int i = card.GetEquippedSpoils().Count - 1; i >= 0; i--)
                    {
                        SpoilsCard spoilsCardToMove = card.GetEquippedSpoils()[i];
                        GameManagerInstance.RemoveSpoilsCardFromPlayerActiveParty(playerIndex, characterSlotFoundIn, spoilsCardToMove);
                        GameManagerInstance.AddSpoilsToAuctionHouse(playerIndex, spoilsCardToMove);
                    }

                    GameManagerInstance.RemoveCharacterFromActiveParty(playerIndex, characterSlotFoundIn);
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
            }
        }

        private bool shouldEnableEndPhaseButton()
        {
            return GameManagerInstance.GetPhase() != CurrentPhase && 
                ((GameManagerInstance.GetCurrentPlayer() != null &&
                GameManagerInstance.GetCurrentPlayer().UserId == GameManagerInstance.GetMyUserId()) || 
                PhasesHelpers.IsAsyncPhase(GameManagerInstance.GetPhase()));
        }

        private void updatePlayerPanels()
        {
            int numPlayers = PhotonNetwork.PlayerList.Length;
            for (int i = 0; i < Constants.MAX_NUM_PLAYERS; i++)
            {
                if (i < numPlayers && GameManagerInstance.GetFaction(i) != null)
                {
                    Debug.Log("Setting faction information for player " + i);
                    PlayerPanels[i].SetActive(true);
                    Color color = PlayerPanels[i].GetComponentInChildren<Image>().color;
                    color.a = (i == CurrentViewedID) ? 244f / 255f : 150f / 255f;
                    PlayerPanels[i].GetComponentInChildren<Image>().color = color;
                    string factionPath = "Factions/FactionSymbols/FactionSymbol" + GameManagerInstance.GetFaction(i).GetId().ToString();
                    Sprite factionSprite = Resources.Load<Sprite>(factionPath);
                    PlayerPanels[i].transform.Find("FactionImage").GetComponentInChildren<Image>().sprite = factionSprite;
                    PlayerPanels[i].transform.Find("PlayerNameText").GetComponentInChildren<Text>().text = PhotonNetwork.PlayerList[i].NickName;
                    PlayerPanels[i].transform.Find("PrestigeActualText").GetComponentInChildren<Text>().text = "0";
                    PlayerPanels[i].transform.Find("TownHealthActualText").GetComponentInChildren<Text>().text = "0";
                }
                else
                {
                    PlayerPanels[i].SetActive(false);
                }
            }
        }

        private void updateActionButton()
        {
            ActionCardsButton.interactable = (CurrentViewedID == GameManagerInstance.GetIndexForMyPlayer());
        }
        #endregion
    }
}