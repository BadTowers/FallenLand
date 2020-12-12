using System.Collections.Generic;

namespace FallenLand
{
	public class PlayerNumberNetworking
	{
		private readonly int PlayerIndex;
		private readonly int TownHealth;
		private readonly int Prestige;
		private readonly int Salvage;

		public PlayerNumberNetworking(int playerIndex, int townHealth, int prestige, int salvage)
		{
			PlayerIndex = playerIndex;
			TownHealth = townHealth;
			Prestige = prestige;
			Salvage = salvage;
		}

		public static object DeserializePlayerNumbers(byte[] data)
		{
			int playerIndex = data[0];
			int townHealth = data[1];
			int prestige = data[2];
			int salvage = data[3];

			PlayerNumberNetworking result = new PlayerNumberNetworking(playerIndex, townHealth, prestige, salvage);
			return result;
		}

		public static byte[] SerializePlayerNumbers(object customType)
		{
			PlayerNumberNetworking playerInfo = (PlayerNumberNetworking)customType;
			List<byte> byteListFinal = new List<byte>
            {
				(byte)playerInfo.GetPlayerIndex(),
				(byte)playerInfo.GetTownHealth(),
				(byte)playerInfo.GetPrestige(),
				(byte)playerInfo.GetSalvage()
			};
			return byteListFinal.ToArray();
		}

		public int GetPlayerIndex()
		{
			return PlayerIndex;
		}

		public int GetTownHealth()
		{
			return TownHealth;
		}

		public int GetPrestige()
        {
			return Prestige;
		}

		public int GetSalvage()
		{
			return Salvage;
		}
	}
}
