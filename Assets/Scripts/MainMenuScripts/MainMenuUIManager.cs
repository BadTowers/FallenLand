using System.Collections.Generic;
using System.Security.Cryptography;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Castle.Core.Internal;
using System.Linq;

namespace FallenLand
{
	public class MainMenuUIManager : UIManager
	{
		public enum MainMenuStates { Main, Options, SinglePlayer, SetUpNewGame, MultiplayerCreation, MultiplayerLobby, Rules };
		public MainMenuStates currentState;

		//Menu game objects
		public GameObject MainMenu;
		public GameObject OptionsMenu;
		public GameObject SinglePlayerMenu;
		public GameObject SetUpNewGameMenu;
		public GameObject MultiplayerCreation;
		public GameObject MultiplayerLobby;
		//public Image townMapImage; //Currently unused
		public const string FACTION_MAP_LOCATION_URI = "Factions/FactionMapLocations/";
		public const string FACTION_IMAGE_URI = "Factions/FactionImage/";
		public const string FACTION_SYMBOL_URI = "Factions/FactionSymbols/";
		public const string TOWN_TECH_IMAGE_URI = "Chips/TownTechs/";
		public GameObject gameModeToggleGroup;
		public Text gameModeInfoText;
		public GameObject soloIIDifficultyToggleGroup;
		public const int SOLO_I_BUTTON_NUM = 0;
		public const int SOLO_II_BUTTON_NUM = 1;
		public GameObject ModifiersContainer;
		public string gameVersion = "1";

		private GameObject LoadingPanel;
		private Image TownLogoImage;
		private Image TownSymbolImage;
		private Image TownTech1Image;
		private Image TownTech2Image;
		private Text TownNameAndLocation;
		private Text SpecificPerk1Text;
		private Text SpecificPerk2Text;
		private Text SpecificPerk3Text;
		private Text SpecificPerk4Text;
		private Text LoreText;
		private Scrollbar LoreScrollBar;
		private Text PingText;
		private Text UserIdText;
		private Button MultiplayerStartButton;
		private int CurrentFactionNumber;
		private bool FactionWasChanged;
		private bool GameModeWasChanged;
		private List<Faction> Factions;
		private Faction CurrentFaction;
		private Text FeedbackText;
		private bool IsCreatingRoom;
		private int NumFactions;
		private int NumSinglePlayerGameModes;
		private int NumSoloIIDifficulties;
		private List<GameObject> FactionLabels;
		private List<GameObject> PlayerTexts;
		private int CurrentPlayerIndex;
		private bool ConnectedToRoom;
		private bool ConnectedToMaster;
		private bool FailedToConnectToRoom;
		private string MyOnlineUserId = "";
        private bool LoadingGame;
		private const string CURRENT_SCENE_PROPERTY = "curScn";
		private const string MAIN_MENU_SCENE_NAME = "MainMenu";
		private GameObject CreateLobbyButton;
		private GameObject JoinGameButton;
		private GameObject RulesPanel;
		private int CurrentRulesPageIndex;
		private GameObject RulesPageImage;
		[SerializeField]
		private byte maxPlayersPerRoom = 5;


