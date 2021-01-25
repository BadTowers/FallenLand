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
        private GameObject TotalPartySuccessesNeededText;
        private GameObject NumberOfTotalPartySuccessesText;
        private List<GameObject> CharacterEncounterRollButtons;
        private GameObject VehicleRollButton;
        private List<GameObject> LastCharacterDiceRollText;
        private GameObject LastVehicleDiceRollText;
        private GameObject RollAllButton;
        private GameObject PartyEncounterFinishedPanel;
        private GameObject DiscardPopupPanel;
        private GameObject DiscardedCardImage;
        private GameObject DiscardedPanel;
        private GameObject DistributeD6PopupPanel;
        private GameObject GenericPopupWithTwoLinesOfTextPanel;
        private GameObject GenericPopupTextPanel;
        private GameObject GenericPopupText;
        private GameObject EncounterButton;
        private GameObject ResourceButton;
        private GameObject HealingButton;
        private bool WasResourceClicked;
        private bool WasEncounterClicked;
        private GameObject SelectCardPanel;
        private GameObject CannotModifyPanel;
        private GameObject EncounterFlightButton;
        private List<string> GenericPopupStringQueue = new List<string>();
        private int CurrentAuctionHouseStartingIndex;
        private int CurrentTownRosterStartingIndex;
        private List<GameObject> DistributeD6CharacterPanels;
        private GameObject DistributeD6DoneButton;
        private GameObject D6DistributeRollButton;
        private GameObject D6DistributeRemainingText;
        private GameObject D6DistributeTitleText;
        private bool HasRolledForDistributeD6;
        private int NumD6sToDistribute;
        private int AmountToDistribute;
        private List<Dictionary<byte, int>> AmountsDistributedPerCharacter;
        private byte DistributeD6Type;
        private GameObject PartyEncounterPanel;
        private GameObject IndividualEncounterPanel;
        private GameObject IndividualEncounterCharacterNumberText;
        private GameObject IndividualCharacterStatText;
        private GameObject IndividualStatPageTitleText;
        private GameObject IndividualEncounterCharacter;
        private GameObject IndividualEncounterFinishedPanel;
        private GameObject IndividualCharacterCrownImage;
        private GameObject IndividualLastDiceRollText;
        private GameObject IndividualRollButton;
        private GameObject TotalIndividualSuccessesNeededText;
        private GameObject NumberOfTotalIndividualSuccessesText;
        private GameObject IndividualNumberOfAutoSuccessesText;
        private GameObject IndividualNumberOfRolledSuccessesText;
        private List<GameObject> MainOverviewCharacterPanels;
        private List<Image> MainOverviewCharacterPortraits;
        private int CurrentIndividualEncounterCharacterIndex;
        private GameObject GenericYesNoPopupPanel;
        private bool HealingInNonStartingTown;
        private bool HealingInStartingTown;
        private bool HealingDeedRollingHasBegun;
        private bool HealingDeedDistributingHasBegun;
        private bool GenericYesPressed;
        private bool GenericNoPressed;
        private GameObject PreviousDistributionPageButton;
        private GameObject NextDistributionPageButton;
        private int CurrentDistributionPage;
        private Dictionary<int, byte> DistributionPageToDistributeTypeMapping;
        bool DistributionWasRolled;
        bool HasFocusedThisPartyExploits;

        #region UnityFunctions
        void Awake()
        {
            EscapePressed = false;
            CurrentState = GameMenuStates.Resume;
            UserRolledTownEventsThisTurn = false;
            CurrentEncounterSkillPage = 0;

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
            TotalPartySuccessesNeededText = GameObject.Find("TotalPartySuccessesNeededText");
            NumberOfTotalPartySuccessesText = GameObject.Find("NumberOfTotalPartySuccessesText");
            DiscardPopupPanel = GameObject.Find("DiscardPopupPanel");
            DiscardedCardImage = GameObject.Find("DiscardedCardImage");
            DiscardedPanel = GameObject.Find("DiscardedPanel");
            DistributeD6PopupPanel = GameObject.Find("DistributeD6DamagePopupPanel");
            GenericPopupWithTwoLinesOfTextPanel = GameObject.Find("GenericPopupWithTwoLinesOfTextPanel");
            GenericPopupTextPanel = GameObject.Find("GenericPopupTextPanel");
            GenericPopupText = GameObject.Find("GenericPopupText");
            EncounterButton = GameObject.Find("EncounterButton");
            ResourceButton = GameObject.Find("ResourceButton");
            HealingButton = GameObject.Find("HealingButton");
            SelectCardPanel = GameObject.Find("SelectCardPanel");
            CannotModifyPanel = GameObject.Find("CannotModifyPanel");
            EncounterFlightButton = GameObject.Find("EncounterFlightButton");
            PartyEncounterPanel = GameObject.Find("PartyEncounterPanel");
            GenericYesNoPopupPanel = GameObject.Find("GenericYesNoPopupPanel");
            PreviousDistributionPageButton = GameObject.Find("PreviousDistributionPageButton");
            NextDistributionPageButton = GameObject.Find("NextDistributionPageButton");

            findEncounterRollGameObjects();
            findEncounterStatGameObjects();

            findDistributeD6GameObjects();

            findIndividualEncounterGameObjects();

            ActiveCharactersScrollContent = new List<GameObject>();
            OverallEncounterVehicleStatPanels = new List<GameObject>();
            MainOverviewCharacterPanels = new List<GameObject>();
            MainOverviewCharacterPortraits = new List<Image>();

            AuctionHouseScrollContent = GameObject.Find("AuctionHouseScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
            TownRosterScrollContent = GameObject.Find("TownRosterScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
            ActionCardsScrollContent = GameObject.Find("ActionCardsScrollView").transform.Find("Viewport").transform.Find("Content").gameObject;
            for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
            {
                ActiveCharactersScrollContent.Add(GameObject.Find("CharacterSlotScrollView" + (i + 1).ToString()).transform.Find("Viewport").transform.Find("Content").gameObject);
                MainOverviewCharacterPanels.Add(GameObject.Find("MainOverviewCharacterPanel" + (i + 1).ToString()));
                MainOverviewCharacterPortraits.Add(MainOverviewCharacterPanels[i].transform.Find("CharacterPortrait").GetComponentInChildren<Image>());
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

            AmountsDistributedPerCharacter = new List<Dictionary<byte, int>>();
            for (int characterIndex = 0; characterIndex < Constants.NUM_PARTY_MEMBERS; characterIndex++)
            {
                AmountsDistributedPerCharacter.Add(new Dictionary<byte, int>());
                for (int distributeTypeIndex = 0; distributeTypeIndex < Constants.DISTRIBUTE_TYPES.Count; distributeTypeIndex++)
                {
                    AmountsDistributedPerCharacter[characterIndex][Constants.DISTRIBUTE_TYPES[distributeTypeIndex]] = 0;
                }
            }

            OverallEncounterPanelGameObject.SetActive(false);
            CardFullScreenGameObject.SetActive(false);
            MainEncounterCardImage.SetActive(false);
            IndividualEncounterPanel.SetActive(false);
            PartyEncounterPanel.SetActive(false);
            EncounterSelectionPanel.SetActive(false);
            DiscardPopupPanel.SetActive(false);
            DistributeD6PopupPanel.SetActive(false);
            GenericPopupWithTwoLinesOfTextPanel.SetActive(false);
            GenericYesNoPopupPanel.SetActive(false);
            SelectCardPanel.SetActive(false);
            CannotModifyPanel.SetActive(false);
            PreviousDistributionPageButton.SetActive(false);
            NextDistributionPageButton.SetActive(false);

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
            EventManager.OnShowGenericPopup += onShowGenericPopup;
            EventManager.OnAuctionHouseWasChanged += onAuctionHouseWasChanged;
            EventManager.OnTownRosterWasChanged += onTownRosterWasChanged;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            EventManager.OnSpoilsCardDiscarded -= onShowSpoilsCardDiscardedPopup;
            EventManager.OnD6DamageNeedsToBeDistributed -= onDistributeD6DamagePopup;
            EventManager.OnD6HealingNeedsDistributed -= onDistributeD6HealingPopup;
            EventManager.OnCharacterCrownTakesDamage -= onCharacterCrownTakesDamage;
            EventManager.OnShowGenericPopup -= onShowGenericPopup;
            EventManager.OnAuctionHouseWasChanged -= onAuctionHouseWasChanged;
            EventManager.OnTownRosterWasChanged -= onTownRosterWasChanged;
        }

        void Update()
        {
            //TODO refactor to a function that returns a list of buttons pressed. That list can then later be passed to an interpretter
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EscapePressed = true;
            }

            //updateActionButton(); //Will add back later when we implement action cards

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
        }

        public void OnOptions()
        {
            CurrentState = GameMenuStates.Options;
        }

        public void OnSave()
        {
            CurrentState = GameMenuStates.Save;
        }

        public void OnQuit()
        {
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
            CurrentViewedID = panelNumber - 1;
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
        }

        public void OnRollTownEventsPress()
        {
            int d10Roll = GameManagerInstance.RollTownEvents(GameManagerInstance.GetIndexForMyPlayer());
            string eventsText;
            switch (d10Roll)
            {
                case 1:
                    eventsText = "1! You gain 2 prestige, 4 town health, and get to choose either an action card, spoils card, or character card.";
                    SelectCardPanel.SetActive(true);
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
                    //No effect
                    break;
            }

            //For a 1, the user needs to pick a card first
            if (d10Roll != 1)
            {
                UserRolledTownEventsThisTurn = true;
            }

            //Update description for user to see the effects
            RollTownEventTextGameObject.GetComponent<Text>().text = eventsText;

            //Disable the roll button now because we only roll once per turn
            RollTownEventButtonGameObject.GetComponent<Button>().interactable = false;
        }

        public void OnMovementDeedPress()
        {
            WasResourceClicked = false;
            WasEncounterClicked = false;
            EncounterSelectionPanel.SetActive(false); //Close this panel if the user was going to do an encounter but switched to movement

            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            MapLayout mapLayout = GameManagerInstance.GetMapLayout();
            Coordinates partyLocation = GameManagerInstance.GetPartyLocation(myIndex);

            if (GameManagerInstance.HasDoneEncounterSinceLastMove(myIndex) || mapLayout.IsFactionBase(partyLocation))
            {
                bool moving = GameManagerInstance.GetPlayerIsMoving(myIndex);
                int d6Roll = GameManagerInstance.RollMovement(myIndex);
                int bonusMovement = GameManagerInstance.GetBonusMovement(myIndex);
                int totalMovement = d6Roll + bonusMovement;
                moving = !moving;
                GameManagerInstance.SetPlayerIsMoving(myIndex, moving);
                if (moving)
                {
                    PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "You have " + totalMovement + " movement(" + d6Roll + "+" + bonusMovement + "). Please select the hex you would like your party to move to.";
                }
                else
                {
                    PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "";
                }
            }
            else
            {
                EventManager.ShowGenericPopup("You have to do an encounter, resource, or mission before you can move again!");
                PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "";
            }
        }

        public void OnEncounterDeedPress()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();

            //Cleanup other party exploits stuff
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
            //Cleanup other party exploits stuff
            WasEncounterClicked = false;
            GameManagerInstance.SetPlayerIsMoving(GameManagerInstance.GetIndexForMyPlayer(), false); //cancel movement if it was happening

            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            Coordinates partyLocation = GameManagerInstance.GetPartyLocation(myIndex);

            if (!GameManagerInstance.IsResourceOwned(partyLocation))
            {
                if (GameManagerInstance.GetNumberOfResourcesOwned(myIndex) < Constants.MAX_NUM_RESOURCES_OWNED)
                {
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
                else
                {
                    onShowGenericPopup("You cannot own more than " + Constants.MAX_NUM_RESOURCES_OWNED + " resources!");
                }
            }
            else
            {
                if (!GameManagerInstance.IsResourceOwnedByPlayer(partyLocation, myIndex))
                {
                    if (GameManagerInstance.GetNumberOfResourcesOwned(myIndex) < Constants.MAX_NUM_RESOURCES_OWNED)
                    {
                        GameManagerInstance.CaptureResource(partyLocation, myIndex);
                    }
                    else
                    {
                        onShowGenericPopup("You cannot own more than " + Constants.MAX_NUM_RESOURCES_OWNED + " resources!");
                    }
                }
                else
                {
                    onShowGenericPopup("You cannot capture a resource you own!");
                }
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

            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            if (GameManagerInstance.IsPartyInStartingLocation(myIndex))
            {
                HealingInStartingTown = true;
                HealingDeedRollingHasBegun = true;
                GameManagerInstance.SetPlayerIsHealing(myIndex);
                showEncounterUi();
            }
            else if (GameManagerInstance.IsPartyInTown(myIndex))
            {
                if (GameManagerInstance.GetSalvage(myIndex) >= 5)
                {
                    HealingInNonStartingTown = true;
                    onShowGenericYesNoPopup("Do you want to pay 5 salvage to heal?");
                }
                else
                {
                    onShowGenericPopup("You don't have 5 salvage to heal in this town!");
                }
            }
            else
            {
                HealingDeedRollingHasBegun = true;
                GameManagerInstance.SetPlayerIsHealing(myIndex);
                showEncounterUi();
            }
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
            showEncounterUi();
        }

        public void OnFlightEncounterPress()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            GameManagerInstance.RollFlight(myIndex, WasResourceClicked);
            MainPartyOverviewPanel.SetActive(true);
            OverallEncounterPanelGameObject.SetActive(false);
            MainEncounterCardImage.SetActive(false);
            PartyExploitsPanel.SetActive(true);
            EncounterHasBegun = false;
            CurrentEncounterSkillPage = 0;
            WasResourceClicked = false;
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

        public void OnIndividualCharacterRollPress()
        {
            GameManagerInstance.RollCharacterEncounter(GameManagerInstance.GetIndexForMyPlayer(), CurrentIndividualEncounterCharacterIndex, CurrentEncounterSkillPage);
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
            CurrentEncounterSkillPage--;
            if (EncounterHasBegun)
            {
                if (CurrentEncounterSkillPage < 0)
                {
                    CurrentEncounterSkillPage = GameManagerInstance.GetCurrentEncounter(GameManagerInstance.GetIndexForMyPlayer()).GetSkillChecks().Count - 1;
                }
            }
            else if (HealingDeedRollingHasBegun)
            {
                CurrentEncounterSkillPage = 0;
            }

            updateSkillIcons();
        }

        public void OnNextEncounterStatPress()
        {
            CurrentEncounterSkillPage++;
            if (EncounterHasBegun)
            {
                if (CurrentEncounterSkillPage >= GameManagerInstance.GetCurrentEncounter(GameManagerInstance.GetIndexForMyPlayer()).GetSkillChecks().Count)
                {
                    CurrentEncounterSkillPage = 0;
                }
            }
            else if (HealingDeedRollingHasBegun)
            {
                CurrentEncounterSkillPage = 0;
            }
            updateSkillIcons();
        }

        public void OnCharacterCardChosenButtonPress()
        {
            SelectCardPanel.SetActive(false);
            GameManagerInstance.DealCharacterCardsToPlayer(GameManagerInstance.GetIndexForMyPlayer(), 1);
            UserRolledTownEventsThisTurn = true;
        }

        public void OnSpoilsCardChosenButtonPress()
        {
            SelectCardPanel.SetActive(false);
            GameManagerInstance.DealSpoilsCardsToPlayer(GameManagerInstance.GetIndexForMyPlayer(), 1);
            UserRolledTownEventsThisTurn = true;
        }

        public void OnActionCardChosenButtonPress()
        {
            SelectCardPanel.SetActive(false);
            GameManagerInstance.DealActionCardsToPlayer(GameManagerInstance.GetIndexForMyPlayer(), 1);
            UserRolledTownEventsThisTurn = true;
        }

        public void OnAcceptEncounterResultsPress()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            if (HealingDeedRollingHasBegun)
            {
                resetAfterEncounter();
                HealingDeedRollingHasBegun = false;
                HealingDeedDistributingHasBegun = true;

                onDistributeD6HealingPopup(GameManagerInstance.GetPartyTotalSuccesses(myIndex, CurrentEncounterSkillPage), new List<byte> { Constants.HEAL_PHYSICAL, Constants.HEAL_INFECTED, Constants.HEAL_RADIATION});
            }
            else
            {
                EncounterCard encounterCard = GameManagerInstance.GetCurrentEncounter(myIndex);
                if (!encounterCard.GetIsIndividualCheck())
                {
                    GameManagerInstance.SetEncounterResultAccepted(GameManagerInstance.GetIndexForMyPlayer(), WasResourceClicked);
                    resetAfterEncounter();
                }
                else
                {
                    IndividualEncounterFinishedPanel.SetActive(false);
                    if (GameManagerInstance.EncounterForIndividualWasSuccessful(myIndex, CurrentIndividualEncounterCharacterIndex))
                    {
                        encounterCard.SetIndividualPassFail(CurrentIndividualEncounterCharacterIndex, Constants.STATUS_PASSED);
                    }
                    else
                    {
                        encounterCard.SetIndividualPassFail(CurrentIndividualEncounterCharacterIndex, Constants.STATUS_FAILED);
                    }
                    //Get new character to do individual check, if necessary
                    bool foundNextCharacter = false;
                    for (int i = CurrentIndividualEncounterCharacterIndex + 1; i < Constants.NUM_PARTY_MEMBERS; i++)
                    {
                        List<CharacterCard> party = GameManagerInstance.GetActiveCharacterCards(myIndex);
                        if (party[i] != null)
                        {
                            CurrentIndividualEncounterCharacterIndex = i;
                            foundNextCharacter = true;
                            break;
                        }
                    }
                    if (!foundNextCharacter)
                    {
                        GameManagerInstance.SetEncounterResultAccepted(GameManagerInstance.GetIndexForMyPlayer(), WasResourceClicked);
                        resetAfterEncounter();
                    }
                }
            }
        }

        public void OnDiscardPanelOkPress()
        {
            DiscardPopupPanel.SetActive(false);
        }

        public void OnGenericPopupOkPress()
        {
            GenericPopupWithTwoLinesOfTextPanel.SetActive(false);
            if (GenericPopupStringQueue.Count > 0)
            {
                string newStringToShow = GenericPopupStringQueue[0];
                GenericPopupStringQueue.RemoveAt(0);
                onShowGenericPopup(newStringToShow);
            }
        }

        public void OnPreviousTownRosterPress()
        {
            CurrentTownRosterStartingIndex -= Constants.CHARACTERS_PER_TOWN_ROSTER_PAGE;
            if (CurrentTownRosterStartingIndex < 0)
            {
                int numCardsTotal = GameManagerInstance.GetTownRoster(CurrentViewedID).Count;
                CurrentTownRosterStartingIndex = numCardsTotal - (numCardsTotal % Constants.CHARACTERS_PER_TOWN_ROSTER_PAGE);
            }
            onTownRosterWasChanged();
        }

        public void OnNextTownRosterPress()
        {
            CurrentTownRosterStartingIndex += Constants.CHARACTERS_PER_TOWN_ROSTER_PAGE;
            if (CurrentTownRosterStartingIndex >= GameManagerInstance.GetTownRoster(CurrentViewedID).Count)
            {
                CurrentTownRosterStartingIndex = 0;
            }
            onTownRosterWasChanged();
        }

        public void OnPreviousAuctionHousePress()
        {
            CurrentAuctionHouseStartingIndex -= Constants.SPOILS_PER_AUCTION_HOUSE_PAGE;
            if (CurrentAuctionHouseStartingIndex < 0)
            {
                int numCardsTotal = GameManagerInstance.GetAuctionHouse(CurrentViewedID).Count;
                CurrentAuctionHouseStartingIndex = numCardsTotal - (numCardsTotal % Constants.SPOILS_PER_AUCTION_HOUSE_PAGE);
            }
            onAuctionHouseWasChanged();
        }

        public void OnNextAuctionHousePress()
        {
            CurrentAuctionHouseStartingIndex += Constants.SPOILS_PER_AUCTION_HOUSE_PAGE;
            if (CurrentAuctionHouseStartingIndex >= GameManagerInstance.GetAuctionHouse(CurrentViewedID).Count)
            {
                CurrentAuctionHouseStartingIndex = 0;
            }
            onAuctionHouseWasChanged();
        }

        public void OnRollD6DistributePress()
        {
            HasRolledForDistributeD6 = true;
            D6DistributeRollButton.GetComponent<Button>().interactable = false;
            AmountToDistribute = 0;
            for (int i = 0; i < NumD6sToDistribute; i++)
            {
                AmountToDistribute += GameManagerInstance.GetDiceRoller().RollDice(Constants.D6);
            }
            if (HealingInStartingTown)
            {
                AmountToDistribute += 1;
            }
            DistributionWasRolled = true;
            updateDistributeD6Panel();
        }

        public void OnDistriubutePlus1()
        {
            distributeD6PlusCommon(0);
        }

        public void OnDistributeMinus1()
        {
            distributeD6MinusCommon(0);
        }

        public void OnDistriubutePlus2()
        {
            distributeD6PlusCommon(1);
        }

        public void OnDistributeMinus2()
        {
            distributeD6MinusCommon(1);
        }

        public void OnDistriubutePlus3()
        {
            distributeD6PlusCommon(2);
        }

        public void OnDistributeMinus3()
        {
            distributeD6MinusCommon(2);
        }

        public void OnDistriubutePlus4()
        {
            distributeD6PlusCommon(3);
        }

        public void OnDistributeMinus4()
        {
            distributeD6MinusCommon(3);
        }

        public void OnDistriubutePlus5()
        {
            distributeD6PlusCommon(4);
        }

        public void OnDistributeMinus5()
        {
            distributeD6MinusCommon(4);
        }

        public void OnDoneDistributingPress()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            List<CharacterCard> party = GameManagerInstance.GetActiveCharacterCards(myIndex);
            if (HealingDeedDistributingHasBegun)
            {
                GameManagerInstance.SetHealingResultAccepted(myIndex);
            }

            for (int characterIndex = 0; characterIndex < Constants.NUM_PARTY_MEMBERS; characterIndex++)
            {
                for (int distributionTypeIndex = 0; distributionTypeIndex < Constants.DISTRIBUTE_TYPES.Count; distributionTypeIndex++)
                {
                    DistributeD6Type = Constants.DISTRIBUTE_TYPES[distributionTypeIndex];
                    if (party[characterIndex] != null && AmountsDistributedPerCharacter[characterIndex][DistributeD6Type] > 0)
                    {
                        if (DistributeD6Type == Constants.DAMAGE_PHYSICAL || DistributeD6Type == Constants.DAMAGE_INFECTED || DistributeD6Type == Constants.DAMAGE_RADIATION)
                        {
                            GameManagerInstance.CharacterCrownTakesSetAmountOfDamage(myIndex, characterIndex, AmountsDistributedPerCharacter[characterIndex][DistributeD6Type], DistributeD6Type);
                        }
                        else if (DistributeD6Type == Constants.HEAL_PHYSICAL || DistributeD6Type == Constants.HEAL_INFECTED || DistributeD6Type == Constants.HEAL_RADIATION)
                        {
                            GameManagerInstance.CharacterCrownTakesSetAmountOfHeal(myIndex, characterIndex, AmountsDistributedPerCharacter[characterIndex][DistributeD6Type], DistributeD6Type);
                        }
                    }
                }
            }

            //Reset vars for next time
            for (int characterIndex = 0; characterIndex < Constants.NUM_PARTY_MEMBERS; characterIndex++)
            {
                for (int distributionTypeIndex = 0; distributionTypeIndex < Constants.DISTRIBUTE_TYPES.Count; distributionTypeIndex++)
                {
                    AmountsDistributedPerCharacter[characterIndex][Constants.DISTRIBUTE_TYPES[distributionTypeIndex]] = 0;
                }
            }
            HasRolledForDistributeD6 = false;
            DistributeD6PopupPanel.SetActive(false);
            NumD6sToDistribute = 0;
            AmountToDistribute = 0;
            DistributionWasRolled = false;
            DistributeD6DoneButton.GetComponent<Button>().interactable = false;
            D6DistributeRollButton.GetComponent<Button>().interactable = true;
            HealingDeedDistributingHasBegun = false;
            HealingInStartingTown = false;
            HealingInNonStartingTown = false;
        }

        public void OnGenericYesNo_YesPress()
        {
            GenericYesNoPopupPanel.SetActive(false);
            GenericYesPressed = true;
        }

        public void OnGenericYesNo_NoPress()
        {
            GenericYesNoPopupPanel.SetActive(false);
            GenericNoPressed = true;
        }

        public void OnPreviousDistributionPagePress()
        {
            CurrentDistributionPage--;
            if (CurrentDistributionPage < 0)
            {
                CurrentDistributionPage = DistributionPageToDistributeTypeMapping.Count - 1;
            }
            DistributeD6Type = DistributionPageToDistributeTypeMapping[CurrentDistributionPage];
            updateDistributeD6Panel();
        }

        public void OnNextDistributionPagePress()
        {
            CurrentDistributionPage++;
            if (CurrentDistributionPage > DistributionPageToDistributeTypeMapping.Count - 1)
            {
                CurrentDistributionPage = 0;
            }
            DistributeD6Type = DistributionPageToDistributeTypeMapping[CurrentDistributionPage];
            updateDistributeD6Panel();
        }
        #endregion









        #region HelperFunctions
        private void distributeD6PlusCommon(int characterIndex)
        {
            AmountToDistribute -= 1;
            AmountsDistributedPerCharacter[characterIndex][DistributeD6Type] += 1;
            updateDistributeD6Panel();
        }

        private void distributeD6MinusCommon(int characterIndex)
        {
            AmountToDistribute += 1;
            AmountsDistributedPerCharacter[characterIndex][DistributeD6Type] -= 1;
            updateDistributeD6Panel();
        }

        private void onShowSpoilsCardDiscardedPopup(SpoilsCard card)
        {
            DiscardPopupPanel.SetActive(true);
            DiscardedCardImage.GetComponent<Image>().sprite = card.GetCardImage();
            showPopup(DiscardedPanel);
        }

        private void onDistributeD6DamagePopup(int numD6s, byte damageType)
        {
            CurrentDistributionPage = 0;
            DistributionPageToDistributeTypeMapping = new Dictionary<int, byte> { { 0, damageType } };
            DistributeD6Type = damageType;
            DistributeD6PopupPanel.SetActive(true);
            DistributionWasRolled = false;
            NumD6sToDistribute = numD6s;
            updateDistributeD6Panel();
        }

        private void onDistributeD6HealingPopup(int numD6s, byte healingType)
        {
            CurrentDistributionPage = 0;
            DistributionPageToDistributeTypeMapping = new Dictionary<int, byte> { { 0, healingType } };
            DistributeD6Type = healingType;
            DistributeD6PopupPanel.SetActive(true);
            DistributionWasRolled = false;
            NumD6sToDistribute = numD6s;
            updateDistributeD6Panel();
        }

        private void onDistributeD6HealingPopup(int numD6s, List<byte> healingTypes)
        {
            CurrentDistributionPage = 0;
            DistributionPageToDistributeTypeMapping = new Dictionary<int, byte>();
            for (int pageIndex = 0; pageIndex < healingTypes.Count; pageIndex++)
            {
                DistributionPageToDistributeTypeMapping[pageIndex] = healingTypes[pageIndex];
            }
            DistributeD6Type = DistributionPageToDistributeTypeMapping[CurrentDistributionPage];
            DistributeD6PopupPanel.SetActive(true);
            DistributionWasRolled = false;
            NumD6sToDistribute = numD6s;
            updateDistributeD6Panel();
        }

        private void onCharacterCrownTakesDamage(int characterIndex, int amountOfDamage, byte damageType, int remainingHp, bool discardsEquipment)
        {
            string toShow = "";
            if (GameManagerInstance.GetActiveCharacterCards(GameManagerInstance.GetIndexForMyPlayer())[characterIndex] == null && remainingHp == -1)
            {
                toShow = "Crown " + (characterIndex + 1) + " was empty. No damage taken!";
            }
            else
            {
                if (damageType == Constants.DAMAGE_PHYSICAL)
                {
                    toShow = "Crown " + (characterIndex + 1) + " takes " + amountOfDamage + " physical damage!";
                }
                else if (damageType == Constants.DAMAGE_RADIATION)
                {
                    toShow = "Crown " + (characterIndex + 1) + " takes " + amountOfDamage + " radiation damage!";
                }
                else if (damageType == Constants.DAMAGE_INFECTED)
                {
                    toShow = "Crown " + (characterIndex + 1) + " takes " + amountOfDamage + " infected damage!";
                }
                else if (damageType == Constants.DAMAGE_PSYCHOLOGICAL)
                {
                    toShow = "Crown " + (characterIndex + 1) + " takes " + amountOfDamage + " psychological damage!";
                }

                if (remainingHp <= 0)
                {
                    toShow += " They died...";
                }
                if (discardsEquipment)
                {
                    toShow += " Equipment lost!";
                }
            }
            onShowGenericPopup(toShow);
        }

        private void onShowGenericPopup(string text)
        {
            if (!GenericPopupWithTwoLinesOfTextPanel.activeSelf)
            {
                GenericPopupWithTwoLinesOfTextPanel.SetActive(true);
                GenericPopupText.GetComponent<Text>().text = text;
                showPopup(GenericPopupTextPanel);
            }
            else
            {
                GenericPopupStringQueue.Add(text);
            }
        }

        private void onShowGenericYesNoPopup(string text)
        {
            if (!GenericYesNoPopupPanel.activeSelf)
            {
                GenericYesNoPopupPanel.SetActive(true);
                GameObject yesNoTextPanel = GenericYesNoPopupPanel.transform.Find("GenericYesNoTextPanel").gameObject;
                yesNoTextPanel.GetComponentInChildren<Text>().text = text;
                showPopup(yesNoTextPanel);
            }
            else
            {
                Debug.LogError("Couldn't show two yes/no panels at the same time");
            }
        }

        private void onAuctionHouseWasChanged()
        {
            if (CurrentAuctionHouseStartingIndex >= GameManagerInstance.GetAuctionHouse(CurrentViewedID).Count)
            {
                CurrentAuctionHouseStartingIndex -= Constants.SPOILS_PER_AUCTION_HOUSE_PAGE;
                if (CurrentAuctionHouseStartingIndex < 0)
                {
                    CurrentAuctionHouseStartingIndex = 0;
                }
            }
            redrawCharacterSpoilsScreen();
        }

        private void onTownRosterWasChanged()
        {
            if (CurrentTownRosterStartingIndex >= GameManagerInstance.GetTownRoster(CurrentViewedID).Count)
            {
                CurrentTownRosterStartingIndex -= Constants.CHARACTERS_PER_TOWN_ROSTER_PAGE;
                if (CurrentTownRosterStartingIndex < 0)
                {
                    CurrentTownRosterStartingIndex = 0;
                }
            }
            redrawCharacterSpoilsScreen();
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
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            AuctionHouseTradeButton.interactable = (CurrentViewedID != myIndex);
            CannotModifyPanel.SetActive(GameManagerInstance.GetPlayerIsDoingAnEncounter(myIndex));
        }

        private void redrawCharacterSpoilsScreen()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            updateTownRosterUi();
            updateAuctionHouseUi();
            updateCharacterPanels(true);
            updateVehiclePanel(true);
            CannotModifyPanel.SetActive(GameManagerInstance.GetPlayerIsDoingAnEncounter(myIndex));
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
                    Destroy(child.gameObject);
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

        //Only call when needed
        private void updateAuctionHouseUi()
        {
            const float OFFSET_X = 125;
            const float OFFSET_Y = 85;
            int playerIndex = GameManagerInstance.GetIndexForMyPlayer();

            List<SpoilsCard> auctionHouse = GameManagerInstance.GetAuctionHouse(CurrentViewedID);
            if (!CardIsDragging)
            {
                //Clear old
                foreach (Transform child in AuctionHouseScrollContent.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }

                //Add new
                for (int i = CurrentAuctionHouseStartingIndex; i < CurrentAuctionHouseStartingIndex + Constants.SPOILS_PER_AUCTION_HOUSE_PAGE && i < auctionHouse.Count; i++)
                {
                    GameObject imageObj = Instantiate(ImageGameObject);
                    if (playerIndex != CurrentViewedID || GameManagerInstance.GetPlayerIsDoingAnEncounter(playerIndex))
                    {
                        Destroy(imageObj.GetComponent<CardMovementHandler>());
                    }
                    Image image = imageObj.GetComponent<Image>();
                    image.sprite = auctionHouse[i].GetCardImage();
                    imageObj.name = "SpoilsCard" + auctionHouse[i].GetId().ToString();
                    image.transform.SetParent(AuctionHouseScrollContent.transform);
                    image.transform.localPosition = new Vector3(97f + ((i - CurrentAuctionHouseStartingIndex) % 8 * OFFSET_X), -64f - ((i - CurrentAuctionHouseStartingIndex) / 8 * OFFSET_Y), 0f);
                    image.transform.localScale = new Vector3(1f, 1f, 1f);
                    image.rectTransform.sizeDelta = new Vector2(75, 100);
                    image.transform.eulerAngles = new Vector3(0f, 0f, 90f);

                    imageObj.GetComponentInChildren<MonoCard>().CardPtr = auctionHouse[i];
                }
            }
        }

        private void updateTownRosterUi()
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
                    GameObject.Destroy(child.gameObject);
                }
            }
            else if (!CardIsDragging)
            {
                //Clear old
                foreach (Transform child in TownRosterScrollContent.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }

                //Add new
                for (int i = CurrentTownRosterStartingIndex; i < CurrentTownRosterStartingIndex + Constants.CHARACTERS_PER_TOWN_ROSTER_PAGE && i < townRoster.Count; i++)
                {
                    GameObject imageObj = Instantiate(ImageGameObject);
                    if (GameManagerInstance.GetPlayerIsDoingAnEncounter(playerIndex))
                    {
                        Destroy(imageObj.GetComponent<CardMovementHandler>());
                    }
                    Image image = imageObj.GetComponent<Image>();
                    image.sprite = townRoster[i].GetCardImage();
                    imageObj.name = "CharacterCard" + townRoster[i].GetId().ToString();
                    image.transform.SetParent(TownRosterScrollContent.transform);
                    image.transform.localPosition = new Vector3(97f + ((i - CurrentTownRosterStartingIndex) % 8 * OFFSET_X), -64f - ((i - CurrentTownRosterStartingIndex) / 8 * OFFSET_Y), 0f);
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
                        if (CurrentViewedID != playerIndex || GameManagerInstance.GetPlayerIsDoingAnEncounter(playerIndex))
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
                            if (CurrentViewedID != playerIndex || GameManagerInstance.GetPlayerIsDoingAnEncounter(playerIndex))
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
                    if (CurrentViewedID != playerIndex || GameManagerInstance.GetPlayerIsDoingAnEncounter(playerIndex))
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
                    for (int curSpoilIndex = 0; curSpoilIndex < curSlotSpoils.Count; curSpoilIndex++)
                    {
                        GameObject imageObj2 = Instantiate(ImageGameObject);
                        if (CurrentViewedID != playerIndex || GameManagerInstance.GetPlayerIsDoingAnEncounter(playerIndex))
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
            if (currentPhase == Phases.Party_Exploits_Party && HealingInNonStartingTown && GenericYesPressed)
            {
                GenericYesPressed = false;
                int myIndex = GameManagerInstance.GetIndexForMyPlayer();
                GameManagerInstance.NetworkSalvage(myIndex, 5, Constants.SALVAGE_LOSE);
                GameManagerInstance.NetworkSalvage(GameManagerInstance.GetPlayerIndexForFaction(GameManagerInstance.GetFactionTownPartyIsIn(myIndex)), 5, Constants.SALVAGE_GAIN);
                HealingDeedRollingHasBegun = true;
                GameManagerInstance.SetPlayerIsHealing(GameManagerInstance.GetIndexForMyPlayer());
                showEncounterUi();
            }
            else if (currentPhase == Phases.Party_Exploits_Party && HealingInNonStartingTown && GenericNoPressed)
            {
                GenericNoPressed = false;
                HealingInNonStartingTown = false;
            }

            if (currentPhase == Phases.Party_Exploits_Party && !EncounterHasBegun && !HealingDeedRollingHasBegun)
            {
                PartyExploitsPanel.SetActive(true);
                ActualRemainingWeeksTextGameObject.GetComponent<Text>().text = GameManagerInstance.GetRemainingPartyExploitWeeks(CurrentViewedID).ToString();
                changeViewBackToPlayersIfNeeded();
                changePartyExploitsButtonStatesAsNeeded();
                int myIndex = GameManagerInstance.GetIndexForMyPlayer();
                if (!GameManagerInstance.GetPlayerIsMoving(myIndex) && !GameManagerInstance.GetPlayerIsDoingAnEncounter(myIndex))
                {
                    PartyExploitsInformationTextGameObject.GetComponent<Text>().text = "";
                }
                if (GameManagerInstance.GetPlayerIsDoingAnEncounter(myIndex) && encounterCard != null && !EncounterHasBegun)
                {
                    OverallEncounterPanelGameObject.SetActive(true);
                    EncounterFlightButton.SetActive(encounterCard.GetFlightAllowed());
                    Image cardImage = GameObject.Find("EncounterCardImage").GetComponent<Image>();
                    cardImage.sprite = loadEncounterCard();
                    updateStatPanelsForOverallEncounterPage();
                }
            }
            else if (currentPhase == Phases.Party_Exploits_Party && EncounterHasBegun)
            {
                if (encounterCard.GetSkillChecks().Count > 0)
                {
                    updateSkillIcons();
                    updateSkillValues(encounterCard);

                    updateCharacterImagesAndPanels(encounterCard);

                    updateEncounterSkillPanel(encounterCard);
                    updateEncounterRollButtons(encounterCard);
                    updateEncounterFinishedPanel(encounterCard);
                }
                else
                {
                    onShowGenericPopup("This card was an auto success!");
                    OnAcceptEncounterResultsPress();
                }
            }
            else if (currentPhase == Phases.Party_Exploits_Party && HealingDeedRollingHasBegun)
            {
                updateSkillIcons();
                updateHealingSkillValues();

                updateCharacterImagesAndPanels(null);

                updateEncounterSkillPanel(null);
                updateEncounterRollButtons(null);
                updateEncounterFinishedPanel(null);
            }
            else
            {
                PartyExploitsPanel.SetActive(false);
                PartyEncounterFinishedPanel.SetActive(false);
                IndividualEncounterFinishedPanel.SetActive(false);
                HasFocusedThisPartyExploits = false;
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

        private void changeViewBackToPlayersIfNeeded()
        {
            if (GameManagerInstance.GetIsItMyTurn() && !HasFocusedThisPartyExploits)
            {
                CurrentViewedID = GameManagerInstance.GetIndexForMyPlayer();
                HasFocusedThisPartyExploits = true;
            }
        }

        private void changePartyExploitsButtonStatesAsNeeded()
        {
            if (GameManagerInstance.GetIsItMyTurn() && GameManagerInstance.GetRemainingPartyExploitWeeks(GameManagerInstance.GetIndexForMyPlayer()) > 0 && CurrentViewedID == GameManagerInstance.GetIndexForMyPlayer())
            {
                int myIndex = GameManagerInstance.GetIndexForMyPlayer();
                MapLayout mapLayout = GameManagerInstance.GetMapLayout();
                Coordinates partyLocation = GameManagerInstance.GetPartyLocation(myIndex);

                GameObject.Find("MovementButton").GetComponent<Button>().interactable = true;
                bool shouldEnableEncounterDeedButton = !mapLayout.IsFactionBase(partyLocation);
                EncounterButton.GetComponent<Button>().interactable = shouldEnableEncounterDeedButton;
                bool shouldEnableResourceDeedButton = mapLayout.IsResource(partyLocation);
                ResourceButton.GetComponent<Button>().interactable = shouldEnableResourceDeedButton;
                HealingButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                GameObject.Find("MovementButton").GetComponent<Button>().interactable = false;
                EncounterButton.GetComponent<Button>().interactable = false;
                GameObject.Find("PVPButton").GetComponent<Button>().interactable = false;
                ResourceButton.GetComponent<Button>().interactable = false;
                HealingButton.GetComponent<Button>().interactable = false;
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
            return Resources.Load<Sprite>(imageLocation);
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
            PartyEncounterFinishedPanel = GameObject.Find("PartyEncounterFinishedPanel");
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

        private void findDistributeD6GameObjects()
        {
            DistributeD6CharacterPanels = new List<GameObject>();

            for (int curCharacterIndex = 0; curCharacterIndex < Constants.NUM_PARTY_MEMBERS; curCharacterIndex++)
            {
                DistributeD6CharacterPanels.Add(GameObject.Find("DistributeD6CharacterPanel" + (curCharacterIndex + 1).ToString()));
            }
            
            DistributeD6DoneButton = GameObject.Find("DoneDistributingDamageButton");
            DistributeD6DoneButton.GetComponent<Button>().interactable = false;

            D6DistributeRollButton = GameObject.Find("RollD6DistributeButton");
            D6DistributeRemainingText = GameObject.Find("AmountRemainingToDistributeText");
            D6DistributeTitleText = GameObject.Find("DistributeTitleText");
        }

        private void findIndividualEncounterGameObjects()
        {
            IndividualEncounterPanel = GameObject.Find("IndividualEncounterPanel");
            IndividualEncounterCharacterNumberText = GameObject.Find("IndividualEncounterCharacterNumberText");
            IndividualCharacterStatText = GameObject.Find("IndividualCharacterStatText");
            IndividualStatPageTitleText = GameObject.Find("IndividualStatPageTitleText");
            IndividualEncounterCharacter = GameObject.Find("IndividualEncounterCharacter");
            IndividualEncounterFinishedPanel = GameObject.Find("IndividualEncounterFinishedPanel");
            IndividualCharacterCrownImage = GameObject.Find("IndividualCharacterCrownImage");
            IndividualLastDiceRollText = GameObject.Find("IndividualLastDiceRollText");
            IndividualRollButton = GameObject.Find("IndividualRollButton");
            TotalIndividualSuccessesNeededText = GameObject.Find("TotalIndividualSuccessesNeededText");
            NumberOfTotalIndividualSuccessesText = GameObject.Find("NumberOfTotalIndividualSuccessesText");
            IndividualNumberOfAutoSuccessesText = GameObject.Find("IndividualNumberOfAutoSuccessesText");
            IndividualNumberOfRolledSuccessesText = GameObject.Find("IndividualNumberOfRolledSuccessesText");
        }

        private void updateDistributeD6Panel()
        {
            updateDistributeD6Title();
            updateDistributeD6RollPanel();

            DistributeD6DoneButton.GetComponent<Button>().interactable = (AmountToDistribute == 0 || wasMaxAmountDistributed()) && DistributionWasRolled;

            List<CharacterCard> partyCharacters = GameManagerInstance.GetActiveCharacterCards(GameManagerInstance.GetIndexForMyPlayer());
            for (int curCharacterIndex = 0; curCharacterIndex < Constants.NUM_PARTY_MEMBERS; curCharacterIndex++)
            {
                if (partyCharacters[curCharacterIndex] != null)
                {
                    DistributeD6CharacterPanels[curCharacterIndex].transform.Find("CharacterImage").GetComponentInChildren<Image>().sprite = partyCharacters[curCharacterIndex].GetCardImage();
                    updateDistributeD6MinusButton(DistributeD6CharacterPanels[curCharacterIndex].transform.Find("MinusButton").GetComponentInChildren<Button>(), curCharacterIndex);
                    updateDistributeD6PlusButton(DistributeD6CharacterPanels[curCharacterIndex].transform.Find("PlusButton").GetComponentInChildren<Button>(), curCharacterIndex, partyCharacters[curCharacterIndex]);
                    DistributeD6CharacterPanels[curCharacterIndex].transform.Find("AmountDistributedText").GetComponentInChildren<Text>().text = AmountsDistributedPerCharacter[curCharacterIndex][DistributeD6Type].ToString();
                    int theoreticalNewHP = getTheoreticalCurrentHp(curCharacterIndex, partyCharacters[curCharacterIndex]);
                    DistributeD6CharacterPanels[curCharacterIndex].transform.Find("RemainingHPActualText").GetComponentInChildren<Text>().text = theoreticalNewHP.ToString() + "/" + partyCharacters[curCharacterIndex].GetMaxHp();
                }
                else
                {
                    DistributeD6CharacterPanels[curCharacterIndex].SetActive(false);
                }
            }

            //Show the page arrows if there are multiple types of damage to distribute/heal
            bool shouldEnableArrows = HealingDeedDistributingHasBegun && (HealingInStartingTown || HealingInNonStartingTown);
            PreviousDistributionPageButton.SetActive(shouldEnableArrows);
            NextDistributionPageButton.SetActive(shouldEnableArrows);
        }

        private void updateDistributeD6Title()
        {
            if (DistributeD6Type == Constants.DAMAGE_PHYSICAL)
            {
                D6DistributeTitleText.GetComponent<Text>().text = "Distribute D6 Physical Damage";
            }
            else if (DistributeD6Type == Constants.DAMAGE_INFECTED)
            {
                D6DistributeTitleText.GetComponent<Text>().text = "Distribute D6 Infected Damage";
            }
            else if (DistributeD6Type == Constants.HEAL_PHYSICAL)
            {
                D6DistributeTitleText.GetComponent<Text>().text = "Distribute D6 Physical Healing";
            }
            else if (DistributeD6Type == Constants.HEAL_INFECTED)
            {
                D6DistributeTitleText.GetComponent<Text>().text = "Distribute D6 Infected Healing";
            }
            else if (DistributeD6Type == Constants.HEAL_RADIATION)
            {
                D6DistributeTitleText.GetComponent<Text>().text = "Distribute D6 Radiation Healing";
            }
        }

        private void updateDistributeD6RollPanel()
        {
            D6DistributeRollButton.GetComponentInChildren<Text>().text = "Roll " + NumD6sToDistribute + "D6";
            D6DistributeRemainingText.GetComponent<Text>().text = AmountToDistribute.ToString();
        }

        private void updateDistributeD6MinusButton(Button minusButton, int characterIndex)
        {
            if (DistributeD6Type == Constants.DAMAGE_PHYSICAL || DistributeD6Type == Constants.DAMAGE_INFECTED)
            {
                bool shouldEnable = HasRolledForDistributeD6 && AmountsDistributedPerCharacter[characterIndex][DistributeD6Type] > 0;
                minusButton.interactable = shouldEnable;
            }
            else if (DistributeD6Type == Constants.HEAL_PHYSICAL || DistributeD6Type == Constants.HEAL_INFECTED || DistributeD6Type == Constants.HEAL_RADIATION)
            {
                bool shouldEnable = HasRolledForDistributeD6 && AmountsDistributedPerCharacter[characterIndex][DistributeD6Type] > 0;
                minusButton.interactable = shouldEnable;
            }
        }

        private void updateDistributeD6PlusButton(Button plusButton, int characterIndex, CharacterCard characterCard)
        {
            if (DistributeD6Type == Constants.DAMAGE_PHYSICAL || DistributeD6Type == Constants.DAMAGE_INFECTED)
            {
                bool shouldEnable = HasRolledForDistributeD6 && AmountsDistributedPerCharacter[characterIndex][DistributeD6Type] < characterCard.GetHpRemaining() && AmountToDistribute > 0;
                plusButton.interactable = shouldEnable;
            }
            else if (DistributeD6Type == Constants.HEAL_PHYSICAL)
            {
                bool shouldEnable = HasRolledForDistributeD6 && (AmountsDistributedPerCharacter[characterIndex][DistributeD6Type] + characterCard.GetHpRemaining() < characterCard.GetMaxPhysicalHp()) && AmountToDistribute > 0;
                plusButton.interactable = shouldEnable;
            }
            else if (DistributeD6Type == Constants.HEAL_INFECTED)
            {
                bool shouldEnable = HasRolledForDistributeD6 && (AmountsDistributedPerCharacter[characterIndex][DistributeD6Type] + characterCard.GetHpRemaining() < characterCard.GetMaxInfectedHp()) && AmountToDistribute > 0;
                plusButton.interactable = shouldEnable;
            }
            else if (DistributeD6Type == Constants.HEAL_RADIATION)
            {
                bool shouldEnable = HasRolledForDistributeD6 && (AmountsDistributedPerCharacter[characterIndex][DistributeD6Type] + characterCard.GetHpRemaining() < characterCard.GetMaxRadiationHp()) && AmountToDistribute > 0;
                plusButton.interactable = shouldEnable;
            }
        }

        private int getTheoreticalCurrentHp(int characterIndex, CharacterCard curCharacter)
        {
            int theoretical = 0;
            if (DistributeD6Type == Constants.DAMAGE_PHYSICAL || DistributeD6Type == Constants.DAMAGE_INFECTED || DistributeD6Type == Constants.DAMAGE_RADIATION)
            {
                theoretical = curCharacter.GetHpRemaining() - AmountsDistributedPerCharacter[characterIndex][Constants.DAMAGE_PHYSICAL];
                theoretical -= AmountsDistributedPerCharacter[characterIndex][Constants.DAMAGE_INFECTED];
                theoretical -= AmountsDistributedPerCharacter[characterIndex][Constants.DAMAGE_RADIATION];
            }
            else if (DistributeD6Type == Constants.HEAL_PHYSICAL || DistributeD6Type == Constants.HEAL_INFECTED || DistributeD6Type == Constants.HEAL_RADIATION)
            {
                theoretical = curCharacter.GetHpRemaining() + AmountsDistributedPerCharacter[characterIndex][Constants.HEAL_PHYSICAL];
                theoretical += AmountsDistributedPerCharacter[characterIndex][Constants.HEAL_INFECTED];
                theoretical += AmountsDistributedPerCharacter[characterIndex][Constants.HEAL_RADIATION];
            }

            return theoretical;
        }

        //Assume you will never have both damage and heal in the same set of pages for distributing
        private bool wasMaxAmountDistributed()
        {
            bool wasMaxDistributed = true;
            List<CharacterCard> party = GameManagerInstance.GetActiveCharacterCards(GameManagerInstance.GetIndexForMyPlayer());
            for (int characterIndex = 0; characterIndex < Constants.NUM_PARTY_MEMBERS; characterIndex++)
            {
                if (party[characterIndex] != null)
                {
                    int currentHp = party[characterIndex].GetHpRemaining();
                    int runningCurrentHp = currentHp;
                    bool shouldCheck = false;
                    if (DistributionPageToDistributeTypeMapping.ContainsValue(Constants.DAMAGE_PHYSICAL))
                    {
                        runningCurrentHp -= AmountsDistributedPerCharacter[characterIndex][Constants.DAMAGE_PHYSICAL];
                        shouldCheck = true;
                    }
                    if (DistributionPageToDistributeTypeMapping.ContainsValue(Constants.DAMAGE_INFECTED))
                    {
                        runningCurrentHp -= AmountsDistributedPerCharacter[characterIndex][Constants.DAMAGE_INFECTED];
                        shouldCheck = true;
                    }
                    if (DistributionPageToDistributeTypeMapping.ContainsValue(Constants.DAMAGE_RADIATION))
                    {
                        runningCurrentHp -= AmountsDistributedPerCharacter[characterIndex][Constants.DAMAGE_RADIATION];
                        shouldCheck = true;
                    }
                    if (runningCurrentHp > 0 && shouldCheck)
                    {
                        wasMaxDistributed = false;
                        break;
                    }

                    if (DistributionPageToDistributeTypeMapping.ContainsValue(Constants.HEAL_PHYSICAL) && currentHp + AmountsDistributedPerCharacter[characterIndex][Constants.HEAL_PHYSICAL] < party[characterIndex].GetMaxPhysicalHp())
                    {
                        wasMaxDistributed = false;
                        break;
                    }
                    if (DistributionPageToDistributeTypeMapping.ContainsValue(Constants.HEAL_INFECTED) && currentHp + AmountsDistributedPerCharacter[characterIndex][Constants.HEAL_INFECTED] < party[characterIndex].GetMaxInfectedHp())
                    {
                        wasMaxDistributed = false;
                        break;
                    }
                    if (DistributionPageToDistributeTypeMapping.ContainsValue(Constants.HEAL_RADIATION) && currentHp + AmountsDistributedPerCharacter[characterIndex][Constants.HEAL_RADIATION] < party[characterIndex].GetMaxRadiationHp())
                    {
                        wasMaxDistributed = false;
                        break;
                    }
                }
            }
            return wasMaxDistributed;
        }

        private void showEncounterUi()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();

            MainPartyOverviewPanel.SetActive(false);
            OverallEncounterPanelGameObject.SetActive(false);
            PartyExploitsPanel.SetActive(false);

            if (GameManagerInstance.GetPlayerIsDoingAnEncounter(myIndex))
            {
                MainEncounterCardImage.SetActive(true);
                MainEncounterCardImage.GetComponent<Image>().sprite = loadEncounterCard();
                EncounterHasBegun = true;
                GameManagerInstance.AddSalvageAtStartOfEncounter(GameManagerInstance.GetIndexForMyPlayer(), WasResourceClicked);
                if (!GameManagerInstance.GetCurrentEncounter(GameManagerInstance.GetIndexForMyPlayer()).GetIsIndividualCheck())
                {
                    PartyEncounterPanel.SetActive(true);
                    IndividualEncounterPanel.SetActive(false);
                }
                else
                {
                    IndividualEncounterPanel.SetActive(true);
                    PartyEncounterPanel.SetActive(false);
                    //Set the first character to make the individual check
                    List<CharacterCard> characters = GameManagerInstance.GetActiveCharacterCards(GameManagerInstance.GetIndexForMyPlayer());
                    for (int currentCharacterIndex = 0; currentCharacterIndex < Constants.NUM_PARTY_MEMBERS; currentCharacterIndex++)
                    {
                        if (characters[currentCharacterIndex] != null)
                        {
                            CurrentIndividualEncounterCharacterIndex = currentCharacterIndex;
                            break;
                        }
                    }
                }
            }
            else if (GameManagerInstance.GetPlayerIsHealing(myIndex))
            {
                PartyEncounterPanel.SetActive(true);
                IndividualEncounterPanel.SetActive(false);
            }
        }

        private void updateSkillIcons()
        {
            //Determine sprite
            string spriteString = "Cards/CardInformation/";
            Sprite sprite;
            Skills skill = Skills.Medical;

            if (EncounterHasBegun)
            {
                EncounterCard card = GameManagerInstance.GetCurrentEncounter(GameManagerInstance.GetIndexForMyPlayer());
                skill = card.GetSkillChecks()[CurrentEncounterSkillPage].Item1;
            }

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

            sprite = Resources.Load<Sprite>(spriteString);
            for (int i = 0; i < CurrentEncounterRollSymbols.Count; i++)
            {
                CurrentEncounterRollSymbols[i].GetComponent<Image>().sprite = sprite;
            }
        }

        private void updateSkillValues(EncounterCard encounterCard)
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            List<(Skills, int)> skillChecks = encounterCard.GetSkillChecks();

            if (!encounterCard.GetIsIndividualCheck())
            {
                //Update character values
                for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
                {
                    if (skillChecks[CurrentEncounterSkillPage].Item1 == Skills.Combat && encounterCard.GetIsMeleeOnly())
                    {
                        CharacterEncounterCurrentStatText[characterIndex].GetComponent<Text>().text = GameManagerInstance.GetCombatSkillTotalForCharacterMeleeOnly(myIndex, characterIndex).ToString();
                    }
                    else
                    {
                        CharacterEncounterCurrentStatText[characterIndex].GetComponent<Text>().text = GameManagerInstance.GetSkillTotalForCharacter(myIndex, characterIndex, CurrentEncounterSkillPage).ToString();
                    }
                }

                //Update vehicle value
                VehicleEncounterCurrentStatText.GetComponent<Text>().text = GameManagerInstance.GetSkillTotalForVehicle(myIndex, CurrentEncounterSkillPage).ToString();
            }
            else
            {
                IndividualCharacterStatText.GetComponent<Text>().text = GameManagerInstance.GetSkillTotalForCharacter(myIndex, CurrentIndividualEncounterCharacterIndex, CurrentEncounterSkillPage).ToString();
            }
        }

        private void updateHealingSkillValues()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            //Update character values
            for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
            {
                CharacterEncounterCurrentStatText[characterIndex].GetComponent<Text>().text = GameManagerInstance.GetSkillTotalForCharacter(myIndex, characterIndex, CurrentEncounterSkillPage).ToString();
            }

            //Update vehicle value
            VehicleEncounterCurrentStatText.GetComponent<Text>().text = GameManagerInstance.GetSkillTotalForVehicle(myIndex, CurrentEncounterSkillPage).ToString();
        }


        private void updateCharacterImagesAndPanels(EncounterCard encounterCard)
        {
            List<CharacterCard> characterCards = GameManagerInstance.GetActiveCharacterCards(CurrentViewedID);
            if (HealingDeedRollingHasBegun || (encounterCard != null && !encounterCard.GetIsIndividualCheck()))
            {
                //Enable character panels that have someone assigned to it
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
            }
            else
            {
                IndividualEncounterCharacter.GetComponent<Image>().sprite = characterCards[CurrentIndividualEncounterCharacterIndex].GetCardImage();
                IndividualEncounterCharacterNumberText.GetComponent<Text>().text = "Character " + (CurrentIndividualEncounterCharacterIndex + 1).ToString();
                IndividualCharacterCrownImage.GetComponent<Image>().sprite = getIndividualCharacterCrownSprite();
            }
        }

        private void updateEncounterSkillPanel(EncounterCard encounterCard)
        {
            if (HealingDeedRollingHasBegun || (encounterCard != null && !encounterCard.GetIsIndividualCheck()))
            {
                updateEncounterSkillPanelForPartyEncounter(encounterCard);
            }
            else
            {
                updateEncounterSkillPanelForIndividualEncounter(encounterCard);
            }
        }

        private void updateEncounterSkillPanelForPartyEncounter(EncounterCard encounterCard)
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            Skills currentSkill = Skills.Medical;
            int valueNeeded = -1;
            if (encounterCard != null)
            {
                currentSkill = encounterCard.GetSkillChecks()[CurrentEncounterSkillPage].Item1;
                valueNeeded = encounterCard.GetSkillChecks()[CurrentEncounterSkillPage].Item2;
            }

            //Update page title
            GameObject.Find("StatPageTitleText").GetComponent<Text>().text = currentSkill.ToString();

            //Update character success values
            for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
            {
                if (encounterCard != null && encounterCard.GetIsMeleeOnly() && currentSkill == Skills.Combat)
                {
                    CurrentEncounterCharacterAutoSuccesses[characterIndex].GetComponent<Text>().text = GameManagerInstance.GetCharacterCombatAutoSuccessesMeleeOnly(myIndex, characterIndex, CurrentEncounterSkillPage).ToString();
                    CurrentEncounterCharacterRolledSuccesses[characterIndex].GetComponent<Text>().text = GameManagerInstance.GetCharacterCombatRolledSuccessesMeleeOnly(myIndex, characterIndex, CurrentEncounterSkillPage).ToString();
                }
                else
                {
                    CurrentEncounterCharacterAutoSuccesses[characterIndex].GetComponent<Text>().text = GameManagerInstance.GetCharacterAutoSuccesses(myIndex, characterIndex, CurrentEncounterSkillPage).ToString();
                    CurrentEncounterCharacterRolledSuccesses[characterIndex].GetComponent<Text>().text = GameManagerInstance.GetCharacterRolledSuccesses(myIndex, characterIndex, CurrentEncounterSkillPage).ToString();
                }
            }
            //Update vehicle success values
            CurrentEncounterVehicleAutoSuccesses.GetComponent<Text>().text = GameManagerInstance.GetVehicleAutoSuccesses(myIndex, CurrentEncounterSkillPage).ToString();
            CurrentEncounterVehicleRolledSuccesses.GetComponent<Text>().text = GameManagerInstance.GetVehicleRolledSuccesses(myIndex, CurrentEncounterSkillPage).ToString();

            //Update total successes needed
            if (EncounterHasBegun)
            {
                TotalPartySuccessesNeededText.GetComponent<Text>().text = valueNeeded.ToString();
            }
            else if (HealingDeedRollingHasBegun)
            {
                TotalPartySuccessesNeededText.GetComponent<Text>().text = "-";
            }

            //Update number of successes had
            NumberOfTotalPartySuccessesText.GetComponent<Text>().text = GameManagerInstance.GetPartyTotalSuccesses(myIndex, CurrentEncounterSkillPage).ToString();
        }

        private void updateEncounterSkillPanelForIndividualEncounter(EncounterCard encounterCard)
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            (Skills currentSkill, int valueNeeded) = encounterCard.GetSkillChecks()[CurrentEncounterSkillPage];

            //Update page title
            IndividualStatPageTitleText.GetComponent<Text>().text = currentSkill.ToString();

            //Update character success values
            if (GameManagerInstance.GetCurrentEncounter(myIndex).GetIsMeleeOnly() && currentSkill == Skills.Combat)
            {
                IndividualNumberOfAutoSuccessesText.GetComponent<Text>().text = GameManagerInstance.GetCharacterCombatAutoSuccessesMeleeOnly(myIndex, CurrentIndividualEncounterCharacterIndex, CurrentEncounterSkillPage).ToString();
                IndividualNumberOfRolledSuccessesText.GetComponent<Text>().text = GameManagerInstance.GetCharacterCombatRolledSuccessesMeleeOnly(myIndex, CurrentIndividualEncounterCharacterIndex, CurrentEncounterSkillPage).ToString();
            }
            else
            {
                IndividualNumberOfAutoSuccessesText.GetComponent<Text>().text = GameManagerInstance.GetCharacterAutoSuccesses(myIndex, CurrentIndividualEncounterCharacterIndex, CurrentEncounterSkillPage).ToString();
                IndividualNumberOfRolledSuccessesText.GetComponent<Text>().text = GameManagerInstance.GetCharacterRolledSuccesses(myIndex, CurrentIndividualEncounterCharacterIndex, CurrentEncounterSkillPage).ToString();
            }

            //Update total successes needed
            TotalIndividualSuccessesNeededText.GetComponent<Text>().text = valueNeeded.ToString();

            //Update number of successes had
            NumberOfTotalIndividualSuccessesText.GetComponent<Text>().text = GameManagerInstance.GetIndividualTotalSuccesses(myIndex, CurrentIndividualEncounterCharacterIndex, CurrentEncounterSkillPage).ToString();
        }

        private void updateEncounterRollButtons(EncounterCard encounterCard)
        {
            if (HealingDeedRollingHasBegun || (encounterCard != null && !encounterCard.GetIsIndividualCheck()))
            {
                updateEncounterRollButtonsForPartyEncounter();
            }
            else
            {
                updateEncounterRollButtonsForIndividualEncounter();
            }
        }

        private void updateEncounterRollButtonsForPartyEncounter()
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

        private void updateEncounterRollButtonsForIndividualEncounter()
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            //Update character roll button
            List<CharacterCard> activeCharacters = GameManagerInstance.GetActiveCharacterCards(myIndex);
            if (activeCharacters[CurrentIndividualEncounterCharacterIndex] != null)
            {
                int previousCharacterRoll = GameManagerInstance.GetLastCharacterRoll(myIndex, CurrentIndividualEncounterCharacterIndex, CurrentEncounterSkillPage);
                IndividualRollButton.GetComponent<Button>().interactable = GameManagerInstance.DoesCharacterHaveRollsRemainingForSkill(myIndex, CurrentIndividualEncounterCharacterIndex, CurrentEncounterSkillPage);
                if (previousCharacterRoll == Constants.HAS_NOT_ROLLED)
                {
                    IndividualLastDiceRollText.GetComponent<Text>().text = "--";
                }
                else
                {
                    IndividualLastDiceRollText.GetComponent<Text>().text = previousCharacterRoll.ToString();
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

        private void updateEncounterFinishedPanel(EncounterCard encounterCard)
        {
            int myIndex = GameManagerInstance.GetIndexForMyPlayer();
            if (HealingDeedRollingHasBegun && GameManagerInstance.IsHealingFinished(myIndex))
            {
                PartyEncounterFinishedPanel.SetActive(true);
                PartyEncounterFinishedPanel.GetComponentInChildren<Text>().text = "Time to heal!";
            }
            else if (GameManagerInstance.GetPlayerIsDoingAnEncounter(myIndex) && GameManagerInstance.IsEncounterFinished(myIndex, CurrentIndividualEncounterCharacterIndex))
            {
                if (encounterCard != null && !encounterCard.GetIsIndividualCheck())
                {
                    PartyEncounterFinishedPanel.SetActive(true);
                    if (GameManagerInstance.EncounterWasSuccessful(myIndex))
                    {
                        PartyEncounterFinishedPanel.GetComponentInChildren<Text>().text = "Encounter was successful!";
                    }
                    else
                    {
                        PartyEncounterFinishedPanel.GetComponentInChildren<Text>().text = "Encounter failed!";
                    }
                }
                else
                {
                    IndividualEncounterFinishedPanel.SetActive(true);
                    if (GameManagerInstance.EncounterForIndividualWasSuccessful(myIndex, CurrentIndividualEncounterCharacterIndex))
                    {
                        IndividualEncounterFinishedPanel.GetComponentInChildren<Text>().text = "Encounter for individual was successful!";
                    }
                    else
                    {
                        IndividualEncounterFinishedPanel.GetComponentInChildren<Text>().text = "Encounter for individual failed!";
                    }
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
                        color.a = 0;
                        foreach ((Skills skillInCheck, int _) in skillChecks)
                        {
                            if (skill == skillInCheck)
                            {
                                color.a = 128;
                            }
                        }
                        OverallEncounterPlayerStatPanels[i][(int)skill].GetComponent<Image>().color = color;
                    }
                }
                foreach (Skills skill in Enum.GetValues(typeof(Skills)))
                {
                    Color color = OverallEncounterVehicleStatPanels[(int)skill].GetComponent<Image>().color;
                    color.a = 0;
                    foreach ((Skills skillInCheck, int _) in skillChecks)
                    {
                        if (skill == skillInCheck)
                        {
                            color.a = 128;
                        }
                    }
                    OverallEncounterVehicleStatPanels[(int)skill].GetComponent<Image>().color = color;
                }
            }
        }

        private Sprite getIndividualCharacterCrownSprite()
        {
            string fileName = "CharacterSlots/" + (CurrentIndividualEncounterCharacterIndex + 1);

            return Resources.Load<Sprite>(fileName);
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
                    }
                }
                catch
                {
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
                    if (!GameManagerInstance.IsAllowedToApplyCharacterToCharacterSlot(myIndex, characterIndex, card.GetCarryCapacity()))
                    {
                        isAllowed = false;
                    }
                }
                catch
                {
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
            int characterSlotComingFrom = findCardInActiveCharacters(cardImage);
            int playerIndex = GameManagerInstance.GetIndexForMyPlayer();

            if (characterSlotComingFrom != -1)
            {
                if (cardImage.GetComponentInChildren<MonoCard>().CardPtr is SpoilsCard)
                {
                    SpoilsCard card = (SpoilsCard)cardImage.GetComponentInChildren<MonoCard>().CardPtr;
                    GameManagerInstance.RemoveSpoilsCardFromPlayerActiveParty(playerIndex, characterSlotComingFrom, card);
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

                    if (panelMovingInto.name.Contains("TownRosterScrollView"))
                    {
                        GameManagerInstance.RemoveCharacterFromActiveParty(playerIndex, characterSlotComingFrom);
                        GameManagerInstance.AddCharacterToTownRoster(playerIndex, card);
                    }
                    else
                    {
                        int characterSlotMovingInto = int.Parse(panelMovingInto.name.Substring(panelMovingInto.name.Length - 1)) - 1;
                        GameManagerInstance.MoveCharacterBetweenSlots(playerIndex, characterSlotComingFrom, characterSlotMovingInto);
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
                    PlayerPanels[currentPlayerIndex].transform.Find("ResourceActualText").GetComponentInChildren<Text>().text = GameManagerInstance.GetNumberOfResourcesOwned(currentPlayerIndex).ToString();
                    PlayerPanels[currentPlayerIndex].transform.Find("BonusMovementActualText").GetComponentInChildren<Text>().text = GameManagerInstance.GetBonusMovement(currentPlayerIndex).ToString();
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
            List<CharacterCard> currentParty = GameManagerInstance.GetActiveCharacterCards(CurrentViewedID);
            for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
            {
                //Update psych resistance
                int psychRes = GameManagerInstance.GetActiveCharacterPsychResistance(CurrentViewedID, characterIndex);
                for (int i = 0; i < ActiveCharactersPsychText[characterIndex].Count; i++)
                {
                    ActiveCharactersPsychResistance[characterIndex][i].GetComponentInChildren<Text>().text = psychRes.ToString();
                }

                //Update psych remaining
                int remainingPsych = GameManagerInstance.GetActiveCharacterRemainingPsych(CurrentViewedID, characterIndex);
                int maxPsych = GameManagerInstance.GetMaxPsych();
                for (int i = 0; i < ActiveCharactersPsychText[characterIndex].Count; i++)
                {
                    ActiveCharactersPsychText[characterIndex][i].GetComponentInChildren<Text>().text = remainingPsych.ToString() + "/" + maxPsych.ToString();
                }

                //Update health remaining
                int remainingHealth = GameManagerInstance.GetActiveCharacterRemainingHealth(CurrentViewedID, characterIndex);
                for (int i = 0; i < ActiveCharactersHealthText[characterIndex].Count; i++)
                {
                    ActiveCharactersHealthText[characterIndex][i].GetComponentInChildren<Text>().text = remainingHealth.ToString();
                }

                //Hide party panel if needed
                MainOverviewCharacterPanels[characterIndex].SetActive(currentParty[characterIndex] != null);

                //Update character portrait
                if (currentParty[characterIndex] != null)
                {
                    MainOverviewCharacterPortraits[characterIndex].sprite = currentParty[characterIndex].GetCardPortrait();
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

        private void resetAfterEncounter()
        {
            MainPartyOverviewPanel.SetActive(true);
            MainEncounterCardImage.SetActive(false);
            PartyExploitsPanel.SetActive(true);
            PartyEncounterPanel.SetActive(false);
            IndividualEncounterPanel.SetActive(false);
            PartyEncounterFinishedPanel.SetActive(false);
            EncounterHasBegun = false;
            CurrentEncounterSkillPage = 0;
            WasResourceClicked = false;
        }
        #endregion
    }
}