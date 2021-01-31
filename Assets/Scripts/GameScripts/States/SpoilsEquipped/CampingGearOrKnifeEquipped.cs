
namespace FallenLand
{
    public class CampingGearOrKnifeEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Camping_Gear) || gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Knife);
        }
    }
}