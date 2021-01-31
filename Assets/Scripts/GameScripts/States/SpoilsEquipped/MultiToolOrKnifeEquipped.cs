
namespace FallenLand
{
    public class MultiToolOrKnifeEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Knife) || gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Nifty Multi-Tool");
        }
    }
}