using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
	public class GameManagerTests
	{
		private GameObject GameManagerObject;
		private GameObject GameCreationObject;
		private GameObject PhotonNetworkHelperObject;
		private GameObject MapCreationObject;
		private PhotonNetworkHelper NetworkHelper;
		private const int MY_PLAYER_INDEX = 0;

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

		//All of these are in one test because the setup and teardown to the photon network is expensive
		[UnityTest]
		[Parallelizable(ParallelScope.None)]
		public IEnumerator TestPublicInterfaceInVarietyOfWays()
		{
			Dictionary<Skills, int> vehicleExpected = new Dictionary<Skills, int>
			{
				{ Skills.Mechanical, 3 },
				{ Skills.Diplomacy, 0 },
				{ Skills.Technical, 2 },
				{ Skills.Combat, 0 },
				{ Skills.Survival, 1 },
				{ Skills.Medical, 8 }
			};

			Dictionary<Skills, int> stowableExpected = new Dictionary<Skills, int>
			{
				{ Skills.Mechanical, 2 },
				{ Skills.Diplomacy, 2 },
				{ Skills.Technical, 1 },
				{ Skills.Combat, 5 },
				{ Skills.Survival, 4 },
				{ Skills.Medical, 0 }
			};

			Dictionary<Skills, int> totalExpected = new Dictionary<Skills, int>
			{
				{ Skills.Mechanical, vehicleExpected[Skills.Mechanical] + stowableExpected[Skills.Mechanical] },
				{ Skills.Diplomacy, vehicleExpected[Skills.Diplomacy] + stowableExpected[Skills.Diplomacy]  },
				{ Skills.Technical, vehicleExpected[Skills.Technical] + stowableExpected[Skills.Technical]  },
				{ Skills.Combat, vehicleExpected[Skills.Combat] + stowableExpected[Skills.Combat]  },
				{ Skills.Survival, vehicleExpected[Skills.Survival] + stowableExpected[Skills.Survival]  },
				{ Skills.Medical, vehicleExpected[Skills.Medical] + stowableExpected[Skills.Medical]  }
			};
			const int expectedCarryWeight = 3;

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
			SpoilsCard stowableSpoil = new SpoilsCard("spoils");
			stowableSpoil.AddSpoilsType(SpoilsTypes.Stowable);
			stowableSpoil.SetBaseSkills(stowableExpected);
			stowableSpoil.SetCarryWeight(expectedCarryWeight);
			Assert.IsFalse(gameManager.IsAllowedToApplySpoilsToCharacterSlot(numPlayers+1, stowableSpoil, 0));
			Assert.IsFalse(gameManager.IsAllowedToApplySpoilsToVehicleSlot(numPlayers+1, stowableSpoil));
			Assert.IsFalse(gameManager.IsAllowedToApplyCharacterToCharacterSlot(numPlayers+1, 0));
			Assert.AreEqual(0, gameManager.GetNumberOfActiveVehicles(numPlayers+1));

			//player index too low will tell us we aren't allowed to attach anything
			Assert.IsFalse(gameManager.IsAllowedToApplySpoilsToCharacterSlot(-1, stowableSpoil, 0));
			Assert.IsFalse(gameManager.IsAllowedToApplySpoilsToVehicleSlot(-1, stowableSpoil));
			Assert.IsFalse(gameManager.IsAllowedToApplyCharacterToCharacterSlot(-1, 0));
			Assert.AreEqual(0, gameManager.GetNumberOfActiveVehicles(-1));

			Assert.AreEqual(MY_PLAYER_INDEX, gameManager.GetIndexForMyPlayer());

			//Can't add vehicle if player index is invalid
			SpoilsCard vehicle = new SpoilsCard("vehicle");
			vehicle.AddSpoilsType(SpoilsTypes.Vehicle);
			vehicle.SetBaseSkills(vehicleExpected);
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

			//Make sure we can extract out our faction
			Dictionary<string, string> myFaction = new Dictionary<string, string>
			{
				{ PhotonNetwork.PlayerList[0].UserId, new DefaultFactionInfo().GetDefaultFactionList()[1].GetName()}
			};
			GameCreationObject.GetComponent<GameCreation>().SetFactions(myFaction);
			yield return null; //progress a frame so the update function runs
			Assert.AreEqual(new DefaultFactionInfo().GetDefaultFactionList()[1].GetName(), gameManager.GetFaction(MY_PLAYER_INDEX).GetName());

			//A valid ID should have some action cards in their hand
			Assert.IsTrue(gameManager.GetActionCards(MY_PLAYER_INDEX).Count > 0);

			//A valid ID should have some characters and spoils in their town roster and auction house
			Assert.IsTrue(gameManager.GetAuctionHouse(MY_PLAYER_INDEX).Count > 0);
			Assert.IsTrue(gameManager.GetTownRoster(MY_PLAYER_INDEX).Count > 0);

			//A valid ID should be able to equip a vehicle
			Assert.IsTrue(gameManager.IsAllowedToApplySpoilsToVehicleSlot(MY_PLAYER_INDEX, vehicle));
			gameManager.AddVehicleToActiveParty(MY_PLAYER_INDEX, vehicle);
			Assert.IsNotNull(gameManager.GetActiveVehicle(MY_PLAYER_INDEX));
			Assert.AreEqual(vehicle, gameManager.GetActiveVehicle(MY_PLAYER_INDEX));
			Assert.AreEqual(1, gameManager.GetNumberOfActiveVehicles(MY_PLAYER_INDEX));

			//A valid ID should be able to equip stowables to their vehicle
			Assert.IsTrue(gameManager.IsAllowedToApplySpoilsToVehicleSlot(MY_PLAYER_INDEX, stowableSpoil));
			gameManager.AddSpoilsToActiveVehicle(MY_PLAYER_INDEX, stowableSpoil);
			Assert.IsNotNull(gameManager.GetActiveVehicle(MY_PLAYER_INDEX).GetEquippedSpoils());
			Assert.AreEqual(1, gameManager.GetActiveVehicle(MY_PLAYER_INDEX).GetEquippedSpoils().Count);
			Assert.AreEqual(stowableSpoil, gameManager.GetActiveVehicle(MY_PLAYER_INDEX).GetEquippedSpoils()[0]);

			//A valid ID should be able to get the stats and carry weight of an equipped vehicle
			Assert.IsNotNull(gameManager.GetActiveVehicleStats(MY_PLAYER_INDEX));
			CollectionAssert.AreEquivalent(totalExpected, gameManager.GetActiveVehicleStats(MY_PLAYER_INDEX));
			Assert.AreEqual(expectedCarryWeight, gameManager.GetActiveVehicleCarryWeight(MY_PLAYER_INDEX));

			//A valid ID can remove stowables from their active vehicle
			gameManager.RemoveSpoilsCardFromActiveVehicle(MY_PLAYER_INDEX, null);
			Assert.AreEqual(1, gameManager.GetActiveVehicle(MY_PLAYER_INDEX).GetEquippedSpoils().Count);
			gameManager.RemoveSpoilsCardFromActiveVehicle(MY_PLAYER_INDEX, stowableSpoil);
			Assert.AreEqual(0, gameManager.GetActiveVehicle(MY_PLAYER_INDEX).GetEquippedSpoils().Count);

			//A valid ID can remove their active vehicle
			gameManager.RemoveActiveVehicle(MY_PLAYER_INDEX);
			Assert.AreEqual(0, gameManager.GetNumberOfActiveVehicles(MY_PLAYER_INDEX));
			Assert.IsNull(gameManager.GetActiveVehicle(MY_PLAYER_INDEX));

			//A valid ID should be able to equip characters to their party and add spoils to that member
			CharacterCard character = new CharacterCard("character");
			const int SLOT_0 = 0;
			const int SLOT_1 = 1;
			Assert.IsNotNull(gameManager.GetActiveCharacterCards(MY_PLAYER_INDEX));
			Assert.AreEqual(5, gameManager.GetActiveCharacterCards(MY_PLAYER_INDEX).Count);
			Assert.IsTrue(gameManager.IsAllowedToApplyCharacterToCharacterSlot(MY_PLAYER_INDEX, SLOT_0));
			Assert.IsNull(gameManager.GetActiveCharacterCards(MY_PLAYER_INDEX)[SLOT_0]);
			gameManager.AssignCharacterToParty(MY_PLAYER_INDEX, SLOT_0, character);
			Assert.IsNotNull(gameManager.GetActiveCharacterCards(MY_PLAYER_INDEX)[SLOT_0]);
			Assert.AreEqual(character, gameManager.GetActiveCharacterCards(MY_PLAYER_INDEX)[SLOT_0]);
			Assert.IsTrue(gameManager.IsAllowedToApplySpoilsToCharacterSlot(MY_PLAYER_INDEX, stowableSpoil, SLOT_0));
			Assert.IsFalse(gameManager.IsAllowedToApplySpoilsToCharacterSlot(MY_PLAYER_INDEX, stowableSpoil, SLOT_1));
			gameManager.AssignSpoilsCardToCharacter(MY_PLAYER_INDEX, SLOT_0, stowableSpoil);
			Assert.AreEqual(1, gameManager.GetActiveCharacterCards(MY_PLAYER_INDEX)[SLOT_0].GetEquippedSpoils().Count);
			Assert.AreEqual(stowableSpoil, gameManager.GetActiveCharacterCards(MY_PLAYER_INDEX)[SLOT_0].GetEquippedSpoils()[0]);

			//A valid ID should be able to get the stats and carry weight for an active character
			Assert.IsNotNull(gameManager.GetActiveCharacterStats(MY_PLAYER_INDEX, SLOT_0));
			CollectionAssert.AreNotEquivalent(Constants.ALL_SKILLS_ZERO, gameManager.GetActiveCharacterStats(MY_PLAYER_INDEX, SLOT_0));
			Assert.AreEqual(expectedCarryWeight, gameManager.GetActiveCharacterCarryWeight(MY_PLAYER_INDEX, SLOT_0));

			//A valid ID should be able to remove characters from their part and spoils from that member
			gameManager.RemoveSpoilsCardFromPlayerActiveParty(MY_PLAYER_INDEX, SLOT_0, null);
			Assert.AreEqual(1, gameManager.GetActiveCharacterCards(MY_PLAYER_INDEX)[SLOT_0].GetEquippedSpoils().Count);
			gameManager.RemoveSpoilsCardFromPlayerActiveParty(MY_PLAYER_INDEX, SLOT_0, stowableSpoil);
			Assert.AreEqual(0, gameManager.GetActiveCharacterCards(MY_PLAYER_INDEX)[SLOT_0].GetEquippedSpoils().Count);
			gameManager.RemoveCharacterFromActiveParty(MY_PLAYER_INDEX, SLOT_0);
			Assert.IsNull(gameManager.GetActiveCharacterCards(MY_PLAYER_INDEX)[SLOT_0]);

			//A valid ID can add spoils to their auction house
			int auctionHouseSizeBefore = gameManager.GetAuctionHouse(MY_PLAYER_INDEX).Count;
			gameManager.AddSpoilsToAuctionHouse(MY_PLAYER_INDEX, stowableSpoil);
			Assert.AreEqual(auctionHouseSizeBefore + 1, gameManager.GetAuctionHouse(MY_PLAYER_INDEX).Count);

			//A valid ID can remove spoils from their auction house
			gameManager.RemoveSpoilFromAuctionHouse(MY_PLAYER_INDEX, stowableSpoil);
			Assert.AreEqual(auctionHouseSizeBefore, gameManager.GetAuctionHouse(MY_PLAYER_INDEX).Count);

			//Null spoils aren't added to auction house
			gameManager.AddSpoilsToAuctionHouse(MY_PLAYER_INDEX, null);
			Assert.AreEqual(auctionHouseSizeBefore, gameManager.GetAuctionHouse(MY_PLAYER_INDEX).Count);

			//A valid ID can add characters to their town roster
			int townRosterSizeBefore = gameManager.GetTownRoster(MY_PLAYER_INDEX).Count;
			gameManager.AddCharacterToTownRoster(MY_PLAYER_INDEX, character);
			Assert.AreEqual(townRosterSizeBefore + 1, gameManager.GetTownRoster(MY_PLAYER_INDEX).Count);

			//A valid ID can remove characters from their town roster
			gameManager.RemoveCharacterFromTownRoster(MY_PLAYER_INDEX, character);
			Assert.AreEqual(townRosterSizeBefore, gameManager.GetTownRoster(MY_PLAYER_INDEX).Count);

			//Null characters aren't added to town roster
			gameManager.AddCharacterToTownRoster(MY_PLAYER_INDEX, null);
			Assert.AreEqual(townRosterSizeBefore, gameManager.GetTownRoster(MY_PLAYER_INDEX).Count);

			//A valid ID should have a non-zero amount of starting salvage
			Assert.IsTrue(gameManager.GetSalvage(MY_PLAYER_INDEX) > 0);

			//A valid ID should have a non-zero amount of starting town techs
			Assert.IsTrue(gameManager.GetTownTechs(MY_PLAYER_INDEX).Count > 0);

			//A valid ID should have a non-empty user ID
			Assert.AreNotEqual("", gameManager.GetMyUserId());

			//Wait for networking stuff to occur
			yield return new WaitForSeconds(0.5f);

			//As the only player, I should be the current player
			Assert.IsNotNull(gameManager.GetCurrentPlayer());
			Assert.AreEqual(gameManager.GetMyUserId(), gameManager.GetCurrentPlayer().UserId);

			//Turn should be 1 to start the game
			Assert.AreEqual(1, gameManager.GetTurn());

			//Phase should begin as the game start
			Assert.AreEqual(Phases.Game_Start_Setup, gameManager.GetPhase());

			//When the lone user ends the phase, we should go to the next one
			gameManager.EndPhase(MY_PLAYER_INDEX);
			yield return new WaitForSeconds(0.5f);
			Assert.AreEqual(1, gameManager.GetTurn());
			Assert.AreEqual(Phases.Before_Effects_Phase, gameManager.GetPhase());




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