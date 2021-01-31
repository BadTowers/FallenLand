
namespace FallenLand
{
    public class KempoKnucklesOrBrassKnucklesEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Lead Filled Kempo Gloves") || gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Brass Knuckles");
        }
    }
}