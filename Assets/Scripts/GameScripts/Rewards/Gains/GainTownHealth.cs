
namespace FallenLand
{
    public class GainTownHealth : Reward
    {
        public GainTownHealth(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainTownHealth(playerIndex, base.GetRewardAmount());
        }
    }
}