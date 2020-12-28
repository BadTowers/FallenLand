
namespace FallenLand
{
    public class GainSpecificSpoilsElseSalvage : Reward
    {
        private string SpecificSpoilsString;

        public GainSpecificSpoilsElseSalvage(string specificName, int salvageAmount) : base(salvageAmount)
        {
            SpecificSpoilsString = specificName;
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (gameManager.IsSpecificCardInSpoilsDeck(SpecificSpoilsString))
            {
                if (playerIndex == myIndex)
                {
                    gameManager.DealSpecificSpoilToPlayer(playerIndex, SpecificSpoilsString); //networked
                }
            }
            else if (gameManager.IsSpecificCardInDiscardedSpoilsDeck(SpecificSpoilsString))
            {
                if (playerIndex == myIndex)
                {
                    gameManager.DealSpecificSpoilToPlayerFromDiscardPile(playerIndex, SpecificSpoilsString); //networked
                } 
            }
            else
            {
                UnityEngine.Debug.LogError("We didn't find the card");
                gameManager.GainSalvageCoins(playerIndex, base.GetRewardAmount()); //not networked, everyone does this
                if (playerIndex == myIndex)
                {
                    EventManager.ShowGenericPopup(SpecificSpoilsString + " card unavailable. You gained " + base.GetRewardAmount().ToString() + " salvage coins instead!");
                }
            }
        }
    }
}