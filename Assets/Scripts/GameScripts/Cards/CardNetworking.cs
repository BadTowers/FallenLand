using System.Collections.Generic;
using System.Text;

namespace FallenLand
{
	public class CardNetworking
	{
		private readonly int PlayerIndex;
		private readonly string CardName;
		private readonly byte CardByte;

		public CardNetworking(string cardName, int playerIndex, byte cardByte)
		{
			CardName = cardName;
			PlayerIndex = playerIndex;
			CardByte = cardByte;
	}

		public static object DeserializeCard(byte[] data)
		{
			int playerIndex = data[0]; //grab index first
			byte cardByte = data[1]; //grab card byte second
			List<byte> byteList = new List<byte>(data);
			byteList.RemoveAt(0); //remove index
			byteList.RemoveAt(0); //remove card byte
			byte[] byteArray = byteList.ToArray(); //grab card name next
			string str = Encoding.ASCII.GetString(byteArray);
			CardNetworking result = new CardNetworking(str, playerIndex, cardByte);
			return result;
		}

		public static byte[] SerializeCard(object customType)
		{
			CardNetworking cardInfo = (CardNetworking)customType;
			List<byte> byteListFinal = new List<byte> //pack index and card byte first
            {
				(byte)cardInfo.GetPlayerIndex(),
				cardInfo.GetCardByte()
            };
            List<byte> byteListString = new List<byte>(Encoding.ASCII.GetBytes(cardInfo.GetCardName()));

            for (int i = 0; i < byteListString.Count; i++) //append card name next
            {
                byteListFinal.Add(byteListString[i]);
            }
            return byteListFinal.ToArray();
        }

		public int GetPlayerIndex()
		{
			return PlayerIndex;
		}

		public string GetCardName()
		{
			return CardName;
		}

		public byte GetCardByte()
		{
			return CardByte;
		}
	}
}
