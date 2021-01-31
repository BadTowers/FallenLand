
namespace FallenLand
{
    public class SledgeHammerEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Sledge Hammer");
        }
    }
}