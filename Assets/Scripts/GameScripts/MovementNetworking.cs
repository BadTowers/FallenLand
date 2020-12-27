using System.Collections.Generic;
using System.Text;

namespace FallenLand
{
	public class MovementNetworking
	{
		private readonly int PlayerIndex;
		private readonly byte MovementType;
		private readonly Coordinates LocationToMoveTo;

		public MovementNetworking(int playerIndex, byte movementType, Coordinates coords)
		{
			PlayerIndex = playerIndex;
			MovementType = movementType;
			LocationToMoveTo = coords;
		}

		public static object DeserializeMovement(byte[] data)
		{
            int playerIndex = data[0];
            byte movementType = data[1];
			int xLocation = data[2];
			int yLocation = data[3];
			MovementNetworking result = new MovementNetworking(playerIndex, movementType, new Coordinates(xLocation, yLocation));
			return result;
		}

		public static byte[] SerializeMovement(object customType)
		{
			MovementNetworking movementInfo = (MovementNetworking)customType;
			UnityEngine.Debug.Log("Serialization: index is " + movementInfo.GetPlayerIndex());
			Coordinates location = movementInfo.GetLocationToMoveTo();
			List<byte> byteListFinal = new List<byte>
			{
				(byte)movementInfo.GetPlayerIndex(),
				movementInfo.GetMovementType(),
				(byte)location.GetX(),
				(byte)location.GetY()
			};

			return byteListFinal.ToArray();
		}

		public int GetPlayerIndex()
		{
			return PlayerIndex;
		}

		public byte GetMovementType()
		{
			return MovementType;
		}

		public Coordinates GetLocationToMoveTo()
		{
			return LocationToMoveTo;
		}
	}
}
