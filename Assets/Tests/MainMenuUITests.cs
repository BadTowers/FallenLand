using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tests
{
	public class MainMenuUITests
	{
		private MainMenuUIManager MainMenuUIManagerInstance;

		[SetUp]
		public void Setup()
		{
			MainMenuUIManagerInstance = new MainMenuUIManager
			{
				mainMenu = new GameObject(),
				optionsMenu = new GameObject(),
				singlePlayerMenu = new GameObject(),
				setUpNewGameMenu = new GameObject(),
				MultiplayerCreation = new GameObject(),
				MultiplayerLobby = new GameObject()
			};
		}

		[TearDown]
		public void Teardown()
		{
			MainMenuUIManagerInstance = null;
		}

		[UnityTest]
		public IEnumerator TestPublicGameObjects()
		{
			Assert.IsNotNull(MainMenuUIManagerInstance.mainMenu);
			Assert.IsNotNull(MainMenuUIManagerInstance.optionsMenu);
			Assert.IsNotNull(MainMenuUIManagerInstance.singlePlayerMenu);
			Assert.IsNotNull(MainMenuUIManagerInstance.setUpNewGameMenu);
			Assert.IsNotNull(MainMenuUIManagerInstance.MultiplayerCreation);
			Assert.IsNotNull(MainMenuUIManagerInstance.MultiplayerLobby);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestUponStartupWeSeeTheMainMenuScreen()
		{
			MainMenuUIManagerInstance.CallAwake();
			MainMenuUIManagerInstance.CallUpdate();

			Assert.IsTrue(MainMenuUIManagerInstance.mainMenu.activeSelf);
			Assert.IsFalse(MainMenuUIManagerInstance.optionsMenu.activeSelf);
			Assert.IsFalse(MainMenuUIManagerInstance.singlePlayerMenu.activeSelf);
			Assert.IsFalse(MainMenuUIManagerInstance.setUpNewGameMenu.activeSelf);
			Assert.IsFalse(MainMenuUIManagerInstance.MultiplayerCreation.activeSelf);
			Assert.IsFalse(MainMenuUIManagerInstance.MultiplayerLobby.activeSelf);

			yield return null;
		}
	}
}