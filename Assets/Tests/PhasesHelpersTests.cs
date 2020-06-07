using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine;
using UnityEngine.UI;
using FallenLand;

namespace Tests
{
	public class PhasesHelpersTests
	{

		[SetUp]
		public void Setup()
		{
		}

		[TearDown]
		public void Teardown()
		{
		}

		[UnityTest]
		public IEnumerator TestIsPhaseAsync()
		{
			Assert.IsTrue(PhasesHelpers.IsAsyncPhase(Phases.Town_Business_Auction_House));
			Assert.IsFalse(PhasesHelpers.IsAsyncPhase(Phases.Before_Town_Business_Auction_House));
			Assert.IsFalse(PhasesHelpers.IsAsyncPhase(Phases.After_Town_Business_Auction_House));

			yield return null;
		}
	}
}