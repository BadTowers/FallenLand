
namespace FallenLand
{
    public class KnifeOrSwordEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Knife) || gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Sword);
        }
    }
}