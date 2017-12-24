using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour {

	public GameObject hexInformationBackground;
	public GameObject hexInformationText;

	//GameObject currentlySelected TODO
	private string toolTipText = "";

	void Start() {
		// Start the tooltips for hex information as hidden
		hexInformationText.SetActive (false);
		hexInformationBackground.SetActive (false);
	}
	
	// Update is called once per frame
	void Update() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Get a vector called a Ray from the mouse through the world

		RaycastHit objectHitInfo; //Object the raycast hit, if any

		//Check if the ray hit any colliders
		if (Physics.Raycast (ray, out objectHitInfo)) {
			GameObject ourHitObject = objectHitInfo.collider.transform.gameObject; //Get the object the mouse is over

			//We know here what we are mousing over
			if (ourHitObject.name != null) {
				MouseOverHex (ourHitObject);
			}
		} else {
			disableHexInfo();
		}
	}

	//Moused over a hex
	void MouseOverHex(GameObject go)
	{
		//If left clicking
		if (Input.GetMouseButtonDown (0)) {
			//If we clicked a Unity UI element
			if (EventSystem.current.IsPointerOverGameObject()) {
				//It is, so let's not do any game click code
				return;
			}

			MeshRenderer mr;
			//Each hex is made of 2 hexes, and inner and an outer. Get the mesh of the inner hex.
			if (go.name == "OuterHex") {
				mr = go.transform.parent.Find("InnerHex").GetComponentInChildren<MeshRenderer> ();
			} else {
				mr = go.GetComponentInChildren<MeshRenderer> ();
			}

			toggleColor (mr);
		} else {
			string info = getHexInfoString(go.transform.GetComponentInParent<Hex>());
			enableHexInfo(info);
		}
	}

	//Toggle the color of the mesh render sent in
	void toggleColor(MeshRenderer mr)
	{
		if (mr.material.color == Color.white) {
			mr.material.color = Color.blue;
		} else {
			mr.material.color = Color.white;
		}
	}

	void enableHexInfo(string text)
	{
		toolTipText = text;
		hexInformationText.SetActive (true);
		hexInformationBackground.SetActive (true);
	}

	void disableHexInfo()
	{
		toolTipText = ""; //Reset the tooltip text when you aren't mousing over something
		hexInformationText.SetActive (false);
		hexInformationBackground.SetActive (false);
	}

	string getHexInfoString(Hex hex)
	{
		StringBuilder toReturn = new StringBuilder();
		toReturn.Append(hex.name);
		toReturn.Append(Environment.NewLine);
		if (hex.isRad ()) {
			toReturn.Append("Rad" + Environment.NewLine);
		}
		if (hex.isCity ()) {
			toReturn.Append("City" + Environment.NewLine);
		}
		if (hex.isMountain ()) {
			toReturn.Append ("Mountain" + Environment.NewLine);
		}
		if (hex.isPlains ()) {
			toReturn.Append ("Plains" + Environment.NewLine);
		}
		if (hex.isRandomLocation ()) {
			toReturn.Append("R: ");
			toReturn.Append(hex.getRandomLocation());
			toReturn.Append (Environment.NewLine);
		}
		if (hex.isResource ()) {
			toReturn.Append ("Resource" + Environment.NewLine);
		}
		if(hex.isFactionBase()){
			toReturn.Append("F: ");
			toReturn.Append(hex.getFaction());
			toReturn.Append(Environment.NewLine);
		}

		return toReturn.ToString ();
	}

	void OnGUI()
	{
		if (toolTipText != "") {
			hexInformationText.GetComponent<Text>().text = toolTipText;
		}
	}
}
