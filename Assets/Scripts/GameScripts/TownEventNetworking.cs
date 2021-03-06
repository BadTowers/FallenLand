﻿using System.Collections.Generic;

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
			TownEventNetworking result = new TownEventNetworking(playerIndex, townEventRoll);
			return result;
		}

		public static byte[] SerializeTownEventRoll(object customType)
		{
			TownEventNetworking townEventRoll = (TownEventNetworking)customType;
            List<byte> byteListFinal = new List<byte>
            {
				(byte)townEventRoll.GetPlayerIndex(),
            	(byte)townEventRoll.GetTownEventRoll()
            };

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
