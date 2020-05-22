using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using FallenLand;
using Photon.Pun;
using UnityEngine.UI;

namespace Tests
{
	public class MainMenuUITests
	{
		private GameObject MainGameObj;
		private List<GameObject> TextGameObjs;
		private List<GameObject> FactionGameObjs;
		private GameObject FeedbackTextObj;
		private MainMenuUIManager MainMenuUIManagerInstance;
		private List<GameObject> MenuList;
		private List<GameObject> FactionSelectionObjectList;

		[SetUp]
		public void Setup()
		{
			const int MAX_NUM_PLAYERS = 5;

			MainGameObj = new GameObject();
			TextGameObjs = new List<GameObject>();
			FactionGameObjs = new List<GameObject>();
			FeedbackTextObj = new GameObject();
			FactionSelectionObjectList = new List<GameObject>();

			for (int i = 0; i < MAX_NUM_PLAYERS; i++)
			{
				TextGameObjs.Add(new GameObject());
				FactionGameObjs.Add(new GameObject());
				TextGameObjs[i].AddComponent<Text>();
				TextGameObjs[i].name = "PlayerText_" + i;
				FactionGameObjs[i].AddComponent<Text>();
				FactionGameObjs[i].name = "FactionText_" + i;
			}

			FeedbackTextObj.AddComponent<Text>();
			FeedbackTextObj.name = "FeedbackText";

			addFactionSelectionElements();

			MainGameObj.AddComponent<MainMenuUIManager>();
			MainMenuUIManagerInstance = MainGameObj.GetComponent<MainMenuUIManager>();
			MenuList = new List<GameObject>
			{
				MainMenuUIManagerInstance.MainMenu,
				MainMenuUIManagerInstance.OptionsMenu,
				MainMenuUIManagerInstance.SinglePlayerMenu,
				MainMenuUIManagerInstance.SetUpNewGameMenu,
				MainMenuUIManagerInstance.MultiplayerCreation,
				MainMenuUIManagerInstance.MultiplayerLobby
			};
		}

		[TearDown]
		public void Teardown()
		{
			PhotonNetwork.Disconnect();
			TextGameObjs = null;
			FactionGameObjs = null;
			MainGameObj = null;
			FeedbackTextObj = null;
			MenuList = null;
			FactionSelectionObjectList = null;
		}

