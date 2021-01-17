using System.Collections.Generic;
using System.Text;

namespace FallenLand
{
	public class HealingDeedNetworking
	{
		private readonly int PlayerIndex;
		private readonly byte Status;

		public HealingDeedNetworking(int playerIndex, byte status)
		{
			PlayerIndex = playerIndex;
			Status = status;
		}

		public static object DeserializeHealingDeed(byte[] data)
		{
            int playerIndex = data[0];
			byte status = data[1];

			HealingDeedNetworking result = new HealingDeedNetworking(playerIndex, status);

			return result;
		}

		public static byte[] SerializeHealingDeed(object customType)
		{
			HealingDeedNetworking healingDeed = (HealingDeedNetworking)customType;

			List<byte> byteListFinal = new List<byte>
			{
				(byte)healingDeed.GetPlayerIndex(),
				healingDeed.GetStatusByte()
			};

			return byteListFinal.ToArray();
		}

		public int GetPlayerIndex()
		{
			return PlayerIndex;
		}

		public byte GetStatusByte()
		{
			return Status;
		}
	}
}
