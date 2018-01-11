using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleDependency : MonoBehaviour {
	/*
	 * 
	 * THIS CLASS SHOULD BE ADDED TO ANY GAME MODIFIER THAT CANNOT BE ACTIVE UNLESS ANOTHER MODIFIER IS ACTIVE
	 * ADD THIS SCRIPT TO THE CHILD MODIFIER
	 * 
	 */


	public Toggle parentModifier;

	void Update() {
		checkIfParentActive();
	}

	public void checkIfParentActive() {
		//A dependent modifier can't be on if the parent isn't on
		if (!parentModifier.isOn) {
			this.transform.GetComponentInChildren<Toggle> ().isOn = false;
			this.transform.GetComponentInChildren<Toggle> ().interactable = false;
		} else {
			this.transform.GetComponentInChildren<Toggle> ().interactable = true;
		}
	}

}
