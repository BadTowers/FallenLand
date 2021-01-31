using System.Collections.Generic;

namespace FallenLand
{
    public class Link
    {
        private readonly string LinkTitle;
        private readonly List<Reward> RewardsOnActivate = new List<Reward>();
        private readonly List<Punishment> PunishmentsOnActivate = new List<Punishment>();
        private readonly List<Reward> RewardsOnDeactivate = new List<Reward>();
        private readonly List<Punishment> PunishmentsOnDeactivate = new List<Punishment>();
        private bool IsActive;
        private readonly State WhenLinkStarts;

        public Link(string title, State whenLinkStarts)
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

        public void OnActivate(GameManager gameManager, int playerIndex, int characterIndex)
        {
            if (!GetLinkIsActive())
            {
                SetLinkIsActive(true);

                List<Reward> rewardsOnActivate = GetRewardsOnActivate();
                for (int rewardIndex = 0; rewardIndex < rewardsOnActivate.Count; rewardIndex++)
                {
                    rewardsOnActivate[rewardIndex].SetCharacterIndex(characterIndex);
                    rewardsOnActivate[rewardIndex].HandleReward(gameManager, playerIndex);
                }

                List<Punishment> punishmentsOnActivate = GetPunishmentsOnActivate();
                for (int punishmentIndex = 0; punishmentIndex < punishmentsOnActivate.Count; punishmentIndex++)
                {
                    punishmentsOnActivate[punishmentIndex].SetCharacterIndex(characterIndex);
                    punishmentsOnActivate[punishmentIndex].HandlePunishment(gameManager, playerIndex);
                }
            }
        }

        public void OnDeactivate(GameManager gameManager, int playerIndex, int characterIndex)
        {
            SetLinkIsActive(false);

            List<Reward> rewardsOnDeactivate = GetRewardsOnDeactivate();
            for (int rewardIndex = 0; rewardIndex < rewardsOnDeactivate.Count; rewardIndex++)
            {
                rewardsOnDeactivate[rewardIndex].SetCharacterIndex(characterIndex);
                rewardsOnDeactivate[rewardIndex].HandleReward(gameManager, playerIndex);
            }

            List<Punishment> punishmentsOnDeactivate = GetPunishmentsOnDeactivate();
            for (int punishmentIndex = 0; punishmentIndex < punishmentsOnDeactivate.Count; punishmentIndex++)
            {
                punishmentsOnDeactivate[punishmentIndex].SetCharacterIndex(characterIndex);
                punishmentsOnDeactivate[punishmentIndex].HandlePunishment(gameManager, playerIndex);
            }
        }
    }
}