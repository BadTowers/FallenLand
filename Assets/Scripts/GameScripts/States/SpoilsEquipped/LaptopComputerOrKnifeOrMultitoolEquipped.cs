
namespace FallenLand
{
    public class LaptopComputerOrKnifeOrMultitoolEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Ultimate Laptop") ||
                gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Nifty Multi-Tool") ||
                gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Knife);
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            int instances = gameManager.GetNumberOfSpoilsTypeEquippedToCharacter(playerIndex, characterIndex, SpoilsTypes.Knife);

            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Ultimate Laptop"))
            {
                instances++;
            }
            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Nifty Multi-Tool"))
            {
                instances++;
            }

            return instances;
        }
    }
}