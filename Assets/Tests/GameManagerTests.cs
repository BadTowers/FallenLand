using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

namespace Tests
{
	public class GameManagerTests
	{
		private GameObject GameManagerObject;
		private GameObject GameCreationObject;
		private GameObject PhotonNetworkHelperObject;
		private GameObject MapCreationObject;
		private PhotonNetworkHelper NetworkHelper;

		[SetUp]
		public void Setup()
		{
			GameCreationObject = new GameObject();
			GameCreationObject.AddComponent<GameCreation>();
			GameCreationObject.GetComponent<GameCreation>().name = "GameCreation";

			PhotonNetworkHelperObject = new GameObject();
			PhotonNetworkHelperObject.AddComponent<PhotonNetworkHelper>();
			NetworkHelper = PhotonNetworkHelperObject.GetComponent<PhotonNetworkHelper>();

			GameManagerObject = new GameObject();

			MapCreationObject = new GameObject();
			MapCreationObject.AddComponent<MapCreation>();
			MapCreationObject.name = "Map";
		}

		[TearDown]
		public void Teardown()
		{
			Object.Destroy(GameManagerObject);
			Object.Destroy(PhotonNetworkHelperObject);
			Object.Destroy(GameCreationObject);
			Object.Destroy(GameManagerObject);
		}

		[UnityTest]
		[Parallelizable(ParallelScope.None)]
		public IEnumerator TestPublicInterfaceInVarietyOfWays()
		{
			//////Setup requires us to connect to the network and join a room
			NetworkHelper.ConnectToMaster();
			while (!NetworkHelper.GetConnectedToMaster())
			{
				yield return null;
			}
			Debug.Log("Test1 CONNECTED to master");
			NetworkHelper.CreateTestRoom();
			while (!NetworkHelper.GetConnectedToRoom())
			{
				yield return null;
			}
			Debug.Log("Test1 JOINED room");


			//////Actual test stuff
			GameManagerObject.AddComponent<GameManager>();
			GameManager gameManager = GameManagerObject.GetComponent<GameManager>();
			int numPlayers = PhotonNetwork.PlayerList.Length;

			//player index too high will tell us we aren't allowed to attach anything
			SpoilsCard spoil = new SpoilsCard("spoils");
			spoil.AddSpoilsType(SpoilsTypes.Stowable);
			Assert.IsFalse(gameManager.IsAllowedToApplySpoilsToCharacterSlot(numPlayers+1, spoil, 0));
			Assert.IsFalse(gameManager.IsAllowedToApplySpoilsToVehicleSlot(numPlayers+1, spoil));
			Assert.IsFalse(gameManager.IsAllowedToApplyCharacterToCharacterSlot(numPlayers+1, 0));
			Assert.AreEqual(0, gameManager.GetNumberOfActiveVehicles(numPlayers+1));

			//player index too low will tell us we aren't allowed to attach anything
			Assert.IsFalse(gameManager.IsAllowedToApplySpoilsToCharacterSlot(-1, spoil, 0));
			Assert.IsFalse(gameManager.IsAllowedToApplySpoilsToVehicleSlot(-1, spoil));
			Assert.IsFalse(gameManager.IsAllowedToApplyCharacterToCharacterSlot(-1, 0));
			Assert.AreEqual(0, gameManager.GetNumberOfActiveVehicles(-1));

			//Since we are the only player connected, our index should be 0
			Assert.AreEqual(0, gameManager.GetIndexForMyPlayer());

			//Can't add vehicle if player index is invalid
			SpoilsCard vehicle = new SpoilsCard("vehicle");
			vehicle.AddSpoilsType(SpoilsTypes.Vehicle);
			gameManager.AddVehicleToActiveParty(numPlayers + 1, vehicle);
			Assert.IsNull(gameManager.GetActiveVehicle(numPlayers + 1));
			gameManager.RemoveActiveVehicle(numPlayers + 1);
			Assert.IsNull(gameManager.GetActiveVehicle(numPlayers + 1));

			//Can try to add or remove spoils from vehicle, but vehicle still won't exist
			gameManager.AddSpoilsToActiveVehicle(numPlayers + 1, null);
			Assert.IsNull(gameManager.GetActiveVehicle(numPlayers + 1));
			gameManager.RemoveSpoilsCardFromActiveVehicle(numPlayers + 1, null);
			Assert.IsNull(gameManager.GetActiveVehicle(numPlayers + 1));

			//Salvage should be 0 for invalid player index
			Assert.AreEqual(0, gameManager.GetSalvage(-1));

			//Get back a dummy faction for invalid player index
			Assert.IsNotNull(gameManager.GetFaction(-1));
			Assert.AreEqual("dummy faction", gameManager.GetFaction(-1).GetName());
			Assert.AreEqual(new Coordinates(Constants.INVALID_LOCATION, Constants.INVALID_LOCATION), gameManager.GetFaction(-1).GetBaseLocation());

			//Get back an empty auction house for an invalid player index
			Assert.IsNotNull(gameManager.GetAuctionHouse(-1));
			Assert.AreEqual(0, gameManager.GetAuctionHouse(-1).Count);

			//Get back an empty hand of action cards for an invalid player index
			Assert.IsNotNull(gameManager.GetActionCards(-1));
			Assert.AreEqual(0, gameManager.GetActionCards(-1).Count);

			//Get back an empty active characters list for an invalid player index
			Assert.IsNotNull(gameManager.GetActiveCharacterCards(-1));
			Assert.AreEqual(0, gameManager.GetActiveCharacterCards(-1).Count);

			//Get back an empty town roster for an invalid player index
			Assert.IsNotNull(gameManager.GetTownRoster(-1));
			Assert.AreEqual(0, gameManager.GetTownRoster(-1).Count);


			//////Teardown requires us to leave the room and disconnect from master
			NetworkHelper.LeaveRoom();
			while (NetworkHelper.GetConnectedToRoom())
			{
				yield return null;
			}
			Debug.Log("Test1 LEFT room");
			NetworkHelper.DisconnectFromMaster();
			while (NetworkHelper.GetConnectedToMaster())
			{
				Debug.Log("Test1 DISCONNECTING to master");
				yield return null;
			}
			Debug.Log("Test1 DISCONNECTED from master");
		}
    }
}