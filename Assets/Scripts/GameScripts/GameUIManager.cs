using Photon.Pun;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

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
        private int CurrentViewedID; //Current ID of player's stuff UI is displaying
        private GameManager GameManagerInstance;
        private GameObject CharacterAndSpoilsScreen;
        private GameObject AuctionHouseScrollContent;
        private GameObject TownRosterScrollContent;
        private GameObject VehicleSlotScrollContent;
        private GameObject ActionCardsScreen;
        private GameObject ActionCardsScrollContent;
        private List<GameObject> ActiveCharactersScrollContent;
        private List<List<List<GameObject>>> ActiveCharactersStatsText;
        private List<List<GameObject>> ActiveCharactersPsychResistance;
        private List<List<GameObject>> ActiveCharactersCarryWeightsText;
        private List<List<GameObject>> ActiveCharactersHealthText;
        private List<List<GameObject>> ActiveCharactersPsychText;
        private List<List<GameObject>> ActiveVehicleStatsText;
        private List<GameObject> ActiveVehicleCarryWeightsText;
        private GameObject MainOverlay;
        private GameObject PauseMenu;
        private GameObject TradeOverlay;
        private List<GameObject> PlayerPanels;
        private Text ActualTurnNumberText;
        private Text ActualTurnPhaseText;
        private Button EndPhaseButton;
        private Button ActionCardsButton;
        private Button AuctionHouseTradeButton;
        private bool CardIsDragging;
        private GameMenuStates CurrentState;
        private GameObject TownEventsRollPanel;
        private GameObject RollTownEventButtonGameObject;
        private GameObject RollTownEventTextGameObject;
        private GameObject PartyExploitsPanel;
        private bool UserRolledTownEventsThisTurn;
        private GameObject ActualRemainingWeeksTextGameObject;
        private GameObject PartyExploitsInformationTextGameObject;
        private GameObject EncounterSelectionPanelGameObject;
        private GameObject OverallEncounterPanelGameObject;
        private GameObject CardFullScreenGameObject;
        private Sprite CardSpriteThatWasClicked;
        private bool CardIsClicked;
        private bool CardIsHorizontal;
        private GameObject FullScreenCardVertical;
        private GameObject FullScreenCardHorizontal;
        private GameObject VerticalCloseButton;
        private GameObject HorizontalCloseButton;
        private List<List<GameObject>> OverallEncounterPlayerStatPanels;
        private List<GameObject> OverallEncounterVehicleStatPanels;
        private GameObject PartyOverviewPanel;
        private GameObject MainEncounterCardImage;
        private bool EncounterHasBegun;

        #region UnityFunctions
        void Awake()
        {
            EscapePressed = false;
            CurrentState = GameMenuStates.Resume;
            UserRolledTownEventsThisTurn = false;

            GameManagerInstance = GameManagerGameObject.GetComponentInChildren<GameManager>();
            PauseMenu = GameObject.Find("PauseMenu");
            CharacterAndSpoilsScreen = GameObject.Find("CharacterAndSpoilsAssigningPanel");
            ActionCardsScreen = GameObject.Find("ActionCardsPanel");
            MainOverlay = GameObject.Find("MainOverlayCanvas");
            TradeOverlay = GameObject.Find("TradeOverlay");
            TownEventsRollPanel = GameObject.Find("TownEventsPanel");
            RollTownEventButtonGameObject = GameObject.Find("RollTownEventsButton");
            RollTownEventTextGameObject = GameObject.Find("RollTownEventsText");
            PartyExploitsPanel = GameObject.Find("PartyExploitsPanel");
            ActualRemainingWeeksTextGameObject = GameObject.Find("ActualRemainingWeeksText");
            PartyExploitsInformationTextGameObject = GameObject.Find("PartyExploitsInformationText");
            EncounterSelectionPanelGameObject = GameObject.Find("EncounterSelectionPanel");
            OverallEncounterPanelGameObject = GameObject.Find("OverallEncounterPanel");
            CardFullScreenGameObject = GameObject.Find("CardFullScreenPanel");
            FullScreenCardVertical = GameObject.Find("LargeCardImageVertical");
            FullScreenCardHorizontal = GameObject.Find("LargeCardImageHorizontal");
            VerticalCloseButton = GameObject.Find("VerticalCloseButton");
            HorizontalCloseButton = GameObject.Find("HorizontalCloseButton");
            PartyOverviewPanel = GameObject.Find("PartyOverviewPanel");
            MainEncounterCardImage = GameObject.Find("MainEncounterCardImage");

            ActiveCharactersScrollContent = new List<GameObject>();
            OverallEncounterVehicleStatPanels = new List<GameObject>();

            AuctionHouseScrollContent = GameObject.Find("AuctionHouseScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
            TownRosterScrollContent = GameObject.Find("TownRosterScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
            ActionCardsScrollContent = GameObject.Find("ActionCardsScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
            for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
            {
                ActiveCharactersScrollContent.Add(GameObject.Find("CharacterSlotScrollView" + (i + 1).ToString()).transform.Find("Viewport").transform.Find("Content").gameObject);
            }
            VehicleSlotScrollContent = GameObject.Find("VehicleSlotScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;

            ActiveCharactersStatsText = new List<List<List<GameObject>>>(); //dim1 = characterIndex, dim2 = skill, dim3 = all ui elements for that skill
            ActiveCharactersCarryWeightsText = new List<List<GameObject>>();
            ActiveCharactersPsychResistance = new List<List<GameObject>>();
            ActiveCharactersHealthText = new List<List<GameObject>>();
            ActiveCharactersPsychText = new List<List<GameObject>>();
            ActiveVehicleStatsText = new List<List<GameObject>>();
            OverallEncounterPlayerStatPanels = new List<List<GameObject>>();
            //Get the UI stuff for the 5 characters
            for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
            {
                ActiveCharactersStatsText.Add(new List<List<GameObject>>());
                OverallEncounterPlayerStatPanels.Add(new List<GameObject>());

                GameObject[] combatObjects = GameObject.FindGameObjectsWithTag("CharacterCombat" + (i + 1).ToString());
                ActiveCharactersStatsText[i].Add(combatObjects.OfType<GameObject>().ToList());

                GameObject[] survivalObjects = GameObject.FindGameObjectsWithTag("CharacterSurvival" + (i + 1).ToString());
                ActiveCharactersStatsText[i].Add(survivalObjects.OfType<GameObject>().ToList());

                GameObject[] diplomacyObjects = GameObject.FindGameObjectsWithTag("CharacterDiplomacy" + (i + 1).ToString());
                ActiveCharactersStatsText[i].Add(diplomacyObjects.OfType<GameObject>().ToList());

                GameObject[] mechanicalObjects = GameObject.FindGameObjectsWithTag("CharacterMechanical" + (i + 1).ToString());
                ActiveCharactersStatsText[i].Add(mechanicalObjects.OfType<GameObject>().ToList());

                GameObject[] technicalObjects = GameObject.FindGameObjectsWithTag("CharacterTechnical" + (i + 1).ToString());
                ActiveCharactersStatsText[i].Add(technicalObjects.OfType<GameObject>().ToList());

                GameObject[] medicalObjects = GameObject.FindGameObjectsWithTag("CharacterMedical" + (i + 1).ToString());
                ActiveCharactersStatsText[i].Add(medicalObjects.OfType<GameObject>().ToList());
                
                GameObject[] psychResistanceObjects = GameObject.FindGameObjectsWithTag("CharacterPsychResistance" + (i + 1).ToString());
                ActiveCharactersPsychResistance.Add(psychResistanceObjects.OfType<GameObject>().ToList());

                GameObject[] carryWeightObjects = GameObject.FindGameObjectsWithTag("CharacterCarryWeight" + (i + 1).ToString());
                ActiveCharactersCarryWeightsText.Add(carryWeightObjects.OfType<GameObject>().ToList());

                GameObject[] healthObjects = GameObject.FindGameObjectsWithTag("CharacterHealth" + (i + 1).ToString());
                ActiveCharactersHealthText.Add(healthObjects.OfType<GameObject>().ToList());

                GameObject[] psychObjects = GameObject.FindGameObjectsWithTag("CharacterPsych" + (i + 1).ToString());
                ActiveCharactersPsychText.Add(psychObjects.OfType<GameObject>().ToList());

                OverallEncounterPlayerStatPanels[i].Add(GameObject.Find("CombatPanel" + (i + 1).ToString()));
                OverallEncounterPlayerStatPanels[i].Add(GameObject.Find("SurvivalPanel" + (i + 1).ToString()));
                OverallEncounterPlayerStatPanels[i].Add(GameObject.Find("DiplomacyPanel" + (i + 1).ToString()));
                OverallEncounterPlayerStatPanels[i].Add(GameObject.Find("MechanicalPanel" + (i + 1).ToString()));
                OverallEncounterPlayerStatPanels[i].Add(GameObject.Find("TechnicalPanel" + (i + 1).ToString()));
                OverallEncounterPlayerStatPanels[i].Add(GameObject.Find("MedicalPanel" + (i + 1).ToString()));

                //Set default values
                foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
                {
                    for (int j = 0; j < ActiveCharactersStatsText[i][(int)skill].Count; j++)
                    {
                        ActiveCharactersStatsText[i][(int)skill][j].GetComponentInChildren<Text>().text = "0";
                    }
                }
                for (int j = 0; j < ActiveCharactersPsychResistance[i].Count; j++)
                {
                    ActiveCharactersPsychResistance[i][j].GetComponentInChildren<Text>().text = "0";
                }
                for (int j = 0; j < ActiveCharactersCarryWeightsText[i].Count; j++)
                {
                    ActiveCharactersCarryWeightsText[i][j].GetComponentInChildren<Text>().text = "0/0";
                }
                for (int j = 0; j < ActiveCharactersHealthText[i].Count; j++)
                {
                    ActiveCharactersHealthText[i][j].GetComponentInChildren<Text>().text = "0/0";
                }
                for (int j = 0; j < ActiveCharactersPsychText[i].Count; j++)
                {
                    ActiveCharactersPsychText[i][j].GetComponentInChildren<Text>().text = "0/0";
                }
            }

            //Get stuff for vehicle slot
            GameObject[] vehicleCombatObjects = GameObject.FindGameObjectsWithTag("CharacterCombatV");
            ActiveVehicleStatsText.Add(vehicleCombatObjects.OfType<GameObject>().ToList());
            OverallEncounterVehicleStatPanels.Add(GameObject.Find("CombatPanelV"));

            GameObject[] vehicleSurvivalObjects = GameObject.FindGameObjectsWithTag("CharacterSurvivalV");
            ActiveVehicleStatsText.Add(vehicleSurvivalObjects.OfType<GameObject>().ToList());
            OverallEncounterVehicleStatPanels.Add(GameObject.Find("SurvivalPanelV"));

            GameObject[] vehicleDeplomacyObjects = GameObject.FindGameObjectsWithTag("CharacterDiplomacyV");
            ActiveVehicleStatsText.Add(vehicleDeplomacyObjects.OfType<GameObject>().ToList());
            OverallEncounterVehicleStatPanels.Add(GameObject.Find("DiplomacyPanelV"));

            GameObject[] vehicleMechanicalObjects = GameObject.FindGameObjectsWithTag("CharacterMechanicalV");
            ActiveVehicleStatsText.Add(vehicleMechanicalObjects.OfType<GameObject>().ToList());
            OverallEncounterVehicleStatPanels.Add(GameObject.Find("MechanicalPanelV"));

            GameObject[] vehicleTechnicalObjects = GameObject.FindGameObjectsWithTag("CharacterTechnicalV");
            ActiveVehicleStatsText.Add(vehicleTechnicalObjects.OfType<GameObject>().ToList());
            OverallEncounterVehicleStatPanels.Add(GameObject.Find("TechnicalPanelV"));

            GameObject[] vehicleMedicalObjects = GameObject.FindGameObjectsWithTag("CharacterMedicalV");
            ActiveVehicleStatsText.Add(vehicleMedicalObjects.OfType<GameObject>().ToList());
            OverallEncounterVehicleStatPanels.Add(GameObject.Find("MedicalPanelV"));

            GameObject[] vehicleCarryWeightObjects = GameObject.FindGameObjectsWithTag("CharacterCarryWeightV");
            ActiveVehicleCarryWeightsText = vehicleCarryWeightObjects.OfType<GameObject>().ToList();

            //Give vehicle stats default values
            foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
            {
                for (int i = 0; i < ActiveVehicleStatsText[(int)skill].Count; i++)
                {
                    ActiveVehicleStatsText[(int)skill][i].GetComponentInChildren<Text>().text = "0";
                }
            }
            for (int i = 0; i < ActiveVehicleCarryWeightsText.Count; i++)
            {
                ActiveVehicleCarryWeightsText[i].GetComponentInChildren<Text>().text = "0/0";            
            }

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

            AuctionHouseTradeButton = GameObject.Find("AuctionHouseTradeButton").GetComponent<Button>();
            AuctionHouseTradeButton.interactable = false;

            TownEventsRollPanel.SetActive(false);
            PartyExploitsPanel.SetActive(false);

            PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "";

            OverallEncounterPanelGameObject.SetActive(false);
            CardFullScreenGameObject.SetActive(false);
            MainEncounterCardImage.SetActive(false);
        }

        void Start()
        {
            PauseMenu.SetActive(false);
            MainOverlay.SetActive(false);
            ActionCardsScreen.SetActive(true);
            CharacterAndSpoilsScreen.SetActive(true);
            TradeOverlay.SetActive(false);

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

            updateActionButton();

            updateCharacterSpoilsScreen();

            updateTurnInformation();

            updateTownEventsUi();

            updatePartyExploitsUi();

            updateEndPhaseButton();

            updatePlayerPanels();

            updateFullScreenCard();

            checkCurrentMenuState();

            EscapePressed = false;
        }
        #endregion

        #region PublicFunctions
        public void SetCardIsClicked(Sprite spriteToShow)
        {
            CardSpriteThatWasClicked = spriteToShow;
            CardIsClicked = true;
        }

        public void SetCardIsHorizontal(bool isHorizontal)
        {
            CardIsHorizontal = isHorizontal;
        }

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
            redrawCharacterSpoilsScreen();
        }

        public void OnOpenActionCardsScreenPress()
        {
            ActionCardsScreen.SetActive(true);
            redrawActionCardsScreen(true);
        }

        public void OnDoneInCharacterAndSpoilsScreenPress()
        {
            CharacterAndSpoilsScreen.SetActive(false);
            ActionCardsScreen.SetActive(false);
        }

        public void OnDoneInActionCardsScreenPress()
        {
            ActionCardsScreen.SetActive(false);
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

        public void OnTradeAuctionHousePress()
        {
            //TradeOverlay.SetActive(true);
        }

        public void OnCancelTradePress()
        {
            //TradeOverlay.SetActive(false);
        }

        public void OnSendTradePress()
        {
            //TradeOverlay.SetActive(false);
            //TODO show "trade sent" somewhere
            //TODO actually send the trade
        }

        public void OnRollTownEventsPress()
        {
            int d10Roll = GameManagerInstance.RollTownEvents(GameManagerInstance.GetIndexForMyPlayer());
            UserRolledTownEventsThisTurn = true;
            string eventsText = "";
            switch (d10Roll)
            {
                case 1:
                    eventsText = "1! You gain 2 prestige, 4 town health, and get to choose either an action card, spoils card, or character card.";
                    break;
                case 2:
                    eventsText = "2. You gain 1 prestige and 2 town health.";
                    break;
                case 3:
                    eventsText = "3. You gain 1 town health.";
                    break;
                case 4:
                    eventsText = "4. No effect.";
                    break;
                case 5:
                    eventsText = "5. No effect.";
                    break;
                case 6:
                    eventsText = "6. No effect.";
                    break;
                case 7:
                    eventsText = "7. No effect.";
                    break;
                case 8:
                    eventsText = "8. Lose 1 town health.";
                    break;
                case 9:
                    eventsText = "9. Lose 1 prestige and 2 town health.";
                    break;
                case 10:
                    eventsText = "10! Pick one resource to lose and suffer all consequences (note, this is not implemented at this time).";
                    break;
                default:
                    eventsText = "Roll glitched. No effect";
                    //No efect
                    break;
            }

            //Update description for user to see the effects
            RollTownEventTextGameObject.GetComponent<Text>().text = eventsText;

            //Disable the roll button now because we only roll once per turn
            RollTownEventButtonGameObject.GetComponent<Button>().interactable = false;
        }

        public void OnMovementDeedPress()
        {
            Debug.Log("Movement deed selected");
            PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "Please select the hex you would like your party to move to.";
            GameManagerInstance.SetPlayerIsMoving(GameManagerInstance.GetIndexForMyPlayer());
        }

        public void OnEncounterDeedPress()
        {
            Debug.Log("Encounter deed selected");
            PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "Please select the encounter type...";
            EncounterSelectionPanelGameObject.SetActive(true);
            Coordinates partyLocation = GameManagerInstance.GetPartyLocation(GameManagerInstance.GetIndexForMyPlayer());
            MapLayout mapLayout = GameManagerInstance.GetMapLayout();
            if (mapLayout.IsPlains(partyLocation) || mapLayout.IsResource(partyLocation))
            {
                GameObject.Find("PlainsEncounterButton").GetComponent<Button>().interactable = true;
            }
            if (mapLayout.IsMountain(partyLocation) || mapLayout.IsResource(partyLocation))
            {
                GameObject.Find("MountainEncounterButton").GetComponent<Button>().interactable = true;
            }
            if (mapLayout.IsCity(partyLocation) || mapLayout.IsRad(partyLocation) || mapLayout.IsResource(partyLocation))
            {
                GameObject.Find("CityRadEncounterButton").GetComponent<Button>().interactable = true;
            }
        }

        public void OnPvpDeedPress()
        {
        
        }

        public void OnResourceDeedPress()
        {
        
        }

        public void OnHealingDeedPress()
        {
        
        }

        public void OnMissionDeedPress()
        {
            
        }

        public void OnPlainEncounterPress()
        {
            Debug.Log("On plains encounter selected.");
            GameObject.Find("PlainsEncounterButton").GetComponent<Button>().interactable = false;
            GameObject.Find("MountainEncounterButton").GetComponent<Button>().interactable = false;
            GameObject.Find("CityRadEncounterButton").GetComponent<Button>().interactable = false;
            EncounterSelectionPanelGameObject.SetActive(false);

            PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "Time for a plains encounter...";
            GameManagerInstance.SetPlayerIsDoingAnEncounter(GameManagerInstance.GetIndexForMyPlayer(), Constants.ENCOUNTER_PLAINS);
        }

        public void OnMountainEncounterPress()
        {

        }

        public void OnCityRadEncounterPress()
        {
        
        }

        public void OnVerticalCardClosePress()
        {
            closeFullScreenCard();
        }

        public void OnHorizontalClosePress()
        {
            closeFullScreenCard();
        }

        public void OnBeginEncounterPress()
        {
            PartyOverviewPanel.SetActive(false);
            OverallEncounterPanelGameObject.SetActive(false);
            MainEncounterCardImage.SetActive(true);
            PartyExploitsPanel.SetActive(false);
            MainEncounterCardImage.GetComponent<Image>().sprite = loadEncounterCard();
            EncounterHasBegun = true;
        }
        #endregion

        #region HelperFunctions
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
            AuctionHouseTradeButton.interactable = (CurrentViewedID != GameManagerInstance.GetIndexForMyPlayer());
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
                    GameObject imageObj = Instantiate(ImageGameObject);
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
                    image.transform.localPosition = new Vector3(97f + (i % 8 * OFFSET_X), -64f - (i / 8 * OFFSET_Y), 0f);
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
                    GameObject imageObj = Instantiate(ImageGameObject);
                    Image image = imageObj.GetComponent<Image>();
                    string fileName = "Cards/CharacterCards/CharacterCard" + townRoster[i].GetId().ToString();
                    Sprite curSprite = Resources.Load<Sprite>(fileName);
                    image.sprite = curSprite;
                    imageObj.name = "CharacterCard" + townRoster[i].GetId().ToString();
                    image.transform.SetParent(TownRosterScrollContent.transform);
                    image.transform.localPosition = new Vector3(97f + (i % 8 * OFFSET_X), -64f - (i / 8 * OFFSET_Y), 0f);
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

                    const float FIRST_CARD_Y = -50f;
                    const float CARD_X = 60f;
                    if (activeCharacters[activeIndex] != null)
                    {
                        //Add character back to slot
                        GameObject imageObj = Instantiate(ImageGameObject);
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
                        image.transform.localPosition = new Vector3(CARD_X, FIRST_CARD_Y, 0f);
                        image.transform.localScale = new Vector3(1f, 1f, 1f);
                        image.rectTransform.sizeDelta = new Vector2(75, 100);
                        image.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                        imageObj.GetComponentInChildren<MonoCard>().CardPtr = activeCharacters[activeIndex];

                        //Add spoils back to slot
                        List<SpoilsCard> curSlotSpoils = activeCharacters[activeIndex].GetEquippedSpoils();
                        for (int curSpoilIndex = 0; curSpoilIndex < curSlotSpoils.Count; curSpoilIndex++)
                        {
                            GameObject imageObj2 = Instantiate(ImageGameObject);
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
                            image2.transform.localPosition = new Vector3(CARD_X, FIRST_CARD_Y - ((curSpoilIndex + 1) * OFFSET_Y), 0f);
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
                        for (int i = 0; i < ActiveCharactersStatsText[activeIndex][(int)skill].Count; i++)
                        {
                            ActiveCharactersStatsText[activeIndex][(int)skill][i].GetComponentInChildren<Text>().text = curCharacterSlotStats[skill].ToString();
                        }
                    }

                    //Update psych resistance
                    int psychResistance = GameManagerInstance.GetActiveCharacterPsychResistance(CurrentViewedID, activeIndex);
                    for (int i = 0; i < ActiveCharactersPsychResistance[activeIndex].Count; i++)
                    {
                        ActiveCharactersPsychResistance[activeIndex][i].GetComponentInChildren<Text>().text = psychResistance.ToString();
                    }

                    //Update carry weight
                    int totalCarryWeight = GameManagerInstance.GetActiveCharacterTotalCarryWeight(CurrentViewedID, activeIndex);
                    int usedCarryWeight = GameManagerInstance.GetActiveCharacterUsedCarryWeight(CurrentViewedID, activeIndex);
                    for (int i = 0; i < ActiveCharactersCarryWeightsText[activeIndex].Count; i++)
                    {
                        ActiveCharactersCarryWeightsText[activeIndex][i].GetComponentInChildren<Text>().text = usedCarryWeight.ToString() + "/" + totalCarryWeight.ToString();
                    }

                    //Update psych
                    int remainingPsych = GameManagerInstance.GetActiveCharacterRemainingPsych(CurrentViewedID, activeIndex);
                    int maxPsych = GameManagerInstance.GetMaxPsych();
                    for (int i = 0; i < ActiveCharactersPsychText[activeIndex].Count; i++)
                    {
                        ActiveCharactersPsychText[activeIndex][i].GetComponentInChildren<Text>().text = remainingPsych.ToString() + "/" + maxPsych.ToString();
                    }

                    //Update health
                    int remainingHealth = GameManagerInstance.GetActiveCharacterRemainingHealth(CurrentViewedID, activeIndex);
                    int maxHealth = GameManagerInstance.GetActiveCharacterMaxHealth(CurrentViewedID, activeIndex);
                    for (int i = 0; i < ActiveCharactersHealthText[activeIndex].Count; i++)
                    {
                        ActiveCharactersHealthText[activeIndex][i].GetComponentInChildren<Text>().text = remainingHealth.ToString() + "/" + maxHealth.ToString();
                    }
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

                const float FIRST_CARD_Y = -50f;
                const float CARD_X = 60f;
                if (activeVehicle != null)
                {
                    //Add vehicle back to slot
                    GameObject imageObj = Instantiate(ImageGameObject);
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
                    image.transform.localPosition = new Vector3(CARD_X, FIRST_CARD_Y, 0f);
                    image.transform.localScale = new Vector3(1f, 1f, 1f);
                    image.rectTransform.sizeDelta = new Vector2(75, 100);
                    image.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                    imageObj.GetComponentInChildren<MonoCard>().CardPtr = activeVehicle;

                    //Add spoils back to slot
                    List<SpoilsCard> curSlotSpoils = activeVehicle.GetEquippedSpoils();
                    Debug.Log("There are currently " + curSlotSpoils.Count + " spoils attached to the vehicle");
                    for (int curSpoilIndex = 0; curSpoilIndex < curSlotSpoils.Count; curSpoilIndex++)
                    {
                        GameObject imageObj2 = Instantiate(ImageGameObject);
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
                        image2.transform.localPosition = new Vector3(CARD_X, FIRST_CARD_Y - ((curSpoilIndex + 1) * OFFSET_Y), 0f);
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
                    for (int i = 0; i < ActiveVehicleStatsText[(int)skill].Count; i++)
                    {
                        ActiveVehicleStatsText[(int)skill][i].GetComponentInChildren<Text>().text = vehicleStats[skill].ToString();
                    }
                }
                int totalCarryWeight = GameManagerInstance.GetActiveVehicleTotalCarryWeight(CurrentViewedID);
                int usedCarryWeight = GameManagerInstance.GetActiveVehicleUsedCarryWeight(CurrentViewedID);
                for (int i = 0; i < ActiveVehicleCarryWeightsText.Count; i++)
                {
                    ActiveVehicleCarryWeightsText[i].GetComponentInChildren<Text>().text = usedCarryWeight.ToString() + "/" + totalCarryWeight.ToString();
                }
            }
        }

        private void updateTurnInformation()
        {
            ActualTurnNumberText.text = GameManagerInstance.GetTurn().ToString();
            ActualTurnPhaseText.text = PhasesHelpers.PhaseToString(GameManagerInstance.GetPhase());
        }

        private void updateTownEventsUi()
        {
            Phases currentPhase = GameManagerInstance.GetPhase();
            if (currentPhase == Phases.Town_Business_Town_Events_Chart || currentPhase == Phases.After_Town_Business_Town_Events_Chart)
            {
                TownEventsRollPanel.SetActive(true);
                if (GameManagerInstance.GetCurrentPlayer() != null && GameManagerInstance.GetCurrentPlayer().UserId == GameManagerInstance.GetMyUserId() && !UserRolledTownEventsThisTurn)
                {
                    RollTownEventButtonGameObject.GetComponent<Button>().interactable = true;
                }
                else
                {
                    RollTownEventButtonGameObject.GetComponent<Button>().interactable = false;
                }
            }
            else
            {
                TownEventsRollPanel.SetActive(false);
                //Reset the UI once it's deactivated so it's ready for next time it shows
                RollTownEventButtonGameObject.GetComponent<Button>().interactable = true;
                RollTownEventTextGameObject.GetComponent<Text>().text = "Roll to see effects...";
                UserRolledTownEventsThisTurn = false;
            }
        }

        private void updatePartyExploitsUi()
        {
            Phases currentPhase = GameManagerInstance.GetPhase();
            if (currentPhase == Phases.Party_Exploits_Party && !EncounterHasBegun)
            {
                PartyExploitsPanel.SetActive(true);
                ActualRemainingWeeksTextGameObject.GetComponent<Text>().text = GameManagerInstance.GetRemainingPartyExploitWeeks(CurrentViewedID).ToString();
                changePartyExploitsButtonStatesAsNeeded();
                if (!GameManagerInstance.GetPlayerIsMoving(GameManagerInstance.GetIndexForMyPlayer()) && !GameManagerInstance.GetPlayerIsDoingAnEncounter(GameManagerInstance.GetIndexForMyPlayer()))
                {
                    PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "";
                }
                if (GameManagerInstance.GetPlayerIsDoingAnEncounter(GameManagerInstance.GetIndexForMyPlayer()) && GameManagerInstance.GetCurrentEncounter() != null && !EncounterHasBegun)
                {
                    OverallEncounterPanelGameObject.SetActive(true);
                    Image cardImage = GameObject.Find("EncounterCardImage").GetComponent<Image>();
                    cardImage.sprite = loadEncounterCard();
                    updateStatPanelsForOverallEncounterPage();
                }
            }
            else
            {
                PartyExploitsPanel.SetActive(false);
            }
        }

        private void updateEndPhaseButton()
        {
            if (GameManagerInstance.GetIsItMyTurn())
            {
                Phases currentPhase = GameManagerInstance.GetCurrentPhase();
                if (currentPhase == Phases.Town_Business_Town_Events_Chart && !UserRolledTownEventsThisTurn)
                {
                    EndPhaseButton.interactable = false;
                    EndPhaseButton.GetComponentInChildren<Text>().text = "Roll...";
                }
                else if (currentPhase == Phases.Party_Exploits_Party && GameManagerInstance.GetRemainingPartyExploitWeeks(GameManagerInstance.GetIndexForMyPlayer()) > 0)
                {
                    EndPhaseButton.interactable = false;
                    EndPhaseButton.GetComponentInChildren<Text>().text = "Deeds...";
                }
                else
                {
                    EndPhaseButton.interactable = true;
                    EndPhaseButton.GetComponentInChildren<Text>().text = "End Phase";
                }
            }
            else
            {
                EndPhaseButton.interactable = false;
                EndPhaseButton.GetComponentInChildren<Text>().text = "Waiting...";
            }
        }

        private void changePartyExploitsButtonStatesAsNeeded()
        {
            if (GameManagerInstance.GetIsItMyTurn() && GameManagerInstance.GetRemainingPartyExploitWeeks(GameManagerInstance.GetIndexForMyPlayer()) > 0)
            {
                GameObject.Find("MovementButton").GetComponent<Button>().interactable = true;

                MapLayout mapLayout = GameManagerInstance.GetMapLayout();
                bool shouldEnableEncounterDeedButton = !mapLayout.IsFactionBase(GameManagerInstance.GetPartyLocation(GameManagerInstance.GetIndexForMyPlayer()));
                GameObject.Find("EncounterButton").GetComponent<Button>().interactable = shouldEnableEncounterDeedButton;
            }
            else
            {
                GameObject.Find("MovementButton").GetComponent<Button>().interactable = false;
                GameObject.Find("EncounterButton").GetComponent<Button>().interactable = false;
                GameObject.Find("PVPButton").GetComponent<Button>().interactable = false;
                GameObject.Find("ResourceButton").GetComponent<Button>().interactable = false;
                GameObject.Find("HealingButton").GetComponent<Button>().interactable = false;
                GameObject.Find("MissionButton").GetComponent<Button>().interactable = false;
            }
        }

        private Sprite loadEncounterCard()
        {
            EncounterCard encounterCard = GameManagerInstance.GetCurrentEncounter();
            string imageLocation = "Cards/EncounterCards/";
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            if (GameManagerInstance.GetPlayerEncounterType(myIndex) == Constants.ENCOUNTER_PLAINS)
            {
                imageLocation += "Plains/";
            }
            else if (GameManagerInstance.GetPlayerEncounterType(myIndex) == Constants.ENCOUNTER_MOUNTAINS)
            {
                imageLocation += "Mountains/";
            }
            else if (GameManagerInstance.GetPlayerEncounterType(myIndex) == Constants.ENCOUNTER_CITY_RAD)
            {
                imageLocation += "CityRad/";
            }
            imageLocation += "Plains" + encounterCard.GetId().ToString();
            return (Sprite)Resources.Load<Sprite>(imageLocation);
        }

        private void updateStatPanelsForOverallEncounterPage()
        {
            EncounterCard card = GameManagerInstance.GetCurrentEncounter();
            if (card != null)
            {
                Dictionary<Skills, int> skillChecks = card.GetSkillChecks();
                List<bool> partySkillChecks = card.GetArePartySkillCheck();
                for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
                {
                    foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
                    {
                        Color color = OverallEncounterPlayerStatPanels[i][(int)skill].GetComponent<Image>().color;
                        if (skillChecks[skill] != 0 && partySkillChecks[(int)skill]) //TODO doesn't handle character specific checks
                        {
                            color.a = 128;
                        }
                        else
                        {
                            color.a = 0;
                        }
                        OverallEncounterPlayerStatPanels[i][(int)skill].GetComponent<Image>().color = color;
                    }
                }
                foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
                {
                    Color color = OverallEncounterVehicleStatPanels[(int)skill].GetComponent<Image>().color;
                    if (skillChecks[skill] != 0 && partySkillChecks[(int)skill]) //TODO doesn't handle vehicle specific checks 
                    {
                        color.a = 128;
                    }
                    else
                    {
                        color.a = 0;
                    }
                    OverallEncounterVehicleStatPanels[(int)skill].GetComponent<Image>().color = color;
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

        private void updatePlayerPanels()
        {
            int numPlayers = PhotonNetwork.PlayerList.Length;
            for (int currentPlayerIndex = 0; currentPlayerIndex < Constants.MAX_NUM_PLAYERS; currentPlayerIndex++)
            {
                if (currentPlayerIndex < numPlayers && GameManagerInstance.GetFaction(currentPlayerIndex) != null)
                {
                    Debug.Log("Setting faction information for player " + currentPlayerIndex);
                    PlayerPanels[currentPlayerIndex].SetActive(true);
                    Color color = PlayerPanels[currentPlayerIndex].GetComponentInChildren<Image>().color;
                    color.a = (currentPlayerIndex == CurrentViewedID) ? 244f / 255f : 150f / 255f;
                    PlayerPanels[currentPlayerIndex].GetComponentInChildren<Image>().color = color;
                    string factionPath = "Factions/FactionSymbols/FactionSymbol" + GameManagerInstance.GetFaction(currentPlayerIndex).GetId().ToString();
                    Sprite factionSprite = Resources.Load<Sprite>(factionPath);
                    PlayerPanels[currentPlayerIndex].transform.Find("FactionImage").GetComponentInChildren<Image>().sprite = factionSprite;
                    PlayerPanels[currentPlayerIndex].transform.Find("PlayerNameText").GetComponentInChildren<Text>().text = PhotonNetwork.PlayerList[currentPlayerIndex].NickName;
                    PlayerPanels[currentPlayerIndex].transform.Find("PrestigeActualText").GetComponentInChildren<Text>().text = GameManagerInstance.GetPrestige(currentPlayerIndex).ToString();
                    PlayerPanels[currentPlayerIndex].transform.Find("TownHealthActualText").GetComponentInChildren<Text>().text = GameManagerInstance.GetTownHealth(currentPlayerIndex).ToString();
                    PlayerPanels[currentPlayerIndex].transform.Find("SalvageActualText").GetComponentInChildren<Text>().text = GameManagerInstance.GetSalvage(currentPlayerIndex).ToString();
                }
                else
                {
                    PlayerPanels[currentPlayerIndex].SetActive(false);
                }
            }
        }

        private void updateActionButton()
        {
            ActionCardsButton.interactable = (CurrentViewedID == GameManagerInstance.GetIndexForMyPlayer());
        }

        private void updateFullScreenCard()
        {
            if (EscapePressed && CardIsClicked)
            {
                closeFullScreenCard();
                EscapePressed = false;
            }
            if (CardIsClicked)
            {
                CardFullScreenGameObject.SetActive(true);
                FullScreenCardVertical.SetActive(!CardIsHorizontal);
                FullScreenCardHorizontal.SetActive(CardIsHorizontal);
                HorizontalCloseButton.SetActive(CardIsHorizontal);
                VerticalCloseButton.SetActive(!CardIsHorizontal);

                FullScreenCardVertical.GetComponent<Image>().sprite = CardSpriteThatWasClicked;
                FullScreenCardHorizontal.GetComponent<Image>().sprite = CardSpriteThatWasClicked;
            }
            
        }

        private void closeFullScreenCard()
        {
            CardIsClicked = false;
            CardFullScreenGameObject.SetActive(false);
        }
        #endregion
    }
}