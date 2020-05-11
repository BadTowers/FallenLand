using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;

namespace Tests
{
	public class DefaultRandomLocationsTests
	{
		[UnityTest]
		public IEnumerator TestSpoilsCardConstructors()
		{
			for (int i = 1; i <= 100; i++)
			{
				Assert.IsNotNull(DefaultRandomNumberLocations.RAND_NUM_LOCATIONS[i]);
			}

			Assert.IsNotNull(DefaultRandomNumberLocations.RAND_NUM_LOCATIONS[-1]);

			yield return null;
		}
	}
}