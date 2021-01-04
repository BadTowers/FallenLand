using System.Collections.Generic;

namespace FallenLand
{
    public class GainSpoilsEffect : Effect
    {
        public GainSpoilsEffect(string effectName) : base(effectName)
        {
        }

        public override void HandleEffect(GameManager gameManager, int playerIndex)
        {
            List<Reward> rewards = GetRewardsWhenEffectEnds();
            for (int i = 0; i < rewards.Count; i++)
            {
                rewards[i].HandleReward(gameManager, playerIndex);
                EventManager.ShowGenericPopup("Effect " + GetEffectName() + " has be completed or worn off.");
            }
        }
    }
}