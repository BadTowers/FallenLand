
namespace FallenLand
{
    public class LaptopComputerEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Ultimate Laptop");
        }
    }
}