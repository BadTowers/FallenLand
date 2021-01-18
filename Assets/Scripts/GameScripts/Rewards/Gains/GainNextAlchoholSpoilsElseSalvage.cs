
namespace FallenLand
{
    public class GainNextAlchoholSpoilsElseSalvage : Reward
    {
        public GainNextAlchoholSpoilsElseSalvage(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (playerIndex == myIndex)
            {
                if (!gameManager.DealNextAlcoholSpoilsToPlayer(myIndex))
                {
                    EventManager.ShowGenericPopup("There were no Alcohol spoils in the deck, so you gained " + GetRewardAmount().ToString() + " salvage!");
                    gameManager.NetworkSalvage(playerIndex, GetRewardAmount(), Constants.SALVAGE_GAIN);
                }
            }
        }
    }
}