
namespace FallenLand
{
    public class DealSetAmountOfPhysicalDamageToCharacterCrown : Action
    {
        private int AmountOfDamage = 0;
        private int CharacterCrownIndex;

        public DealSetAmountOfPhysicalDamageToCharacterCrown(int characterCrownIndex, int amount)
        {
            AmountOfDamage = amount;
            CharacterCrownIndex = characterCrownIndex;
        }

        public override void HandleAction(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (myIndex == playerIndex)
            {
                gameManager.CharacterCrownTakesSetAmountOfDamage(playerIndex, CharacterCrownIndex, AmountOfDamage, Constants.DAMAGE_PHYSICAL);
            }
        }
    }
}