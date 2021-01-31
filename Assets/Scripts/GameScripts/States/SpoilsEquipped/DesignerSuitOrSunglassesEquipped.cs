
namespace FallenLand
{
    public class DesignerSuitOrSunglassesEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Luxurious Designer Suit") || gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Sunglasses");
        }
    }
}