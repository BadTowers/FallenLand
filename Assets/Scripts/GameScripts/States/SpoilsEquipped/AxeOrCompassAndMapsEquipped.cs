
namespace FallenLand
{
    public class AxeOrCompassAndMapsEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Axe) || gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Compass and Maps");
        }
    }
}