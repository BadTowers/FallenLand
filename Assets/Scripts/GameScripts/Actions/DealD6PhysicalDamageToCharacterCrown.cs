
namespace FallenLand
{
    public class DealD6PhysicalDamageToCharacterCrown : Action
    {
        private int NumberOfD6s;
        private int CharacterCrownIndex;

        public DealD6PhysicalDamageToCharacterCrown(int characterCrownIndex, int numOfD6s)
        {
            CharacterCrownIndex = characterCrownIndex;
            NumberOfD6s = numOfD6s;
        }

        public override void HandleAction(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (myIndex == playerIndex)
            {
                gameManager.CharacterCrownTakesD6Damage(playerIndex, CharacterCrownIndex, NumberOfD6s, Constants.DAMAGE_PHYSICAL);
            }
        }
    }
}