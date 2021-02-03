using System.Collections.Generic;

namespace FallenLand
{
    public abstract class LinkCommon
    {
        private readonly string LinkTitle;
        private readonly List<Reward> RewardsOnActivate = new List<Reward>();
        private readonly List<Punishment> PunishmentsOnActivate = new List<Punishment>();
        private readonly List<Reward> RewardsOnDeactivate = new List<Reward>();
        private readonly List<Punishment> PunishmentsOnDeactivate = new List<Punishment>();
        private bool IsActive;
        private readonly State WhenLinkStarts;

        public LinkCommon(string title, State whenLinkStarts)
        {
            LinkTitle = title;
            WhenLinkStarts = whenLinkStarts;
        }

        public string GetTitle()
        {
            return LinkTitle;
        }

        public State GetWhenLinkStarts()
        {
            return WhenLinkStarts;
        }

        public void AddRewardOnActivate(Reward reward)
        {
            RewardsOnActivate.Add(reward);
        }

        public void AddPunishmentOnActivate(Punishment punishment)
        {
            PunishmentsOnActivate.Add(punishment);
        }

        public void AddRewardOnDeactivate(Reward reward)
        {
            RewardsOnDeactivate.Add(reward);
        }

        public void AddPunishmentOnDeactivate(Punishment punishment)
        {
            PunishmentsOnDeactivate.Add(punishment);
        }

        public List<Reward> GetRewardsOnActivate()
        {
            return RewardsOnActivate;
        }

        public List<Punishment> GetPunishmentsOnActivate()
        {
            return PunishmentsOnActivate;
        }

        public List<Reward> GetRewardsOnDeactivate()
        {
            return RewardsOnDeactivate;
        }

        public List<Punishment> GetPunishmentsOnDeactivate()
        {
            return PunishmentsOnDeactivate;
        }

        public void SetLinkIsActive(bool isActive)
        {
            IsActive = isActive;
        }

        public bool GetLinkIsActive()
        {
            return IsActive;
        }

        public abstract void OnActivate(GameManager gameManager, int playerIndex, int characterIndex);

        public abstract void OnDeactivate(GameManager gameManager, int playerIndex, int characterIndex);
    }
}