        #region UnityFunctions
        void Awake()
		{
			// #Critical
			// this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
			PhotonNetwork.AutomaticallySyncScene = true;

			PhotonNetwork.PhotonServerSettings.StartInOfflineMode = false;
			PhotonNetwork.QuickResends = 3;
			PhotonNetwork.MaxResendsBeforeDisconnect = 7;

			//Initialize default values
			CurrentFactionNumber = 1;
			FactionWasChanged = true;
			GameModeWasChanged = true;
			LoadingGame = false;
			Factions = (new DefaultFactionInfo()).GetDefaultFactionList();

			FactionLabels = new List<GameObject>();
			PlayerTexts = new List<GameObject>();
			for (int i = 0; i < maxPlayersPerRoom; i++)
			{
				PlayerTexts.Add(GameObject.Find("PlayerText_" + i));
				FactionLabels.Add(GameObject.Find("FactionText_" + i));
			}

			FeedbackText = GameObject.Find("FeedbackText").GetComponent<Text>();

			instantiateGameObjects();

			RulesPanel = GameObject.Find("RulesPanel");

			//Add all of the menu game objects to the array list (ADD NEW MENU PANELS HERE)
			AddToMenuList(MainMenu);
			AddToMenuList(OptionsMenu);
			AddToMenuList(SinglePlayerMenu);
			AddToMenuList(SetUpNewGameMenu);
			AddToMenuList(MultiplayerCreation);
			AddToMenuList(MultiplayerLobby);
			AddToMenuList(RulesPanel);

			currentState = MainMenuStates.Main;
			IsCreatingRoom = false;

			NumFactions = 10;
			NumSinglePlayerGameModes = 2;
			NumSoloIIDifficulties = 4;
			ConnectedToRoom = false;
			FailedToConnectToRoom = false;

			CurrentPlayerIndex = -1;

			TownLogoImage = GameObject.Find("FactionLogoImage").GetComponent<Image>();
			TownSymbolImage = GameObject.Find("FactionSymbolImage").GetComponent<Image>();
			TownTech1Image = GameObject.Find("Tech1Image").GetComponent<Image>();
			TownTech2Image = GameObject.Find("Tech2Image").GetComponent<Image>();
			TownNameAndLocation = GameObject.Find("TownInfoText").GetComponent<Text>();
			SpecificPerk1Text = GameObject.Find("SpecificPerk1Text").GetComponent<Text>();
			SpecificPerk2Text = GameObject.Find("SpecificPerk2Text").GetComponent<Text>();
			SpecificPerk3Text = GameObject.Find("SpecificPerk3Text").GetComponent<Text>();
			SpecificPerk4Text = GameObject.Find("SpecificPerk4Text").GetComponent<Text>();
			LoreText = GameObject.Find("LoreText").GetComponent<Text>();
			LoreScrollBar = GameObject.Find("LoreScrollbar").GetComponent<Scrollbar>();
			PingText = GameObject.Find("ActualPingText").GetComponent<Text>();
			UserIdText = GameObject.Find("UserIdText").GetComponent<Text>();
			MultiplayerStartButton = GameObject.Find("StartGameButton").GetComponent<Button>();
			LoadingPanel = GameObject.Find("LoadingPanel");
			CreateLobbyButton = GameObject.Find("CreateLobbyButton");
			JoinGameButton = GameObject.Find("JoinGameButton");
			RulesPageImage = GameObject.Find("RulesPageImage");

			LoadingPanel.SetActive(false);

			//Limit the frame rate
			QualitySettings.vSyncCount = 0;  // VSync must be disabled
			Application.targetFrameRate = 144;

			if (System.IO.File.Exists("UserId"))
			{
				System.IO.StreamReader reader = new System.IO.StreamReader("UserId");
				MyOnlineUserId = reader.ReadLine();
				reader.Close();
				PhotonNetwork.AuthValues = new AuthenticationValues(MyOnlineUserId);
			}
		}

		void Update()
		{
			//Checks current menu state
			switch (currentState)
			{
				case MainMenuStates.Main:
					SetActiveMenu(MainMenu);
					break;
				case MainMenuStates.SinglePlayer:
					SetActiveMenu(SinglePlayerMenu);
					break;
				case MainMenuStates.SetUpNewGame:
					SetActiveMenu(SetUpNewGameMenu);
					if (FactionWasChanged)
					{
						updateFactionDisplay(); //Update which faction is currently displaying if a new one was selected
					}
					if (GameModeWasChanged)
					{
						updateGameModeDisplay(); //Update the game mode information if a different one was selected
					}
					break;
				case MainMenuStates.Options:
					SetActiveMenu(OptionsMenu);
					break;
				case MainMenuStates.MultiplayerCreation:
					SetActiveMenu(MultiplayerCreation);
					break;
				case MainMenuStates.MultiplayerLobby:
					SetActiveMenu(MultiplayerLobby);
					if (FactionWasChanged)
					{
						updateFactionDisplay(); //Update which faction is currently displaying if a new one was selected
					}
					updatePlayerList();
					updatePing();
					updateStartButton();
					break;
				case MainMenuStates.Rules:
					SetActiveMenu(RulesPanel);
					break;
				default:
					//Default will be to show the main menu in case of error
					SetActiveMenu(MainMenu);
					break;
			}

			handleLoading();
		}
		#endregion

