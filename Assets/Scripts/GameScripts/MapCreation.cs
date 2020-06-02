using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class MapCreation : MonoBehaviour
	{
		public const int MAP_HEIGHT = 23;
		public const int MAP_WIDTH = 34;
		public const int MAP_SCALE = 3;

		private const float LeftRightOffset = .860f * MAP_SCALE;
		private const float UpDownOffset = .740f * MAP_SCALE;
		private const int NUM_RANDOM_LOCATIONS = 100;
		private GameObject[,] MapOfHexes;
		private List<Faction> Factions;
		private GameObject HexTilePrefab;
		private MapLayout MapLayout;

		public void CreateMap()
		{
			HexTilePrefab = (GameObject)Resources.Load("Prefabs/HexNoSlantsPrefab", typeof(GameObject));
			if (HexTilePrefab == null)
			{
				Debug.LogError("HexTilePrefab null");
			}

			//Set map size
			MapOfHexes = new GameObject[MAP_WIDTH, MAP_HEIGHT];

			if (MapLayout == null)
			{
				Debug.Log("Error, map layout not set. Using default");
				MapLayout = new DefaultMapLayout();
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
					if (MapLayout.IsHexInGame(LR, UD))
					{
						curHex = (GameObject)Instantiate(HexTilePrefab, new Vector3(lrPos, 0, udPos), Quaternion.identity); //Create hexTile, at given vector, with no rotation
						configureHex(curHex, LR, UD);
					}

					//Store the hex
					MapOfHexes[LR, UD] = curHex;
				}
			}
		}

		private void configureHex(GameObject go, int x, int y)
		{
			go.name = "Hex_" + x + "_" + y; //Name the hex
			go.transform.SetParent(this.transform); //Put the hex into the map object
			go.isStatic = true; //The hex won't be moving

			//Define the hex's attributes
			Coordinates coords = new Coordinates(x, y);
			go.AddComponent<Hex>();
			go.GetComponent<Hex>().SetCoordinates(coords);
			go.GetComponent<Hex>().SetIsCity(MapLayout.IsCity(coords));
			go.GetComponent<Hex>().SetIsMountain(MapLayout.IsMountain(coords));
			go.GetComponent<Hex>().SetIsRad(MapLayout.IsRad(coords));
			go.GetComponent<Hex>().SetIsFactionBase(MapLayout.IsFactionBase(coords));
			go.GetComponent<Hex>().SetIsPlains(MapLayout.IsPlains(coords));
			go.GetComponent<Hex>().SetIsRandomLocation(MapLayout.IsRandomLocation(coords));
			go.GetComponent<Hex>().SetIsWater(MapLayout.IsWater(coords));
			go.GetComponent<Hex>().SetIsResource(MapLayout.IsResource(coords));
			go.GetComponent<Hex>().SetIsHexInGame(MapLayout.IsHexInGame(coords));

			//Set the faction base, if needed
			if (go.GetComponent<Hex>().IsFactionBase())
			{
				foreach (Faction f in Factions)
				{
					if (f.GetBaseLocation().Equals(go.GetComponent<Hex>().GetCoordinates()))
					{
						go.GetComponent<Hex>().SetFaction(f);
						//go.transform.Find("OuterHex").GetComponentInChildren<MeshRenderer>().material.color = Color.white; //Debug thingy
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
			Texture2D loadTex = Resources.Load(fileName) as Texture2D;
			go.GetComponentInChildren<Renderer>().material.mainTexture = loadTex;
		}
	}
}
