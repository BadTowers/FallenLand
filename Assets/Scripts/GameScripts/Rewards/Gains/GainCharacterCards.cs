
namespace FallenLand
{
    public class GainCharacterCards : Reward
    {
        public GainCharacterCards(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (playerIndex == myIndex)
            {
                gameManager.DealCharacterCardsToPlayer(myIndex, base.GetRewardAmount());
            }
        }
    }
}