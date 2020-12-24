
namespace FallenLand
{
    public class GainNextRelicSpoilsCard : Reward
    {
        public GainNextRelicSpoilsCard() : base(1)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (playerIndex == myIndex)
            {
                gameManager.DealNextRelicSpoilsToPlayer(myIndex);
            }
        }
    }
}