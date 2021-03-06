﻿using System.Collections.Generic;

namespace FallenLand
{
    public class LoseBonusMovementEffect : Effect
    {
        public LoseBonusMovementEffect(string effectName) : base(effectName)
        {
        }

        public override void OnActivate(GameManager gameManager, int playerIndex)
        {
            List<Punishment> punishments = GetPunishmetsWhenEffectStarts();
            int myIndex = gameManager.GetIndexForMyPlayer();
            for (int i = 0; i < punishments.Count; i++)
            {
                punishments[i].HandlePunishment(gameManager, playerIndex);
                if (myIndex == playerIndex)
                {
                    EventManager.ShowGenericPopup("Effect " + GetEffectName() + " has been applied.");
                }
            }
        }

        public override void OnDeactivate(GameManager gameManager, int playerIndex)
        {
            List<Reward> rewards = GetRewardsWhenEffectEnds();
            int myIndex = gameManager.GetIndexForMyPlayer();
            for (int i = 0; i < rewards.Count; i++)
            {
                rewards[i].HandleReward(gameManager, playerIndex);
                if (myIndex == playerIndex)
                {
                    EventManager.ShowGenericPopup("Effect " + GetEffectName() + " has been removed.");
                }
            }
        }
    }
}