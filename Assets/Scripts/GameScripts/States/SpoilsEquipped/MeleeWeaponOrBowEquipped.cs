
namespace FallenLand
{
    public class MeleeWeaponOrBowEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Melee_Weapon) || gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Bow);
        }
    }
}