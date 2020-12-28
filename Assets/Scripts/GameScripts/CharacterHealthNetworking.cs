﻿using System.Collections.Generic;

namespace FallenLand
{
	public class CharacterHealthNetworking
	{
		private readonly int PlayerIndex;
		private readonly int CharacterIndex;
		private readonly byte DamageType;
		private readonly int AmountOfDamage;
		private readonly bool ShouldDiscardEquipmentIfDead;

		public CharacterHealthNetworking(int playerIndex, int characterIndex, byte damageType, int amountOfDamage, bool shouldDiscardEquipmentIfDead)
		{
			PlayerIndex = playerIndex;
			CharacterIndex = characterIndex;
			DamageType = damageType;
			AmountOfDamage = amountOfDamage;
			ShouldDiscardEquipmentIfDead = shouldDiscardEquipmentIfDead;
		}

		public static object DeserializeCharacterHealth(byte[] data)
		{
            int playerIndex = data[0];
			int characterIndex = data[1];
			byte damageType = data[2];
			int amount = data[3];
			bool shouldDiscardEquipmentIfDead = (data[4] != 0);

			CharacterHealthNetworking result = new CharacterHealthNetworking(playerIndex, characterIndex, damageType, amount, shouldDiscardEquipmentIfDead);

			return result;
		}

		public static byte[] SerializeCharacterHealth(object customType)
		{
			CharacterHealthNetworking encounterStatus = (CharacterHealthNetworking)customType;
			int shouldDiscardEquipIfDead = (encounterStatus.GetShouldDiscardEquipmentIfDead()) ? 1 : 0;

            List<byte> byteListFinal = new List<byte>
            {
                (byte)encounterStatus.GetPlayerIndex(),
				(byte)encounterStatus.GetCharacterIndex(),
				encounterStatus.GetDamageType(),
				(byte)encounterStatus.GetAmountOfDamage(),
				(byte)shouldDiscardEquipIfDead
			};

			return byteListFinal.ToArray();
		}

		public int GetPlayerIndex()
		{
			return PlayerIndex;
		}

		public int GetCharacterIndex()
		{
			return CharacterIndex;
		}

		public byte GetDamageType()
        {
			return DamageType;
		}

		public int GetAmountOfDamage()
		{
			return AmountOfDamage;
		}

		public bool GetShouldDiscardEquipmentIfDead()
		{
			return ShouldDiscardEquipmentIfDead;
		}
	}
}
