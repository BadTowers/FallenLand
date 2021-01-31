
namespace FallenLand
{
    public class BluntWeaponOrHandgunEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Blunt) || gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Handgun);
        }
    }
}