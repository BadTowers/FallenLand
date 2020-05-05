using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownTech
{
	//A town tech has a name
	private string TechName;
	//A town tech has a purchase cost
	private int PurchaseCost;
	//A town tech has an upgrade cost
	private int UpgradeCost;
	//A town tech has a tier (tier 1 or tier 2)
	private int Tier;
	//A town tech has a sell cost
	private int SellCost;
	//A town tech has gains that the player may recieve
	private Dictionary<Gains, int> ConditionalGains;
	//A town tech has times when the gains are active
	private List<Times> WhenUsable;
	//A town tech is or is not a starting town tech
	private bool IsStartingTech;
	//A town tech has an ID
	private int Id;

	public TownTech(string name)
	{
		this.TechName = name;
	}

	public void SetTechName(string n)
	{
		this.TechName = n;
	}

	public string GetTechName()
	{
		return this.TechName;
	}

	public void SetPurchaseCost(int c)
	{
		this.PurchaseCost = c;
	}

	public int GetPurchaseCost()
	{
		return this.PurchaseCost;
	}

	public void SetUpgradeCost(int c)
	{
		this.UpgradeCost = c;
	}

	public int GetUpgradeCost()
	{
		return this.UpgradeCost;
	}

	public void SetTier(int t)
	{
		this.Tier = t;
	}

	public int GetTier()
	{
		return this.Tier;
	}

	public void SetSellCost(int s)
	{
		this.SellCost = s;
	}

	public int GetSellCost()
	{
		return this.SellCost;
	}

	public void SetConditionalGains(Dictionary<Gains, int> cg)
	{
		this.ConditionalGains = cg;
	}

	public Dictionary<Gains, int> GetConditionalGains()
	{
		return this.ConditionalGains;
	}

	public void SetTimes(List<Times> t)
	{
		this.WhenUsable = t;
	}

	public void AddTimes(Times t)
	{
		this.WhenUsable.Add(t);
	}

	public List<Times> GetTimes()
	{
		return this.WhenUsable;
	}

	public void SetIsStartingTech(bool b)
	{
		this.IsStartingTech = b;
	}

	public bool GetIsStartingTech()
	{
		return this.IsStartingTech;
	}

	public void SetId(int id)
	{
		this.Id = id;
	}

	public int GetId()
	{
		return this.Id;
	}
}
