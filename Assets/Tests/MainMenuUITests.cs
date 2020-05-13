using System.Collections;
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

		[SetUp]
		public void Setup()
		{
			GameObj = new GameObject();
			GameObj.AddComponent<MainMenuUIManager>();
			MainMenuUIManagerInstance = GameObj.GetComponent<MainMenuUIManager>();
		}

		[TearDown]
		public void Teardown()
		{
			GameObj = null;
		}

		[UnityTest]
		public IEnumerator TestPublicGameObjects()
		{
			yield return null;

			Assert.IsNotNull(MainMenuUIManagerInstance.mainMenu);
			Assert.IsNotNull(MainMenuUIManagerInstance.optionsMenu);
			Assert.IsNotNull(MainMenuUIManagerInstance.singlePlayerMenu);
			Assert.IsNotNull(MainMenuUIManagerInstance.setUpNewGameMenu);
			Assert.IsNotNull(MainMenuUIManagerInstance.MultiplayerCreation);
			Assert.IsNotNull(MainMenuUIManagerInstance.MultiplayerLobby);			
		}

		[UnityTest]
		public IEnumerator TestUponStartupWeSeeTheMainMenuScreen()
		{
			yield return null;

			Assert.IsTrue(MainMenuUIManagerInstance.mainMenu.activeSelf);
			Assert.IsFalse(MainMenuUIManagerInstance.optionsMenu.activeSelf);
			Assert.IsFalse(MainMenuUIManagerInstance.singlePlayerMenu.activeSelf);
			Assert.IsFalse(MainMenuUIManagerInstance.setUpNewGameMenu.activeSelf);
			Assert.IsFalse(MainMenuUIManagerInstance.MultiplayerCreation.activeSelf);
			Assert.IsFalse(MainMenuUIManagerInstance.MultiplayerLobby.activeSelf);
		}
	}
}