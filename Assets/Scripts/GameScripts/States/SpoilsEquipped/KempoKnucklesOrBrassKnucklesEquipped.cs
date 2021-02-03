
namespace FallenLand
{
    public class KempoKnucklesOrBrassKnucklesEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Lead Filled Kempo Gloves") || gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Brass Knuckles");
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            int instances = 0;

            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Lead Filled Kempo Gloves"))
            {
                instances++;
            }
            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Brass Knuckles"))
            {
                instances++;
            }

            return instances;
        }
    }
}