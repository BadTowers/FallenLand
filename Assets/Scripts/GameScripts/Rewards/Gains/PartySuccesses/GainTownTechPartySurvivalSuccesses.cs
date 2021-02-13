
namespace FallenLand
{
    public class GainTownTechPartySurvivalSuccesses : Reward
    {
        public GainTownTechPartySurvivalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainTownTechSuccesses(playerIndex, Skills.Survival, GetRewardAmount());
        }
    }
}