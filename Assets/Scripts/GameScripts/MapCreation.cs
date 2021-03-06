﻿using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class MapCreation : MonoBehaviour
	{
		public const int MAP_HEIGHT = 23;
		public const int MAP_WIDTH = 34;
		public const int HEX_PREFAB_SCALE = 3;
		public const float HEX_HEIGHT = 0.134497f * HEX_PREFAB_SCALE; //snagged from blender
		public const float HEX_WIDTH = 1.0001f * HEX_PREFAB_SCALE;
		public const float HEX_LENGTH = 0.86834f * HEX_PREFAB_SCALE;

		private const float LeftRightOffset = .860f * HEX_PREFAB_SCALE;
		private const float UpDownOffset = .740f * HEX_PREFAB_SCALE;
		private const int NUM_RANDOM_LOCATIONS = 100;
		private readonly GameObject[,] MapOfHexes;
		private List<Faction> Factions;
		private GameObject HexTilePrefab;
		private MapLayout MapLayoutInst;
		private GameObject GameBoardPrefab;

		public MapCreation()
		{
			//Set map size
			MapOfHexes = new GameObject[MAP_WIDTH, MAP_HEIGHT];
		}

		public void CreateMap(MapLayout mapLayout)
		{
			HexTilePrefab = (GameObject)Resources.Load("Prefabs/HexNoSlantsPrefab", typeof(GameObject));
			if (HexTilePrefab == null)
			{
				Debug.LogError("HexTilePrefab null");
			}

			if (MapLayoutInst != null || mapLayout != null)
			{
				MapLayoutInst = mapLayout;
			}
			else
			{
				Debug.LogError("Error, map layout not set. Using default");
				MapLayoutInst = new DefaultMapLayout();
			}

			//Load default factions
			Factions = new DefaultFactionInfo().GetDefaultFactionList();

			for (int LR = 0; LR < MAP_WIDTH; LR++)
			{
				for (int UD = 0; UD < MAP_HEIGHT; UD++)
				{
					float lrPos = LR * LeftRightOffset;
					float udPos = UD * UpDownOffset;

					//Odd row needs half an offset added on
					if (UD % 2 == 1)
					{
						lrPos += LeftRightOffset / 2f;
					}

					GameObject curHex = null;

					//Create a hex and change its starting information
					if (MapLayoutInst.IsHexInGame(LR, UD))
					{
						//Debug.Log("lr " + lrPos + " ud " + udPos);
						curHex = (GameObject)Instantiate(HexTilePrefab, new Vector3(lrPos, 0, udPos), Quaternion.identity); //Create hexTile, at given vector, with no rotation
						configureHex(curHex, LR, UD, lrPos, udPos);
					}

					//Store the hex
					MapOfHexes[LR, UD] = curHex;
				}
			}

			createBoard();
		}

		public GameWorldCoordinates GetFactionGameLocationFromCoordinates(Coordinates coords)
		{
			GameWorldCoordinates worldCoords = null;
			for (int LR = 0; LR < MAP_WIDTH; LR++)
			{
				for (int UD = 0; UD < MAP_HEIGHT; UD++)
				{
					GameObject go = MapOfHexes[LR, UD];
					if (go != null)
					{
						Hex hex = go.GetComponent<Hex>();
						if (hex != null && hex.IsFactionBase())
						{
							Coordinates baseLoc = hex.GetFaction().GetBaseLocation();
							if (baseLoc.Equals(coords))
							{
								worldCoords = hex.GetGameWorldCoords();
							}
						}
					}
				}
			}

			return worldCoords;
		}

		public GameWorldCoordinates GetRandomLocGameLocationFromCoordinates(Coordinates coords)
		{
			GameWorldCoordinates worldCoords = null;
			for (int LR = 0; LR < MAP_WIDTH; LR++)
			{
				for (int UD = 0; UD < MAP_HEIGHT; UD++)
				{
					GameObject go = MapOfHexes[LR, UD];
					if (go != null)
					{
						Hex hex = go.GetComponent<Hex>();
						if (hex != null && hex.IsRandomLocation())
						{
							Coordinates randomLoc = hex.GetCoordinates();
							if (randomLoc.Equals(coords))
							{
								worldCoords = hex.GetGameWorldCoords();
							}
						}
					}
				}
			}

			return worldCoords;
		}

		public GameWorldCoordinates GetResourceGameLocationFromCoordinates(Coordinates coords)
		{
			GameWorldCoordinates worldCoords = null;
			for (int LR = 0; LR < MAP_WIDTH; LR++)
			{
				for (int UD = 0; UD < MAP_HEIGHT; UD++)
				{
					GameObject go = MapOfHexes[LR, UD];
					if (go != null)
					{
						Hex hex = go.GetComponent<Hex>();
						if (hex != null && hex.IsResource())
						{
							Coordinates resourceLoc = hex.GetCoordinates();
							if (resourceLoc.Equals(coords))
							{
								worldCoords = hex.GetGameWorldCoords();
							}
						}
					}
				}
			}

			return worldCoords;
		}

		public GameWorldCoordinates GetGameLocationFromCoordinates(Coordinates coords)
		{
			GameWorldCoordinates worldCoords = null;
			for (int LR = 0; LR < MAP_WIDTH; LR++)
			{
				for (int UD = 0; UD < MAP_HEIGHT; UD++)
				{
					GameObject go = MapOfHexes[LR, UD];
					if (go != null)
					{
						Hex hex = go.GetComponent<Hex>();
						if (hex != null)
						{
							Coordinates hexLocation = hex.GetCoordinates();
							if (hexLocation.Equals(coords))
							{
								worldCoords = hex.GetGameWorldCoords();
							}
						}
					}
				}
			}
			return worldCoords;
		}

		private void configureHex(GameObject go, int x, int y, float xInGameWorld, float yInGameWorld)
		{
			go.name = "Hex_" + x + "_" + y; //Name the hex
			go.transform.SetParent(this.transform); //Put the hex into the map object
			go.isStatic = true; //The hex won't be moving

			//Define the hex's attributes
			Coordinates coords = new Coordinates(x, y);
			GameWorldCoordinates gameCoords = new GameWorldCoordinates(xInGameWorld, yInGameWorld);
			go.AddComponent<Hex>();
			go.GetComponent<Hex>().SetCoordinates(coords);
			go.GetComponent<Hex>().SetGameWorldCoordinates(gameCoords);
			go.GetComponent<Hex>().SetIsCity(MapLayoutInst.IsCity(coords));
			go.GetComponent<Hex>().SetIsMountain(MapLayoutInst.IsMountain(coords));
			go.GetComponent<Hex>().SetIsRad(MapLayoutInst.IsRad(coords));
			go.GetComponent<Hex>().SetIsFactionBase(MapLayoutInst.IsFactionBase(coords));
			go.GetComponent<Hex>().SetIsPlains(MapLayoutInst.IsPlains(coords));
			go.GetComponent<Hex>().SetIsRandomLocation(MapLayoutInst.IsRandomLocation(coords));
			go.GetComponent<Hex>().SetIsWater(MapLayoutInst.IsWater(coords));
			go.GetComponent<Hex>().SetIsResource(MapLayoutInst.IsResource(coords));
			go.GetComponent<Hex>().SetIsHexInGame(MapLayoutInst.IsHexInGame(coords));

			//Set the faction base, if needed
			if (go.GetComponent<Hex>().IsFactionBase())
			{
				foreach (Faction f in Factions)
				{
					if (f.GetBaseLocation().Equals(go.GetComponent<Hex>().GetCoordinates()))
					{
						go.GetComponent<Hex>().SetFaction(f);
					}
				}
			}

			//Set random location number, if needed
			if (go.GetComponent<Hex>().IsRandomLocation())
			{
				for (int loc = 1; loc <= NUM_RANDOM_LOCATIONS; loc++)
				{
					if (DefaultRandomNumberLocations.RAND_NUM_LOCATIONS[loc].Equals(go.GetComponentInChildren<Hex>().GetCoordinates()))
					{
						go.GetComponent<Hex>().SetRandomLocationNumber(loc);
						break;
					}
				}
			}

			//Set the start color of the hex
			go.transform.Find("OuterHex").GetComponentInChildren<MeshRenderer>().material.color = Color.gray;

			//Set the texture of the hex
			string fileName = "Hexes/Hex_" + x.ToString() + "_" + y.ToString();
			Texture2D loadTex = Resources.Load(fileName) as Texture2D;
			go.GetComponentInChildren<Renderer>().material.mainTexture = loadTex;
		}

		private void createBoard()
		{
			GameBoardPrefab = (GameObject)Resources.Load("Prefabs/GameBoard", typeof(GameObject));
			GameObject boardObject = (GameObject)Instantiate(GameBoardPrefab, new Vector3(44.56f, .28f, 24.6f), Quaternion.identity);
			boardObject.transform.Rotate(-90, 0, -90);
		}
	}
}
