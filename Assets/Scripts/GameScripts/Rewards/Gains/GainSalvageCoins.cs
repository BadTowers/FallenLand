
namespace FallenLand
{
    public class GainSalvageCoins : Reward
    {
        public GainSalvageCoins(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainSalvageCoins(playerIndex, base.GetRewardAmount());
        }
    }
}