		#region PublicAPI
		public void JoinRoom()
		{
			RoomNameInputField roomNameInputField = GameObject.Find("RoomNameInputField").GetComponent<RoomNameInputField>();
			if (string.IsNullOrEmpty(roomNameInputField.GetRoomName()))
			{
				FeedbackText.text = "Room name cannot be empty";
			}
			else
			{
				if (PhotonNetwork.IsConnected)
				{
					Debug.Log("Already connected to the photon network");
					PhotonNetwork.JoinRoom(roomNameInputField.GetRoomName());
				}
				else
				{
					Debug.Log("Not connected to photon network... need to do that");
					PhotonNetwork.ConnectUsingSettings();
					PhotonNetwork.GameVersion = gameVersion;
				}
			}
		}

		public void CreateRoom()
		{
			IsCreatingRoom = true;
			RoomNameInputField roomNameInputField = GameObject.Find("RoomNameInputField").GetComponent<RoomNameInputField>();
			if (string.IsNullOrEmpty(roomNameInputField.GetRoomName()))
			{
				Debug.Log("Room name is null or empty");
				FeedbackText.text = "Room name cannot be empty";
			}
			else
			{
				if (PhotonNetwork.IsConnected)
				{
					Debug.Log("Connected to the photon network");
					OnConnectedToMaster();
				}
				else
				{
					Debug.Log("Not connected to photon network... need to do that");
					PhotonNetwork.ConnectUsingSettings();
					PhotonNetwork.GameVersion = gameVersion;
				}
			}
		}

		public bool GetConnectedToRoom()
		{
			return ConnectedToRoom;
		}

		public bool GetFailedToConnectToRoom()
		{
			return FailedToConnectToRoom;
		}
		
		public bool GetConnectedToMaster()
		{
			return ConnectedToMaster;
		}
        #endregion

        #region PunCallbacks
        public override void OnConnectedToMaster()
		{
			Debug.Log("OnConnectedToMaster callback");
			ConnectedToMaster = true;
			RoomNameInputField roomNameInputField = GameObject.Find("RoomNameInputField").GetComponent<RoomNameInputField>();

			if (IsCreatingRoom)
			{
				Debug.Log("Is creating OnConnectedToMaster");
				RoomOptions roomOptions = new RoomOptions
				{
					MaxPlayers = maxPlayersPerRoom,
					PublishUserId = true,
					PlayerTtl=0
				};
				PhotonNetwork.CreateRoom(roomNameInputField.GetRoomName(), roomOptions);
				IsCreatingRoom = false;
			}
			else
			{
				Debug.Log("Is joining OnConnectedToMaster");
				PhotonNetwork.JoinRoom(roomNameInputField.GetRoomName());
			}
		}

		public override void OnCreateRoomFailed(short returnCode, string message)
		{
			Debug.LogWarningFormat("OnCreateRoomFailed() was called by PUN with reason {0}", message);
			Debug.Log("OnCreateRoomFailed() was called by PUN with reason " + message);
			FailedToConnectToRoom = true;
			ConnectedToRoom = false;
			FeedbackText.text = "Failed to create lobby: " + message;
			CreateLobbyButton.GetComponent<Button>().interactable = true;
			JoinGameButton.GetComponent<Button>().interactable = true;
		}

		public override void OnJoinRoomFailed(short returnCode, string message)
		{
			if (returnCode == ErrorCode.JoinFailedFoundInactiveJoiner || returnCode == ErrorCode.GameClosed)
			{
				RoomNameInputField roomNameInputField = GameObject.Find("RoomNameInputField").GetComponent<RoomNameInputField>();
				PhotonNetwork.RejoinRoom(roomNameInputField.GetRoomName());
				FeedbackText.text = "Attempting to rejoin...";
			}
			else
			{
				Debug.LogWarningFormat("OnJoinRoomFailed() was called by PUN with code {0} with reason {1}", returnCode, message);
				Debug.Log("OnJoinRoomFailed() was called by PUN with reason " + message);
				FailedToConnectToRoom = true;
				ConnectedToRoom = false;
				FeedbackText.text = "Failed to join lobby: " + message;
				CreateLobbyButton.GetComponent<Button>().interactable = true;
				JoinGameButton.GetComponent<Button>().interactable = true;
			}
		}

