
namespace FallenLand
{
    public class UltimateSetOfToolsEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Ultimate Set of Tools");
        }
    }
}