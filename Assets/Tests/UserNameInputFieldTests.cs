using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine;
using FallenLand;
using UnityEngine.UI;

namespace Tests
{
	public class UserNameInputFieldTests
	{
		private GameObject GameObj;

		[SetUp]
		public void Setup()
		{
			GameObj = new GameObject();
			PlayerPrefs.DeleteKey("PlayerName");
		}

		[TearDown]
		public void Teardown()	
		{
			GameObj = null;
		}

		[UnityTest]
		public IEnumerator TestInputFieldDefault()
		{
			GameObj.AddComponent<UserNameInputField>();
			UserNameInputField UserNameInputFieldObj = GameObj.GetComponent<UserNameInputField>();

			yield return null;

			InputField nameInputField = UserNameInputFieldObj.GetComponent<InputField>();
			Assert.IsNotNull(nameInputField);
			Assert.AreEqual(string.Empty, nameInputField.text);
		}

		[UnityTest]
		public IEnumerator TestPlayerPreferenceSet()
		{
			GameObj.AddComponent<UserNameInputField>();
			UserNameInputField UserNameInputFieldObj = GameObj.GetComponent<UserNameInputField>();
			PlayerPrefs.SetString("PlayerName", "JSB");

			yield return null;

			InputField nameInputField = UserNameInputFieldObj.GetComponent<InputField>();
			Assert.IsNotNull(nameInputField);
			Assert.AreEqual("JSB", nameInputField.text);
		}

		[UnityTest]
		public IEnumerator TestSetPlayerName()
		{
			GameObj.AddComponent<UserNameInputField>();
			UserNameInputField UserNameInputFieldObj = GameObj.GetComponent<UserNameInputField>();

			yield return null;

			UserNameInputFieldObj.SetPlayerName("Test name");
			InputField nameInputField = UserNameInputFieldObj.GetComponent<InputField>();
			Assert.IsNotNull(nameInputField);
			Assert.AreEqual("Test name", nameInputField.text);

			UserNameInputFieldObj.SetPlayerName("");
			Assert.AreEqual("Test name", nameInputField.text);
			UserNameInputFieldObj.SetPlayerName(null);
			Assert.AreEqual("Test name", nameInputField.text);
		}
	}
}