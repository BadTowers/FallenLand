
using System.Collections.Generic;

namespace FallenLand
{
    public class LoseRandomCharacterCrownAndTheirEquipment : Punishment
    {
        public LoseRandomCharacterCrownAndTheirEquipment() : base(1)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (myIndex == playerIndex)
            {
                Dice diceRoller = gameManager.GetDiceRoller();
                bool hasAtLeastOneCharacterInParty = false;

                //First make sure there exists at least one character in the party
                List<CharacterCard> characters = gameManager.GetActiveCharacterCards(playerIndex);
                for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
                {
                    if (characters[characterIndex] != null)
                    {
                        hasAtLeastOneCharacterInParty = true;
                    }
                }

                if (!hasAtLeastOneCharacterInParty)
                {
                    return; //No one in the party, so we have no one to kill. Exit.
                }

                //Find a valid random character crown to kill
                bool foundCharacterSlot = false;
                int randomCharacterCrownIndex;
                do
                {
                    randomCharacterCrownIndex = diceRoller.RollDice(5) - 1;
                    if (characters[randomCharacterCrownIndex] != null)
                    {
                        foundCharacterSlot = true;
                    }
                } while (!foundCharacterSlot);
                gameManager.CharacterCrownDiesAndLosesEquipment(playerIndex, randomCharacterCrownIndex);
            }
        }
    }
}