using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
    public class MissionPieceManager : MonoBehaviour
    {
        private List<GameObject> MissionPieces;
        private MapCreation Map;
        private const float X_OFFSET = 0.04f;
        private const float Y_OFFSET = 0f;
        private const float Z_OFFSET = 0.1f;

        public MissionPieceManager()
        {
            MissionPieces = new List<GameObject>();
        }

        public void CreatePiece(int missionNum, Coordinates coords)
        {
            if (Map != null)
            {
                string pieceName = "MissionPiece" + missionNum.ToString();
                GameObject missionPrefab = (GameObject)Resources.Load("Prefabs/" + pieceName, typeof(GameObject));

                GameWorldCoordinates gameCoords = Map.GetRandomLocGameLocationFromCoordinates(coords);
                GameObject curPiece = (GameObject)Instantiate(missionPrefab, new Vector3(gameCoords.GetX() + X_OFFSET, MapCreation.HEX_HEIGHT + Z_OFFSET, gameCoords.GetY() + Y_OFFSET), Quaternion.identity);
                curPiece.transform.Rotate(-90, 180, 0);
                curPiece.name = pieceName;
                curPiece.isStatic = true;

                MissionPieces.Add(curPiece);
            }
            else
            {
                Debug.LogError("Map wasn't set for Mission Piece Manager. Cannot create piece!");
            }
        }

        public void SetMap(MapCreation map)
        {
            Map = map;
        }
    }
}