using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;

namespace Tests
{
	public class DefaultMapLayoutTests
	{
		private DefaultMapLayout DefaultMap;

		[SetUp]
		public void Setup()
		{
			DefaultMap = new DefaultMapLayout();
		}

		[TearDown]
		public void Teardown()
		{
			DefaultMap = null;
		}

		[UnityTest]
		public IEnumerator TestIsCity()
		{
			Assert.IsTrue(DefaultMap.IsCity(new Coordinates(2, 9)));
			Assert.IsFalse(DefaultMap.IsCity(new Coordinates(2, 11)));

			Assert.IsTrue(DefaultMap.IsCity(2, 9));
			Assert.IsFalse(DefaultMap.IsCity(2, 11));
			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsFactionBase()
		{
			Assert.IsTrue(DefaultMap.IsFactionBase(new Coordinates(4, 15)));
			Assert.IsFalse(DefaultMap.IsFactionBase(new Coordinates(4, 16)));

			Assert.IsTrue(DefaultMap.IsFactionBase(4, 15));
			Assert.IsFalse(DefaultMap.IsFactionBase(4, 16));

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsHexInGame()
		{
			Assert.IsTrue(DefaultMap.IsHexInGame(new Coordinates(4, 20)));
			Assert.IsFalse(DefaultMap.IsHexInGame(new Coordinates(4, 0)));

			Assert.IsTrue(DefaultMap.IsHexInGame(4, 20));
			Assert.IsFalse(DefaultMap.IsHexInGame(4, 0));

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsRad()
		{
			Assert.IsTrue(DefaultMap.IsRad(new Coordinates(2, 22)));
			Assert.IsFalse(DefaultMap.IsRad(new Coordinates(3, 12)));

			Assert.IsTrue(DefaultMap.IsRad(2, 22));
			Assert.IsFalse(DefaultMap.IsRad(3, 12));

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsMountain()
		{
			Assert.IsTrue(DefaultMap.IsMountain(new Coordinates(3, 14)));
			Assert.IsFalse(DefaultMap.IsMountain(new Coordinates(3, 21)));

			Assert.IsTrue(DefaultMap.IsMountain(3, 14));
			Assert.IsFalse(DefaultMap.IsMountain(3, 21));

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsPlains()
		{
			Assert.IsTrue(DefaultMap.IsPlains(new Coordinates(5, 11)));
			Assert.IsFalse(DefaultMap.IsPlains(new Coordinates(30, 10)));

			Assert.IsTrue(DefaultMap.IsPlains(5, 11));
			Assert.IsFalse(DefaultMap.IsPlains(30, 10));

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsWater()
		{
			Assert.IsTrue(DefaultMap.IsWater(new Coordinates(29, 2)));
			Assert.IsFalse(DefaultMap.IsWater(new Coordinates(29, 10)));

			Assert.IsTrue(DefaultMap.IsWater(29, 2));
			Assert.IsFalse(DefaultMap.IsWater(29, 10));

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsRandomLocation()
		{
			Assert.IsTrue(DefaultMap.IsRandomLocation(new Coordinates(29, 16)));
			Assert.IsFalse(DefaultMap.IsRandomLocation(new Coordinates(29, 15)));

			Assert.IsTrue(DefaultMap.IsRandomLocation(29, 16));
			Assert.IsFalse(DefaultMap.IsRandomLocation(29, 15));

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIsResource()
		{
			Assert.IsTrue(DefaultMap.IsResource(new Coordinates(29, 17)));
			Assert.IsFalse(DefaultMap.IsResource(new Coordinates(29, 18)));

			Assert.IsTrue(DefaultMap.IsResource(29, 17));
			Assert.IsFalse(DefaultMap.IsResource(29, 18));

			yield return null;
		}
	}
}