
namespace FallenLand
{
    public class HeavyWeaponEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Heavy_Weapon);
        }
    }
}