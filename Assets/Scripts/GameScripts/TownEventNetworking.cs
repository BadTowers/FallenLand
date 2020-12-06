using System.Collections.Generic;

namespace FallenLand
{
	public class TownEventNetworking
	{
		private readonly int PlayerIndex;
		private readonly int TownEventRoll;

		public TownEventNetworking(int playerIndex, int townEventRoll)
		{
			PlayerIndex = playerIndex;
			TownEventRoll = townEventRoll;
		}

		public static object DeserializeTownEventRoll(byte[] data)
		{
			int playerIndex = data[0];
			int townEventRoll = data[1];
			UnityEngine.Debug.Log("Deserialization: town event roll is " + townEventRoll);
			TownEventNetworking result = new TownEventNetworking(playerIndex, townEventRoll);
			return result;
		}

		public static byte[] SerializeTownEventRoll(object customType)
		{
			TownEventNetworking townEventRoll = (TownEventNetworking)customType;
			UnityEngine.Debug.Log("Serialization: town event roll is " + townEventRoll.GetTownEventRoll());
            List<byte> byteListFinal = new List<byte>
            {
				(byte)townEventRoll.GetPlayerIndex(),
            	(byte)townEventRoll.GetTownEventRoll()
            };
            UnityEngine.Debug.Log("Serialization for town event: size is " + byteListFinal.Count);

            return byteListFinal.ToArray();
        }

        public int GetPlayerIndex()
		{
			return PlayerIndex;
		}

		public int GetTownEventRoll()
		{
			return TownEventRoll;
		}
	}
}
