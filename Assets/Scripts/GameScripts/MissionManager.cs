using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
    public class MissionManager
    {
        private GameObject MissionPieceManagerGameObject;
        private MissionPieceManager MissionPieceManagerInst;
        private List<Coordinates> MissionLocations;
        private List<int> RandomNumberLocations;

        public MissionManager()
        {
            MissionPieceManagerGameObject = new GameObject();
            MissionPieceManagerGameObject.AddComponent<MissionPieceManager>();
            MissionPieceManagerInst = MissionPieceManagerGameObject.GetComponent<MissionPieceManager>();
            MissionLocations = new List<Coordinates>();
            RandomNumberLocations = new List<int>();
        }

        public void SetMap(MapCreation map)
        {
            MissionPieceManagerInst.SetMap(map);
        }

        public void AddMissionLocation(int missionNumber, int randomLocationNumber)
        {
            Coordinates coord = DefaultRandomNumberLocations.RAND_NUM_LOCATIONS[randomLocationNumber];
            MissionLocations.Add(coord);
            RandomNumberLocations.Add(randomLocationNumber);
            MissionPieceManagerInst.CreatePiece(missionNumber, coord);
        }

        public List<int> GetRandomNumberLocations()
        {
            return RandomNumberLocations;
        }
    }
}