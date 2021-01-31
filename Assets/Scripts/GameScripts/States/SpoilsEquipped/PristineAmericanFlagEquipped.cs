
namespace FallenLand
{
    public class PristineAmericanFlagEquipped : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex)
        {
            return gameManager.IsSpecificSpoilsEquipped(playerIndex, characterIndex, "Pristine American Flag");
        }
    }
}