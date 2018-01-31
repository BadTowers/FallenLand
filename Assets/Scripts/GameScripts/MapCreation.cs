﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MapCreation : MonoBehaviour {

	public GameObject hexTilePrefab;
	public const int height = 23;
	public const int width = 34;
	public const int scale = 3;
	public MapLayout ml;
	private const float LROffset = .860f * scale;
	private const float UDOffset = .740f * scale;
	private const int NUM_RANDOM_LOCATIONS = 100;
	private GameObject[,] mapOfHexes;

	// Use this for initialization (for debugging only, creates a default map layout and creates the map)
	/*
	void Start () {
		
		//Can be changed to RandomMapLayout later if desired
		ml = new DefaultMapLayout();

		//Debug.Log (newGameState.GetComponent("GameCreation").gameMode);

		//Assign the hexes their properties
		createMap();
	}
	*/

	public void createMap()
	{
		mapOfHexes = new GameObject[width, height];

		if(ml == null) {
			Debug.Log("Error, map layout not set. Using default");
			ml = new DefaultMapLayout();
		}

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
				//Debug.Log("x: " + LR + "   y: " + UD);
				if (ml.isHexInGame (LR, UD)) {
					curHex = (GameObject)Instantiate (hexTilePrefab, new Vector3 (lrPos, 0, udPos), Quaternion.identity); //Create hexTile, at given vector, with no rotation
					configureHex (curHex, LR, UD);
				}

				//Store the hex
				mapOfHexes[LR, UD] = curHex;
			}
		}
	}

	private void configureHex(GameObject go, int x, int y)
	{
		go.name = "Hex_" + x + "_" + y; //Name the hex
		go.transform.SetParent (this.transform); //Put the hex into the map object
		go.isStatic = true; //The hex won't be moving

		//Define the hex's attributes
		Coordinates coords = new Coordinates(x, y);
		go.AddComponent<Hex>();
		go.GetComponent<Hex>().setCoordinates(coords);
		go.GetComponent<Hex>().setIsCity(ml.isCity(coords));
		go.GetComponent<Hex>().setIsMountain(ml.isMountain(coords));
		go.GetComponent<Hex>().setIsRad(ml.isRad(coords));
		go.GetComponent<Hex>().setIsFactionBase(ml.isFactionBase(coords));
		go.GetComponent<Hex>().setIsPlains(ml.isPlains(coords));
		go.GetComponent<Hex>().setIsRandomLocation(ml.isRandomLocation(coords));
		go.GetComponent<Hex>().setIsWater(ml.isWater(coords));
		go.GetComponent<Hex>().setIsResource(ml.isResource(coords));
		go.GetComponent<Hex>().setIsHexInGame(ml.isHexInGame(coords));

		//Set the faction base, if needed
		if (go.GetComponent<Hex>().isFactionBase()) {
			foreach (Factions.name fac in Enum.GetValues((typeof(Factions.name)))) {
				if (DefaultFactionLocations.FACTION_LOCATIONS[fac].Equals (go.GetComponent<Hex>().getCoordinates ())) {
					go.GetComponent<Hex>().setFaction (fac);
					//go.transform.Find("OuterHex").GetComponentInChildren<MeshRenderer>().material.color = Color.white; //Debug thingy
				}
			}
		}

		//Set random location number, if needed
		if(go.GetComponent<Hex>().isRandomLocation())
		{
			for(int loc = 1; loc <= NUM_RANDOM_LOCATIONS; loc++){
				if (DefaultRandomNumberLocations.RAND_NUM_LOCATIONS[loc].Equals(go.GetComponentInChildren<Hex>().getCoordinates ())) {
					go.GetComponent<Hex>().setRandomLocation(loc);
					//go.transform.Find("OuterHex").GetComponentInChildren<MeshRenderer>().material.color = Color.cyan; //Debug thingy
					break;
				}
			}
		}

		//Set the start color of the hex
		//go.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
		go.transform.Find("OuterHex").GetComponentInChildren<MeshRenderer>().material.color = Color.gray;

		//Set the texture of the hex
		string fileName = "Hexes/Hex_" + x.ToString() + "_" + y.ToString();
		Texture2D loadTex = Resources.Load (fileName) as Texture2D;
		go.GetComponentInChildren<Renderer> ().material.mainTexture = loadTex;
	}
}
