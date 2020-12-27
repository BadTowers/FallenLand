using System.Collections.Generic;
using System.Text;

namespace FallenLand
{
	public class EncounterStatusNetworking
	{
		private readonly int PlayerIndex;
		private readonly byte EncounterType;
		private readonly byte Status;
		private readonly string CardName;

		public EncounterStatusNetworking(int playerIndex, byte encounterType, byte status, string cardName)
		{
			PlayerIndex = playerIndex;
			EncounterType = encounterType;
			Status = status;
			CardName = cardName;
		}

		public static object DeserializeEncounterStatus(byte[] data)
		{
            int playerIndex = data[0];
			byte encounterType = data[1];
			byte status = data[2];

			List<byte> byteList = new List<byte>(data);
			byteList.RemoveAt(0);
			byteList.RemoveAt(0);
			byteList.RemoveAt(0);
			byte[] byteArray = byteList.ToArray();
			string cardName = Encoding.ASCII.GetString(byteArray);

			EncounterStatusNetworking result = new EncounterStatusNetworking(playerIndex, encounterType, status, cardName);

			return result;
		}

		public static byte[] SerializeEncounterStatus(object customType)
		{
			EncounterStatusNetworking encounterStatus = (EncounterStatusNetworking)customType;

            List<byte> byteListFinal = new List<byte>
            {
                (byte)encounterStatus.GetPlayerIndex(),
				encounterStatus.GetEncounterType(),
				encounterStatus.GetStatus()
			};

			List<byte> byteListString = new List<byte>(Encoding.ASCII.GetBytes(encounterStatus.GetCardName()));

			for (int i = 0; i < byteListString.Count; i++) //append card name
			{
				byteListFinal.Add(byteListString[i]);
			}

			return byteListFinal.ToArray();
		}

		public int GetPlayerIndex()
		{
			return PlayerIndex;
		}

		public byte GetEncounterType()
		{
			return EncounterType;
		}

		public byte GetStatus()
		{
			return Status;
		}

		public string GetCardName()
		{
			return CardName;
		}
	}
}
