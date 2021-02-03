using System.Collections.Generic;

namespace FallenLand
{
    public class Link : LinkCommon
    {
        public Link(string title, State whenLinkStarts) : base(title, whenLinkStarts)
        {
        }

        public override void OnActivate(GameManager gameManager, int playerIndex, int characterIndex)
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

        public override void OnDeactivate(GameManager gameManager, int playerIndex, int characterIndex)
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