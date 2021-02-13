
namespace FallenLand
{
    public class GainTownTechPartyMechanicalSuccesses : Reward
    {
        public GainTownTechPartyMechanicalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainTownTechSuccesses(playerIndex, Skills.Mechanical, GetRewardAmount());
        }
    }
}