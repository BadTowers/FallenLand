
namespace FallenLand
{
    public class GainTownTechPartyDiplomacySuccesses : Reward
    {
        public GainTownTechPartyDiplomacySuccesses(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainTownTechSuccesses(playerIndex, Skills.Diplomacy, GetRewardAmount());
        }
    }
}