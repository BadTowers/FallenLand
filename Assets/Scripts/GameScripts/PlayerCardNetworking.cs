using System.Collections.Generic;
using System.Text;

namespace FallenLand
{
	public class PlayerCardNetworking
	{
		private readonly int PlayerIndex;
		private readonly byte ActionByte;
		private readonly string CardName;
		private readonly int SlotIndex1;
		private readonly int SlotIndex2;

		public PlayerCardNetworking(int playerIndex, byte actionByte, string cardName, int indexComingFrom, int indexGoingTo)
		{
			PlayerIndex = playerIndex;
			ActionByte = actionByte;
			CardName = cardName;
			SlotIndex1 = indexComingFrom;
			SlotIndex2 = indexGoingTo;
		}

		public PlayerCardNetworking(int playerIndex, byte actionByte, string cardName, int slotIndex)
		{
			PlayerIndex = playerIndex;
			ActionByte = actionByte;
			CardName = cardName;
			SlotIndex1 = slotIndex;
		}

		public PlayerCardNetworking(int playerIndex, byte actionByte, string cardName)
		{
			PlayerIndex = playerIndex;
			ActionByte = actionByte;
			CardName = cardName;
			SlotIndex1 = Constants.DONT_CARE;
		}

		public static object DeserializePlayerCard(byte[] data)
		{
			int playerIndex = data[0];
			byte actionByte = data[1];
			int slotIndex1 = data[2];
			int slotIndex2 = data[3];
			List<byte> byteList = new List<byte>(data);
			byteList.RemoveAt(0); //remove player index
			byteList.RemoveAt(0); //remove action byte
			byteList.RemoveAt(0); //remove slot index 1
			byteList.RemoveAt(0); //remove slot index 2
			byte[] byteArray = byteList.ToArray(); //grab card name next
			string cardNameString = Encoding.ASCII.GetString(byteArray);
			PlayerCardNetworking result = new PlayerCardNetworking(playerIndex, actionByte, cardNameString, slotIndex1, slotIndex2);
			return result;
		}

		public static byte[] SerializePlayerCard(object customType)
		{
			PlayerCardNetworking playerInfo = (PlayerCardNetworking)customType;
			List<byte> byteListFinal = new List<byte>
            {
				(byte)playerInfo.GetPlayerIndex(),
				playerInfo.GetActionByte(),
				(byte)playerInfo.GetFirstSlotIndex(),
				(byte)playerInfo.GetSecondSlotIndex()
			};
			List<byte> byteListString = new List<byte>(Encoding.ASCII.GetBytes(playerInfo.GetCardName()));

			for (int i = 0; i < byteListString.Count; i++)
			{
				byteListFinal.Add(byteListString[i]);
			}
			return byteListFinal.ToArray();
		}

		public int GetPlayerIndex()
		{
			return PlayerIndex;
		}

		public byte GetActionByte()
		{
			return ActionByte;
		}

		public string GetCardName()
		{
			return CardName;
		}

		public int GetFirstSlotIndex()
		{
			return SlotIndex1;
		}

		public int GetSecondSlotIndex()
		{
			return SlotIndex2;
		}
	}
}
