using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownTech {
	//A town tech has a name
	private string techName;
	//A town tech has a purchase cost
	private int purchaseCost;
	//A town tech has an upgrade cost
	private int upgradeCost;
	//A town tech has a tier (tier 1 or tier 2)
	private int tier;
	//A town tech has a sell cost
	private int sellCost;
	//A town tech has gains that the player may recieve
	private Dictionary<Gains, int> conditionalGains;
	//A town tech has times when the gains are active
	private List<Times> whenUsable;
	//A town tech is or is not a starting town tech
	private bool isStartingTech;


	//Constructor
	public TownTech(string name){
		this.techName = name;
	}

	public void setTechName(string n){
		this.techName = n;
	}

	public string getTechName(){
		return this.techName;
	}

	public void setPurchaseCost(int c){
		this.purchaseCost = c;
	}

	public int getPurchaseCost(){
		return this.purchaseCost;
	}

	public void setUpgradeCost(int c){
		this.upgradeCost = c;
	}

	public int getUpgradeCost(){
		return this.upgradeCost;
	}

	public void setTier(int t){
		this.tier = t;
	}

	public int getTier(){
		return this.tier;
	}

	public void setSellCost(int s){
		this.sellCost = s;
	}

	public int getSellCost(){
		return this.sellCost;
	}

	public void setConditionalGains(Dictionary<Gains, int> cg){
		this.conditionalGains = cg;
	}

	public Dictionary<Gains, int> getConditionalGains(){
		return this.conditionalGains;
	}

	private void setTimes(List<Times> t){
		this.whenUsable = t;
	}

	public void addTimes(Times t){
		this.whenUsable.Add(t);
	}

	public List<Times> getTimes(){
		return this.whenUsable;
	}

	public void setIsStartingTech(bool b){
		this.isStartingTech = b;
	}

	public bool getIsStartingTech(){
		return this.isStartingTech;
	}
}
