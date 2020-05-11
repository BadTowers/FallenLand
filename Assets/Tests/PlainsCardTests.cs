using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;

namespace Tests
{
	public class PlainsCardTests
	{
		PlainsCard PlainsCardInstance;

		[SetUp]
		public void Setup()
		{
			PlainsCardInstance = new PlainsCard("Plains card constructor");
		}

		[TearDown]
		public void Teardown()
		{
			PlainsCardInstance = null;
		}

		[UnityTest]
		public IEnumerator TestPlainsCardTitle()
		{
			Assert.AreEqual("Plains card constructor", PlainsCardInstance.GetTitle());

			yield return null;
		}
	}
}