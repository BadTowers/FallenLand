using System.Collections.Generic;

namespace FallenLand
{
    public abstract class Effect
    {
        private string EffectName;
        private State WhenEffectEnds;
        private List<Reward> RewardsWhenEffectEnds = new List<Reward>();
        private List<Punishment> PunishmentsWhenEffectStarts = new List<Punishment>();
        private bool IsRemovedWhenEffectEnds;
        private bool HasBeenActivated;

        public Effect(string effectName)
        {
            EffectName = effectName;
            HasBeenActivated = false;
        }

        public string GetEffectName()
        {
            return EffectName;
        }

        public bool GetHasBeenActivated()
        {
            return HasBeenActivated;
        }

        public void SetHasBeenActivated(bool hasActivated)
        {
            HasBeenActivated = hasActivated;
        }

        public void SetWhenEffectDeactivates(State whenEnds)
        {
            WhenEffectEnds = whenEnds;
        }

        public State GetWhenEffectDeactivates()
        {
            return WhenEffectEnds;
        }

        public void AddRewardToApplyOnDeactivate(Reward rewardOnEnd)
        {
            RewardsWhenEffectEnds.Add(rewardOnEnd);
        }

        public List<Reward> GetRewardsWhenEffectEnds()
        {
            return RewardsWhenEffectEnds;
        }

        public void AddPunishmentToApplyOnActivate(Punishment punishment)
        {
            PunishmentsWhenEffectStarts.Add(punishment);
        }

        public List<Punishment> GetPunishmetsWhenEffectStarts()
        {
            return PunishmentsWhenEffectStarts;
        }

        public void SetEffectIsRemovedOnceDeactivated(bool isRemovedOnceEnded)
        {
            IsRemovedWhenEffectEnds = isRemovedOnceEnded;
        }

        public bool GetEffectIsRemovedOnceEnded()
        {
            return IsRemovedWhenEffectEnds;
        }

        public abstract void OnActivate(GameManager gameManager, int playerIndex);
        public abstract void OnDeactivate(GameManager gameManager, int playerIndex);
    }
}