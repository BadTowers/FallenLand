using System.Collections.Generic;

namespace FallenLand
{
    public class CumulativeLink : LinkCommon
    {
        private int NumCumulativeAccountedFor;

        public CumulativeLink(string title, State whenLinkStarts) : base(title, whenLinkStarts)
        {
        }

        public override void OnActivate(GameManager gameManager, int playerIndex, int characterIndex)
        {
            SetLinkIsActive(true);

            //Compute number of cumulative stacks
            int numInstances = GetWhenLinkStarts().NumberOfInstancesOfStateOccurring(gameManager, playerIndex, characterIndex);
            int differencesOfInstances = numInstances - NumCumulativeAccountedFor;

            if (differencesOfInstances > 0)
            {
                List<Reward> rewardsOnActivate = GetRewardsOnActivate();
                for (int numRewardsToAdd = 0; numRewardsToAdd < differencesOfInstances; numRewardsToAdd++)
                {
                    for (int rewardIndex = 0; rewardIndex < rewardsOnActivate.Count; rewardIndex++)
                    {
                        rewardsOnActivate[rewardIndex].SetCharacterIndex(characterIndex);
                        rewardsOnActivate[rewardIndex].HandleReward(gameManager, playerIndex);
                    }
                }
            }
            else if (differencesOfInstances < 0)
            {
                differencesOfInstances *= -1;
                List<Punishment> punishmentsOnActivate = GetPunishmentsOnActivate();
                for (int numPunishmentsToAdd = 0; numPunishmentsToAdd < differencesOfInstances; numPunishmentsToAdd++)
                {
                    for (int punishmentIndex = 0; punishmentIndex < punishmentsOnActivate.Count; punishmentIndex++)
                    {
                        punishmentsOnActivate[punishmentIndex].SetCharacterIndex(characterIndex);
                        punishmentsOnActivate[punishmentIndex].HandlePunishment(gameManager, playerIndex);
                    }
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

        public void SetNumCumulativeAccountedFor(int amount)
        {
            NumCumulativeAccountedFor = amount;
        }

        public int GetNumCumulativeAccountedFor()
        {
            return NumCumulativeAccountedFor;
        }
    }
}