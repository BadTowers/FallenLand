
namespace FallenLand
{
    public class GainTownTechPartyTechnicalSuccesses : Reward
    {
        public GainTownTechPartyTechnicalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainTownTechSuccesses(playerIndex, Skills.Technical, GetRewardAmount());
        }
    }
}