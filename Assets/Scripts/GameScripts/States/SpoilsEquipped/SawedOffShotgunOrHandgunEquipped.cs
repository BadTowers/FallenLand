
namespace FallenLand
{
    public class SawedOffShotgunOrHandgunEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpoilsTypeEquipped(playerIndex, characterIndex, SpoilsTypes.Handgun) || gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Sawed Off Double Barreled");
        }
    }
}