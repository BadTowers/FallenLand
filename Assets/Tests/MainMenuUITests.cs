using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using FallenLand;

namespace Tests
{
	public class MainMenuUITests
	{
		private GameObject GameObj;
		private MainMenuUIManager MainMenuUIManagerInstance;
		private List<GameObject> MenuList;

		[SetUp]
		public void Setup()
		{
			GameObj = new GameObject();
			GameObj.AddComponent<MainMenuUIManager>();
			MainMenuUIManagerInstance = GameObj.GetComponent<MainMenuUIManager>();
			MenuList = new List<GameObject>
			{
				MainMenuUIManagerInstance.mainMenu,
				MainMenuUIManagerInstance.optionsMenu,
				MainMenuUIManagerInstance.singlePlayerMenu,
				MainMenuUIManagerInstance.setUpNewGameMenu,
				MainMenuUIManagerInstance.MultiplayerCreation,
				MainMenuUIManagerInstance.MultiplayerLobby
			};
		}

		[TearDown]
		public void Teardown()
		{
			GameObj = null;
			MenuList = null;
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
			assertMenuIsActiveOthersAreNot(MainMenuUIManagerInstance.mainMenu);

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

			assertMenuIsActiveOthersAreNot(MainMenuUIManagerInstance.optionsMenu);
		}

		[UnityTest]
		public IEnumerator TestUponClickingSinglePlayerButton_OpenSinglePlayer()
		{
			MainMenuUIManagerInstance.OnSinglePlayerButtonPressed();

			yield return null;

			assertMenuIsActiveOthersAreNot(MainMenuUIManagerInstance.singlePlayerMenu);
		}

		[UnityTest]
		public IEnumerator TestUponClickingSetUpNewGame_OpensSetUpNewGame()
		{
			MainMenuUIManagerInstance.OnSetUpGame();

			yield return null;

			assertMenuIsActiveOthersAreNot(MainMenuUIManagerInstance.setUpNewGameMenu);
		}




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
	}
}