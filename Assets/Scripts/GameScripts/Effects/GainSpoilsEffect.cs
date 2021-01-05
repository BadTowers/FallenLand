using System.Collections.Generic;

namespace FallenLand
{
    public class GainSpoilsEffect : Effect
    {
        public GainSpoilsEffect(string effectName) : base(effectName)
        {
        }

        public override void OnActivate(GameManager gameManager, int playerIndex)
        {
            EventManager.ShowGenericPopup("Effect " + GetEffectName() + " has been applied.");
        }

        public override void OnDeactivate(GameManager gameManager, int playerIndex)
        {
            List<Reward> rewards = GetRewardsWhenEffectEnds();
            for (int i = 0; i < rewards.Count; i++)
            {
                rewards[i].HandleReward(gameManager, playerIndex);
                EventManager.ShowGenericPopup("Effect " + GetEffectName() + " has been completed or worn off.");
            }
        }
    }
}