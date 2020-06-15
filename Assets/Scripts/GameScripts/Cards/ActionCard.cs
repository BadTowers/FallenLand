using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace FallenLand
{
	public class ActionCard : NonpartyCard
	{
		private int SellValue;
		//phase. This is the phase the card can be played in TODO
		//Actions. The list of actions the card can do. Sometimes this is one thing. Sometimes this is a list of things and can pick one. TODO

		public ActionCard(string title) : base(title)
		{

		}

		public static object DeserializeActionCard(byte[] data)
		{
			string str = Encoding.ASCII.GetString(data);
			ActionCard result = new ActionCard(str);
			return result;
		}

		public static byte[] SerializeActionCard(object customType)
		{
			ActionCard actionCard = (ActionCard)customType;
			return Encoding.ASCII.GetBytes(actionCard.GetTitle());
		}

		public void SetSellValue(int sellValue)
		{
			if (sellValue >= 0)
			{
				SellValue = sellValue;
			}
		}

		public int GetSellValue()
		{
			return SellValue;
		}
	}
}
