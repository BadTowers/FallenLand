
namespace FallenLand
{
    public class IndestructibleTennisRacquetOrSledgeHammerOrSockMonkeyPuppetEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Indestructible Tennis Racquet") ||
                gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Sledge Hammer") ||
                gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Genuine Sock Monkey Puppet");
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            int instances = 0;

            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Indestructible Tennis Racquet"))
            {
                instances++;
            }
            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Sledge Hammer"))
            {
                instances++;
            }
            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Genuine Sock Monkey Puppet"))
            {
                instances++;
            }

            return instances;
        }
    }
}