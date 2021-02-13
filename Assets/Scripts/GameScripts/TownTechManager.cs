using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
    public class TownTechManager
    {
        public static void HandlePhase(GameManager gameManager)
        {
            List<Player> players = gameManager.GetPlayers();
            int myIndex = gameManager.GetIndexForMyPlayer();

            List<TownTech> townTechs = players[myIndex].GetTownTechs();
            for (int i = 0; i < townTechs.Count; i++)
            {
                ConditionalGain conditionalGain = townTechs[i].GetConditionalGain();
                ConditionalGainHelpers.HandleConditionalGain(gameManager, conditionalGain, myIndex);
            }
        }

        public static void HandleTownTechPurchase(GameManager gameManager, int playerIndex, TownTech townTech)
        {
            List<Reward> rewards = townTech.GetOnPurchaseRewards();
            for (int rewardIndex = 0; rewardIndex < rewards.Count; rewardIndex++)
            {
                rewards[rewardIndex].HandleReward(gameManager, playerIndex);
            }
        }

        public static void HandleTownTechSell(GameManager gameManager, int playerIndex, TownTech townTech)
        {
            List<Punishment> punishments = townTech.GetOnSellPunishments();
            for (int punishmentIndex = 0; punishmentIndex < punishments.Count; punishmentIndex++)
            {
                punishments[punishmentIndex].HandlePunishment(gameManager, playerIndex);
            }
        }

        public static void HandleTownTechUpgrade(GameManager gameManager, int playerIndex, TownTech townTech)
        {
            List<Reward> rewards = townTech.GetOnUpgradeRewards();
            for (int rewardIndex = 0; rewardIndex < rewards.Count; rewardIndex++)
            {
                rewards[rewardIndex].HandleReward(gameManager, playerIndex);
            }
        }

        public static void HandleTownTechDowngrade(GameManager gameManager, int playerIndex, TownTech townTech)
        {
            List<Punishment> punishments = townTech.GetOnDowngradePunishments();
            for (int punishmentIndex = 0; punishmentIndex < punishments.Count; punishmentIndex++)
            {
                punishments[punishmentIndex].HandlePunishment(gameManager, playerIndex);
            }
        }
    }
}