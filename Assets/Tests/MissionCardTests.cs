using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using System.Linq;
using FallenLand;

namespace Tests
{
	public class MissionCardTests
	{
		MissionCard MissionCardInstance;

		[SetUp]
		public void Setup()
		{
			MissionCardInstance = new MissionCard("Mission card constructor");
		}

		[TearDown]
		public void Teardown()
		{
			MissionCardInstance = null;
		}

		[UnityTest]
		public IEnumerator TestMissionTitle()
		{
			Assert.AreEqual("Mission card constructor", MissionCardInstance.GetTitle());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestMissionConstructors()
		{
			Assert.IsNotNull(MissionCardInstance.GetOptionalSkillChecks());

			MissionCard missionCard = new MissionCard("title");
			Assert.IsNotNull(missionCard.GetOptionalSkillChecks());
			Assert.AreEqual(0, missionCard.GetOptionalSkillChecks().Count);
			Assert.IsNotNull(missionCard.GetSkillChecks());
			Assert.AreEqual(0, missionCard.GetSkillChecks().Count);
			Assert.AreEqual(0, missionCard.GetSalvageReward());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSkillChecks()
		{
			Assert.IsNotNull(MissionCardInstance.GetSkillChecks());
			Assert.AreEqual(0, MissionCardInstance.GetSkillChecks().Count);

			MissionCardInstance.SetSkillChecks(new List<(Skills, int)> { ( Skills.Combat, 3 ), ( Skills.Medical, 4 ) });
			Assert.AreEqual(2, MissionCardInstance.GetSkillChecks().Count);
			Assert.AreEqual(Skills.Combat, MissionCardInstance.GetSkillChecks().ElementAt(0).Item1);
			Assert.AreEqual(3, MissionCardInstance.GetSkillChecks().ElementAt(0).Item2);
			Assert.AreEqual(Skills.Medical, MissionCardInstance.GetSkillChecks().ElementAt(1).Item1);
			Assert.AreEqual(4, MissionCardInstance.GetSkillChecks().ElementAt(1).Item2);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSuccessText()
		{
			Assert.AreEqual("", MissionCardInstance.GetSuccessHeaderText());

			MissionCardInstance.SetSuccessHeaderText("You did it!");
			Assert.AreEqual("You did it!", MissionCardInstance.GetSuccessHeaderText());

			MissionCardInstance.SetSuccessHeaderText("");
			Assert.AreEqual("", MissionCardInstance.GetSuccessHeaderText());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestFailureText()
		{
			Assert.AreEqual("", MissionCardInstance.GetFailureHeaderText());

			MissionCardInstance.SetFailureHeaderText("You didn't do it!");
			Assert.AreEqual("You didn't do it!", MissionCardInstance.GetFailureHeaderText());

			MissionCardInstance.SetFailureHeaderText("");
			Assert.AreEqual("", MissionCardInstance.GetFailureHeaderText());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSalvageReward()
		{
			Assert.AreEqual(0, MissionCardInstance.GetSalvageReward());

			MissionCardInstance.SetSalvageReward(12);
			Assert.AreEqual(12, MissionCardInstance.GetSalvageReward());

			MissionCardInstance.SetSalvageReward(-1);
			Assert.AreEqual(12, MissionCardInstance.GetSalvageReward());

			MissionCardInstance.SetSalvageReward(0);
			Assert.AreEqual(0, MissionCardInstance.GetSalvageReward());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestOptionalSkillChecks()
		{
			Assert.IsNotNull(MissionCardInstance.GetOptionalSkillChecks());
			Assert.AreEqual(0, MissionCardInstance.GetOptionalSkillChecks().Count);

			MissionCardInstance.SetOptionalSkillChecks(new Dictionary<Skills, int>() { { Skills.Medical, 7 }, { Skills.Combat, 9 } });
			Assert.AreEqual(2, MissionCardInstance.GetOptionalSkillChecks().Count);
			Assert.AreEqual(Skills.Medical, MissionCardInstance.GetOptionalSkillChecks().ElementAt(0).Key);
			Assert.AreEqual(7, MissionCardInstance.GetOptionalSkillChecks().ElementAt(0).Value);
			Assert.AreEqual(Skills.Combat, MissionCardInstance.GetOptionalSkillChecks().ElementAt(1).Key);
			Assert.AreEqual(9, MissionCardInstance.GetOptionalSkillChecks().ElementAt(1).Value);

			MissionCardInstance.SetOptionalSkillChecks(null);
			Assert.IsNotNull(MissionCardInstance.GetOptionalSkillChecks());
			Assert.AreEqual(2, MissionCardInstance.GetOptionalSkillChecks().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestOptionalSuccessText()
		{
			Assert.AreEqual("", MissionCardInstance.GetOptionalSuccessText());

			MissionCardInstance.SetOptionalSuccessText("You did it! Wowza!");
			Assert.AreEqual("You did it! Wowza!", MissionCardInstance.GetOptionalSuccessText());

			MissionCardInstance.SetOptionalSuccessText("");
			Assert.AreEqual("", MissionCardInstance.GetOptionalSuccessText());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestOptionalFailureText()
		{
			Assert.AreEqual("", MissionCardInstance.GetOptionalFailureText());

			MissionCardInstance.SetOptionalFailureText("You didn't do it! Dang...");
			Assert.AreEqual("You didn't do it! Dang...", MissionCardInstance.GetOptionalFailureText());

			MissionCardInstance.SetOptionalFailureText("");
			Assert.AreEqual("", MissionCardInstance.GetOptionalFailureText());

			yield return null;
		}
	}
}