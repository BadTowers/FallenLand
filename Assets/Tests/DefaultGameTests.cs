using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;
using System.Linq;

namespace Tests
{
	public class DefaultGameTests
	{
		private DefaultGame DefaultGameInst;

		[SetUp]
		public void Setup()
		{
			DefaultGameInst = new DefaultGame();
		}

		[TearDown]
		public void Teardown()
		{
			DefaultGameInst = null;
		}

		[UnityTest]
		public IEnumerator TestDefaultStartingValues()
		{
			Assert.AreEqual(30, DefaultGameInst.startingNumbers[GameInformation.GameValues.Starting_Town_Health]);
			Assert.AreEqual(1, DefaultGameInst.startingNumbers[GameInformation.GameValues.Starting_Prestige]);
			Assert.AreEqual(10, DefaultGameInst.startingNumbers[GameInformation.GameValues.Starting_Salvage]);
			Assert.AreEqual(3, DefaultGameInst.startingNumbers[GameInformation.GameValues.Starting_Action_Cards]);
			Assert.AreEqual(6, DefaultGameInst.startingNumbers[GameInformation.GameValues.Starting_Character_Cards]);
			Assert.AreEqual(10, DefaultGameInst.startingNumbers[GameInformation.GameValues.Starting_Spoils_Cards]);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestDefaultWinConditions()
		{
			Assert.AreEqual(GameInformation.WinConditions.Prestige, DefaultGameInst.winConditions[0].ElementAt(0).Key);
			Assert.AreEqual(20, DefaultGameInst.winConditions[0].ElementAt(0).Value);

			Assert.AreEqual(GameInformation.WinConditions.Town_Health, DefaultGameInst.winConditions[1].ElementAt(0).Key);
			Assert.AreEqual(80, DefaultGameInst.winConditions[1].ElementAt(0).Value);

			yield return null;
		}
	}
}