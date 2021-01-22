using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;

namespace Tests
{
	public class GainSpecificSpoilsTests
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
		public IEnumerator TestGain68mmAdvancedRifle()
		{
			Moq.Mock<GameManager> mockGameManager = new Moq.Mock<GameManager>();

			Reward reward = new Gain68mmAdvancedRifle();
			reward.HandleReward(mockGameManager.Object, 0);

			mockGameManager.Verify(mock => mock.DealSpecificSpoilToPlayer(Moq.It.IsAny<int>(), Moq.It.Is<string>(arg => arg == "68mm Advanced Rifle")), Moq.Times.Once());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestGainAmericanIronCustomChoppers()
		{
			Moq.Mock<GameManager> mockGameManager = new Moq.Mock<GameManager>();

			Reward reward = new GainAmericanIronCustomChoppers();
			reward.HandleReward(mockGameManager.Object, 0);

			mockGameManager.Verify(mock => mock.DealSpecificSpoilToPlayer(Moq.It.IsAny<int>(), Moq.It.Is<string>(arg => arg == "American Iron Custom Choppers")), Moq.Times.Once());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestGainCompoundHuntingBow()
		{
			Moq.Mock<GameManager> mockGameManager = new Moq.Mock<GameManager>();

			Reward reward = new GainCompoundHuntingBow();
			reward.HandleReward(mockGameManager.Object, 0);

			mockGameManager.Verify(mock => mock.DealSpecificSpoilToPlayer(Moq.It.IsAny<int>(), Moq.It.Is<string>(arg => arg == "Compound Hunting Bow")), Moq.Times.Once());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestGainMilitiaRifle()
		{
			Moq.Mock<GameManager> mockGameManager = new Moq.Mock<GameManager>();

			Reward reward = new GainMilitiaRifle();
			reward.HandleReward(mockGameManager.Object, 0);

			mockGameManager.Verify(mock => mock.DealSpecificSpoilToPlayer(Moq.It.IsAny<int>(), Moq.It.Is<string>(arg => arg == "Militia Rifle")), Moq.Times.Once());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestGainParamedicMedKit()
		{
			Moq.Mock<GameManager> mockGameManager = new Moq.Mock<GameManager>();

			Reward reward = new GainParamedicMedKit();
			reward.HandleReward(mockGameManager.Object, 0);

			mockGameManager.Verify(mock => mock.DealSpecificSpoilToPlayer(Moq.It.IsAny<int>(), Moq.It.Is<string>(arg => arg == "Paramedic Medical Kit")), Moq.Times.Once());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestGainSixFastHorses()
		{
			Moq.Mock<GameManager> mockGameManager = new Moq.Mock<GameManager>();

			Reward reward = new GainSixFastHorses();
			reward.HandleReward(mockGameManager.Object, 0);

			mockGameManager.Verify(mock => mock.DealSpecificSpoilToPlayer(Moq.It.IsAny<int>(), Moq.It.Is<string>(arg => arg == "6 Fast Horses")), Moq.Times.Once());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestGainVendettaDaggers()
		{
			Moq.Mock<GameManager> mockGameManager = new Moq.Mock<GameManager>();

			Reward reward = new GainVendettaDaggers();
			reward.HandleReward(mockGameManager.Object, 0);

			mockGameManager.Verify(mock => mock.DealSpecificSpoilToPlayer(Moq.It.IsAny<int>(), Moq.It.Is<string>(arg => arg == "Vendetta Daggers")), Moq.Times.Once());

			yield return null;
		}
	}
}