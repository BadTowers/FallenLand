
namespace FallenLand
{
    public class WristRockerSlingshotOrFlareGunOrSportingGoodsEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Wrist Rocker Slingshot") ||
                gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Flare Gun Pistol") ||
                gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Sporting_Goods);
        }
    }
}