using System.Collections.Generic;

namespace FallenLand
{
	public class DefaultTownTechs
	{
		private List<TownTech> Techs;

		public DefaultTownTechs()
		{
			Techs = new List<TownTech>();

			TownTech curTech;
			ConditionalGain conditionalGain;
			List<Reward> reward;

			/***************************************************/
			curTech = new TownTech("Energy Production");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			curTech.AddOnPurchaseReward(new GainTownTechPartyTechnicalSuccesses(1));
			curTech.AddOnSellPunishment(new LoseTownTechPartyTechnicalSuccesses(1));
			curTech.AddOnUpgradeReward(new GainTownTechPartyTechnicalSuccesses(1));
			curTech.AddOnDowngradePunishment(new LoseTownTechPartyTechnicalSuccesses(1));
			curTech.SetId(1);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Garrison");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			curTech.AddOnPurchaseReward(new GainTownTechPartyCombatSuccesses(1));
			curTech.AddOnSellPunishment(new LoseTownTechPartyCombatSuccesses(1));
			curTech.AddOnUpgradeReward(new GainTownTechPartyCombatSuccesses(1));
			curTech.AddOnDowngradePunishment(new LoseTownTechPartyCombatSuccesses(1));
			curTech.SetId(2);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Law and Order");
			curTech.SetPurchaseCost(40);
			curTech.SetUpgradeCost(40);
			curTech.SetSellCost(25);
            reward = new List<Reward> { new GainActionCards(1) };
            conditionalGain = new ConditionalGain();
            conditionalGain.AddRewardChoice(reward);
			conditionalGain.SetWhenRewardCanBeClaimed(new DuringDealPhase());
			curTech.SetConditionalGains(conditionalGain);
            curTech.SetId(3);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Learning Center");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			curTech.AddOnPurchaseReward(new GainTownTechPartyDiplomacySuccesses(1));
			curTech.AddOnSellPunishment(new LoseTownTechPartyDiplomacySuccesses(1));
			curTech.AddOnUpgradeReward(new GainTownTechPartyDiplomacySuccesses(1));
			curTech.AddOnDowngradePunishment(new LoseTownTechPartyDiplomacySuccesses(1));
			curTech.SetId(4);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Machinist Shop");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			curTech.AddOnPurchaseReward(new GainTownTechPartyMechanicalSuccesses(1));
			curTech.AddOnSellPunishment(new LoseTownTechPartyMechanicalSuccesses(1));
			curTech.AddOnUpgradeReward(new GainTownTechPartyMechanicalSuccesses(1));
			curTech.AddOnDowngradePunishment(new LoseTownTechPartyMechanicalSuccesses(1));
			curTech.SetId(5);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Marketplace");
			curTech.SetPurchaseCost(40);
			curTech.SetUpgradeCost(40);
			curTech.SetSellCost(25);
            reward = new List<Reward> { new GainSpoilsCards(1) };
            conditionalGain = new ConditionalGain();
            conditionalGain.AddRewardChoice(reward);
            conditionalGain.SetWhenRewardCanBeClaimed(new DuringDealPhase());
            curTech.SetConditionalGains(conditionalGain);
            curTech.SetId(6);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Medical Center");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			curTech.AddOnPurchaseReward(new GainTownTechPartyMedicalSuccesses(1));
			curTech.AddOnSellPunishment(new LoseTownTechPartyMedicalSuccesses(1));
			curTech.AddOnUpgradeReward(new GainTownTechPartyMedicalSuccesses(1));
			curTech.AddOnDowngradePunishment(new LoseTownTechPartyMedicalSuccesses(1));
			curTech.SetId(7);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Communication Center");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			curTech.AddOnPurchaseReward(new GainBonusMovement(2));
			curTech.AddOnSellPunishment(new LoseBonusMovement(2));
			curTech.AddOnUpgradeReward(new GainBonusMovement(2));
			curTech.AddOnDowngradePunishment(new LoseBonusMovement(2));
			curTech.SetId(8);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Water and Supplies");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			curTech.AddOnPurchaseReward(new GainTownTechPartySurvivalSuccesses(1));
			curTech.AddOnSellPunishment(new LoseTownTechPartySurvivalSuccesses(1));
			curTech.AddOnUpgradeReward(new GainTownTechPartySurvivalSuccesses(1));
			curTech.AddOnDowngradePunishment(new LoseTownTechPartySurvivalSuccesses(1));
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
