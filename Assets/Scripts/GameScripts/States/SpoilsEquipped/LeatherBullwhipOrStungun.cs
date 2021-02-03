
namespace FallenLand
{
    public class LeatherBullwhipOrStungun : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Leather Bull Whip") || gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Top o' the Line Stun Gun");
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            int instances = 0;

            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Leather Bull Whip"))
            {
                instances++;
            }
            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Top o' the Line Stun Gun"))
            {
                instances++;
            }

            return instances;
        }
    }
}