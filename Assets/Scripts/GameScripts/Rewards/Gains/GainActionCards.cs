
namespace FallenLand
{
    public class GainActionCards : Reward
    {
        public GainActionCards(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (myIndex == playerIndex)
            {
                gameManager.DealActionCardsToPlayer(playerIndex, base.GetRewardAmount());
            }
        }
    }
}