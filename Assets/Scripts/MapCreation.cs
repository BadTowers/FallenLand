using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour {

	public GameObject hexTilePrefab;
	public const int height = 23;
	public const int width = 33;
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
				if (DefaultMapLayout.isHexInGame(LR, UD))
				{
					curHex = (GameObject)Instantiate (hexTilePrefab, new Vector3(lrPos, 0, udPos), Quaternion.identity); //Create hexTile, at given vector, with no rotation
					configureHex(curHex, LR, UD);

					//Set the start color of the hex
					MeshRenderer curMR = curHex.GetComponentInChildren<MeshRenderer>();
					curMR.material.color = Color.white;
				}
			}
		}
	}

	private void configureHex(GameObject hex, int x, int y)
	{
		hex.name = "Hex_" + x + "_" + y; //Name the hex
		hex.transform.SetParent (this.transform); //Put the hex into the map object
		hex.isStatic = true; //The hex won't be moving

		//Define the hex's attributes
		hex.AddComponent<Hex>();
		hex.GetComponent<Hex>().x = x;
		hex.GetComponent<Hex>().y = y;
		hex.GetComponent<Hex>().setIsCity(DefaultMapLayout.isCity(x, y));
		hex.GetComponent<Hex>().setIsMountain(DefaultMapLayout.isMountain(x, y));
		hex.GetComponent<Hex>().setIsRad(DefaultMapLayout.isRad(x, y));
		hex.GetComponent<Hex>().setIsFactionBase(DefaultMapLayout.isFactionBase(x, y));
		hex.GetComponent<Hex>().setIsPlains(DefaultMapLayout.isPlains(x, y));
		hex.GetComponent<Hex>().setIsRandomNumber(DefaultMapLayout.isRandomNumber(x, y));
		hex.GetComponent<Hex>().setIsWater(DefaultMapLayout.isWater(x, y));
		//hex.GetComponent<Hex>().setFaction(DefaultMapLayout.faction(x, y));
		hex.GetComponent<Hex>().setIsResource(DefaultMapLayout.isResource(x, y));
		hex.GetComponent<Hex>().setIsVisible(DefaultMapLayout.isVisible(x, y));
	}
}
