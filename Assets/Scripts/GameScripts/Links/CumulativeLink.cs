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
                List<Punishment> punishmentsOnActivate = GetPunishmentsOnActivate();
                for (int numToAdd = 0; numToAdd < differencesOfInstances; numToAdd++)
                {
                    for (int rewardIndex = 0; rewardIndex < rewardsOnActivate.Count; rewardIndex++)
                    {
                        rewardsOnActivate[rewardIndex].SetCharacterIndex(characterIndex);
                        rewardsOnActivate[rewardIndex].HandleReward(gameManager, playerIndex);
                    }

                    for (int punishmentIndex = 0; punishmentIndex < punishmentsOnActivate.Count; punishmentIndex++)
                    {
                        punishmentsOnActivate[punishmentIndex].SetCharacterIndex(characterIndex);
                        punishmentsOnActivate[punishmentIndex].HandlePunishment(gameManager, playerIndex);
                    }
                }
            }
            else if (differencesOfInstances < 0)
            {
                List<Reward> rewardsOnDeactivate = GetRewardsOnDeactivate();
                List<Punishment> punishmentsOnDeactivate = GetPunishmentsOnDeactivate();
                differencesOfInstances *= -1;
                for (int numToAdd = 0; numToAdd < differencesOfInstances; numToAdd++)
                {
                    for (int rewardIndex = 0; rewardIndex < rewardsOnDeactivate.Count; rewardIndex++)
                    {
                        rewardsOnDeactivate[rewardIndex].SetCharacterIndex(characterIndex);
                        rewardsOnDeactivate[rewardIndex].HandleReward(gameManager, playerIndex);
                    }

                    for (int punishmentIndex = 0; punishmentIndex < punishmentsOnDeactivate.Count; punishmentIndex++)
                    {
                        punishmentsOnDeactivate[punishmentIndex].SetCharacterIndex(characterIndex);
                        punishmentsOnDeactivate[punishmentIndex].HandlePunishment(gameManager, playerIndex);
                    }
                }
            }
            NumCumulativeAccountedFor = numInstances;
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
            NumCumulativeAccountedFor = 0;
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