
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
    }
}