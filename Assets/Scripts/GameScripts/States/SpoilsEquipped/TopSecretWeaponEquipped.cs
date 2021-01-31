
namespace FallenLand
{
    public class TopSecretWeaponEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Top_Secret);
        }
    }
}