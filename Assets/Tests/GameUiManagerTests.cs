using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;
using UnityEngine;
using UnityEngine.UI;

namespace Tests
{
	public class GameUiManagerTests
	{
		private GameUIManager GameUIManagerInstance;

		[SetUp]
		public void Setup()
		{
			GameUIManagerInstance = new GameUIManager();
		}

		[TearDown]
		public void Teardown()
		{
			GameUIManagerInstance = null;
		}

		[UnityTest]
		public IEnumerator TestCardIsDraggingInterface()
		{
			Assert.IsFalse(GameUIManagerInstance.GetCardIsDragging());
			GameUIManagerInstance.SetCardIsDragging(true);
			Assert.IsTrue(GameUIManagerInstance.GetCardIsDragging());
			GameUIManagerInstance.SetCardIsDragging(false);
			Assert.IsFalse(GameUIManagerInstance.GetCardIsDragging());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestTryingToMoveASpoilsCardIntoTheTownRosterPanel()
		{
			SpoilsCard spoilsCard = new SpoilsCard("spoils 1");
			GameObject imageObj = new GameObject();
			GameObject panel = new GameObject();
			panel.name = "TownRosterScrollView";
			imageObj.AddComponent<Image>();
			imageObj.AddComponent<MonoCard>();
			imageObj.GetComponentInChildren<MonoCard>().CardPtr = spoilsCard;
			Image image = imageObj.GetComponentInChildren<Image>();

			Assert.IsFalse(GameUIManagerInstance.CardIsAllowedToMoveHere(image, panel));

			yield return null;
		}
	}
}