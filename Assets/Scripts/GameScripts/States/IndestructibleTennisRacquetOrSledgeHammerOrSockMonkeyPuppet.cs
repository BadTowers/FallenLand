
namespace FallenLand
{
    public class IndestructibleTennisRacquetOrSledgeHammerOrSockMonkeyPuppet : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Indestructible Tennis Racquet") ||
                gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Sledge Hammer") ||
                gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Genuine Sock Monkey Puppet");
        }
    }
}