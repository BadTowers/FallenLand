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
                if (conditionalGain != null && conditionalGain.GetWhenRewardCanBeClaimed() != null && conditionalGain.GetWhenRewardCanBeClaimed().IsStateOccurring(gameManager))
                {
                    List<List<Reward>> rewards = conditionalGain.GetRewardChoices();
                    if (rewards.Count == 1)
                    {
                        for (int rewardIndex = 0; rewardIndex < rewards[0].Count; rewardIndex++)
                        {
                            rewards[0][rewardIndex].HandleReward(gameManager);
                        }
                    }
                    else
                    {
                        //Ask the game manager to show the user their options
                    }
                }
            }
        }
    }
}