		[UnityTest]
		public IEnumerator TestPublicGameObjects()
		{
			for (int i = 0; i < MenuList.Count; i++)
			{
				Assert.IsNotNull(MenuList[i]);
			}

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestUponStartupWeSeeTheMainMenuScreen()
		{
			assertMenuIsActiveOthersAreNot(MainMenuUIManagerInstance.MainMenu);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestUponClickingMultiplayerButton_OpenMultiplayerCreation()
		{
			MainMenuUIManagerInstance.OnMultiplayerButtonPressed();

			yield return null;

			assertMenuIsActiveOthersAreNot(MainMenuUIManagerInstance.MultiplayerCreation);
		}

		[UnityTest]
		public IEnumerator TestUponClickingOptionButton_OpenOptions()
		{
			MainMenuUIManagerInstance.OnOptionsButtonPressed();

			yield return null;

			assertMenuIsActiveOthersAreNot(MainMenuUIManagerInstance.OptionsMenu);
		}

		[UnityTest]
		public IEnumerator TestUponClickingSinglePlayerButton_OpenSinglePlayer()
		{
			MainMenuUIManagerInstance.OnSinglePlayerButtonPressed();

			yield return null;

			assertMenuIsActiveOthersAreNot(MainMenuUIManagerInstance.SinglePlayerMenu);
		}

		[UnityTest]
		public IEnumerator TestUponClickingSetUpNewGame_OpensSetUpNewGame()
		{
			MainMenuUIManagerInstance.OnSetUpGame();

			yield return null;

			assertMenuIsActiveOthersAreNot(MainMenuUIManagerInstance.SetUpNewGameMenu);
		}

		[UnityTest]
		public IEnumerator TestMultiplayerLobbyWithOnePlayer()
		{
			const string EXPECTED_USERNAME = "JSB";

			MainGameObj.AddComponent<RoomNameInputField>();
			RoomNameInputField roomNameInputField = MainGameObj.GetComponent<RoomNameInputField>();
			Assert.IsNotNull(roomNameInputField);
			roomNameInputField.name = "RoomNameInputField";
			roomNameInputField.SetRoomName("TestRoom");

			GameObject anotherGameObject = new GameObject();
			anotherGameObject.AddComponent<UserNameInputField>(); //Can't add to MainGameObj for some reason
			UserNameInputField userNameInputField = anotherGameObject.GetComponent<UserNameInputField>();
			Assert.IsNotNull(userNameInputField);
			userNameInputField.name = "UsernameInputField";
			userNameInputField.SetPlayerName(EXPECTED_USERNAME);

			PhotonNetwork.PhotonServerSettings.StartInOfflineMode = true;

			MainMenuUIManagerInstance.CreateRoom();

			yield return null;

			Assert.AreEqual(1, PhotonNetwork.PlayerList.Length);

			assertMenuIsActiveOthersAreNot(MainMenuUIManagerInstance.MultiplayerLobby);

			Text playerOneText = TextGameObjs[0].GetComponent<Text>();
			Assert.IsNotNull(playerOneText);
			Assert.AreEqual(EXPECTED_USERNAME, playerOneText.text);
		}

		//Valid tests, but can't get them to run all at once. Requires more investigation

		//[UnityTest]
		//public IEnumerator TestTryingToJoinWithoutARoomExisting()
		//{
		//	const string EXPECTED_USERNAME_1 = "JSB";
		//	MainMenuUIManagerInstance.OnMultiplayerButtonPressed();

		//	MainGameObj.AddComponent<RoomNameInputField>();
		//	RoomNameInputField roomNameInputField = MainGameObj.GetComponent<RoomNameInputField>();
		//	Assert.IsNotNull(roomNameInputField);
		//	roomNameInputField.name = "RoomNameInputField";
		//	roomNameInputField.SetRoomName("TestRoom");

		//	GameObject anotherGameObject = new GameObject();
		//	anotherGameObject.AddComponent<UserNameInputField>(); //Can't add to MainGameObj for some reason
		//	UserNameInputField userNameInputField = anotherGameObject.GetComponent<UserNameInputField>();
		//	Assert.IsNotNull(userNameInputField);
		//	userNameInputField.name = "UsernameInputField";
		//	userNameInputField.SetPlayerName(EXPECTED_USERNAME_1);
		//	PhotonNetwork.PhotonServerSettings.StartInOfflineMode = false;

		//	MainMenuUIManagerInstance.JoinRoom();

		//	while (!MainMenuUIManagerInstance.GetConnectedToRoom() && !MainMenuUIManagerInstance.GetFailedToConnectToRoom())
		//	{
		//		yield return null;
		//	}

		//	Assert.AreEqual(0, PhotonNetwork.PlayerList.Length);

		//	assertMenuIsActiveOthersAreNot(MainMenuUIManagerInstance.MultiplayerCreation);

		//	Text failText = FeedbackTextObj.GetComponent<Text>();
		//	Assert.AreEqual("Failed to join lobby", failText.text);
		//}

		//[UnityTest]
		//public IEnumerator TestTryingToJoinWithoutWithABlankRoom()
		//{
		//	const string EXPECTED_USERNAME_1 = "JSB";
		//	MainMenuUIManagerInstance.OnMultiplayerButtonPressed();

		//	MainGameObj.AddComponent<RoomNameInputField>();
		//	RoomNameInputField roomNameInputField = MainGameObj.GetComponent<RoomNameInputField>();
		//	Assert.IsNotNull(roomNameInputField);
		//	roomNameInputField.name = "RoomNameInputField";
		//	roomNameInputField.SetRoomName("");

		//	GameObject anotherGameObject = new GameObject();
		//	anotherGameObject.AddComponent<UserNameInputField>(); //Can't add to MainGameObj for some reason
		//	UserNameInputField userNameInputField = anotherGameObject.GetComponent<UserNameInputField>();
		//	Assert.IsNotNull(userNameInputField);
		//	userNameInputField.name = "UsernameInputField";
		//	userNameInputField.SetPlayerName(EXPECTED_USERNAME_1);
		//	PhotonNetwork.PhotonServerSettings.StartInOfflineMode = false;

		//	MainMenuUIManagerInstance.JoinRoom();

		//	while (!MainMenuUIManagerInstance.GetConnectedToRoom() && !MainMenuUIManagerInstance.GetFailedToConnectToRoom())
		//	{
		//		yield return null;
		//	}
		//	yield return null; //yield an extra frame for the text to render

		//	Assert.AreEqual(0, PhotonNetwork.PlayerList.Length);

		//	assertMenuIsActiveOthersAreNot(MainMenuUIManagerInstance.MultiplayerCreation);

		//	Text failText = FeedbackTextObj.GetComponent<Text>();
		//	Assert.AreEqual("Room name cannot be empty", failText.text);
		//}




		private void assertMenuIsActiveOthersAreNot(GameObject activeObject)
		{
			for (int i = 0; i < MenuList.Count; i++)
			{
				if (MenuList[i].Equals(activeObject))
				{
					Assert.IsTrue(MenuList[i].activeSelf);
				}
				else
				{
					Assert.IsFalse(MenuList[i].activeSelf);
				}
			}
		}

		private void addFactionSelectionElements()
		{
			FactionSelectionObjectList.Add(new GameObject());
			FactionSelectionObjectList[0].AddComponent<Image>();
			FactionSelectionObjectList[0].GetComponent<Image>().name = "FactionLogoImage";
			FactionSelectionObjectList.Add(new GameObject());
			FactionSelectionObjectList[1].AddComponent<Image>();
			FactionSelectionObjectList[1].GetComponent<Image>().name = "FactionSymbolImage";
			FactionSelectionObjectList.Add(new GameObject());
			FactionSelectionObjectList[2].AddComponent<Image>();
			FactionSelectionObjectList[2].GetComponent<Image>().name = "Tech1Image";
			FactionSelectionObjectList.Add(new GameObject());
			FactionSelectionObjectList[3].AddComponent<Image>();
			FactionSelectionObjectList[3].GetComponent<Image>().name = "Tech2Image";
			FactionSelectionObjectList.Add(new GameObject());
			FactionSelectionObjectList[4].AddComponent<Text>();
			FactionSelectionObjectList[4].GetComponent<Text>().name = "TownInfoText";
			FactionSelectionObjectList.Add(new GameObject());
			FactionSelectionObjectList[5].AddComponent<Text>();
			FactionSelectionObjectList[5].GetComponent<Text>().name = "SpecificPerk1Text";
			FactionSelectionObjectList.Add(new GameObject());
			FactionSelectionObjectList[6].AddComponent<Text>();
			FactionSelectionObjectList[6].GetComponent<Text>().name = "SpecificPerk2Text";
			FactionSelectionObjectList.Add(new GameObject());
			FactionSelectionObjectList[7].AddComponent<Text>();
			FactionSelectionObjectList[7].GetComponent<Text>().name = "SpecificPerk3Text";
			FactionSelectionObjectList.Add(new GameObject());
			FactionSelectionObjectList[8].AddComponent<Text>();
			FactionSelectionObjectList[8].GetComponent<Text>().name = "SpecificPerk4Text";
			FactionSelectionObjectList.Add(new GameObject());
			FactionSelectionObjectList[9].AddComponent<Text>();
			FactionSelectionObjectList[9].GetComponent<Text>().name = "LoreText";
			FactionSelectionObjectList.Add(new GameObject());
			FactionSelectionObjectList[10].AddComponent<Scrollbar>();
			FactionSelectionObjectList[10].GetComponent<Scrollbar>().name = "LoreScrollbar";
			FactionSelectionObjectList.Add(new GameObject());
			FactionSelectionObjectList[11].AddComponent<Text>();
			FactionSelectionObjectList[11].GetComponent<Text>().name = "ActualPingText";
		}
	}
}