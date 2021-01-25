using System.Collections.Generic;
using System.Text;

namespace FallenLand
{
	public class FactionNetworking
	{
		private readonly int PlayerIndex;
		private readonly string FactionName;

		public FactionNetworking(string factionName, int playerIndex)
		{
			FactionName = factionName;
			PlayerIndex = playerIndex;
		}

		public static object DeserializeFaction(byte[] data)
		{
            int playerIndex = data[0]; //grab index first
            List<byte> byteList = new List<byte>(data);
            byteList.RemoveAt(0);
            byte[] byteArray = byteList.ToArray(); //grab faction name next
            string str = Encoding.ASCII.GetString(byteArray);
            FactionNetworking result = new FactionNetworking(str, playerIndex);
			return result;
		}

		public static byte[] SerializeFaction(object customType)
		{
			FactionNetworking factionInfo = (FactionNetworking)customType;
            List<byte> byteListFinal = new List<byte> //pack index first
            {
                (byte)factionInfo.GetPlayerIndex()
            };
			List<byte> byteListString = new List<byte>(Encoding.ASCII.GetBytes(factionInfo.GetFactionName()));

			for (int i = 0; i < byteListString.Count; i++) //append faction name next
			{
				byteListFinal.Add(byteListString[i]);
			}
			return byteListFinal.ToArray();
		}

		public int GetPlayerIndex()
		{
			return PlayerIndex;
		}

		public string GetFactionName()
		{
			return FactionName;
		}
	}
}