		public override void OnJoinedRoom()
		{
			ConnectedToRoom = true;
			FailedToConnectToRoom = false;
			Debug.Log("MainMenuUIManager.OnJoinedRoom()");

			if (CurrentPlayerIndex == -1)
			{
				CurrentPlayerIndex = PhotonNetwork.PlayerList.Length - 1;
			}
			if (MyOnlineUserId != PhotonNetwork.PlayerList[CurrentPlayerIndex].UserId)
			{
				MyOnlineUserId = PhotonNetwork.PlayerList[CurrentPlayerIndex].UserId;
				System.IO.File.WriteAllText("UserId", MyOnlineUserId);
			}
			UserIdText.text = MyOnlineUserId;

			currentState = MainMenuStates.MultiplayerLobby;
		}

		public override void OnDisconnected(DisconnectCause cause)
		{
			Debug.Log("OnDisconnected: " + cause.ToString());
			ConnectedToRoom = false;
			ConnectedToMaster = false;
			MyOnlineUserId = "";
		}

		public override void OnLeftLobby()
		{
			Debug.Log("Left lobby callback");
		}
		
		public override void OnLeftRoom()
		{
			Debug.Log("Left room callback");
			ConnectedToRoom = false;
			CurrentPlayerIndex = -1;
		}

		public override void OnPlayerEnteredRoom(Photon.Realtime.Player player)
		{
			Debug.Log("OnPlayerEnteredRoom callback. Name: " + player.NickName + " ID: " + player.UserId);
		}

		public override void OnPlayerLeftRoom(Photon.Realtime.Player player)
		{
			Debug.Log("OnPlayerLeftRoom callback. Name: " + player.NickName + " ID: " + player.UserId);
			updateUserOnlineInformation();
		}

		public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
		{
			Debug.Log("OnRoomPropertiesUpdate in MainMenuUIManager");
			if (propertiesThatChanged.ContainsKey(CURRENT_SCENE_PROPERTY))
			{
				object sceneId = PhotonNetwork.CurrentRoom.CustomProperties[CURRENT_SCENE_PROPERTY];
				if (sceneId is string)
				{
					if (MAIN_MENU_SCENE_NAME != (string)sceneId)
					{
						LoadingGame = true;
					}
				}
			}
		}
		#endregion

		#region UICallbacks
		public void OnSinglePlayerButtonPressed()
		{
			Debug.Log("Single Player");
			currentState = MainMenuStates.SinglePlayer;
			//asyncSceneLoad("GameScene");
		}

		public void OnOptionsButtonPressed()
		{
			Debug.Log("Options");
			currentState = MainMenuStates.Options;
		}

		public void OnMultiplayerButtonPressed()
		{
			Debug.Log("Multiplayer creation");
			currentState = MainMenuStates.MultiplayerCreation;
		}

		public void OnRulesButtonPressed()
		{
			currentState = MainMenuStates.Rules;
		}

		public void OnQuitButtonPressed()
		{
			Debug.Log("Quit");
			#if UNITY_STANDALONE
			Application.Quit();
			#endif

			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#endif
		}

		public void OnStartDefault()
		{
			//TODO
			Debug.Log("Start default");
		}

		public void OnSetUpGame()
		{
			currentState = MainMenuStates.SetUpNewGame;
		}

		public void OnLoadGame()
		{
			//TODO
			Debug.Log("Load game");
		}

		public void OnTutorial()
		{
			//TODO
			Debug.Log("Tutorial");
		}

		public void OnPreviousFactionButtonPressed()
		{
			if (CurrentFactionNumber == 1)
			{
				CurrentFactionNumber = NumFactions;
			}
			else
			{
				CurrentFactionNumber--;
			}
			FactionWasChanged = true;
		}

		public void OnNextFactionButtonPressed()
		{
			if (CurrentFactionNumber == NumFactions)
			{
				CurrentFactionNumber = 1;
			}
			else
			{
				CurrentFactionNumber++;
			}
			FactionWasChanged = true;
		}

		public void onGameModeChange()
		{
			GameModeWasChanged = true;
		}

