using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine;
using UnityEngine.UI;
using FallenLand;

namespace Tests
{
	public class ToggleDependencyTests
	{
		private GameObject GameObj;
		private ToggleDependency ToggleDep;

		[SetUp]
		public void Setup()
		{
			GameObj = new GameObject();

			GameObj.AddComponent<ToggleDependency>();
			GameObj.AddComponent<Toggle>();
			ToggleDep = GameObj.GetComponent<ToggleDependency>();
			ToggleDep.parentModifier = GameObj.GetComponent<Toggle>();
		}

		[TearDown]
		public void Teardown()
		{
			Object.Destroy(GameObj);
			ToggleDep = null;
		}

		[UnityTest]
		public IEnumerator TestToggleDependencyWorksDependingOnParentState()
		{
			ToggleDep.parentModifier.isOn = false;
			yield return null;
			Assert.IsFalse(ToggleDep.transform.GetComponentInChildren<Toggle>().interactable);

			ToggleDep.parentModifier.isOn = true;
			yield return null;
			Assert.IsTrue(ToggleDep.transform.GetComponentInChildren<Toggle>().interactable);
		}
	}
}