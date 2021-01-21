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

		[UnityTest]
		public IEnumerator TestPassDescriptionText()
		{
			MissionCardInstance.SetSuccessDescriptionText("You passed!");
			Assert.AreEqual("You passed!", MissionCardInstance.GetSuccessDescriptionText());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestFailDescriptionText()
		{
			MissionCardInstance.SetFailureDescriptionText("You failed");
			Assert.AreEqual("You failed", MissionCardInstance.GetFailureDescriptionText());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestDescriptionText()
		{
			MissionCardInstance.SetDescriptionText("This is a description");
			Assert.AreEqual("This is a description", MissionCardInstance.GetDescriptionText());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestFlightAllowed()
		{
			MissionCardInstance.SetFlightAllowed(true);
			Assert.IsTrue(MissionCardInstance.GetFlightAllowed());

			MissionCardInstance.SetFlightAllowed(false);
			Assert.IsFalse(MissionCardInstance.GetFlightAllowed());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestMeleeOnly()
		{
			MissionCardInstance.SetIsMeleeOnly(true);
			Assert.IsTrue(MissionCardInstance.GetIsMeleeOnly());

			MissionCardInstance.SetIsMeleeOnly(false);
			Assert.IsFalse(MissionCardInstance.GetIsMeleeOnly());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestPsychCheckAfter()
		{
			Assert.IsFalse(MissionCardInstance.GetMakePsychCheckAfterEncounter());

			MissionCardInstance.SetMakePsychCheckAfterEncounter(true);
			Assert.IsTrue(MissionCardInstance.GetMakePsychCheckAfterEncounter());

			MissionCardInstance.SetMakePsychCheckAfterEncounter(false);
			Assert.IsFalse(MissionCardInstance.GetMakePsychCheckAfterEncounter());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestPrechecks()
		{
			Assert.AreEqual(0, MissionCardInstance.GetPrechecks().Count);

			Precheck precheck = new HasMotorizedVehicle();
			MissionCardInstance.AddPrecheck(precheck);
			Assert.AreEqual(1, MissionCardInstance.GetPrechecks().Count);
			Assert.AreEqual(precheck, MissionCardInstance.GetPrechecks()[0]);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestActionsOnBegin()
		{
			Assert.AreEqual(0, MissionCardInstance.GetActionsOnBegin().Count);

			Action actionOnBegin = new DiscardEquippedAllies();
			MissionCardInstance.AddActionOnBegin(actionOnBegin);
			Assert.AreEqual(1, MissionCardInstance.GetActionsOnBegin().Count);
			Assert.AreEqual(actionOnBegin, MissionCardInstance.GetActionsOnBegin()[0]);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestClassifications()
		{
			Assert.AreEqual(0, MissionCardInstance.GetClassifications().Count);

			MissionCardInstance.AddClassification(EncounterTypes.Ambush);
			Assert.AreEqual(1, MissionCardInstance.GetClassifications().Count);
			Assert.AreEqual(EncounterTypes.Ambush, MissionCardInstance.GetClassifications()[0]);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestRewardsOnSuccess()
		{
			Assert.AreEqual(0, MissionCardInstance.GetRewardsOnSuccess().Count);

			Reward reward = new GainActionCards(2);
			MissionCardInstance.AddRewardOnSuccess(reward);
			Assert.AreEqual(1, MissionCardInstance.GetRewardsOnSuccess().Count);
			Assert.AreEqual(reward, MissionCardInstance.GetRewardsOnSuccess()[0]);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestPunishmentsOnSuccess()
		{
			Assert.AreEqual(0, MissionCardInstance.GetPunishmentsOnSuccess().Count);

			Punishment punishment = new LosePrestige(2);
			MissionCardInstance.AddPunishmentOnSuccess(punishment);
			Assert.AreEqual(1, MissionCardInstance.GetPunishmentsOnSuccess().Count);
			Assert.AreEqual(punishment, MissionCardInstance.GetPunishmentsOnSuccess()[0]);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestPunishmentOnFail()
		{
			Assert.AreEqual(0, MissionCardInstance.GetPunishmentsOnFail().Count);

			Punishment punishment = new LosePrestige(2);
			MissionCardInstance.AddPunishmentOnFail(punishment);
			Assert.AreEqual(1, MissionCardInstance.GetPunishmentsOnFail().Count);
			Assert.AreEqual(punishment, MissionCardInstance.GetPunishmentsOnFail()[0]);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIndividualCheck()
		{
			Assert.IsFalse(MissionCardInstance.GetIsIndividualCheck());

			MissionCardInstance.SetIsIndividualCheck(true);
			Assert.IsTrue(MissionCardInstance.GetIsIndividualCheck());

			MissionCardInstance.SetIsIndividualCheck(false);
			Assert.IsFalse(MissionCardInstance.GetIsIndividualCheck());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestD6Roll()
		{
			Assert.AreEqual(5, MissionCardInstance.GetD6Rolls().Count);
			Assert.AreEqual(0, MissionCardInstance.GetD6Rolls()[0]);
			Assert.AreEqual(0, MissionCardInstance.GetD6Rolls()[1]);
			Assert.AreEqual(0, MissionCardInstance.GetD6Rolls()[2]);
			Assert.AreEqual(0, MissionCardInstance.GetD6Rolls()[3]);
			Assert.AreEqual(0, MissionCardInstance.GetD6Rolls()[4]);

			MissionCardInstance.SetD6RollForCharacter(0, 5);
			Assert.AreEqual(5, MissionCardInstance.GetD6Rolls()[0]);

			MissionCardInstance.SetD6RollForCharacter(2, 3);
			Assert.AreEqual(3, MissionCardInstance.GetD6Rolls()[2]);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestIndividualPassFail()
		{
			Assert.AreEqual(5, MissionCardInstance.GetIndividualPassFail().Count);
			Assert.AreEqual(Constants.STATUS_BEGIN, MissionCardInstance.GetD6Rolls()[0]);
			Assert.AreEqual(Constants.STATUS_BEGIN, MissionCardInstance.GetD6Rolls()[1]);
			Assert.AreEqual(Constants.STATUS_BEGIN, MissionCardInstance.GetD6Rolls()[2]);
			Assert.AreEqual(Constants.STATUS_BEGIN, MissionCardInstance.GetD6Rolls()[3]);
			Assert.AreEqual(Constants.STATUS_BEGIN, MissionCardInstance.GetD6Rolls()[4]);

			MissionCardInstance.SetIndividualPassFail(0, Constants.STATUS_FAILED);
			Assert.AreEqual(Constants.STATUS_FAILED, MissionCardInstance.GetIndividualPassFail()[0]);

			MissionCardInstance.SetIndividualPassFail(2, Constants.STATUS_PASSED);
			Assert.AreEqual(Constants.STATUS_PASSED, MissionCardInstance.GetIndividualPassFail()[2]);

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestResetState()
		{
			MissionCardInstance.SetIndividualPassFail(0, Constants.STATUS_FAILED);
			MissionCardInstance.SetIndividualPassFail(1, Constants.STATUS_FAILED);
			MissionCardInstance.SetIndividualPassFail(2, Constants.STATUS_PASSED);
			MissionCardInstance.SetD6RollForCharacter(2, 4);
			MissionCardInstance.SetD6RollForCharacter(3, 3);
			MissionCardInstance.SetD6RollForCharacter(0, 1);

			MissionCardInstance.ResetState();

			Assert.AreEqual(0, MissionCardInstance.GetD6Rolls()[0]);
			Assert.AreEqual(0, MissionCardInstance.GetD6Rolls()[1]);
			Assert.AreEqual(0, MissionCardInstance.GetD6Rolls()[2]);
			Assert.AreEqual(0, MissionCardInstance.GetD6Rolls()[3]);
			Assert.AreEqual(0, MissionCardInstance.GetD6Rolls()[4]);

			Assert.AreEqual(Constants.STATUS_BEGIN, MissionCardInstance.GetD6Rolls()[0]);
			Assert.AreEqual(Constants.STATUS_BEGIN, MissionCardInstance.GetD6Rolls()[1]);
			Assert.AreEqual(Constants.STATUS_BEGIN, MissionCardInstance.GetD6Rolls()[2]);
			Assert.AreEqual(Constants.STATUS_BEGIN, MissionCardInstance.GetD6Rolls()[3]);
			Assert.AreEqual(Constants.STATUS_BEGIN, MissionCardInstance.GetD6Rolls()[4]);

			yield return null;
		}
	}
}