		//When randomize button is pressed (on secure random numbers https://stackify.com/csharp-random-numbers/)
		public void onRandomize()
		{

			//Collect all the modifier toggles from the container
			Toggle[] modifierToggles = ModifiersContainer.GetComponentsInChildren<Toggle>();

			/* Randomly pick a faction */
			RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
			byte[] byteArray = new byte[1];
			provider.GetBytes(byteArray);
			int randInt = Convert.ToInt32(byteArray[0]);
			CurrentFactionNumber = Math.Abs(((randInt) % (NumFactions)) + 1);
			//Debug.Log ("FAC: " + curFactionNum.ToString ());
			FactionWasChanged = true;

			/* Randomly pick game mode */
			//Game mode first
			provider = new RNGCryptoServiceProvider();
			byteArray = new byte[1];
			provider.GetBytes(byteArray);
			randInt = Convert.ToInt32(byteArray[0]);
			int randNum = Math.Abs((randInt) % NumSinglePlayerGameModes);
			//Debug.Log ("MODE: " + randNum.ToString ());
			gameModeToggleGroup.GetComponentsInChildren<Toggle>()[randNum].isOn = true;
			//Difficulty too (if not needed, it won't show up in the UI)
			//Turn them all off first
			foreach (Toggle diffToggle in soloIIDifficultyToggleGroup.GetComponentsInChildren<Toggle>())
			{
				diffToggle.isOn = false;
			}
			byteArray = new byte[1];
			provider.GetBytes(byteArray);
			randInt = Convert.ToInt32(byteArray[0]);
			randNum = Math.Abs((randInt) % NumSoloIIDifficulties);
			//Debug.Log("DIFF: " + randNum.ToString ());
			soloIIDifficultyToggleGroup.GetComponentsInChildren<Toggle>()[randNum].isOn = true;
			GameModeWasChanged = true;

			/* Randomly pick the modifiers */
			foreach (Toggle modifier in modifierToggles)
			{
				//First turn off the modifer
				modifier.isOn = false;

				//Generate a random number to determine if we should turn on a modifer
				provider = new RNGCryptoServiceProvider();
				byteArray = new byte[1];
				provider.GetBytes(byteArray);
				randInt = Convert.ToInt32(byteArray[0]);
				if (randInt % 2 == 0)
				{
					modifier.isOn = true;
					//If this modifier toggle is dependent on another, the checkIfParentActive method checks that the parent is on before turning the dependent child on
					if (modifier.GetComponentInChildren<ToggleDependency>() != null)
					{
						modifier.GetComponentInChildren<ToggleDependency>().CheckIfParentActive();
					}
				}
			}

			//Collect all dependent modifiers
		}

		public void onStartGameFromSetup()
		{
			/****** Pass all information from this screen into the game creation object ********/


			//Faction (Find the game creation object in the scene and then get the script from it
			foreach (Faction f in Factions)
			{
				if (f.GetId() == CurrentFactionNumber)
				{
					GameObject.Find("GameCreation").GetComponentInChildren<GameCreation>().SetFaction(f);
				}
			}

			//Game mode
			foreach (Toggle curModeToggle in gameModeToggleGroup.GetComponentsInChildren<Toggle>())
			{
				if (curModeToggle.isOn)
				{
					GameObject.Find("GameCreation").GetComponentInChildren<GameCreation>().SetMode(curModeToggle.GetComponentInChildren<ToggleInformation>().mode);
				}
			}

			//Solo II difficulty if needed
			foreach (Toggle curDiffToggle in soloIIDifficultyToggleGroup.GetComponentsInChildren<Toggle>())
			{
				if (curDiffToggle.isOn)
				{
					GameObject.Find("GameCreation").GetComponentInChildren<GameCreation>().SetSoloIIDifficulty(curDiffToggle.GetComponentInChildren<ToggleInformation>().soloIIDifficulty);
				}
			}

			//Game modifiers
			foreach (Toggle modifier in ModifiersContainer.GetComponentsInChildren<Toggle>())
			{
				if (modifier.isOn)
				{
					GameObject.Find("GameCreation").GetComponentInChildren<GameCreation>().AddModifier(modifier.GetComponentInChildren<ToggleInformation>().modifier);
				}
			}

			//Load the next scene to start the game
			asyncSceneLoad("GameScene");
		}

		public void onJoinMultiplayerGame()
		{
			CreateLobbyButton.GetComponent<Button>().interactable = false;
			JoinGameButton.GetComponent<Button>().interactable = false;
			FeedbackText.text = "Attempting to join...";
			JoinRoom();
		}

