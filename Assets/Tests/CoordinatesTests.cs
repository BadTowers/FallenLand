﻿using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;

namespace Tests
{
	public class CoordinatesTests
	{
		private Coordinates CoordinatesInstance;
		private Coordinates CoordInvalidY;
		private Coordinates CoordInvalidX;
		private Coordinates CoordInvalidXAndY;

		[SetUp]
		public void Setup()
		{
			CoordinatesInstance = new Coordinates(25, 10);
			CoordInvalidY = new Coordinates(19, -5);
			CoordInvalidX = new Coordinates(-100, 20);
			CoordInvalidXAndY = new Coordinates(-3, -4);
		}

		[TearDown]
		public void Teardown()
		{
			CoordinatesInstance = null;
			CoordInvalidY = null;
			CoordInvalidX = null;
			CoordInvalidXAndY = null;
		}

		[UnityTest]
		public IEnumerator TestCoordinatesConstructor()
		{
			Assert.AreEqual(25, CoordinatesInstance.GetX());
			Assert.AreEqual(10, CoordinatesInstance.GetY());

			Assert.AreEqual(Constants.INVALID_LOCATION, CoordInvalidX.GetX());
			Assert.AreEqual(20, CoordInvalidX.GetY());

			Assert.AreEqual(19, CoordInvalidY.GetX());
			Assert.AreEqual(Constants.INVALID_LOCATION, CoordInvalidY.GetY());

			Assert.AreEqual(Constants.INVALID_LOCATION, CoordInvalidXAndY.GetX());
			Assert.AreEqual(Constants.INVALID_LOCATION, CoordInvalidXAndY.GetY());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestEquality()
		{
			Coordinates sameCoords = new Coordinates(25, 10);
			Coordinates flippedCoords = new Coordinates(10, 25);
			Coordinates differentCoords = new Coordinates(2, 3);

			Assert.IsTrue(CoordinatesInstance.Equals(sameCoords));
			Assert.IsFalse(CoordinatesInstance.Equals(flippedCoords));
			Assert.IsFalse(CoordinatesInstance.Equals(differentCoords));
			Assert.IsFalse(CoordinatesInstance.Equals(CoordInvalidY));
			Assert.IsFalse(CoordinatesInstance.Equals(CoordInvalidX));
			Assert.IsFalse(CoordinatesInstance.Equals(CoordInvalidXAndY));

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestGetX()
		{
			Assert.AreEqual(25, CoordinatesInstance.GetX());
			Assert.AreEqual(19, CoordInvalidY.GetX());
			Assert.AreEqual(-1, CoordInvalidX.GetX());
			Assert.AreEqual(-1, CoordInvalidXAndY.GetX());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestGetY()
		{
			Assert.AreEqual(10, CoordinatesInstance.GetY());
			Assert.AreEqual(-1, CoordInvalidY.GetY());
			Assert.AreEqual(20, CoordInvalidX.GetY());
			Assert.AreEqual(-1, CoordInvalidXAndY.GetY());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestToString()
		{
			Assert.AreEqual("(x, y) = (25, 10)", CoordinatesInstance.ToString());
			Assert.AreEqual("(x, y) = (19, -1)", CoordInvalidY.ToString());
			Assert.AreEqual("(x, y) = (-1, 20)", CoordInvalidX.ToString());
			Assert.AreEqual("(x, y) = (-1, -1)", CoordInvalidXAndY.ToString());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestGetHash()
		{
			Assert.AreEqual(System.Tuple.Create(25, 10).GetHashCode(), CoordinatesInstance.GetHashCode());
			Assert.AreEqual(System.Tuple.Create(19, -1).GetHashCode(), CoordInvalidY.GetHashCode());
			Assert.AreEqual(System.Tuple.Create(-1, 20).GetHashCode(), CoordInvalidX.GetHashCode());
			Assert.AreEqual(System.Tuple.Create(-1, -1).GetHashCode(), CoordInvalidXAndY.GetHashCode());


			yield return null;
		}

		[UnityTest]
		public IEnumerator TestWithinOneHexHelperFunction()
		{
			//Given we click on (18,14), then we would expect (17,14), (17, 15), (18, 15), (19, 14), (18, 13), and (17, 13) to be within one hex
			Coordinates clicked = new Coordinates(18, 14);
			Assert.IsTrue(Coordinates.IsCoordinateWithinOneHex(clicked, new Coordinates(17, 14))); //to the left
			Assert.IsTrue(Coordinates.IsCoordinateWithinOneHex(clicked, new Coordinates(17, 15))); //to the top left
			Assert.IsTrue(Coordinates.IsCoordinateWithinOneHex(clicked, new Coordinates(18, 15))); //to the top right
			Assert.IsTrue(Coordinates.IsCoordinateWithinOneHex(clicked, new Coordinates(19, 14))); //to the right
			Assert.IsTrue(Coordinates.IsCoordinateWithinOneHex(clicked, new Coordinates(18, 13))); //to the bottom right
			Assert.IsTrue(Coordinates.IsCoordinateWithinOneHex(clicked, new Coordinates(17, 13))); //to the bottom left
			Assert.IsFalse(Coordinates.IsCoordinateWithinOneHex(clicked, new Coordinates(19, 13)));
			Assert.IsFalse(Coordinates.IsCoordinateWithinOneHex(clicked, new Coordinates(19, 15)));

			yield return null;
		}
	}
}