using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour {

	public GameObject hexTilePrefab;
	private const int height = 23;
	private const int width = 33;
	private const float LROffset = .860f;
	private const float UDOffset = .740f;
	private GameObject[,] mapOfHexes;

	// Use this for initialization
	void Start () {
		mapOfHexes = new GameObject[width, height];

		createDefaultMap();
	}

	private void createDefaultMap()
	{
		for (int LR = 0; LR < width; LR++) { //Left/right
			for (int UD = 0; UD < height; UD++) { //Up/down

				float lrPos = LR * LROffset;
				float udPos = UD * UDOffset;

				//Odd row needs half an offset added on
				if (UD % 2 == 1) {
					lrPos += LROffset / 2f;
				}

				GameObject curHex = null;

				//Create a hex and change its starting information
				if (createHex(LR, UD)) {
					curHex = (GameObject)Instantiate (hexTilePrefab, new Vector3(lrPos, 0, udPos), Quaternion.identity); //Create hexTile, at given vector, with no rotation
					curHex.name = "Hex_" + LR + "_" + UD; //Name the hex
					curHex.transform.SetParent (this.transform); //Put the hex into the map object
					curHex.isStatic = true; //The hex won't be moving

					//Add location information to the hex
					curHex.AddComponent<HexInformation>();
					curHex.GetComponent<HexInformation>().x = LR;
					curHex.GetComponent<HexInformation>().y = UD;

					//Set the start color of the hex
					MeshRenderer curMR = curHex.GetComponentInChildren<MeshRenderer>();
					curMR.material.color = Color.white;
				}
			}
		}
	}

	private bool createHex(int x, int y)
	{

	}
}
