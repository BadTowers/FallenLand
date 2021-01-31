
namespace FallenLand
{
    public class FlamethrowerEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Flame Thrower");
        }
    }
}