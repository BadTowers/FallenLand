using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;

namespace Tests
{
	public class GameWorldCoordinatesCoordinatesTests
	{
		private GameWorldCoordinates GameWorldCoords;

		[SetUp]
		public void Setup()
		{
			GameWorldCoords = new GameWorldCoordinates(25.432f, 10.32f);
		}

		[TearDown]
		public void Teardown()
		{
			GameWorldCoords = null;
		}

		[UnityTest]
		public IEnumerator TestGameWorldsConstructorAndGetters()
		{
			Assert.AreEqual(25.432f, GameWorldCoords.GetX());
			Assert.AreEqual(10.32f, GameWorldCoords.GetY());

			yield return null;
		}
	}
}