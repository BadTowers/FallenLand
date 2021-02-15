using System.Collections.Generic;
using System.Text;

namespace FallenLand
{
	public class TownTechNetworking
	{
		private readonly int PlayerIndex;
		private readonly byte Action;
		private readonly string TownTechName;

		public TownTechNetworking(int playerIndex, byte action, string townTechName)
		{
			PlayerIndex = playerIndex;
			Action = action;
			TownTechName = townTechName;
		}

		public static object DeserializeTownTech(byte[] data)
		{
            int playerIndex = data[0];
			byte action = data[1];

            List<byte> byteList = new List<byte>(data);
            byteList.RemoveAt(0); //remove player index
            byteList.RemoveAt(0); //remove action byte
            byte[] byteArray = byteList.ToArray();
            string townTechName = Encoding.ASCII.GetString(byteArray);

            TownTechNetworking result = new TownTechNetworking(playerIndex, action, townTechName);

			return result;
		}

		public static byte[] SerializeTownTech(object customType)
		{
			TownTechNetworking townTech = (TownTechNetworking)customType;

			List<byte> byteListFinal = new List<byte>
			{
				(byte)townTech.GetPlayerIndex(),
				townTech.GetActionByte()
			};

            List<byte> byteListString = new List<byte>(Encoding.ASCII.GetBytes(townTech.GetTechName()));

            for (int i = 0; i < byteListString.Count; i++) //append name
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
			return Action;
		}

		public string GetTechName()
		{
			return TownTechName;
		}
	}
}
