
namespace FallenLand
{
    public class FangEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Fang");
        }
    }
}