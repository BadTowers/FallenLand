using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Tests
{
	public class HexTests
	{
		private Hex HexInstance;

		[SetUp]
		public void Setup()
		{
			HexInstance = new Hex();
		}

		[TearDown]
		public void Teardown()
		{
			HexInstance = null;
		}

		[UnityTest]
		public IEnumerator TestConstructors()
		{
			Assert.IsNotNull(HexInstance.GetCoordinates());
			Assert.AreEqual(Constants.INVALID_LOCATION, HexInstance.GetCoordinates().GetX());
			Assert.AreEqual(Constants.INVALID_LOCATION, HexInstance.GetCoordinates().GetY());
			Assert.IsNotNull(HexInstance.GetFaction());
			Assert.AreEqual("invalid faction", HexInstance.GetFaction().GetName());
			Assert.AreEqual(Constants.INVALID_LOCATION, HexInstance.GetFaction().GetBaseLocation().GetX());
			Assert.AreEqual(Constants.INVALID_LOCATION, HexInstance.GetFaction().GetBaseLocation().GetY());

			Hex hexNullCoordinates = new Hex(null);
			Assert.IsNotNull(hexNullCoordinates.GetCoordinates());
			Assert.AreEqual(Constants.INVALID_LOCATION, hexNullCoordinates.GetCoordinates().GetX());
			Assert.AreEqual(Constants.INVALID_LOCATION, hexNullCoordinates.GetCoordinates().GetY());
			Assert.IsNotNull(hexNullCoordinates.GetFaction());
			Assert.AreEqual("invalid faction", hexNullCoordinates.GetFaction().GetName());
			Assert.AreEqual(Constants.INVALID_LOCATION, hexNullCoordinates.GetFaction().GetBaseLocation().GetX());
			Assert.AreEqual(Constants.INVALID_LOCATION, hexNullCoordinates.GetFaction().GetBaseLocation().GetY());

			Hex hexValidCoordiantes = new Hex(new Coordinates(10, 20));
			Assert.IsNotNull(hexValidCoordiantes.GetCoordinates());
			Assert.AreEqual(10, hexValidCoordiantes.GetCoordinates().GetX());
			Assert.AreEqual(20, hexValidCoordiantes.GetCoordinates().GetY());
			Assert.IsNotNull(hexValidCoordiantes.GetFaction());
			Assert.AreEqual("invalid faction", hexValidCoordiantes.GetFaction().GetName());
			Assert.AreEqual(Constants.INVALID_LOCATION, hexValidCoordiantes.GetFaction().GetBaseLocation().GetX());
			Assert.AreEqual(Constants.INVALID_LOCATION, hexValidCoordiantes.GetFaction().GetBaseLocation().GetY());

			Hex hexValidXY = new Hex(4, 5);
			Assert.IsNotNull(hexValidXY.GetCoordinates());
			Assert.AreEqual(4, hexValidXY.GetCoordinates().GetX());
			Assert.AreEqual(5, hexValidXY.GetCoordinates().GetY());
			Assert.IsNotNull(hexValidXY.GetFaction());
			Assert.AreEqual("invalid faction", hexValidXY.GetFaction().GetName());
			Assert.AreEqual(Constants.INVALID_LOCATION, hexValidXY.GetFaction().GetBaseLocation().GetX());
			Assert.AreEqual(Constants.INVALID_LOCATION, hexValidXY.GetFaction().GetBaseLocation().GetY());

			Hex hexInvalidX = new Hex(-100, 6);
			Assert.IsNotNull(hexInvalidX.GetCoordinates());
			Assert.AreEqual(Constants.INVALID_LOCATION, hexInvalidX.GetCoordinates().GetX());
			Assert.AreEqual(6, hexInvalidX.GetCoordinates().GetY());
			Assert.IsNotNull(hexInvalidX.GetFaction());
			Assert.AreEqual("invalid faction", hexInvalidX.GetFaction().GetName());
			Assert.AreEqual(Constants.INVALID_LOCATION, hexInvalidX.GetFaction().GetBaseLocation().GetX());
			Assert.AreEqual(Constants.INVALID_LOCATION, hexInvalidX.GetFaction().GetBaseLocation().GetY());

			Hex hexInvalidY = new Hex(16, -6);
			Assert.IsNotNull(hexInvalidY.GetCoordinates());
			Assert.AreEqual(16, hexInvalidY.GetCoordinates().GetX());
			Assert.AreEqual(Constants.INVALID_LOCATION, hexInvalidY.GetCoordinates().GetY());
			Assert.IsNotNull(hexInvalidY.GetFaction());
			Assert.AreEqual("invalid faction", hexInvalidY.GetFaction().GetName());
			Assert.AreEqual(Constants.INVALID_LOCATION, hexInvalidY.GetFaction().GetBaseLocation().GetX());
			Assert.AreEqual(Constants.INVALID_LOCATION, hexInvalidY.GetFaction().GetBaseLocation().GetY());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestCoordinates()
		{
			HexInstance.SetCoordinates(new Coordinates(7, 8));
			Assert.IsNotNull(HexInstance.GetCoordinates());
			Assert.AreEqual(7, HexInstance.GetCoordinates().GetX());
			Assert.AreEqual(8, HexInstance.GetCoordinates().GetY());

			HexInstance.SetCoordinates(null);
			Assert.IsNotNull(HexInstance.GetCoordinates());
			Assert.AreEqual(7, HexInstance.GetCoordinates().GetX());
			Assert.AreEqual(8, HexInstance.GetCoordinates().GetY());

			HexInstance.SetCoordinates(78, 90);
			Assert.IsNotNull(HexInstance.GetCoordinates());
			Assert.AreEqual(78, HexInstance.GetCoordinates().GetX());
			Assert.AreEqual(90, HexInstance.GetCoordinates().GetY());

			HexInstance.SetCoordinates(72, -90);
			Assert.IsNotNull(HexInstance.GetCoordinates());
			Assert.AreEqual(72, HexInstance.GetCoordinates().GetX());
			Assert.AreEqual(Constants.INVALID_LOCATION, HexInstance.GetCoordinates().GetY());

			HexInstance.SetCoordinates(-72, 90);
			Assert.IsNotNull(HexInstance.GetCoordinates());
			Assert.AreEqual(Constants.INVALID_LOCATION, HexInstance.GetCoordinates().GetX());
			Assert.AreEqual(90, HexInstance.GetCoordinates().GetY());

			HexInstance.SetCoordinates(-72, -90);
			Assert.IsNotNull(HexInstance.GetCoordinates());
			Assert.AreEqual(Constants.INVALID_LOCATION, HexInstance.GetCoordinates().GetX());
			Assert.AreEqual(Constants.INVALID_LOCATION, HexInstance.GetCoordinates().GetY());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsCity()
		{
			HexInstance.SetIsCity(false);
			Assert.IsFalse(HexInstance.IsCity());

			HexInstance.SetIsCity(true);
			Assert.IsTrue(HexInstance.IsCity());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsRad()
		{
			HexInstance.SetIsRad(false);
			Assert.IsFalse(HexInstance.IsRad());

			HexInstance.SetIsRad(true);
			Assert.IsTrue(HexInstance.IsRad());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsMountain()
		{
			HexInstance.SetIsMountain(false);
			Assert.IsFalse(HexInstance.IsMountain());

			HexInstance.SetIsMountain(true);
			Assert.IsTrue(HexInstance.IsMountain());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsPlains()
		{
			HexInstance.SetIsPlains(false);
			Assert.IsFalse(HexInstance.IsPlains());

			HexInstance.SetIsPlains(true);
			Assert.IsTrue(HexInstance.IsPlains());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsRandomLocation()
		{
			HexInstance.SetIsRandomLocation(false);
			Assert.IsFalse(HexInstance.IsRandomLocation());

			HexInstance.SetIsRandomLocation(true);
			Assert.IsTrue(HexInstance.IsRandomLocation());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsWater()
		{
			HexInstance.SetIsWater(false);
			Assert.IsFalse(HexInstance.IsWater());

			HexInstance.SetIsWater(true);
			Assert.IsTrue(HexInstance.IsWater());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsResource()
		{
			HexInstance.SetIsResource(false);
			Assert.IsFalse(HexInstance.IsResource());

			HexInstance.SetIsResource(true);
			Assert.IsTrue(HexInstance.IsResource());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsFactionBase()
		{
			HexInstance.SetIsFactionBase(false);
			Assert.IsFalse(HexInstance.IsFactionBase());

			HexInstance.SetIsFactionBase(true);
			Assert.IsTrue(HexInstance.IsFactionBase());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsHexInGame()
		{
			HexInstance.SetIsHexInGame(false);
			Assert.IsFalse(HexInstance.IsHexInGame());

			HexInstance.SetIsHexInGame(true);
			Assert.IsTrue(HexInstance.IsHexInGame());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestFaction()
		{
			HexInstance.SetFaction(new Faction("test faction", new Coordinates(1, 2)));
			Assert.IsNotNull(HexInstance.GetFaction());

			HexInstance.SetFaction(null);
			Assert.IsNotNull(HexInstance.GetFaction());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestRandomNumberLocation()
		{
			HexInstance.SetRandomLocationNumber(-1);
			Assert.AreEqual(0, HexInstance.GetRandomLocationNumber());

			HexInstance.SetRandomLocationNumber(0);
			Assert.AreEqual(0, HexInstance.GetRandomLocationNumber());

			HexInstance.SetRandomLocationNumber(6);
			Assert.AreEqual(6, HexInstance.GetRandomLocationNumber());

			HexInstance.SetRandomLocationNumber(-1);
			Assert.AreEqual(6, HexInstance.GetRandomLocationNumber());

			HexInstance.SetRandomLocationNumber(0);
			Assert.AreEqual(6, HexInstance.GetRandomLocationNumber());

			yield return null;
		}
	}
}