using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Tests
{
	public class CityRadCardTests
	{
		CityRadCard CityRadCardInstance;

		[SetUp]
		public void Setup()
		{
			CityRadCardInstance = new CityRadCard("City/Rad card constructor");
		}

		[TearDown]
		public void Teardown()
		{
			CityRadCardInstance = null;
		}

		[UnityTest]
		public IEnumerator TestCityRadCardTitle()
		{
			Assert.AreEqual("City/Rad card constructor", CityRadCardInstance.GetTitle());

			yield return null;
		}
	}
}