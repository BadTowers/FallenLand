using System.Collections.Generic;

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
			//ConditionalGain conditionalGain;
			//List<Reward> reward;

			/***************************************************/
			curTech = new TownTech("Energy Production");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			//reward = new List<Reward>
			//{ 
			//	//{ Gains.Gain_Party_Technical_Skill_Check_Successes, 1 }
			//};
			//conditionalGain = new ConditionalGain();
			//conditionalGain.AddRewardChoice(reward);
			//conditionalGain.AddWhenRewardCanBeGained(new List<Times>() { Times.During_Technical_Skill_Check });
			//curTech.SetConditionalGains(conditionalGain);
			curTech.SetId(1);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Garrison");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			//reward = new List<Reward> 
			//{ 
			//	//{ Gains.Gain_Party_Combat_Skill_Check_Successes, 1 }
			//};
			//conditionalGain = new ConditionalGain();
			//conditionalGain.AddRewardChoice(reward);
			//conditionalGain.AddWhenRewardCanBeGained(new List<Times>() { Times.During_Combat_Skill_Check });
			//curTech.SetConditionalGains(conditionalGain);
			curTech.SetId(2);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Law and Order");
			curTech.SetPurchaseCost(40);
			curTech.SetUpgradeCost(40);
			curTech.SetSellCost(25);
			//reward = new List<Reward>
			//{
			//	new GainActionCards(1)
			//};
			//conditionalGain = new ConditionalGain();
			//conditionalGain.AddRewardChoice(reward);
			//conditionalGain.AddWhenRewardCanBeGained(new List<Times>() { Times.During_Deal_Subphase });
			//curTech.SetConditionalGains(conditionalGain);
			curTech.SetId(3);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Learning Center");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			//reward = new List<Reward> 
			//{ 
			//	//{ Gains.Gain_Party_Diplomacy_Skill_Check_Successes, 1 }
			//};
			//conditionalGain = new ConditionalGain();
			//conditionalGain.AddRewardChoice(reward);
			//conditionalGain.AddWhenRewardCanBeGained(new List<Times>() { Times.During_Diplomacy_Skill_Check });
			//curTech.SetConditionalGains(conditionalGain);
			curTech.SetId(4);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Machinist Shop");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			//reward = new List<Reward>
			//{
			//	//{ Gains.Gain_Party_Mechanical_Skill_Check_Successes, 1 }
			//};
			//conditionalGain = new ConditionalGain();
			//conditionalGain.AddRewardChoice(reward);
			//conditionalGain.AddWhenRewardCanBeGained(new List<Times>() { Times.During_Mechanical_Skill_Check });
			//curTech.SetConditionalGains(conditionalGain);
			curTech.SetId(5);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Marketplace");
			curTech.SetPurchaseCost(40);
			curTech.SetUpgradeCost(40);
			curTech.SetSellCost(25);
			//reward = new List<Reward>
			//{
			//	new GainSpoilsCards(1)
			//};
			//conditionalGain = new ConditionalGain();
			//conditionalGain.AddRewardChoice(reward);
			//conditionalGain.AddWhenRewardCanBeGained(new List<Times>() { Times.During_Deal_Subphase });
			//conditionalGain.SetWhenRewardCanBeClaimed(new DuringDealPhase());
			//curTech.SetConditionalGains(conditionalGain);
			curTech.SetId(6);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Medical Center");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			//reward = new List<Reward>
			//{
			//	//{ Gains.Gain_Party_Medical_Skill_Check_Successes, 1 } 
			//};
			//conditionalGain = new ConditionalGain();
			//conditionalGain.AddRewardChoice(reward);
			//conditionalGain.AddWhenRewardCanBeGained(new List<Times>() { Times.During_Medical_Skill_Check });
			//curTech.SetConditionalGains(conditionalGain);
			curTech.SetId(7);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Communication Center");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			//curTech.AddPassiveGain(Gains.Gain_Movement, 1);
			//curTech.SetConditionalGains(conditionalGain);
			curTech.SetId(8);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Water and Supplies");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			//reward = new List<Reward>
			//{ 
			//	//{ Gains.Gain_Party_Survival_Skill_Check_Successes, 1 } 
			//};
			//conditionalGain = new ConditionalGain();
			//conditionalGain.AddRewardChoice(reward);
			//conditionalGain.AddWhenRewardCanBeGained(new List<Times>() { Times.During_Survival_Skill_Check });
			//curTech.SetConditionalGains(conditionalGain);
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
