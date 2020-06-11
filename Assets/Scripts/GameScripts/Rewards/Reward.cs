
namespace FallenLand
{
    public abstract class Reward
    {
        private int Amount;

        public Reward(int amount)
        {
            Amount = amount;
        }

        public int GetRewardAmount()
        {
            return Amount;
        }

        public abstract void HandleReward(GameManager gameManager);
    }
}