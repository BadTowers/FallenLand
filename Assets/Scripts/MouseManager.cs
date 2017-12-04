﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {

	//GameObject

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		//If we are over a Unity UI element
		//if (EventSystem.current.IsPointerOverGameObject ()) {
			//It is, so let's not do any game click code
		//	return;
		//}

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Get a vector called a Ray from the mouse through the world

		RaycastHit objectHitInfo; //Object the raycast hit, if any

		//Check if the ray hit any colliders
		if(Physics.Raycast(ray, out objectHitInfo))
		{
			GameObject ourHitObject = objectHitInfo.collider.transform.gameObject; //Get the object the mouse is over

			//Moused over a hex
			if (ourHitObject.GetComponent<HexInformation> () != null) {

			}

			//We know here what we are mousing over, so we could show a tooltip
			//TODO

			//We can check if we are clicking on the thing the raycast hit, we can interpret that here
			if (Input.GetMouseButtonDown(0)) {
				MeshRenderer[] mr = ourHitObject.GetComponentsInChildren<MeshRenderer>();

				toggleColor(mr[0]);
			}
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
}
