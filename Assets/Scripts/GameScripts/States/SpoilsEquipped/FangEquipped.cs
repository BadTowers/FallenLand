
namespace FallenLand
{
    public class FangEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Fang");
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            int instances = 0;
            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Fang"))
            {
                instances++;
            }
            return instances;
        }
    }
}