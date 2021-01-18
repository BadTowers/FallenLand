using System.Collections.Generic;

namespace FallenLand
{
	public class SalvageNetworking
	{
		private readonly int PlayerIndex;
		private readonly int Amount;
		private readonly byte Action;

		public SalvageNetworking(int playerIndex, int amountOfSalvage, byte action)
		{
			PlayerIndex = playerIndex;
			Amount = amountOfSalvage;
			Action = action;
		}

		public static object DeserializeSalvage(byte[] data)
		{
            int playerIndex = data[0];
			int amount = data[1];
			byte action = data[2];

			SalvageNetworking result = new SalvageNetworking(playerIndex, amount, action);

			return result;
		}

		public static byte[] SerializeSalvage(object customType)
		{
			SalvageNetworking salvageNetworking = (SalvageNetworking)customType;

			List<byte> byteListFinal = new List<byte>
			{
				(byte)salvageNetworking.GetPlayerIndex(),
				(byte)salvageNetworking.GetAmount(),
				salvageNetworking.GetAction()
			};

			return byteListFinal.ToArray();
		}

		public int GetPlayerIndex()
		{
			return PlayerIndex;
		}

		public int GetAmount()
		{
			return Amount;
		}

		public byte GetAction()
		{
			return Action;
		}
	}
}
