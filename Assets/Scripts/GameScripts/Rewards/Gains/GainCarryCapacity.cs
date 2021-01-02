
namespace FallenLand
{
    public class GainCarryCapacity : Reward
    {
        public GainCarryCapacity(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainCarryWeight(playerIndex, base.GetCharacterIndex(), base.GetRewardAmount());
        }
    }
}