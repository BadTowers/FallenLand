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

			MissionCard missionCardOptionalSkillChecks = new MissionCard("title", new Dictionary<Skills, int>() { { Skills.Medical, 2 } });
			Assert.AreEqual(1, missionCardOptionalSkillChecks.GetOptionalSkillChecks().Count);
			Assert.AreEqual(Skills.Medical, missionCardOptionalSkillChecks.GetOptionalSkillChecks().ElementAt(0).Key);
			Assert.AreEqual(2, missionCardOptionalSkillChecks.GetOptionalSkillChecks().ElementAt(0).Value);

			Dictionary<Skills, int> optionalSkillCheck = new Dictionary<Skills, int>() { { Skills.Diplomacy, 3 } };
			Dictionary<Skills, int> requiredSkillCheck = new Dictionary<Skills, int>() { { Skills.Technical, 5 } };
			MissionCard missionCardTwoDictionaryConstructor = new MissionCard("title", requiredSkillCheck, optionalSkillCheck);
			Assert.AreEqual(1, missionCardTwoDictionaryConstructor.GetOptionalSkillChecks().Count);
			Assert.AreEqual(Skills.Diplomacy, missionCardTwoDictionaryConstructor.GetOptionalSkillChecks().ElementAt(0).Key);
			Assert.AreEqual(3, missionCardTwoDictionaryConstructor.GetOptionalSkillChecks().ElementAt(0).Value);
			Assert.AreEqual(1, missionCardTwoDictionaryConstructor.GetSkillChecks().Count);
			Assert.AreEqual(Skills.Technical, missionCardTwoDictionaryConstructor.GetSkillChecks().ElementAt(0).Key);
			Assert.AreEqual(5, missionCardTwoDictionaryConstructor.GetSkillChecks().ElementAt(0).Value);
			Assert.AreEqual(0, missionCardTwoDictionaryConstructor.GetSalvageReward());

			MissionCard missionCardTwoDictionaryConstructorAndSalvageValue = new MissionCard("title", 9, requiredSkillCheck, optionalSkillCheck);
			Assert.AreEqual(1, missionCardTwoDictionaryConstructorAndSalvageValue.GetOptionalSkillChecks().Count);
			Assert.AreEqual(Skills.Diplomacy, missionCardTwoDictionaryConstructorAndSalvageValue.GetOptionalSkillChecks().ElementAt(0).Key);
			Assert.AreEqual(3, missionCardTwoDictionaryConstructorAndSalvageValue.GetOptionalSkillChecks().ElementAt(0).Value);
			Assert.AreEqual(1, missionCardTwoDictionaryConstructorAndSalvageValue.GetSkillChecks().Count);
			Assert.AreEqual(Skills.Technical, missionCardTwoDictionaryConstructorAndSalvageValue.GetSkillChecks().ElementAt(0).Key);
			Assert.AreEqual(5, missionCardTwoDictionaryConstructorAndSalvageValue.GetSkillChecks().ElementAt(0).Value);
			Assert.AreEqual(9, missionCardTwoDictionaryConstructorAndSalvageValue.GetSalvageReward());

			MissionCard missionCardOptionalDictionaryConstructorAndSalvageValue = new MissionCard("title", 4, optionalSkillCheck);
			Assert.AreEqual(1, missionCardOptionalDictionaryConstructorAndSalvageValue.GetOptionalSkillChecks().Count);
			Assert.AreEqual(Skills.Diplomacy, missionCardOptionalDictionaryConstructorAndSalvageValue.GetOptionalSkillChecks().ElementAt(0).Key);
			Assert.AreEqual(3, missionCardOptionalDictionaryConstructorAndSalvageValue.GetOptionalSkillChecks().ElementAt(0).Value);
			Assert.IsNotNull(missionCardOptionalDictionaryConstructorAndSalvageValue.GetSkillChecks());
			Assert.AreEqual(0, missionCardOptionalDictionaryConstructorAndSalvageValue.GetSkillChecks().Count);
			Assert.AreEqual(4, missionCardOptionalDictionaryConstructorAndSalvageValue.GetSalvageReward());

			MissionCard missionCardSalvageValueConstructor = new MissionCard("title", 8);
			Assert.IsNotNull(missionCardSalvageValueConstructor.GetOptionalSkillChecks());
			Assert.AreEqual(0, missionCardSalvageValueConstructor.GetOptionalSkillChecks().Count);
			Assert.IsNotNull(missionCardSalvageValueConstructor.GetSkillChecks());
			Assert.AreEqual(0, missionCardSalvageValueConstructor.GetSkillChecks().Count);
			Assert.AreEqual(8, missionCardSalvageValueConstructor.GetSalvageReward());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSkillChecks()
		{
			Assert.IsNotNull(MissionCardInstance.GetSkillChecks());
			Assert.AreEqual(0, MissionCardInstance.GetSkillChecks().Count);

			MissionCardInstance.SetSkillChecks(new Dictionary<Skills, int>() { { Skills.Combat, 3 }, { Skills.Medical, 4 } });
			Assert.AreEqual(2, MissionCardInstance.GetSkillChecks().Count);
			Assert.AreEqual(Skills.Combat, MissionCardInstance.GetSkillChecks().ElementAt(0).Key);
			Assert.AreEqual(3, MissionCardInstance.GetSkillChecks().ElementAt(0).Value);
			Assert.AreEqual(Skills.Medical, MissionCardInstance.GetSkillChecks().ElementAt(1).Key);
			Assert.AreEqual(4, MissionCardInstance.GetSkillChecks().ElementAt(1).Value);

			MissionCardInstance.SetSkillChecks(null);
			Assert.IsNotNull(MissionCardInstance.GetSkillChecks());
			Assert.AreEqual(2, MissionCardInstance.GetSkillChecks().Count);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSuccessText()
		{
			Assert.AreEqual("", MissionCardInstance.GetSuccessText());

			MissionCardInstance.SetSuccessText("You did it!");
			Assert.AreEqual("You did it!", MissionCardInstance.GetSuccessText());

			MissionCardInstance.SetSuccessText("");
			Assert.AreEqual("", MissionCardInstance.GetSuccessText());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestFailureText()
		{
			Assert.AreEqual("", MissionCardInstance.GetFailureText());

			MissionCardInstance.SetFailureText("You didn't do it!");
			Assert.AreEqual("You didn't do it!", MissionCardInstance.GetFailureText());

			MissionCardInstance.SetFailureText("");
			Assert.AreEqual("", MissionCardInstance.GetFailureText());

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