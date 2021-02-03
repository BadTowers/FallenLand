
namespace FallenLand
{
    public class SockMonkeyOrShotgunOrAlcoholEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Genuine Sock Monkey Puppet") ||
                gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Shotgun) ||
                gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Alcohol);
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            int instances = gameManager.GetNumberOfSpoilsTypeEquippedToCharacter(playerIndex, characterIndex, SpoilsTypes.Shotgun) + gameManager.GetNumberOfSpoilsTypeEquippedToCharacter(playerIndex, characterIndex, SpoilsTypes.Alcohol);

            if (gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Genuine Sock Monkey Puppet"))
            {
                instances++;
            }

            return instances;
        }
    }
}