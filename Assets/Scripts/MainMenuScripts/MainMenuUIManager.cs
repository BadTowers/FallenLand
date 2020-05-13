﻿using System.Collections.Generic;
using System.Security.Cryptography;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

namespace FallenLand
{
	public class MainMenuUIManager : UIManager
	{

		public enum MainMenuStates { Main, Options, SinglePlayer, SetUpNewGame, MultiplayerCreation, MultiplayerLobby };
		public MainMenuStates currentState;

		//Menu game objects
		public GameObject mainMenu;
		public GameObject optionsMenu;
		public GameObject singlePlayerMenu;
		public GameObject setUpNewGameMenu;
		public GameObject MultiplayerCreation;
		public GameObject MultiplayerLobby;

		//List of all things to randomize

		//For set up new game
		public Image townLogoImage;
		public Image townSymbolImage;
		//public Image townMapImage; //Currently unused
		public Image townTech1Image;
		public Image townTech2Image;
		public int numFactions;
		public int numSinglePlayerGameModes;
		public int numSoloIIDifficulties;
		public Text townNameAndLocation;
		public Text specificPerk1Text;
		public Text specificPerk2Text;
		public Text specificPerk3Text;
		public Text specificPerk4Text;
		public Text loreText;
		public Scrollbar loreScrollBar;
		public const string FACTION_MAP_LOCATION_URI = "Factions/FactionMapLocations/";
		public const string FACTION_IMAGE_URI = "Factions/FactionImage/";
		public const string FACTION_SYMBOL_URI = "Factions/FactionSymbols/";
		public const string TOWN_TECH_IMAGE_URI = "Chips/TownTechs/";
		public GameObject gameModeToggleGroup;
		public Text gameModeInfoText;
		public GameObject soloIIDifficultyToggleGroup;
		public const int SOLO_I_BUTTON_NUM = 0;
		public const int SOLO_II_BUTTON_NUM = 1;
		public GameObject modifiersContainer;
		public string gameVersion = "1";

		private int CurrentFactionNumber;
		private bool FactionWasChanged;
		private bool GameModeWasChanged;
		private List<Faction> Factions;
		private Faction CurrentFaction;
		private Text FeedbackText;
		private bool IsCreatingRoom;

		[SerializeField]
		private byte maxPlayersPerRoom = 5;

		//When script first starts
		void Awake()
		{
			// #Critical
			// this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
			PhotonNetwork.AutomaticallySyncScene = true;

			//Initialize default values
			CurrentFactionNumber = 1;
			FactionWasChanged = true;
			GameModeWasChanged = true;
			Factions = (new DefaultFactionInfo()).GetDefaultFactionList(); //TODO rework to handle mods later?

			instantiateGameObjects();

			//Add all of the menu game objects to the array list (ADD NEW MENU PANELS HERE)
			addToMenuList(mainMenu);
			addToMenuList(optionsMenu);
			addToMenuList(singlePlayerMenu);
			addToMenuList(setUpNewGameMenu);
			addToMenuList(MultiplayerCreation);
			addToMenuList(MultiplayerLobby);

			currentState = MainMenuStates.Main;
			IsCreatingRoom = false;
		}

