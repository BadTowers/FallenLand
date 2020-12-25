
namespace FallenLand
{
    public class GainPrestige : Reward
    {
        public GainPrestige(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainPrestige(playerIndex, base.GetRewardAmount());
        }
    }
}