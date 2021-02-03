
namespace FallenLand
{
    public class EspressoVanInPartyOrKnifeOrSwordEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificVehicleInParty(playerIndex, "Espresso Van") ||
                gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Knife) ||
                gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Sword);
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            int instances = gameManager.GetNumberOfSpoilsTypeEquippedToCharacter(playerIndex, characterIndex, SpoilsTypes.Knife) + gameManager.GetNumberOfSpoilsTypeEquippedToCharacter(playerIndex, characterIndex, SpoilsTypes.Sword);
            if (gameManager.IsSpecificVehicleInParty(playerIndex, "Espresso Van"))
            {
                instances++;
            }
            return instances;
        }
    }
}