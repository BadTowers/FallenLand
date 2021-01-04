using System.Collections.Generic;

namespace FallenLand
{
    public abstract class Effect
    {
        private string EffectName;
        private State WhenEffectEnds;
        private List<Reward> RewardsWhenEffectEnds = new List<Reward>();
        private bool IsRemovedWhenEffectEnds;

        public Effect(string effectName)
        {
            EffectName = effectName;
        }

        public string GetEffectName()
        {
            return EffectName;
        }

        public void SetWhenEffectEnds(State whenEnds)
        {
            WhenEffectEnds = whenEnds;
        }

        public State GetWhenEffectEnds()
        {
            return WhenEffectEnds;
        }

        public void AddRewardWhenEffectEnds(Reward rewardOnEnd)
        {
            RewardsWhenEffectEnds.Add(rewardOnEnd);
        }

        public List<Reward> GetRewardsWhenEffectEnds()
        {
            return RewardsWhenEffectEnds;
        }

        public void SetEffectIsRemovedOnceRewardGiven(bool isRemovedOnceEnded)
        {
            IsRemovedWhenEffectEnds = isRemovedOnceEnded;
        }

        public bool GetEffectIsRemovedOnceEnded()
        {
            return IsRemovedWhenEffectEnds;
        }

        public abstract void HandleEffect(GameManager gameManager, int playerIndex);
    }
}