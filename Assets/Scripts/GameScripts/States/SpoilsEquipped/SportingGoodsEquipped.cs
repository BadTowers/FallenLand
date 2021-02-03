
namespace FallenLand
{
    public class SportingGoodsEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Sporting_Goods);
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.GetNumberOfSpoilsTypeEquippedToCharacter(playerIndex, characterIndex, SpoilsTypes.Sporting_Goods);
        }
    }
}