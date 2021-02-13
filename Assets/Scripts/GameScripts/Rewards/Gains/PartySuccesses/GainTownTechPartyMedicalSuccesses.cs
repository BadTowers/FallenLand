
namespace FallenLand
{
    public class GainTownTechPartyMedicalSuccesses : Reward
    {
        public GainTownTechPartyMedicalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainTownTechSuccesses(playerIndex, Skills.Medical, GetRewardAmount());
        }
    }
}