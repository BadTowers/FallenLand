using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
    public class ResourcePieceManager : MonoBehaviour
    {
        private List<List<GameObject>> PlayerResourcePieces;
        private List<List<Coordinates>> PlayerResourcePiecesLocations;
        private MapCreation Map;
        private const float X_OFFSET = 0.04f;
        private const float Y_OFFSET = 0f;

        public ResourcePieceManager()
        {
            PlayerResourcePieces = new List<List<GameObject>>();
            PlayerResourcePiecesLocations = new List<List<Coordinates>>();
            for (int playerIndex = 0; playerIndex < Constants.MAX_NUM_PLAYERS; playerIndex++)
            {
                PlayerResourcePieces.Add(new List<GameObject>());
                PlayerResourcePiecesLocations.Add(new List<Coordinates>());
            }
        }

        public void CreatePiece(int playerIndex, Faction faction, Coordinates resourceLocation)
        {
            if (Map != null)
            {
                string pieceName = "PlayerPiece" + faction.GetId().ToString();
                GameObject playerPiecePrefab = (GameObject)Resources.Load("Prefabs/" + pieceName, typeof(GameObject));

                GameWorldCoordinates gameCoords = Map.GetResourceGameLocationFromCoordinates(resourceLocation);
                GameObject curPiece = (GameObject)Instantiate(playerPiecePrefab, new Vector3(gameCoords.GetX() + X_OFFSET, MapCreation.HEX_HEIGHT, gameCoords.GetY() + Y_OFFSET), Quaternion.identity);
                curPiece.transform.Rotate(0, 180, 0);
                curPiece.transform.localScale = new Vector3(0.65f, 0.95f, 0.65f);
                curPiece.name = pieceName + "_resource";
                curPiece.isStatic = true;

                curPiece.transform.Find("CylinderOuter").GetComponentInChildren<MeshRenderer>().material.color = Color.cyan;

                if (playerIndex < PlayerResourcePieces.Count)
                {
                    PlayerResourcePieces[playerIndex].Add(curPiece);
                    PlayerResourcePiecesLocations[playerIndex].Add(resourceLocation);
                }
                else
                {
                    Debug.LogError("Tried to create a player resource piece for player index " + playerIndex.ToString() + ", but that's larger than the max number of players!");
                }
            }
            else
            {
                Debug.LogError("Map wasn't set for Game Piece Manager. Cannot create piece!");
            }
        }

        public void RemovePiece(int playerIndex, Coordinates resourceLocation)
        {
            int resourceIndex = Constants.INVALID_INDEX;
            for (int resourcePieceIndex = 0; resourcePieceIndex < PlayerResourcePiecesLocations[playerIndex].Count; resourcePieceIndex++)
            {
                Coordinates curCoords = PlayerResourcePiecesLocations[playerIndex][resourcePieceIndex];
                if (curCoords.Equals(resourceLocation))
                {
                    resourceIndex = resourcePieceIndex;
                    break;
                }
            }
            if (resourceIndex != Constants.INVALID_INDEX)
            {
                Destroy(PlayerResourcePieces[playerIndex][resourceIndex]);
                PlayerResourcePieces[playerIndex].RemoveAt(resourceIndex);
                PlayerResourcePiecesLocations[playerIndex].RemoveAt(resourceIndex);
            }
            else
            {
                Debug.LogError("RemovePiece was called for location " + resourceLocation.ToString() + ", but no such piece was found at this location");
            }
        }

        public void SetMap(MapCreation map)
        {
            Map = map;
        }
    }
}