		public void onCreateMultiplayerGame()
		{
			CreateLobbyButton.GetComponent<Button>().interactable = false;
			JoinGameButton.GetComponent<Button>().interactable = false;
			FeedbackText.text = "Creating lobby...";
			CreateRoom();
		}

		public void OnMultiplayerStartButtonPressed()
		{
			if (!PhotonNetwork.IsMasterClient)
			{
				Debug.Log("PhotonNetwork : Trying to Load a level but we are not the master Client");
			}
			else
			{
				Debug.Log("PhotonNetwork : Loading game");

				gatherDataForNextScene();

			    PhotonNetwork.CurrentRoom.IsOpen = false; //Lock the room so no one else can join
				PhotonNetwork.CurrentRoom.PlayerTtl = 60000 * 5; //Once the game starts, then we keep player data in the server

				//Show loading screen
				LoadingGame = true;

				PhotonNetwork.LoadLevel("GameScene");
			}
		}

		public void onBack()
		{
			currentState = MainMenuStates.Main;
			if (PhotonNetwork.InRoom)
			{
				Debug.Log("leaving room from back");
				PhotonNetwork.LeaveRoom();
			}
			if (PhotonNetwork.InLobby)
			{
				Debug.Log("leaving lobby from back");
				PhotonNetwork.LeaveLobby();
			}

			FeedbackText.text = "";
		}

        public void OnRulesPreviousPress()
        {
			CurrentRulesPageIndex--;
			if (CurrentRulesPageIndex < 0)
			{
				CurrentRulesPageIndex = 0;
			}
			updateRulesPageImage();
		}

		public void OnRulesNextPress()
		{
			CurrentRulesPageIndex++;
			if (CurrentRulesPageIndex > Constants.NUM_PAGES_IN_RULEBOOK)
			{
				CurrentRulesPageIndex = Constants.NUM_PAGES_IN_RULEBOOK;
			}
			updateRulesPageImage();
		}
        #endregion

        #region HelperFunctions
        // Used to load a scene by name TODO: Put inside helper function file?
        private void asyncSceneLoad(string name)
		{
			SceneManager.LoadSceneAsync(name);
		}

