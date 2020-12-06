using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
    public class PlayerPieceManager : MonoBehaviour
    {
        private List<GameObject> PlayerPieces;
        private MapCreation Map;
        private const float X_OFFSET = 0.04f;
        private const float Y_OFFSET = 0f;

        public PlayerPieceManager()
        {
            PlayerPieces = new List<GameObject>();
        }

        public void CreatePiece(Faction faction)
        {
            if (Map != null)
            {
                string pieceName = "PlayerPiece" + faction.GetId().ToString();
                GameObject playerPiecePrefab = (GameObject)Resources.Load("Prefabs/" + pieceName, typeof(GameObject));

                GameWorldCoordinates gameCoords = Map.GetFactionGameLocationFromCoordinates(faction.GetBaseLocation());
                GameObject curPiece = (GameObject)Instantiate(playerPiecePrefab, new Vector3(gameCoords.GetX() + X_OFFSET, MapCreation.HEX_HEIGHT, gameCoords.GetY() + Y_OFFSET), Quaternion.identity);
                curPiece.transform.Rotate(0, 180, 0);
                curPiece.name = pieceName;
                curPiece.isStatic = true;

                curPiece.transform.Find("CylinderOuter").GetComponentInChildren<MeshRenderer>().material.color = Color.magenta;

                PlayerPieces.Add(curPiece);
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