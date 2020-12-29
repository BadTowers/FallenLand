using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private GameObject EncounterSelectionPanel;
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
        private GameObject MainPartyOverviewPanel;
        private GameObject MainEncounterCardImage;
        private bool EncounterHasBegun;
        private GameObject EncounterRollPanel;
        private GameObject EncounterStatsPanel;
        private List<GameObject> CharacterEncounterRollImages;
        private List<GameObject> CharacterEncounterCurrentStatText;
        private List<GameObject> CharacterEncounterPanels;
        private GameObject VehicleEncounterRollImage;
        private GameObject VehicleEncounterCurrentStatText;
        private GameObject VehicleEncounterPanel;
        private List<GameObject> CurrentEncounterRollSymbols;
        private int CurrentEncounterSkillPage;
        private List<GameObject> CurrentEncounterCharacterAutoSuccesses;
        private List<GameObject> CurrentEncounterCharacterRolledSuccesses;
        private GameObject CurrentEncounterVehicleAutoSuccesses;
        private GameObject CurrentEncounterVehicleRolledSuccesses;
        private GameObject TotalSuccessesNeededText;
        private GameObject NumberOfTotalSuccessesText;
        private List<GameObject> CharacterEncounterRollButtons;
        private GameObject VehicleRollButton;
        private List<GameObject> LastCharacterDiceRollText;
        private GameObject LastVehicleDiceRollText;
        private GameObject RollAllButton;
        private GameObject EncounterFinishedPanel;
        private GameObject DiscardPopupPanel;
        private GameObject DiscardedCardImage;
        private GameObject DiscardedPanel;
        private GameObject DistributeD6DamagePopupPanel;
        private List<GameObject> PartyOverviewInfectedSymbols;
        private List<GameObject> PartyOverviewRadiationSymbols;
        private GameObject GenericPopupWithTwoLinesOfTextPanel;
        private GameObject GenericPopupTextPanel;
        private GameObject GenericPopupText;
        private GameObject EncounterButton;
        private GameObject ResourceButton;
        private bool WasResourceClicked;
        private bool WasEncounterClicked;

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
            MainOverlay = GameObject.Find("MainOverlay");
            TradeOverlay = GameObject.Find("TradeOverlay");
            TownEventsRollPanel = GameObject.Find("TownEventsPanel");
            RollTownEventButtonGameObject = GameObject.Find("RollTownEventsButton");
            RollTownEventTextGameObject = GameObject.Find("RollTownEventsText");
            PartyExploitsPanel = GameObject.Find("PartyExploitsPanel");
            ActualRemainingWeeksTextGameObject = GameObject.Find("ActualRemainingWeeksText");
            PartyExploitsInformationTextGameObject = GameObject.Find("PartyExploitsInformationText");
            EncounterSelectionPanel = GameObject.Find("EncounterSelectionPanel");
            OverallEncounterPanelGameObject = GameObject.Find("OverallEncounterPanel");
            CardFullScreenGameObject = GameObject.Find("CardFullScreenPanel");
            FullScreenCardVertical = GameObject.Find("LargeCardImageVertical");
            FullScreenCardHorizontal = GameObject.Find("LargeCardImageHorizontal");
            VerticalCloseButton = GameObject.Find("VerticalCloseButton");
            HorizontalCloseButton = GameObject.Find("HorizontalCloseButton");
            MainPartyOverviewPanel = GameObject.Find("MainPartyOverviewPanel");
            MainEncounterCardImage = GameObject.Find("MainEncounterCardImage");
            EncounterRollPanel = GameObject.Find("EncounterRollPanel");
            EncounterStatsPanel = GameObject.Find("EncounterStatsPanel");
            TotalSuccessesNeededText = GameObject.Find("TotalSuccessesNeededText");
            NumberOfTotalSuccessesText = GameObject.Find("NumberOfTotalSuccessesText");
            DiscardPopupPanel = GameObject.Find("DiscardPopupPanel");
            DiscardedCardImage = GameObject.Find("DiscardedCardImage");
            DiscardedPanel = GameObject.Find("DiscardedPanel");
            DistributeD6DamagePopupPanel = GameObject.Find("DistributeD6DamagePopupPanel");
            GenericPopupWithTwoLinesOfTextPanel = GameObject.Find("GenericPopupWithTwoLinesOfTextPanel");
            GenericPopupTextPanel = GameObject.Find("GenericPopupTextPanel");
            GenericPopupText = GameObject.Find("GenericPopupText");
            EncounterButton = GameObject.Find("EncounterButton");
            ResourceButton = GameObject.Find("ResourceButton");

            findEncounterRollGameObjects();
            findEncounterStatGameObjects();

            ActiveCharactersScrollContent = new List<GameObject>();
            OverallEncounterVehicleStatPanels = new List<GameObject>();
            PartyOverviewInfectedSymbols = new List<GameObject>();
            PartyOverviewRadiationSymbols = new List<GameObject>();

            AuctionHouseScrollContent = GameObject.Find("AuctionHouseScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
            TownRosterScrollContent = GameObject.Find("TownRosterScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
            ActionCardsScrollContent = GameObject.Find("ActionCardsScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
            for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
            {
                ActiveCharactersScrollContent.Add(GameObject.Find("CharacterSlotScrollView" + (i + 1).ToString()).transform.Find("Viewport").transform.Find("Content").gameObject);
                PartyOverviewInfectedSymbols.Add(GameObject.Find("InfectedImage" + (i + 1).ToString()));
                PartyOverviewRadiationSymbols.Add(GameObject.Find("RadiationImage" + (i + 1).ToString()));
                PartyOverviewInfectedSymbols[i].SetActive(false);
                PartyOverviewRadiationSymbols[i].SetActive(false);
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
            EncounterRollPanel.SetActive(false);
            EncounterStatsPanel.SetActive(false);
            EncounterSelectionPanel.SetActive(false);
            DiscardPopupPanel.SetActive(false);
            DistributeD6DamagePopupPanel.SetActive(false);
            GenericPopupWithTwoLinesOfTextPanel.SetActive(false);

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

        public override void OnEnable()
        {
            base.OnEnable();
            EventManager.OnSpoilsCardDiscarded += onShowSpoilsCardDiscardedPopup;
            EventManager.OnD6DamageNeedsToBeDistributed += onDistributeD6DamagePopup;
            EventManager.OnD6HealingNeedsDistributed += onDistributeD6HealingPopup;
            EventManager.OnCharacterCrownTakesDamage += onCharacterCrownTakesDamage;
            EventManager.OnVehicleDestroyed += onVehicleDestroyed;
            EventManager.OnShowGenericPopup += onShowGenericPopup;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            EventManager.OnSpoilsCardDiscarded -= onShowSpoilsCardDiscardedPopup;
            EventManager.OnD6DamageNeedsToBeDistributed -= onDistributeD6DamagePopup;
            EventManager.OnD6HealingNeedsDistributed -= onDistributeD6HealingPopup;
            EventManager.OnCharacterCrownTakesDamage -= onCharacterCrownTakesDamage;
            EventManager.OnVehicleDestroyed -= onVehicleDestroyed;
            EventManager.OnShowGenericPopup -= onShowGenericPopup;
        }

        void Update()
        {
            //TODO refactor to a function that returns a list of buttons pressed. That list can then later be passed to an interpretter
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EscapePressed = true;
            }

            updateActionButton();

            updatePartyOverviewValues();

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
            WasResourceClicked = false;
            WasEncounterClicked = false;
            EncounterSelectionPanel.SetActive(false); //Close this panel if the user was going to do an encounter but switched to movement

            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            bool moving = GameManagerInstance.GetPlayerIsMoving(myIndex);
            moving = !moving;
            GameManagerInstance.SetPlayerIsMoving(myIndex, moving);
            if (moving)
            {
                PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "Please select the hex you would like your party to move to.";
            }
            else
            {
                PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "";
            }
        }

        public void OnEncounterDeedPress()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();

            //Cleanup other party exploits stuff
            Debug.Log("Encounter deed selected");
            WasResourceClicked = false;
            GameManagerInstance.SetPlayerIsMoving(myIndex, false); //cancel movement if it was happening

            WasEncounterClicked = !WasEncounterClicked;
            EncounterSelectionPanel.SetActive(WasEncounterClicked);
            if (WasEncounterClicked)
            {
                Coordinates partyLocation = GameManagerInstance.GetPartyLocation(myIndex);
                MapLayout mapLayout = GameManagerInstance.GetMapLayout();
                PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "Please select the encounter type...";
                GameObject.Find("PlainsEncounterButton").GetComponent<Button>().interactable = mapLayout.IsPlains(partyLocation);
                GameObject.Find("MountainEncounterButton").GetComponent<Button>().interactable = mapLayout.IsMountain(partyLocation);
                GameObject.Find("CityRadEncounterButton").GetComponent<Button>().interactable = (mapLayout.IsCity(partyLocation) || mapLayout.IsRad(partyLocation));
            }
            else
            {
                PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "";
            }
        }

        public void OnPvpDeedPress()
        {
            //Cleanup other party exploits stuff
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            WasResourceClicked = false;
            WasEncounterClicked = false;
            GameManagerInstance.SetPlayerIsMoving(myIndex, false); //cancel movement if it was happening
            EncounterSelectionPanel.SetActive(false); //Close this panel if the user was going to do an encounter but switched to pvp
            PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "";

            //TODO
        }

        public void OnResourceDeedPress()
        {
            Debug.Log("Resource deed selected");

            //Cleanup other party exploits stuff
            WasEncounterClicked = false;
            GameManagerInstance.SetPlayerIsMoving(GameManagerInstance.GetIndexForMyPlayer(), false); //cancel movement if it was happening

            WasResourceClicked = !WasResourceClicked;
            EncounterSelectionPanel.SetActive(WasResourceClicked);
            if (WasResourceClicked)
            {
                GameObject.Find("PlainsEncounterButton").GetComponent<Button>().interactable = WasResourceClicked;
                GameObject.Find("MountainEncounterButton").GetComponent<Button>().interactable = WasResourceClicked;
                GameObject.Find("CityRadEncounterButton").GetComponent<Button>().interactable = WasResourceClicked;
                PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "Please select the encounter type...";
            }
            else
            {
                PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "";
            }
        }

        public void OnHealingDeedPress()
        {
            //Cleanup other party exploits stuff
            WasResourceClicked = false;
            WasEncounterClicked = false;
            GameManagerInstance.SetPlayerIsMoving(GameManagerInstance.GetIndexForMyPlayer(), false); //cancel movement if it was happening
            EncounterSelectionPanel.SetActive(false); //Close this panel if the user was going to do an encounter but switched to healing
            PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "";

            //TODO
        }

        public void OnMissionDeedPress()
        {
            //Cleanup other party exploits stuff
            WasResourceClicked = false;
            WasEncounterClicked = false;
            GameManagerInstance.SetPlayerIsMoving(GameManagerInstance.GetIndexForMyPlayer(), false); //cancel movement if it was happening
            EncounterSelectionPanel.SetActive(false); //Close this panel if the user was going to do an encounter but switched to mission
            PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "";

            //TODO
        }

        public void OnPlainEncounterPress()
        {
            Debug.Log("On plains encounter selected.");
            GameObject.Find("PlainsEncounterButton").GetComponent<Button>().interactable = false;
            GameObject.Find("MountainEncounterButton").GetComponent<Button>().interactable = false;
            GameObject.Find("CityRadEncounterButton").GetComponent<Button>().interactable = false;
            EncounterSelectionPanel.SetActive(false);

            PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "Time for a plains encounter...";
            GameManagerInstance.SetPlayerIsDoingAnEncounter(GameManagerInstance.GetIndexForMyPlayer(), Constants.ENCOUNTER_PLAINS);
        }

        public void OnMountainEncounterPress()
        {
            Debug.LogError("Mountain encounters are not implemented currently. Please select another.");
        }

        public void OnCityRadEncounterPress()
        {
            Debug.LogError("City/Rad encounters are not implemented currently. Please select another.");
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
            MainPartyOverviewPanel.SetActive(false);
            OverallEncounterPanelGameObject.SetActive(false);
            MainEncounterCardImage.SetActive(true);
            PartyExploitsPanel.SetActive(false);
            EncounterRollPanel.SetActive(true);
            EncounterStatsPanel.SetActive(true);
            MainEncounterCardImage.GetComponent<Image>().sprite = loadEncounterCard();
            EncounterHasBegun = true;
            GameManagerInstance.AddSalvageAtStartOfEncounter(GameManagerInstance.GetIndexForMyPlayer(), WasResourceClicked);
            GameManagerInstance.HandleActionsOnBegin();
        }

        public void OnCharacter1RollPress()
        {
            int characterIndex = 0;
            GameManagerInstance.RollCharacterEncounter(GameManagerInstance.GetIndexForMyPlayer(), characterIndex, CurrentEncounterSkillPage);
        }

        public void OnCharacter2RollPress()
        {
            int characterIndex = 1;
            GameManagerInstance.RollCharacterEncounter(GameManagerInstance.GetIndexForMyPlayer(), characterIndex, CurrentEncounterSkillPage);
        }

        public void OnCharacter3RollPress()
        {
            int characterIndex = 2;
            GameManagerInstance.RollCharacterEncounter(GameManagerInstance.GetIndexForMyPlayer(), characterIndex, CurrentEncounterSkillPage);
        }

        public void OnCharacter4RollPress()
        {
            int characterIndex = 3;
            GameManagerInstance.RollCharacterEncounter(GameManagerInstance.GetIndexForMyPlayer(), characterIndex, CurrentEncounterSkillPage);
        }

        public void OnCharacter5RollPress()
        {
            int characterIndex = 4;
            GameManagerInstance.RollCharacterEncounter(GameManagerInstance.GetIndexForMyPlayer(), characterIndex, CurrentEncounterSkillPage);
        }

        public void OnVehicleRollPress()
        {
            GameManagerInstance.RollVehicleEncounter(GameManagerInstance.GetIndexForMyPlayer(), CurrentEncounterSkillPage);
        }

        public void OnRollAllPress()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            //characters
            for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
            {
                if (GameManagerInstance.DoesCharacterHaveRollsRemainingForSkill(myIndex, characterIndex, CurrentEncounterSkillPage))
                {
                    GameManagerInstance.RollCharacterEncounter(myIndex, characterIndex, CurrentEncounterSkillPage);
                }
            }

            //vehicle
            if (GameManagerInstance.DoesVehicleHaveRollsRemainingForSkill(myIndex, CurrentEncounterSkillPage))
            {
                GameManagerInstance.RollVehicleEncounter(myIndex, CurrentEncounterSkillPage);
            }
        }

        public void OnPreviousEncounterStatPress()
        {
            CurrentEncounterSkillPage++;
            if (CurrentEncounterSkillPage >= GameManagerInstance.GetCurrentEncounter(GameManagerInstance.GetIndexForMyPlayer()).GetSkillChecks().Count)
            {
                CurrentEncounterSkillPage = 0;
            }
            updateSkillIcons();
        }

        public void OnNextEncounterStatPress()
        {
            CurrentEncounterSkillPage--;
            if (CurrentEncounterSkillPage < 0)
            {
                CurrentEncounterSkillPage = GameManagerInstance.GetCurrentEncounter(GameManagerInstance.GetIndexForMyPlayer()).GetSkillChecks().Count - 1;
            }
            updateSkillIcons();
        }

        public void OnAcceptEncounterResultsPress()
        {
            GameManagerInstance.SetEncounterResultAccepted(GameManagerInstance.GetIndexForMyPlayer(), WasResourceClicked);

            MainPartyOverviewPanel.SetActive(true);
            MainEncounterCardImage.SetActive(false);
            PartyExploitsPanel.SetActive(true);
            EncounterRollPanel.SetActive(false);
            EncounterStatsPanel.SetActive(false);
            EncounterFinishedPanel.SetActive(false);
            EncounterHasBegun = false;
            CurrentEncounterSkillPage = 0;
            WasResourceClicked = false;
        }

        public void OnDiscardPanelOkPress()
        {
            DiscardPopupPanel.SetActive(false);
        }

        public void OnGenericPopupOkPress()
        {
            GenericPopupWithTwoLinesOfTextPanel.SetActive(false);
        }
        #endregion

        #region HelperFunctions
        private void onShowSpoilsCardDiscardedPopup(SpoilsCard card)
        {
            DiscardPopupPanel.SetActive(true);
            DiscardedCardImage.GetComponent<Image>().sprite = card.GetCardImage();
            showPopup(DiscardedPanel);
        }

        private void onDistributeD6DamagePopup(int numD6s)
        {
            Debug.LogError("TODO onDistributeD6DamagePopup");
            //eventually, show this panel and do the do's DistributeD6DamagePopupPanel
        }

        private void onDistributeD6HealingPopup(int numD6s)
        {
            Debug.LogError("TODO onDistributeD6HealingPopup");
        }

        private void onCharacterCrownTakesDamage(int characterIndex, int amountOfDamage, byte damageType, int remainingHp, bool discardsEquipment)
        {
            GenericPopupWithTwoLinesOfTextPanel.SetActive(true);
            if (GameManagerInstance.GetActiveCharacterCards(GameManagerInstance.GetIndexForMyPlayer())[characterIndex] == null && remainingHp == -1)
            {
                GenericPopupText.GetComponent<Text>().text = "Crown " + (characterIndex + 1) + " was empty. No damage taken!";
            }
            else
            {
                if (damageType == Constants.DAMAGE_PHYSICAL)
                {
                    GenericPopupText.GetComponent<Text>().text = "Crown " + (characterIndex + 1) + " takes " + amountOfDamage + " physical damage!";
                }
                else if (damageType == Constants.DAMAGE_RADIATION)
                {
                    GenericPopupText.GetComponent<Text>().text = "Crown " + (characterIndex + 1) + " takes " + amountOfDamage + " radiation damage!";
                }
                else if (damageType == Constants.DAMAGE_INFECTED)
                {
                    GenericPopupText.GetComponent<Text>().text = "Crown " + (characterIndex + 1) + " takes " + amountOfDamage + " infected damage!";
                }
                else if (damageType == Constants.DAMAGE_PSYCHOLOGICAL)
                {
                    GenericPopupText.GetComponent<Text>().text = "Crown " + (characterIndex + 1) + " takes " + amountOfDamage + " psychological damage!";
                }

                if (remainingHp <= 0)
                {
                    GenericPopupText.GetComponent<Text>().text = GenericPopupText.GetComponent<Text>().text + " They died...";
                }
                if (discardsEquipment)
                {
                    GenericPopupText.GetComponent<Text>().text = GenericPopupText.GetComponent<Text>().text + " Equipment lost!";
                }
            }
            showPopup(GenericPopupTextPanel);
        }

        private void onVehicleDestroyed()
        {
            GenericPopupWithTwoLinesOfTextPanel.SetActive(true);
            GenericPopupText.GetComponent<Text>().text = "Vehicle was destroyed with all its gear!";
            showPopup(GenericPopupTextPanel);
        }

        private void onShowGenericPopup(string text)
        {
            GenericPopupWithTwoLinesOfTextPanel.SetActive(true);
            GenericPopupText.GetComponent<Text>().text = text;
            showPopup(GenericPopupTextPanel);
        }

        private void showPopup(GameObject go)
        {
            go.transform.localScale = new Vector3(0f, 0f, 0f);
            LeanTween.scale(go, new Vector3(1f, 1f, 1f), 1f).setEase(LeanTweenType.easeOutCubic);
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
                    image.sprite = auctionHouse[i].GetCardImage();
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
                    image.sprite = townRoster[i].GetCardImage();
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
                        image.sprite = activeCharacters[activeIndex].GetCardImage();
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
                            image2.sprite = curSlotSpoils[curSpoilIndex].GetCardImage();
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
                    image.sprite = activeVehicle.GetCardImage();
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
                        image2.sprite = curSlotSpoils[curSpoilIndex].GetCardImage();
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
            EncounterCard encounterCard = GameManagerInstance.GetCurrentEncounter(GameManagerInstance.GetIndexForMyPlayer());
            if (currentPhase == Phases.Party_Exploits_Party && !EncounterHasBegun)
            {
                PartyExploitsPanel.SetActive(true);
                ActualRemainingWeeksTextGameObject.GetComponent<Text>().text = GameManagerInstance.GetRemainingPartyExploitWeeks(CurrentViewedID).ToString();
                changePartyExploitsButtonStatesAsNeeded();
                if (!GameManagerInstance.GetPlayerIsMoving(GameManagerInstance.GetIndexForMyPlayer()) && !GameManagerInstance.GetPlayerIsDoingAnEncounter(GameManagerInstance.GetIndexForMyPlayer()))
                {
                    PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "";
                }
                if (GameManagerInstance.GetPlayerIsDoingAnEncounter(GameManagerInstance.GetIndexForMyPlayer()) && encounterCard != null && !EncounterHasBegun)
                {
                    OverallEncounterPanelGameObject.SetActive(true);
                    Image cardImage = GameObject.Find("EncounterCardImage").GetComponent<Image>();
                    cardImage.sprite = loadEncounterCard();
                    updateStatPanelsForOverallEncounterPage();
                }
            }
            else if (currentPhase == Phases.Party_Exploits_Party && EncounterHasBegun)
            {
                updateSkillIcons();
                updateSkillValues();

                //Enable character panels that have someone assigned to it
                List<CharacterCard> characterCards = GameManagerInstance.GetActiveCharacterCards(CurrentViewedID);
                for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
                {
                    if (characterCards[i] != null)
                    {
                        CharacterEncounterPanels[i].SetActive(true);
                        CharacterEncounterRollImages[i].GetComponent<Image>().sprite = characterCards[i].GetCardImage();
                    }
                    else
                    {
                        CharacterEncounterPanels[i].SetActive(false);
                    }
                }

                //Enable vehicle panel if something is assigned to it
                SpoilsCard vehicleCard = GameManagerInstance.GetActiveVehicle(CurrentViewedID);
                if (vehicleCard != null)
                {
                    VehicleEncounterPanel.SetActive(true);
                    VehicleEncounterRollImage.GetComponent<Image>().sprite = vehicleCard.GetCardImage();
                }
                else
                {
                    VehicleEncounterPanel.SetActive(false);
                }

                updateEncounterSkillPanel();
                updateEncounterRollButtons();
                updateEncounterFinishedPanel();
            }
            else
            {
                PartyExploitsPanel.SetActive(false);
                EncounterFinishedPanel.SetActive(false);
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
            if (GameManagerInstance.GetIsItMyTurn() && GameManagerInstance.GetRemainingPartyExploitWeeks(GameManagerInstance.GetIndexForMyPlayer()) > 0 && CurrentViewedID == GameManagerInstance.GetIndexForMyPlayer())
            {
                GameObject.Find("MovementButton").GetComponent<Button>().interactable = true;

                MapLayout mapLayout = GameManagerInstance.GetMapLayout();
                Coordinates partyLocation = GameManagerInstance.GetPartyLocation(GameManagerInstance.GetIndexForMyPlayer());
                bool shouldEnableEncounterDeedButton = !mapLayout.IsFactionBase(partyLocation);
                EncounterButton.GetComponent<Button>().interactable = shouldEnableEncounterDeedButton;
                bool shouldEnableResourceDeedButton = (mapLayout.IsResource(partyLocation) && !GameManagerInstance.IsResourceOwned(partyLocation)); //don't allow taking owned resource at this time
                ResourceButton.GetComponent<Button>().interactable = shouldEnableResourceDeedButton;
            }
            else
            {
                GameObject.Find("MovementButton").GetComponent<Button>().interactable = false;
                EncounterButton.GetComponent<Button>().interactable = false;
                GameObject.Find("PVPButton").GetComponent<Button>().interactable = false;
                ResourceButton.GetComponent<Button>().interactable = false;
                GameObject.Find("HealingButton").GetComponent<Button>().interactable = false;
                GameObject.Find("MissionButton").GetComponent<Button>().interactable = false;
            }
        }

        private Sprite loadEncounterCard()
        {
            EncounterCard encounterCard = GameManagerInstance.GetCurrentEncounter(GameManagerInstance.GetIndexForMyPlayer());
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

        private void findEncounterRollGameObjects()
        {
            CharacterEncounterRollImages = new List<GameObject>();
            CharacterEncounterCurrentStatText = new List<GameObject>();
            CharacterEncounterPanels = new List<GameObject>();
            CharacterEncounterRollButtons = new List<GameObject>();
            LastCharacterDiceRollText = new List<GameObject>();
            for (int characterNumber = 1; characterNumber <= Constants.NUM_PARTY_MEMBERS; characterNumber++)
            {
                CharacterEncounterRollImages.Add(GameObject.Find("EncounterCharacter" + characterNumber.ToString()));
                CharacterEncounterCurrentStatText.Add(GameObject.Find("CharacterStatText" + characterNumber.ToString()));
                CharacterEncounterPanels.Add(GameObject.Find("CharacterEncounterPanel" + characterNumber.ToString()));
                CharacterEncounterRollButtons.Add(GameObject.Find("RollButton" + characterNumber.ToString()));
                LastCharacterDiceRollText.Add(GameObject.Find("LastDiceRollText" + characterNumber.ToString()));
            }
            VehicleEncounterRollImage = GameObject.Find("EncounterCharacterV");
            VehicleEncounterCurrentStatText = GameObject.Find("CharacterStatTextV");
            VehicleEncounterPanel = GameObject.Find("CharacterEncounterPanelV");
            VehicleRollButton = GameObject.Find("RollButtonV");
            LastVehicleDiceRollText = GameObject.Find("LastDiceRollTextV");

            CurrentEncounterRollSymbols = GameObject.FindGameObjectsWithTag("CurrentEncounterRollSymbol").ToList();

            RollAllButton = GameObject.Find("RollAllButton");
            EncounterFinishedPanel = GameObject.Find("EncounterFinishedPanel");
        }

        private void findEncounterStatGameObjects()
        {
            CurrentEncounterCharacterAutoSuccesses = new List<GameObject>();
            CurrentEncounterCharacterRolledSuccesses = new List<GameObject>();

            for(int characterNumber = 1; characterNumber <= Constants.MAX_NUM_PLAYERS; characterNumber++)
            {
                CurrentEncounterCharacterAutoSuccesses.Add(GameObject.Find("NumberOfAutoSuccessesText" + characterNumber.ToString()));
                CurrentEncounterCharacterRolledSuccesses.Add(GameObject.Find("NumberOfRolledSuccessesText" + characterNumber.ToString()));
            }
            CurrentEncounterVehicleAutoSuccesses = GameObject.Find("NumberOfAutoSuccessesTextV");
            CurrentEncounterVehicleRolledSuccesses = GameObject.Find("NumberOfRolledSuccessesTextV");
        }

        private void updateSkillIcons()
        {
            //Determine sprite
            string spriteString = "Cards/CardInformation/";
            Sprite sprite;
            EncounterCard card = GameManagerInstance.GetCurrentEncounter(GameManagerInstance.GetIndexForMyPlayer());
            (Skills skill, int _) = card.GetSkillChecks()[CurrentEncounterSkillPage];
            switch (skill)
            {
                case Skills.Combat:
                    spriteString += "Combat";
                    break;
                case Skills.Diplomacy:
                    spriteString += "Diplomacy";
                    break;
                case Skills.Mechanical:
                    spriteString += "Mechanical";
                    break;
                case Skills.Medical:
                    spriteString += "Medical";
                    break;
                case Skills.Survival:
                    spriteString += "Survival";
                    break;
                case Skills.Technical:
                    spriteString += "Technical";
                    break;
                default:
                    Debug.LogError("Failed to load skill image for encounter");
                    spriteString += "CarryWeight"; //random to denote issue
                    break;
            }

            //Load sprite
            sprite = (Sprite)Resources.Load<Sprite>(spriteString);

            //Assign sprite
            for (int i = 0; i < CurrentEncounterRollSymbols.Count; i++)
            {
                CurrentEncounterRollSymbols[i].GetComponent<Image>().sprite = sprite;
            }
        }

        private void updateSkillValues()
        {
            //Update character values
            for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
            {
                CharacterEncounterCurrentStatText[characterIndex].GetComponent<Text>().text = GameManagerInstance.GetSkillTotalForCharacter(GameManagerInstance.GetIndexForMyPlayer(), characterIndex, CurrentEncounterSkillPage).ToString();
            }

            //Update vehicle value
            VehicleEncounterCurrentStatText.GetComponent<Text>().text = GameManagerInstance.GetSkillTotalForVehicle(GameManagerInstance.GetIndexForMyPlayer(), CurrentEncounterSkillPage).ToString();
        }

        private void updateEncounterSkillPanel()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            (Skills currentSkill, int valueNeeded) = GameManagerInstance.GetCurrentEncounter(myIndex).GetSkillChecks()[CurrentEncounterSkillPage];

            //Update page title
            GameObject.Find("StatPageTitleText").GetComponent<Text>().text = currentSkill.ToString();

            //Update character success values
            for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
            {
                CurrentEncounterCharacterAutoSuccesses[characterIndex].GetComponent<Text>().text = GameManagerInstance.GetCharacterAutoSuccesses(myIndex, characterIndex, CurrentEncounterSkillPage).ToString();
                CurrentEncounterCharacterRolledSuccesses[characterIndex].GetComponent<Text>().text = GameManagerInstance.GetCharacterRolledSuccesses(myIndex, characterIndex, CurrentEncounterSkillPage).ToString();
            }
            //Update vehicle success values
            CurrentEncounterVehicleAutoSuccesses.GetComponent<Text>().text = GameManagerInstance.GetVehicleAutoSuccesses(myIndex, CurrentEncounterSkillPage).ToString();
            CurrentEncounterVehicleRolledSuccesses.GetComponent<Text>().text = GameManagerInstance.GetVehicleRolledSuccesses(myIndex, CurrentEncounterSkillPage).ToString();

            //Update total successes needed
            TotalSuccessesNeededText.GetComponent<Text>().text = valueNeeded.ToString();

            //Update number of successes had
            NumberOfTotalSuccessesText.GetComponent<Text>().text = GameManagerInstance.GetTotalSuccesses(myIndex, CurrentEncounterSkillPage).ToString();
        }

        private void updateEncounterRollButtons()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            //Update character roll buttons
            List<CharacterCard> activeCharacters = GameManagerInstance.GetActiveCharacterCards(myIndex);
            for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
            {
                if (activeCharacters[characterIndex] != null)
                {
                    int previousCharacterRoll = GameManagerInstance.GetLastCharacterRoll(myIndex, characterIndex, CurrentEncounterSkillPage);
                    CharacterEncounterRollButtons[characterIndex].GetComponent<Button>().interactable = GameManagerInstance.DoesCharacterHaveRollsRemainingForSkill(myIndex, characterIndex, CurrentEncounterSkillPage);
                    if (previousCharacterRoll == Constants.HAS_NOT_ROLLED)
                    {
                        LastCharacterDiceRollText[characterIndex].GetComponent<Text>().text = "--";
                    }
                    else
                    {
                        LastCharacterDiceRollText[characterIndex].GetComponent<Text>().text = previousCharacterRoll.ToString();
                    }
                }
            }

            //Update vehicle roll button
            if (GameManagerInstance.GetActiveVehicle(myIndex) != null)
            {
                int previousVehicleRoll = GameManagerInstance.GetLastVehicleRoll(myIndex, CurrentEncounterSkillPage);
                VehicleRollButton.GetComponent<Button>().interactable = GameManagerInstance.DoesVehicleHaveRollsRemainingForSkill(myIndex, CurrentEncounterSkillPage);
                if (previousVehicleRoll == Constants.HAS_NOT_ROLLED)
                {
                    LastVehicleDiceRollText.GetComponent<Text>().text = "--";
                }
                else
                {
                    LastVehicleDiceRollText.GetComponent<Text>().text = previousVehicleRoll.ToString();
                }
            }

            //Update roll all button
            bool enableRollAllButton = false;
            for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
            {
                if (GameManagerInstance.DoesCharacterHaveRollsRemainingForSkill(myIndex, characterIndex, CurrentEncounterSkillPage))
                {
                    enableRollAllButton = true;
                    break;
                }
            }
            if (GameManagerInstance.DoesVehicleHaveRollsRemainingForSkill(myIndex, CurrentEncounterSkillPage))
            {
                enableRollAllButton = true;
            }
            RollAllButton.GetComponent<Button>().interactable = enableRollAllButton;
        }

        private void updateEncounterFinishedPanel()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            if (GameManagerInstance.GetPlayerIsDoingAnEncounter(myIndex) && GameManagerInstance.IsEncounterFinished(myIndex))
            {
                EncounterFinishedPanel.SetActive(true);
                if (GameManagerInstance.EncounterWasSuccessful(myIndex))
                {
                    EncounterFinishedPanel.GetComponentInChildren<Text>().text = "Encounter was successful!";
                }
                else
                {
                    EncounterFinishedPanel.GetComponentInChildren<Text>().text = "Encounter failed!";
                }
            }
        }

        private void updateStatPanelsForOverallEncounterPage()
        {
            EncounterCard card = GameManagerInstance.GetCurrentEncounter(GameManagerInstance.GetIndexForMyPlayer());
            if (card != null)
            {
                List<(Skills, int)> skillChecks = card.GetSkillChecks();
                for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
                {
                    foreach (Skills skill in Enum.GetValues(typeof(Skills)))
                    {
                        Color color = OverallEncounterPlayerStatPanels[i][(int)skill].GetComponent<Image>().color;
                        foreach ((Skills skillInCheck, int _) in skillChecks)
                        {
                            if (skill == skillInCheck)
                            {
                                color.a = 128;
                            }
                            else
                            {
                                color.a = 0;
                            }
                            OverallEncounterPlayerStatPanels[i][(int)skill].GetComponent<Image>().color = color;
                            break;
                        }
                    }
                }
                foreach (Skills skill in Enum.GetValues(typeof(Skills)))
                {
                    Color color = OverallEncounterVehicleStatPanels[(int)skill].GetComponent<Image>().color;
                    foreach ((Skills skillInCheck, int _) in skillChecks)
                    {
                        if (skill == skillInCheck)
                        {
                            color.a = 128;
                        }
                        else
                        {
                            color.a = 0;
                        }
                        OverallEncounterVehicleStatPanels[(int)skill].GetComponent<Image>().color = color;
                        break;
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

        private void updatePartyOverviewValues()
        {
            for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
            {
                //Update psych
                int remainingPsych = GameManagerInstance.GetActiveCharacterRemainingPsych(CurrentViewedID, characterIndex);
                int maxPsych = GameManagerInstance.GetMaxPsych();
                for (int i = 0; i < ActiveCharactersPsychText[characterIndex].Count; i++)
                {
                    ActiveCharactersPsychText[characterIndex][i].GetComponentInChildren<Text>().text = remainingPsych.ToString() + "/" + maxPsych.ToString();
                }

                //Update health
                int remainingHealth = GameManagerInstance.GetActiveCharacterRemainingHealth(CurrentViewedID, characterIndex);
                int maxHealth = GameManagerInstance.GetActiveCharacterMaxHealth(CurrentViewedID, characterIndex);
                for (int i = 0; i < ActiveCharactersHealthText[characterIndex].Count; i++)
                {
                    ActiveCharactersHealthText[characterIndex][i].GetComponentInChildren<Text>().text = remainingHealth.ToString() + "/" + maxHealth.ToString();
                }

                //Update infected symbol
                if (GameManagerInstance.CharacterHasInfectedDamage(CurrentViewedID, characterIndex))
                {
                    PartyOverviewInfectedSymbols[characterIndex].SetActive(true);
                }
                else
                {
                    PartyOverviewInfectedSymbols[characterIndex].SetActive(false);
                }

                //Update carry weight
                int totalCarryWeight = GameManagerInstance.GetActiveCharacterTotalCarryWeight(CurrentViewedID, characterIndex);
                int usedCarryWeight = GameManagerInstance.GetActiveCharacterUsedCarryWeight(CurrentViewedID, characterIndex);
                for (int i = 0; i < ActiveCharactersCarryWeightsText[characterIndex].Count; i++)
                {
                    ActiveCharactersCarryWeightsText[characterIndex][i].GetComponentInChildren<Text>().text = usedCarryWeight.ToString() + "/" + totalCarryWeight.ToString();
                }
            }
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