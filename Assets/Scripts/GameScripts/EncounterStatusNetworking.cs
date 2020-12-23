using System.Collections.Generic;
using System.Text;

namespace FallenLand
{
	public class EncounterStatusNetworking
	{
		private readonly int PlayerIndex;
		private readonly byte EncounterType;
		private readonly bool WasASuccess;
		private readonly string CardName;

		public EncounterStatusNetworking(int playerIndex, byte encounterType, bool wasSuccess, string cardName)
		{
			PlayerIndex = playerIndex;
			EncounterType = encounterType;
			WasASuccess = wasSuccess;
			CardName = cardName;
		}

		public static object DeserializeEncounterStatus(byte[] data)
		{
            int playerIndex = data[0];
			byte encounterType = data[1];
			bool wasSuccess = (data[2] != 0);

			List<byte> byteList = new List<byte>(data);
			byteList.RemoveAt(0);
			byteList.RemoveAt(0);
			byteList.RemoveAt(0);
			byte[] byteArray = byteList.ToArray();
			string cardName = Encoding.ASCII.GetString(byteArray);

			EncounterStatusNetworking result = new EncounterStatusNetworking(playerIndex, encounterType, wasSuccess, cardName);

			return result;
		}

		public static byte[] SerializeEncounterStatus(object customType)
		{
			EncounterStatusNetworking encounterStatus = (EncounterStatusNetworking)customType;
			byte wasSuccess = 0;
			if (encounterStatus.GetWasSuccess())
			{
				wasSuccess = 1;
			}

            List<byte> byteListFinal = new List<byte>
            {
                (byte)encounterStatus.GetPlayerIndex(),
				encounterStatus.GetEncounterType(),
				wasSuccess
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

		public bool GetWasSuccess()
		{
			return WasASuccess;
		}

		public string GetCardName()
		{
			return CardName;
		}
	}
}
