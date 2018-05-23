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
		curTech.setPurchaseCost(30);
		curTech.setUpgradeCost(30);
		curTech.setSellCost(25);
		curTech.setConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Party_Technical_Skill_Check_Successes, 1}
		});
		curTech.setTimes(new List<Times>(){
			{Times.During_Technical_Skill_Check}
		});
		curTech.setID(1);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Garrison");
		curTech.setPurchaseCost(30);
		curTech.setUpgradeCost(30);
		curTech.setSellCost(25);
		curTech.setConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Party_Combat_Skill_Check_Successes, 1}
		});
		curTech.setTimes(new List<Times>(){
			{Times.During_Combat_Skill_Check}
		});
		curTech.setID(2);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Law and Order");
		curTech.setPurchaseCost(30);
		curTech.setUpgradeCost(30);
		curTech.setSellCost(25);
		curTech.setConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Action_Cards, 1}
		});
		curTech.setTimes(new List<Times>(){
			{Times.During_Deal_Subphase}
		});
		curTech.setID(3);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Learning Center");
		curTech.setPurchaseCost(30);
		curTech.setUpgradeCost(30);
		curTech.setSellCost(25);
		curTech.setConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Party_Diplomacy_Skill_Check_Successes, 1}
		});
		curTech.setTimes(new List<Times>(){
			{Times.During_Diplomacy_Skill_Check}
		});
		curTech.setID(4);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Machinist Shop");
		curTech.setPurchaseCost(30);
		curTech.setUpgradeCost(30);
		curTech.setSellCost(25);
		curTech.setConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Party_Mechanical_Skill_Check_Successes, 1}
		});
		curTech.setTimes(new List<Times>(){
			{Times.During_Mechanical_Skill_Check}
		});
		curTech.setID(5);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Marketplace");
		curTech.setPurchaseCost(30);
		curTech.setUpgradeCost(30);
		curTech.setSellCost(25);
		curTech.setConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Spoils_Cards, 1}
		});
		curTech.setTimes(new List<Times>(){
			{Times.During_Deal_Subphase}
		});
		curTech.setID(6);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Medical Center");
		curTech.setPurchaseCost(30);
		curTech.setUpgradeCost(30);
		curTech.setSellCost(25);
		curTech.setConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Party_Medical_Skill_Check_Successes, 1}
		});
		curTech.setTimes(new List<Times>(){
			{Times.During_Medical_Skill_Check}
		});
		curTech.setID(7);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Communication Center");
		curTech.setPurchaseCost(30);
		curTech.setUpgradeCost(30);
		curTech.setSellCost(25);
		curTech.setConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Movement, 2}
		});
		curTech.setTimes(new List<Times>(){
			{Times.Anytime}
		});
		curTech.setID(8);
		techs.Add(curTech);

		/***************************************************/
		curTech = new TownTech("Water and Supplies");
		curTech.setPurchaseCost(30);
		curTech.setUpgradeCost(30);
		curTech.setSellCost(25);
		curTech.setConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Party_Survival_Skill_Check_Successes, 1}
		});
		curTech.setTimes(new List<Times>(){
			{Times.During_Survival_Skill_Check}
		});
		curTech.setID(9);
		techs.Add(curTech);

	}


	public List<TownTech> getDefaultTownTechList(){
		return this.techs;
	}
		
	public TownTech getTownTechByName(string name){
		foreach(TownTech tt in techs) {
			if(tt.getTechName() == name) {
				return tt;
			}
		}

		//Error condition
		return null;
	}
}
