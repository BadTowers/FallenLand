using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownTech
{
	private string TechName;
	private int PurchaseCost;
	private int UpgradeCost;
	private int Tier; //tier 1 or 2
	private int SellCost;
	private Dictionary<Gains, int> ConditionalGains;
	private List<Times> WhenUsable;
	private bool IsStartingTech;
	private int Id;

	public TownTech(string name)
	{
		TechName = name;
		ConditionalGains = new Dictionary<Gains, int>();
		WhenUsable = new List<Times>();
	}

	public void SetTechName(string n)
	{
		TechName = n;
	}

	public string GetTechName()
	{
		return TechName;
	}

	public void SetPurchaseCost(int c)
	{
		PurchaseCost = c;
	}

	public int GetPurchaseCost()
	{
		return PurchaseCost;
	}

	public void SetUpgradeCost(int c)
	{
		UpgradeCost = c;
	}

	public int GetUpgradeCost()
	{
		return UpgradeCost;
	}

	public void SetTier(int t)
	{
		Tier = t;
	}

	public int GetTier()
	{
		return Tier;
	}

	public void SetSellCost(int s)
	{
		SellCost = s;
	}

	public int GetSellCost()
	{
		return SellCost;
	}

	public void SetConditionalGains(Dictionary<Gains, int> condGains)
	{
		if (condGains != null)
		{
			ConditionalGains = condGains;
		}
	}

	public Dictionary<Gains, int> GetConditionalGains()
	{
		return ConditionalGains;
	}

	public void SetTimes(List<Times> times)
	{
		if (times != null)
		{
			WhenUsable = times;
		}
	}

	public List<Times> GetTimes()
	{
		return WhenUsable;
	}

	public void SetIsStartingTech(bool b)
	{
		IsStartingTech = b;
	}

	public bool GetIsStartingTech()
	{
		return IsStartingTech;
	}

	public void SetId(int id)
	{
		Id = id;
	}

	public int GetId()
	{
		return Id;
	}
}
