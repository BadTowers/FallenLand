using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Tests
{
	public class MountainCardTests
	{
		MountainCard MountainCardInstance;

		[SetUp]
		public void Setup()
		{
			MountainCardInstance = new MountainCard("Mountain card constructor");
		}

		[TearDown]
		public void Teardown()
		{
			MountainCardInstance = null;
		}

		[UnityTest]
		public IEnumerator TestMountainCardTitle()
		{
			Assert.AreEqual("Mountain card constructor", MountainCardInstance.GetTitle());

			yield return null;
		}
	}
}