		void Update()
		{
			//Checks current menu state
			switch (currentState)
			{
				case MainMenuStates.Main:
					setActiveMenu(mainMenu);
					break;
				case MainMenuStates.SinglePlayer:
					setActiveMenu(singlePlayerMenu);
					break;
				case MainMenuStates.SetUpNewGame:
					setActiveMenu(setUpNewGameMenu);
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
					setActiveMenu(optionsMenu);
					break;
				case MainMenuStates.MultiplayerCreation:
					setActiveMenu(MultiplayerCreation);
					break;
				case MainMenuStates.MultiplayerLobby:
					setActiveMenu(MultiplayerLobby);
					updatePlayerList();
					break;
				default:
					//Default will be to show the main menu in case of error
					setActiveMenu(mainMenu);
					break;
			}
		}

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
					Debug.Log("Connected to the photon network");
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
				FeedbackText.text = "Room name cannot be empty";
			}
			else
			{
				if (PhotonNetwork.IsConnected)
				{
					Debug.Log("Connected to the photon network");
				}
				else
				{
					Debug.Log("Not connected to photon network... need to do that");
					PhotonNetwork.ConnectUsingSettings();
					PhotonNetwork.GameVersion = gameVersion;
				}
			}
		}

		public override void OnConnectedToMaster()
		{
			RoomNameInputField roomNameInputField = GameObject.Find("RoomNameInputField").GetComponent<RoomNameInputField>();

			if (IsCreatingRoom)
			{
				Debug.Log("Is creating OnConnectedToMaster");
				RoomOptions roomOptions = new RoomOptions();
				roomOptions.MaxPlayers = maxPlayersPerRoom;
				PhotonNetwork.CreateRoom(roomNameInputField.GetRoomName(), roomOptions);
				IsCreatingRoom = false;
			}
			else
			{
				Debug.Log("Is joining OnConnectedToMaster");
				PhotonNetwork.JoinRoom(roomNameInputField.GetRoomName());
			}
		}

		public override void OnJoinRoomFailed(short returnCode, string message)
		{
			Debug.LogWarningFormat("OnJoinRoomFailed() was called by PUN with reason {0}", message);
			FeedbackText.text = "Failed to join lobby";
		}

		public override void OnJoinedRoom()
		{
			Debug.Log("OnJoinedRoom()");
			currentState = MainMenuStates.MultiplayerLobby;
		}


		/*
		 * MAIN MENU METHODS
		 */
		// When new game button is pressed
		public void OnSinglePlayerButtonPressed()
		{
			Debug.Log("Single Player");
			currentState = MainMenuStates.SinglePlayer;
			//asyncSceneLoad("GameScene");
		}

		// When options button is pressed
		public void OnOptionsButtonPressed()
		{
			Debug.Log("Options");
			currentState = MainMenuStates.Options;
		}

		// When multiplayer button is pressed
		public void OnMultiplayerButtonPressed()
		{
			Debug.Log("Multiplayer creation");
			currentState = MainMenuStates.MultiplayerCreation;
		}

		// When quit button is pressed
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


		/*
		 * NEW GAME METHODS
		 */
		//When start default game button is pressed
		public void OnStartDefault()
		{
			//TODO
			Debug.Log("Start default");
		}

		//When set up new game button is pressed
		public void OnSetUpGame()
		{
			currentState = MainMenuStates.SetUpNewGame;
		}

		//When load game button is pressed
		public void OnLoadGame()
		{
			//TODO
			Debug.Log("Load game");
		}

		//When tutorial button is pressed
		public void OnTutorial()
		{
			//TODO
			Debug.Log("Tutorial");
		}


		/*
		 * SET UP NEW GAME METHODS
		 */
		//When the previous town play mat arrow is pressed
		public void onPrevious()
		{
			if (CurrentFactionNumber == 1)
			{
				CurrentFactionNumber = numFactions;
			}
			else
			{
				CurrentFactionNumber--;
			}
			FactionWasChanged = true;
		}

		//When the next town play mat arrow is pressed
		public void onNext()
		{
			if (CurrentFactionNumber == numFactions)
			{
				CurrentFactionNumber = 1;
			}
			else
			{
				CurrentFactionNumber++;
			}
			FactionWasChanged = true;
		}

		//When game mode toggle changes
		public void onGameModeChange()
		{
			GameModeWasChanged = true;
		}

		//When randomize button is pressed (on secure random numbers https://stackify.com/csharp-random-numbers/)
		public void onRandomize()
		{

			//Collect all the modifier toggles from the container
			Toggle[] modifierToggles = modifiersContainer.GetComponentsInChildren<Toggle>();

			/* Randomly pick a faction */
			RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
			byte[] byteArray = new byte[1];
			provider.GetBytes(byteArray);
			int randInt = Convert.ToInt32(byteArray[0]);
			CurrentFactionNumber = Math.Abs(((randInt) % (numFactions)) + 1);
			//Debug.Log ("FAC: " + curFactionNum.ToString ());
			FactionWasChanged = true;

			/* Randomly pick game mode */
			//Game mode first
			provider = new RNGCryptoServiceProvider();
			byteArray = new byte[1];
			provider.GetBytes(byteArray);
			randInt = Convert.ToInt32(byteArray[0]);
			int randNum = Math.Abs((randInt) % numSinglePlayerGameModes);
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
			randNum = Math.Abs((randInt) % numSoloIIDifficulties);
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
						modifier.GetComponentInChildren<ToggleDependency>().checkIfParentActive();
					}
				}
			}

			//Collect all dependent modifiers
		}

		//When start button is pressed
		public void onStartGameFromSetup()
		{
			/****** Pass all information from this screen into the game creation object ********/


			//Faction (Find the game creation object in the scene and then get the script from it
			foreach (Faction f in Factions)
			{
				if (f.GetId() == CurrentFactionNumber)
				{
					GameObject.Find("GameCreation").GetComponentInChildren<GameCreation>().setFaction(f);
				}
			}

			//Game mode
			foreach (Toggle curModeToggle in gameModeToggleGroup.GetComponentsInChildren<Toggle>())
			{
				if (curModeToggle.isOn)
				{
					GameObject.Find("GameCreation").GetComponentInChildren<GameCreation>().setMode(curModeToggle.GetComponentInChildren<ToggleInformation>().mode);
				}
			}

			//Solo II difficulty if needed
			foreach (Toggle curDiffToggle in soloIIDifficultyToggleGroup.GetComponentsInChildren<Toggle>())
			{
				if (curDiffToggle.isOn)
				{
					GameObject.Find("GameCreation").GetComponentInChildren<GameCreation>().soloIIDifficulty = curDiffToggle.GetComponentInChildren<ToggleInformation>().soloIIDifficulty;
				}
			}

			//Game modifiers
			foreach (Toggle modifier in modifiersContainer.GetComponentsInChildren<Toggle>())
			{
				if (modifier.isOn)
				{
					GameObject.Find("GameCreation").GetComponentInChildren<GameCreation>().modifiers.Add(modifier.GetComponentInChildren<ToggleInformation>().modifier);
				}
			}

			//Load the next scene to start the game
			asyncSceneLoad("GameScene");
		}

		/*
		 * MULTIPLAYER PAGE
		 */
		public void onJoinMultiplayerGame()
		{
			Debug.Log("Join multiplayer game button pressed");
			JoinRoom();
		}

		public void onCreateMultiplayerGame()
		{
			Debug.Log("Create multiplayer game button pressed");
			CreateRoom();
		}

		/*
		 * UNIVERSAL METHODS
		 */
		//When the back button is pressed
		public void onBack()
		{
			currentState = MainMenuStates.Main;
		}

		// Used to load a scene by name TODO: Put inside helper function file?
		private void asyncSceneLoad(string name)
		{
			SceneManager.LoadSceneAsync(name);
		}

		// Used to load in new faction and display it
		private void updateFactionDisplay()
		{
			//Set the current faction
			foreach (Faction f in Factions)
			{
				if (f.GetId() == CurrentFactionNumber)
				{
					CurrentFaction = f;
				}
			}

			//Load it
			Sprite img = (Sprite)Resources.Load<Sprite>(FACTION_IMAGE_URI + "FactionImage" + CurrentFactionNumber.ToString());

			//Apply it
			if (townLogoImage != null)
			{
				townLogoImage.sprite = img;
			}
			else
			{
				Debug.Log("Town logo image container not set");
			}

			//Load it
			img = (Sprite)Resources.Load<Sprite>(FACTION_SYMBOL_URI + "FactionSymbol" + CurrentFactionNumber.ToString());

			//Apply it
			if (townSymbolImage != null)
			{
				townSymbolImage.sprite = img;
			}
			else
			{
				Debug.Log("Town symbol image container not set");
			}

			//Set up town name and location
			if (townNameAndLocation != null)
			{
				townNameAndLocation.text = CurrentFaction.GetName() + "\n" + CurrentFaction.GetBaseLocationString();
			}
			else
			{
				Debug.Log("Town name and location container not set");
			}

			//Set up the perk texts TODO rework this to be more dynamic (could have more or less than 4 perks)
			if (specificPerk1Text != null)
			{
				specificPerk1Text.text = CurrentFaction.GetPerks()[0].GetPerkTitle() + ": " + CurrentFaction.GetPerks()[0].GetPerkDescription();
			}
			else
			{
				Debug.Log("Perk 1 text container not set");
			}
			if (specificPerk2Text != null)
			{
				specificPerk2Text.text = CurrentFaction.GetPerks()[1].GetPerkTitle() + ": " + CurrentFaction.GetPerks()[1].GetPerkDescription();
			}
			else
			{
				Debug.Log("Perk 2 text container not set");
			}
			if (specificPerk3Text != null)
			{
				specificPerk3Text.text = CurrentFaction.GetPerks()[2].GetPerkTitle() + ": " + CurrentFaction.GetPerks()[2].GetPerkDescription();
			}
			else
			{
				Debug.Log("Perk 3 text container not set");
			}
			if (specificPerk4Text != null)
			{
				specificPerk4Text.text = CurrentFaction.GetPerks()[3].GetPerkTitle() + ": " + CurrentFaction.GetPerks()[3].GetPerkDescription();
			}
			else
			{
				Debug.Log("Perk 4 text container not set");
			}

			//Set up town lore
			if (loreText != null)
			{
				loreText.text = CurrentFaction.GetLore();
			}
			else
			{
				Debug.Log("Lore text container not set");
			}
			//Move the lore back to the top when the faction switches
			if (loreScrollBar != null)
			{
				loreScrollBar.value = 1;
			}
			else
			{
				Debug.Log("Lore scroll bar not set");
			}

			//Set up town techs TODO rework so this is not hardcoded to two
			//Load tech 1
			img = (Sprite)Resources.Load<Sprite>(TOWN_TECH_IMAGE_URI + "TownTech" + CurrentFaction.GetStartingTownTechs()[0].GetId().ToString());
			//Apply it
			if (townTech1Image != null)
			{
				townTech1Image.sprite = img;
			}
			else
			{
				Debug.Log("Town tech image 1 container not set");
			}
			//Load tech 2
			img = (Sprite)Resources.Load<Sprite>(TOWN_TECH_IMAGE_URI + "TownTech" + CurrentFaction.GetStartingTownTechs()[1].GetId().ToString());
			//Apply it
			if (townTech2Image != null)
			{
				townTech2Image.sprite = img;
			}
			else
			{
				Debug.Log("Town tech image 2 container not set");
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
			for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
			{
				GameObject.Find("PlayerText_" + i).GetComponent<Text>().text = PhotonNetwork.PlayerList[i].NickName;
			}
		}

		private void instantiateGameObjects()
		{
			if (mainMenu == null)
			{
				mainMenu = new GameObject();
			}
			if (optionsMenu == null)
			{
				optionsMenu = new GameObject();
			}
			if (singlePlayerMenu == null)
			{
				singlePlayerMenu = new GameObject();
			}
			if (setUpNewGameMenu == null)
			{
				setUpNewGameMenu = new GameObject();
			}
			if (MultiplayerCreation == null)
			{
				MultiplayerCreation = new GameObject();
			}
			if (MultiplayerLobby == null)
			{
				MultiplayerLobby = new GameObject();
			}
		}
	}
}