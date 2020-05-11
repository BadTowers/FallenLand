﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class DefaultTownTechs
	{
		private List<TownTech> Techs;

		public DefaultTownTechs()
		{
			Techs = new List<TownTech>();

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
			Techs.Add(curTech);

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
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Law and Order");
			curTech.SetPurchaseCost(40);
			curTech.SetUpgradeCost(40);
			curTech.SetSellCost(25);
			curTech.SetConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Action_Cards, 1}
		});
			curTech.SetTimes(new List<Times>(){
			{Times.During_Deal_Subphase}
		});
			curTech.SetId(3);
			Techs.Add(curTech);

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
			Techs.Add(curTech);

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
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Marketplace");
			curTech.SetPurchaseCost(40);
			curTech.SetUpgradeCost(40);
			curTech.SetSellCost(25);
			curTech.SetConditionalGains(new Dictionary<Gains, int>(){
			{Gains.Gain_Spoils_Cards, 1}
		});
			curTech.SetTimes(new List<Times>(){
			{Times.During_Deal_Subphase}
		});
			curTech.SetId(6);
			Techs.Add(curTech);

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
			Techs.Add(curTech);

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
			Techs.Add(curTech);

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
			Techs.Add(curTech);
		}

		public List<TownTech> GetDefaultTownTechList()
		{
			return Techs;
		}

		public TownTech GetTownTechByName(string name)
		{
			TownTech toReturn = null;
			foreach (TownTech tt in Techs)
			{
				if (tt.GetTechName() == name)
				{
					toReturn = tt;
					break;
				}
			}

			return toReturn;
		}
	}
}
