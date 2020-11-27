using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine;
using FallenLand;

namespace Tests
{
	public class CameraManagerTests
	{
		private GameObject GameObj;
		private GameObject PauseMenuObj;
		private GameObject CharacterScreenObj;
        private Camera Cam;

		[SetUp]
		public void Setup()
		{
			PauseMenuObj = new GameObject();
			PauseMenuObj.name = "PauseMenu";
			CharacterScreenObj = new GameObject();
			CharacterScreenObj.name = "CharacterAndSpoilsAssigningPanel";

			GameObj = new GameObject();
			GameObj.AddComponent<GameCreation>();
            Cam = GameObj.AddComponent<Camera>();
            Cam.tag = "MainCamera";

			GameObj.AddComponent<CameraManager>();
        }

		[TearDown]
		public void Teardown()
		{
			UnityEngine.Object.Destroy(GameObj);
            Cam = null;

        }

		[UnityTest]
		public IEnumerator TestStartingCamPosition()
		{
            const int STARTING_Y = 10;
            const int STARTING_X = 12 * MapCreation.HEX_PREFAB_SCALE;
            const int STARTING_Z = 5 * MapCreation.HEX_PREFAB_SCALE;
            yield return null;

            Assert.AreEqual(STARTING_X, Cam.transform.position.x);
            Assert.AreEqual(STARTING_Z, Cam.transform.position.z);
            Assert.AreEqual(STARTING_Y, Cam.transform.position.y);
        }
    }
}