
namespace FallenLand
{
    public class GainNextRelicSpoilsCard : Reward
    {
        public GainNextRelicSpoilsCard() : base(1)
        {
        }

        public override void HandleReward(GameManager gameManager)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            gameManager.DealNextRelicSpoilsToPlayer(myIndex);
        }
    }
}