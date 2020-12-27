
namespace FallenLand
{
    public class GainHealD6PhysicalDamage : Reward
    {
        public GainHealD6PhysicalDamage(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (myIndex == playerIndex)
            {
                gameManager.DistributeD6HealingPhysicalDamage(playerIndex, base.GetRewardAmount());
            }
        }
    }
}