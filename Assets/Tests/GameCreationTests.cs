using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using FallenLand;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;

namespace Tests
{
	public class GameCreationTests
	{
		private GameObject GameObj;
		private GameCreation GameCreationInst;

		[SetUp]
		public void Setup()
		{
			GameObj = new GameObject();
			GameObj.AddComponent<GameCreation>();
			GameCreationInst = GameObj.GetComponent<GameCreation>();
			Assert.IsNotNull(GameCreationInst);
		}

		[TearDown]
		public void Teardown()
		{
			Object.Destroy(GameObj);
		}

		[UnityTest]
		public IEnumerator TestListOfModifiers()
		{
			Assert.IsNotNull(GameCreationInst.GetListOfModifiers());
			Assert.AreEqual(0, GameCreationInst.GetListOfModifiers().Count);

			GameCreationInst.AddModifier(GameInformation.GameModifier.HarshRealityMod1);
			Assert.AreEqual(1, GameCreationInst.GetListOfModifiers().Count);
			Assert.AreEqual(GameInformation.GameModifier.HarshRealityMod1, GameCreationInst.GetListOfModifiers()[0]);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestFaction()
		{
			Assert.IsNull(GameCreationInst.GetFaction());

			GameCreationInst.SetFaction(new Faction("faction", new Coordinates(0, 0)));
			Assert.IsNotNull(GameCreationInst.GetFaction());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestMode()
		{
			Assert.AreEqual(GameInformation.GameModes.Null, GameCreationInst.GetMode());

			GameCreationInst.SetMode(GameInformation.GameModes.NormalGame);
			Assert.AreEqual(GameInformation.GameModes.NormalGame, GameCreationInst.GetMode());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSoloIIDifficulty()
		{
			Assert.AreEqual(GameInformation.SoloII.Null, GameCreationInst.GetSoloIIDifficulty());

			GameCreationInst.SetSoloIIDifficulty(GameInformation.SoloII.SoloIIUltimate);
			Assert.AreEqual(GameInformation.SoloII.SoloIIUltimate, GameCreationInst.GetSoloIIDifficulty());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestMultiplayerFactionsInformation()
		{
            Assert.IsNotNull(GameCreationInst.GetFactions());

            Dictionary<int, string> userIdToFactionDict = new Dictionary<int, string>
            {
                { 0, "Coalition of the Black Angels" }
            };
            GameCreationInst.SetFactions(userIdToFactionDict);

            Assert.AreEqual(1, GameCreationInst.GetFactions().Count);
            Assert.AreEqual(0, GameCreationInst.GetFactions().Keys.ElementAt(0));
            Assert.AreEqual("Coalition of the Black Angels", GameCreationInst.GetFactions().Values.ElementAt(0));

            GameCreationInst.AddFaction(1, "Enclave of Terra");

            Assert.AreEqual(2, GameCreationInst.GetFactions().Count);
            Assert.AreEqual(1, GameCreationInst.GetFactions().Keys.ElementAt(1));
            Assert.AreEqual("Enclave of Terra", GameCreationInst.GetFactions().Values.ElementAt(1));

            yield return null;
		}
	}
}