		// Used to load in new faction and display it
		private void updateFactionDisplay()
		{
			//Set the current faction
			foreach (Faction faction in Factions)
			{
				if (faction.GetId() == CurrentFactionNumber)
				{
					CurrentFaction = faction;
				}
			}

			//Load it
			Sprite img = (Sprite)Resources.Load<Sprite>(FACTION_IMAGE_URI + "FactionImage" + CurrentFactionNumber.ToString());

			//Apply it
			if (TownLogoImage != null)
			{
				TownLogoImage.sprite = img;
			}
			else
			{
				Debug.Log("Town logo image container not set");
			}

			//Load it
			img = Resources.Load<Sprite>(FACTION_SYMBOL_URI + "FactionSymbol" + CurrentFactionNumber.ToString());

			//Apply it
			if (TownSymbolImage != null)
			{
				TownSymbolImage.sprite = img;
			}
			else
			{
				Debug.Log("Town symbol image container not set");
			}

			//Set up town name and location
			if (TownNameAndLocation != null)
			{
				TownNameAndLocation.text = CurrentFaction.GetName() + "\n" + CurrentFaction.GetBaseLocationString();
			}
			else
			{
				Debug.Log("Town name and location container not set");
			}

			//Set up the perk texts TODO rework this to be more dynamic (could have more or less than 4 perks)
			if (SpecificPerk1Text != null)
			{
				SpecificPerk1Text.text = CurrentFaction.GetPerks()[0].GetPerkTitle() + ": " + CurrentFaction.GetPerks()[0].GetPerkDescription();
			}
			else
			{
				Debug.Log("Perk 1 text container not set");
			}
			if (SpecificPerk2Text != null)
			{
				SpecificPerk2Text.text = CurrentFaction.GetPerks()[1].GetPerkTitle() + ": " + CurrentFaction.GetPerks()[1].GetPerkDescription();
			}
			else
			{
				Debug.Log("Perk 2 text container not set");
			}
			if (SpecificPerk3Text != null)
			{
				SpecificPerk3Text.text = CurrentFaction.GetPerks()[2].GetPerkTitle() + ": " + CurrentFaction.GetPerks()[2].GetPerkDescription();
			}
			else
			{
				Debug.Log("Perk 3 text container not set");
			}
			if (SpecificPerk4Text != null)
			{
				SpecificPerk4Text.text = CurrentFaction.GetPerks()[3].GetPerkTitle() + ": " + CurrentFaction.GetPerks()[3].GetPerkDescription();
			}
			else
			{
				Debug.Log("Perk 4 text container not set");
			}

			//Set up town lore
			if (LoreText != null)
			{
				LoreText.text = CurrentFaction.GetLore();
			}
			else
			{
				Debug.Log("Lore text container not set");
			}
			//Move the lore back to the top when the faction switches
			if (LoreScrollBar != null)
			{
				LoreScrollBar.value = 1;
			}
			else
			{
				Debug.Log("Lore scroll bar not set");
			}

			//Set up town techs TODO rework so this is not hardcoded to two
			//Load tech 1
			img = Resources.Load<Sprite>(TOWN_TECH_IMAGE_URI + "TownTech" + CurrentFaction.GetStartingTownTechs()[0].GetId().ToString());
			//Apply it
			if (TownTech1Image != null)
			{
				TownTech1Image.sprite = img;
			}
			else
			{
				Debug.Log("Town tech image 1 container not set");
			}
			//Load tech 2
			img = Resources.Load<Sprite>(TOWN_TECH_IMAGE_URI + "TownTech" + CurrentFaction.GetStartingTownTechs()[1].GetId().ToString());
			//Apply it
			if (TownTech2Image != null)
			{
				TownTech2Image.sprite = img;
			}
			else
			{
				Debug.Log("Town tech image 2 container not set");
			}

			//Set faction label
			if (CurrentPlayerIndex > -1)
			{
				FactionLabels[CurrentPlayerIndex].GetComponent<Text>().text = CurrentFaction.GetName();
			}

			//No more changes to account for
			FactionWasChanged = false;
		}

		private void updateGameModeDisplay()
		{
			//If solo I is selected
			if (gameModeToggleGroup != null)
			{
				if (gameModeToggleGroup.GetComponentsInChildren<Toggle>()[SOLO_I_BUTTON_NUM].isOn)
				{
					//Don't display the solo II difficulties
					if (soloIIDifficultyToggleGroup != null)
					{
						soloIIDifficultyToggleGroup.SetActive(false);
					}
					else
					{
						Debug.Log("soloIIDifficultyToggleGroup is null");
					}

					//Update the text to describe the game mode
					if (gameModeInfoText != null)
					{
						gameModeInfoText.text = GameInformation.getRules(GameInformation.GameModes.SoloI);
					}
					else
					{
						Debug.Log("gameModeInfoText is null");
					}
				}
				//If solo II is selected
				else if (gameModeToggleGroup.GetComponentsInChildren<Toggle>()[SOLO_II_BUTTON_NUM].isOn)
				{
					//Display the solo II difficulties
					if (soloIIDifficultyToggleGroup != null)
					{
						soloIIDifficultyToggleGroup.SetActive(true);
					}
					else
					{
						Debug.Log("soloIIDifficultyToggleGroup is null");
					}

					//Update the text to describe the game mode
					if (gameModeInfoText != null)
					{
						gameModeInfoText.text = GameInformation.getRules(GameInformation.GameModes.SoloII);
					}
					else
					{
						Debug.Log("gameModeInfoText is null");
					}
				}
			}
			else
			{
				Debug.Log("gameModeToggleGroup is null");
			}

			//No more changes to account for
			GameModeWasChanged = false;
		}

