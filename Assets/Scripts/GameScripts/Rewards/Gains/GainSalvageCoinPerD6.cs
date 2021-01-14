using System.Collections.Generic;

namespace FallenLand
{
    public class GainSalvageCoinPerD6 : Reward
    {
        public GainSalvageCoinPerD6(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            EncounterCard encounter = gameManager.GetCurrentEncounter(playerIndex);
            List<int> d6Rolls = encounter.GetD6Rolls();
            List<byte> individualPassFailStates = encounter.GetIndividualPassFail();
            int sum = 0;
            for (int characterIndex = 0; characterIndex < d6Rolls.Count; characterIndex++)
            {
                if (individualPassFailStates[characterIndex] == Constants.STATUS_PASSED)
                {
                    sum += d6Rolls[characterIndex] * base.GetRewardAmount();
                }
            }
            gameManager.GainSalvageCoins(playerIndex, sum);
        }
    }
}