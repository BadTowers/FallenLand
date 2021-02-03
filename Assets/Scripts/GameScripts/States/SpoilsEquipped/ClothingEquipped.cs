
namespace FallenLand
{
    public class ClothingEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Clothing);
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.GetNumberOfSpoilsTypeEquippedToCharacter(playerIndex, characterIndex, SpoilsTypes.Clothing);
        }
    }
}