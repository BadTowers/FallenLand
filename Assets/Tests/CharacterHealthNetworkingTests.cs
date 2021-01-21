using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine;
using FallenLand;
using UnityEngine.UI;

namespace Tests
{
	public class CharacterHealthNetworkingTests
	{
		private CharacterHealthNetworking CharHealthNetworking;

		[SetUp]
		public void Setup()
		{
		}

		[TearDown]
		public void Teardown()
		{
		}

		private void mySetup(int playerIndex, int characterIndex, byte healthEventType, int amount, bool shouldDiscardEquipmentIfDead)
		{
			CharHealthNetworking = new CharacterHealthNetworking(playerIndex, characterIndex, healthEventType, amount, shouldDiscardEquipmentIfDead);
		}

		[UnityTest]
		public IEnumerator TestCharacterHealthNetworkingInterface()
		{
			int playerIndex = 0;
			int characterIndex = 1;
			int amount = 5;
			bool shouldDiscard = false;

			mySetup(playerIndex, characterIndex, Constants.DAMAGE_PHYSICAL, amount, shouldDiscard);

			Assert.AreEqual(playerIndex, CharHealthNetworking.GetPlayerIndex());
			Assert.AreEqual(characterIndex, CharHealthNetworking.GetCharacterIndex());
			Assert.AreEqual(amount, CharHealthNetworking.GetAmount());
			Assert.AreEqual(Constants.DAMAGE_PHYSICAL, CharHealthNetworking.GetHealthEventType());
			Assert.AreEqual(shouldDiscard, CharHealthNetworking.GetShouldDiscardEquipmentIfDead());

			byte[] byteData = CharacterHealthNetworking.SerializeCharacterHealth(CharHealthNetworking);
			Assert.AreEqual((byte)playerIndex, byteData[0]);
			Assert.AreEqual((byte)characterIndex, byteData[1]);
			Assert.AreEqual(Constants.DAMAGE_PHYSICAL, byteData[2]);
			Assert.AreEqual((byte)amount, byteData[3]);
			Assert.AreEqual((byte)0, byteData[4]);

			shouldDiscard = true;
			mySetup(playerIndex, characterIndex, Constants.DAMAGE_PHYSICAL, amount, shouldDiscard);
			byteData = CharacterHealthNetworking.SerializeCharacterHealth(CharHealthNetworking);
			Assert.AreEqual((byte)1, byteData[4]);

			CharHealthNetworking = (CharacterHealthNetworking)CharacterHealthNetworking.DeserializeCharacterHealth(byteData);
			Assert.AreEqual(playerIndex, CharHealthNetworking.GetPlayerIndex());
			Assert.AreEqual(characterIndex, CharHealthNetworking.GetCharacterIndex());
			Assert.AreEqual(amount, CharHealthNetworking.GetAmount());
			Assert.AreEqual(Constants.DAMAGE_PHYSICAL, CharHealthNetworking.GetHealthEventType());
			Assert.AreEqual(shouldDiscard, CharHealthNetworking.GetShouldDiscardEquipmentIfDead());

			yield return null;
		}
	}
}