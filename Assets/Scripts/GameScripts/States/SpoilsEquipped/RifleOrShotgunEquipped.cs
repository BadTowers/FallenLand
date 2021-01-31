
namespace FallenLand
{
    public class RifleOrShotgunEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Rifle) || gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Shotgun);
        }
    }
}