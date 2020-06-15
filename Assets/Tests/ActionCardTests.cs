using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;

namespace Tests
{
	public class ActionCardTests
	{
		ActionCard ActionCardInstance;

		[SetUp]
		public void Setup()
		{
			ActionCardInstance = new ActionCard("Action card constructor");
		}

		[TearDown]
		public void Teardown()
		{
			ActionCardInstance = null;
		}

		[UnityTest]
		public IEnumerator TestActionCardTitle()
		{
			Assert.AreEqual("Action card constructor", ActionCardInstance.GetTitle());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSellValue()
		{
			Assert.AreEqual(0, ActionCardInstance.GetSellValue());

			ActionCardInstance.SetSellValue(23);
			Assert.AreEqual(23, ActionCardInstance.GetSellValue());

			ActionCardInstance.SetSellValue(-10);
			Assert.AreEqual(23, ActionCardInstance.GetSellValue());

			ActionCardInstance.SetSellValue(0);
			Assert.AreEqual(0, ActionCardInstance.GetSellValue());

			yield return null;
		}

		[UnityTest]
		public IEnumerator TestSerializeAndDeserialize()
		{
			byte[] byteArray = ActionCard.SerializeActionCard(ActionCardInstance);
			ActionCard newActionCard = (ActionCard)ActionCard.DeserializeActionCard(byteArray);
			Assert.AreEqual(newActionCard.GetTitle(), ActionCardInstance.GetTitle());

			yield return null;
		}
	}
}