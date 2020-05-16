﻿using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine;
using FallenLand;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Tests
{
	public class CameraManagerTests
	{
		private GameObject GameObj;
        private Camera Cam;

		[SetUp]
		public void Setup()
		{
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
            const int STARTING_X = 12 * MapCreation.scale;
            const int STARTING_Z = 5 * MapCreation.scale;
            yield return null;

            Assert.AreEqual(STARTING_X, Cam.transform.position.x);
            Assert.AreEqual(STARTING_Z, Cam.transform.position.z);
            Assert.AreEqual(STARTING_Y, Cam.transform.position.y);
        }
    }
}