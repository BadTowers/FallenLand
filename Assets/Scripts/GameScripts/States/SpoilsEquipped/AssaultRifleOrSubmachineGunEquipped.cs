
namespace FallenLand
{
    public class AssaultRifleOrSubmachineGunEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Assault_Rifle) || gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Submachine_Gun);
        }
    }
}