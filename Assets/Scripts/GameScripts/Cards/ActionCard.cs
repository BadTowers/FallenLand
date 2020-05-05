using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCard : NonpartyCard
{
	private int SellValue; //The value the card can be sold to the bank for
	//phase. This is the phase the card can be played in
	//Actions. The list of actions the card can do. Sometimes this is one thing. Sometimes this is a list of things and can pick one. TODO

	public ActionCard(string title) : base(title)
	{

	}

	public void SetSellValue(int sv)
	{
		this.SellValue = sv;
	}

	public int GetSellValue()
	{
		return this.SellValue;
	}
}
