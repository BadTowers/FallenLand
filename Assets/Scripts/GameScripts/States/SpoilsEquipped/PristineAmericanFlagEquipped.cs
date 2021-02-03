
namespace FallenLand
{
    public class PristineAmericanFlagEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Pristine American Flag");
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            int instances = 0;

            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Pristine American Flag"))
            {
                instances++;
            }

            return instances;
        }
    }
}