		private void updatePlayerList()
		{
			for (int playerIndex = 0; playerIndex < PhotonNetwork.PlayerList.Length; playerIndex++)
			{
				Photon.Realtime.Player player = PhotonNetwork.PlayerList[playerIndex];
				Hashtable playerHashTable = player.CustomProperties;

				PlayerTexts[playerIndex].GetComponent<Text>().text = player.NickName;
				PlayerTexts[playerIndex].SetActive(true);
				FactionLabels[playerIndex].SetActive(true);

				if (playerIndex == CurrentPlayerIndex)
				{
					updateMultiplayerNameColor(playerIndex, 37f / 255f, 135f / 255f, 6f / 255f);
					if ((string)playerHashTable["FactionName"] != CurrentFaction.GetName())
					{
						Hashtable properties = new Hashtable
						{
							["FactionName"] = CurrentFaction.GetName()
						};
						player.SetCustomProperties(properties);
					}
				}
				else
				{
					updateMultiplayerNameColor(playerIndex, 0f, 0f, 0f);
				}

				if (!playerHashTable.IsNullOrEmpty())
				{
					string currentPlayerFaction = (string)playerHashTable["FactionName"];
					FactionLabels[playerIndex].GetComponent<Text>().text = currentPlayerFaction;
				}
			}

			for (int i = PhotonNetwork.PlayerList.Length; i < maxPlayersPerRoom; i++)
			{
				PlayerTexts[i].SetActive(false);
				FactionLabels[i].SetActive(false);
			}
		}

		private void updatePing()
		{
			PingText.text = PhotonNetwork.GetPing() + "ms";
		}

		private void updateStartButton()
		{
			//Check if two players are on the same faction
			List<string> factions = new List<string>();
			for (int playerIndex = 0; playerIndex < PhotonNetwork.PlayerList.Length; playerIndex++)
			{
				Photon.Realtime.Player player = PhotonNetwork.PlayerList[playerIndex];
				Hashtable playerHashTable = player.CustomProperties;

                if (!playerHashTable.IsNullOrEmpty())
                {
                    factions.Add((string)playerHashTable["FactionName"]);
                }
            }
			IEnumerable<string> duplicates = factions.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => x.Key);

			MultiplayerStartButton.interactable = (PhotonNetwork.IsMasterClient) && (PhotonNetwork.PlayerList.Length > 1) && (duplicates.Count() == 0);
		}

		private void instantiateGameObjects()
		{
			if (MainMenu == null)
			{
				MainMenu = new GameObject();
				Debug.Log("mainMenu was not set");
			}
			if (OptionsMenu == null)
			{
				OptionsMenu = new GameObject();
				Debug.Log("optionsMenu was not set");
			}
			if (SinglePlayerMenu == null)
			{
				SinglePlayerMenu = new GameObject();
				Debug.Log("singlePlayerMenu was not set");
			}
			if (SetUpNewGameMenu == null)
			{
				SetUpNewGameMenu = new GameObject();
				Debug.Log("setUpNewGameMenu was not set");
			}
			if (MultiplayerCreation == null)
			{
				MultiplayerCreation = new GameObject();
				Debug.Log("MultiplayerCreation was not set");
			}
			if (MultiplayerLobby == null)
			{
				MultiplayerLobby = new GameObject();
				Debug.Log("MultiplayerLobby was not set");
			}
		}

		private void gatherDataForNextScene()
		{
			for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
			{
				GameObject.Find("GameCreation").GetComponentInChildren<GameCreation>().AddFaction(i, (string)PhotonNetwork.PlayerList[i].CustomProperties["FactionName"]);
			}

			GameObject.Find("GameCreation").GetComponentInChildren<GameCreation>().SetMode(GameInformation.GameModes.NormalGame);
		}

		private void updateUserOnlineInformation()
		{
			for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
			{
				if (PhotonNetwork.PlayerList[i].UserId == MyOnlineUserId)
				{
					CurrentPlayerIndex = i;
				}
			}
		}

		private void updateMultiplayerNameColor(int playerIndex, float r, float g, float b)
		{
			//Color requires a number between 0-1
			if (PlayerTexts[playerIndex].GetComponent<Text>().color.r != r ||
			    PlayerTexts[playerIndex].GetComponent<Text>().color.g != g ||
			    PlayerTexts[playerIndex].GetComponent<Text>().color.b != b)
			{
				PlayerTexts[playerIndex].GetComponent<Text>().color = new Color(r, g, b);
			}
		}

		private void handleLoading()
		{
			if (LoadingGame)
			{
				LoadingPanel.SetActive(true);
			}
		}

		private void updateRulesPageImage()
		{
			RulesPageImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Rules/" + CurrentRulesPageIndex.ToString());
		}
		#endregion
	}
}