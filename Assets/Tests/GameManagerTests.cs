using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using FallenLand;
using UnityEngine;
using UnityEngine.UI;

namespace Tests
{
	public class GameManagerTests
	{
		public GameObject GameManagerObject;

		[SetUp]
		public void Setup()
		{
			GameManagerObject = new GameObject();
			//GameManagerObject.AddComponent<GameManager>();
		}

		[TearDown]
		public void Teardown()
		{
		}

		//[UnityTest]
		//public IEnumerator Test1()
		//{

		//	yield return null;
		//}
	}
}