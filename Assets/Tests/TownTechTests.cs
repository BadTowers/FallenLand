using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using UnityEngine;

namespace Tests
{
	public class TownTechTests
	{
		[UnityTest]
		public IEnumerator TestGetterSetters()
		{
			TownTech townTech = new TownTech("Tech Name");

			yield return null; //Wait for one frame

			Assert.AreEqual("Tech Name", townTech.GetTechName());
		}
	}
}