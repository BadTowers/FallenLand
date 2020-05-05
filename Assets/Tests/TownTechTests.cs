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
			Assert.AreEqual("Tech Name", townTech.GetTechName());
			townTech.SetTechName("New Tech Name");
			Assert.AreEqual("New Tech Name", townTech.GetTechName());

			townTech.SetId(10);
			Assert.AreEqual(10, townTech.GetId());

			townTech.SetIsStartingTech(true);
			Assert.IsTrue(townTech.GetIsStartingTech());
			townTech.SetIsStartingTech(false);
			Assert.IsFalse(townTech.GetIsStartingTech());

			yield return null; //Wait for one frame
		}
	}
}