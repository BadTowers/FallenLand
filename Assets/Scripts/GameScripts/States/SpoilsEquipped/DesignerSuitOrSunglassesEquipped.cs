
namespace FallenLand
{
    public class DesignerSuitOrSunglassesEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Luxurious Designer Suit") || gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Sunglasses");
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            int instances = 0;
            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Luxurious Designer Suit"))
            {
                instances++;
            }
            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Sunglasses"))
            {
                instances++;
            }
            return instances;
        }
    }
}