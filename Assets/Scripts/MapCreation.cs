using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour {

	public GameObject hexTilePrefab;
	private int height = 21;
	private int width = 31;
	private float LROffset = .860f;
	private float UDOffset = .740f;

	// Use this for initialization
	void Start () {
		for (int LR = 0; LR < width; LR++) { //Left/right
			for (int UD = 0; UD < height; UD++) { //Up/down

				float lrPos = LR * LROffset;
				float udPos = UD * UDOffset;

				//Odd row needs half an offset added on
				if (UD % 2 == 1) {
					lrPos += LROffset / 2f;
				}

				//Create a hex and change its starting information
				GameObject curHex = (GameObject)Instantiate (hexTilePrefab, new Vector3(lrPos, 0, udPos), Quaternion.identity); //Create hexTile, at given vector, with no rotation
				curHex.name = "Hex_" + LR + "_" + UD; //Name the hex
				curHex.transform.SetParent (this.transform); //Put the hex into the map object
				curHex.isStatic = true; //The hex won't be moving
				curHex.AddComponent<HexInformation>(); //Add hex information object to current hex
				curHex.GetComponent<HexInformation>().x = LR; //Set X location for hex
				curHex.GetComponent<HexInformation>().y = UD; //Set Y location for hex

				MeshRenderer curMR = curHex.GetComponentInChildren<MeshRenderer>(); //Get the mesh of the current hex
				curMR.material.color = Color.white; //Set the color to be white initially
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
