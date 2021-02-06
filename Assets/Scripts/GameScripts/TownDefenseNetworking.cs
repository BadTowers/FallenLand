using System.Collections.Generic;

namespace FallenLand
{
	public class TownDefenseNetworking
	{
		private readonly int PlayerIndex;
		private readonly byte Action;

		public TownDefenseNetworking(int playerIndex, byte action)
		{
			PlayerIndex = playerIndex;
			Action = action;
		}

		public static object DeserializeTownDefense(byte[] data)
		{
            int playerIndex = data[0];
			byte action = data[1];

			TownDefenseNetworking result = new TownDefenseNetworking(playerIndex, action);

			return result;
		}

		public static byte[] SerializeTownDefense(object customType)
		{
			TownDefenseNetworking townDefense = (TownDefenseNetworking)customType;

            List<byte> byteListFinal = new List<byte>
            {
                (byte)townDefense.GetPlayerIndex(),
				townDefense.GetAction()
			};

			return byteListFinal.ToArray();
		}

		public int GetPlayerIndex()
		{
			return PlayerIndex;
		}

		public byte GetAction()
		{
			return Action;
		}
	}
}
