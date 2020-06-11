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
                if (conditionalGain != null && TimesManager.AreTimeConstraintsMet(gameManager, conditionalGain.GetWhenRewardCanBeGained()))
                {
                    GainsManager.HandleGains(gameManager, conditionalGain.GetRewardChoices());
                }
            }
        }
    }
}