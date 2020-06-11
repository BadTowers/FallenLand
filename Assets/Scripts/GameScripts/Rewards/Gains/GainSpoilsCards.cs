
namespace FallenLand
{
    public class GainSpoilsCards : Reward
    {
        public GainSpoilsCards(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            gameManager.DealSpoilsToPlayer(myIndex, base.GetRewardAmount());
        }
    }
}