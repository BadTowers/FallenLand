
namespace FallenLand
{
    public class MeleeWeaponEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Melee_Weapon);
        }
    }
}