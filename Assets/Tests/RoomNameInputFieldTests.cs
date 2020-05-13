using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine;
using FallenLand;
using UnityEngine.UI;

namespace Tests
{
	public class RoomNameInputFieldTests
	{
		private GameObject GameObj;

		[SetUp]
		public void Setup()
		{
			GameObj = new GameObject();
		}

		[TearDown]
		public void Teardown()
		{
			Object.Destroy(GameObj);
		}

		[UnityTest]
		public IEnumerator TestInputFieldDefault()
		{
			GameObj.AddComponent<RoomNameInputField>();
			RoomNameInputField RoomNameInputFieldObj = GameObj.GetComponent<RoomNameInputField>();

			yield return null;

			InputField roomInputField = RoomNameInputFieldObj.GetComponent<InputField>();
			Assert.IsNotNull(roomInputField);
			Assert.AreEqual("JeksPeen", roomInputField.text);
		}

		[UnityTest]
		public IEnumerator TestGetSetRoomName()
		{
			GameObj.AddComponent<RoomNameInputField>();
			RoomNameInputField RoomNameInputFieldObj = GameObj.GetComponent<RoomNameInputField>();

			yield return null;

			RoomNameInputFieldObj.SetRoomName("Test name");
			InputField nameInputField = RoomNameInputFieldObj.GetComponent<InputField>();
			Assert.IsNotNull(nameInputField);
			Assert.AreEqual("Test name", nameInputField.text);

			RoomNameInputFieldObj.SetRoomName("");
			Assert.AreEqual(string.Empty, nameInputField.text);
			RoomNameInputFieldObj.SetRoomName(null);
			Assert.AreEqual(string.Empty, nameInputField.text);
		}
	}
}