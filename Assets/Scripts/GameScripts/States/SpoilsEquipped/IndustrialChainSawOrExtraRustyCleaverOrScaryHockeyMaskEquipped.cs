
namespace FallenLand
{
    public class IndustrialChainSawOrExtraRustyCleaverOrScaryHockeyMaskEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Industrial Chainsaw") ||
                gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Extra Rusty Cleaver") ||
                gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Scary Hockey Mask");
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            int instances = 0;

            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Industrial Chainsaw"))
            {
                instances++;
            }
            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Extra Rusty Cleaver"))
            {
                instances++;
            }
            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Scary Hockey Mask"))
            {
                instances++;
            }

            return instances;
        }
    }
}