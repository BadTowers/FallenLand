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
	public GameObject pauseMenu;

	//GameObject currentlySelected TODO
	private string toolTipText = "";

	void Start() {
		// Start the tooltips for hex information as hidden
		hexInformationText.SetActive (false);
		hexInformationBackground.SetActive (false);
	}

	// Update is called once per frame
	void Update() {
		//Don't do any game UI if the game is paused
		if(pauseMenu.activeSelf) {
			disableHexInfo(); //Don't show the hex info if paused
			return;
		}

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
			Debug.Log("Clicked a hex");
			//If we clicked a Unity UI element
			if (EventSystem.current.IsPointerOverGameObject()) {
				//It is, so let's not do any game click code
				Debug.Log("Clicked a game object");
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
		Debug.Log("toggleColor");
		if (mr.material.color == Color.white)
		{
			Debug.Log("blue");
			mr.material.color = Color.blue;
		} else
		{
			Debug.Log("white");
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
		if (hex.IsRad ()) {
			toReturn.Append("Rad" + Environment.NewLine);
		}
		if (hex.IsCity ()) {
			toReturn.Append("City" + Environment.NewLine);
		}
		if (hex.IsMountain ()) {
			toReturn.Append ("Mountain" + Environment.NewLine);
		}
		if (hex.IsPlains ()) {
			toReturn.Append ("Plains" + Environment.NewLine);
		}
		if (hex.IsRandomLocation ()) {
			toReturn.Append("R: ");
			toReturn.Append(hex.GetRandomLocationNumber());
			toReturn.Append (Environment.NewLine);
		}
		if (hex.IsResource ()) {
			toReturn.Append ("Resource" + Environment.NewLine);
		}
		if(hex.IsFactionBase()){
			toReturn.Append("F: ");
			toReturn.Append(hex.GetFaction());
			toReturn.Append(Environment.NewLine);
		}
		if (hex.IsWater ()) {
			toReturn.Append ("Water" + Environment.NewLine);
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
