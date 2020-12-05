using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
    public class PlayerPieceManager : MonoBehaviour
    {
        private List<GameObject> PlayerPiecePrefabs;
        private MapCreation Map;
        private const float X_OFFSET = 0.04f;
        private const float Y_OFFSET = 0f;

        public PlayerPieceManager()
        {
        }

        public void CreatePiece(Faction faction)
        {
            PlayerPiecePrefabs = new List<GameObject>();
            string pieceName = "Piece" + faction.GetId().ToString();
            PlayerPiecePrefabs.Add((GameObject)Resources.Load("Prefabs/" + pieceName, typeof(GameObject)));

            if (Map != null)
            {
                GameWorldCoordinates gameCoords = Map.GetGameLocationFromCoordinates(faction.GetBaseLocation());
                GameObject curPiece = (GameObject)Instantiate(PlayerPiecePrefabs[0], new Vector3(gameCoords.GetX() + X_OFFSET, MapCreation.HEX_HEIGHT, gameCoords.GetY() + Y_OFFSET), Quaternion.identity);
                curPiece.transform.Rotate(0, 180, 0);
                curPiece.name = pieceName;
                curPiece.isStatic = true;

                curPiece.transform.Find("CylinderOuter").GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
            }
            else
            {
                Debug.LogError("Map wasn't set for Game Piece Manager. Cannot create piece!");
            }
        }

        public void SetMap(MapCreation map)
        {
            Map = map;
        }
    }
}