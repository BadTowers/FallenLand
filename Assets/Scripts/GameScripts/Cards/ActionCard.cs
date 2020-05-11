using System.Collections;
using System.Collections.Generic;
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
