
namespace FallenLand
{
    public class GainBonusMovement : Reward
    {
        public GainBonusMovement(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.AddBonusMovement(playerIndex, base.GetRewardAmount());
        }
    }
}