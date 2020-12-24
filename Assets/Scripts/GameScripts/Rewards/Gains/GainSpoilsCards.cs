
namespace FallenLand
{
    public class GainSpoilsCards : Reward
    {
        public GainSpoilsCards(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (playerIndex == myIndex)
            {
                gameManager.DealSpoilsToPlayer(myIndex, base.GetRewardAmount());
            }
        }
    }
}