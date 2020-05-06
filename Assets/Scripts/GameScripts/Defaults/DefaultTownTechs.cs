using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultTownTechs {


	private List<TownTech> techs;

	//Constructor
	public DefaultTownTechs(){
		techs = new List<TownTech>();

		//Vars
		TownTech curTech;

		/***************************************************/
		curTech = new TownTech("Energy Production");
		curTech.SetPurchaseCost(30);
		curTech.SetUpgradeCost(30);
		curTech.SetSellCost(25);
		curTech.SetConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Party_Technical_Skill_Check_Successes, 1}
		});
		curTech.SetTimes(new List<Times>(){
			{Times.During_Technical_Skill_Check}
		});
		curTech.SetId(1);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Garrison");
		curTech.SetPurchaseCost(30);
		curTech.SetUpgradeCost(30);
		curTech.SetSellCost(25);
		curTech.SetConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Party_Combat_Skill_Check_Successes, 1}
		});
		curTech.SetTimes(new List<Times>(){
			{Times.During_Combat_Skill_Check}
		});
		curTech.SetId(2);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Law and Order");
		curTech.SetPurchaseCost(30);
		curTech.SetUpgradeCost(30);
		curTech.SetSellCost(25);
		curTech.SetConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Action_Cards, 1}
		});
		curTech.SetTimes(new List<Times>(){
			{Times.During_Deal_Subphase}
		});
		curTech.SetId(3);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Learning Center");
		curTech.SetPurchaseCost(30);
		curTech.SetUpgradeCost(30);
		curTech.SetSellCost(25);
		curTech.SetConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Party_Diplomacy_Skill_Check_Successes, 1}
		});
		curTech.SetTimes(new List<Times>(){
			{Times.During_Diplomacy_Skill_Check}
		});
		curTech.SetId(4);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Machinist Shop");
		curTech.SetPurchaseCost(30);
		curTech.SetUpgradeCost(30);
		curTech.SetSellCost(25);
		curTech.SetConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Party_Mechanical_Skill_Check_Successes, 1}
		});
		curTech.SetTimes(new List<Times>(){
			{Times.During_Mechanical_Skill_Check}
		});
		curTech.SetId(5);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Marketplace");
		curTech.SetPurchaseCost(30);
		curTech.SetUpgradeCost(30);
		curTech.SetSellCost(25);
		curTech.SetConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Spoils_Cards, 1}
		});
		curTech.SetTimes(new List<Times>(){
			{Times.During_Deal_Subphase}
		});
		curTech.SetId(6);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Medical Center");
		curTech.SetPurchaseCost(30);
		curTech.SetUpgradeCost(30);
		curTech.SetSellCost(25);
		curTech.SetConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Party_Medical_Skill_Check_Successes, 1}
		});
		curTech.SetTimes(new List<Times>(){
			{Times.During_Medical_Skill_Check}
		});
		curTech.SetId(7);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Communication Center");
		curTech.SetPurchaseCost(30);
		curTech.SetUpgradeCost(30);
		curTech.SetSellCost(25);
		curTech.SetConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Movement, 2}
		});
		curTech.SetTimes(new List<Times>(){
			{Times.Anytime}
		});
		curTech.SetId(8);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Water and Supplies");
		curTech.SetPurchaseCost(30);
		curTech.SetUpgradeCost(30);
		curTech.SetSellCost(25);
		curTech.SetConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Party_Survival_Skill_Check_Successes, 1}
		});
		curTech.SetTimes(new List<Times>(){
			{Times.During_Survival_Skill_Check}
		});
		curTech.SetId(9);
		techs.Add(curTech);

	}





	public List<TownTech> getDefaultTownTechList(){
		return this.techs;
	}

	public TownTech getTownTechByName(string name){
		foreach(TownTech tt in techs) {
			if(tt.GetTechName() == name) {
				return tt;
			}
		}

		//Error condition
		return null;
	}
}
