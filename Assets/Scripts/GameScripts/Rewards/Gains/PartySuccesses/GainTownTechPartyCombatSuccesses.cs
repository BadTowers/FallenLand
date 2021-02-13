
namespace FallenLand
{
    public class GainTownTechPartyCombatSuccesses : Reward
    {
        public GainTownTechPartyCombatSuccesses(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainTownTechSuccesses(playerIndex, Skills.Combat, GetRewardAmount());
        }
    }
}