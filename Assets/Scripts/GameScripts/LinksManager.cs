using System.Collections.Generic;

namespace FallenLand
{
    public class LinksManager
    {
        public static void HandleLinks(GameManager gameManager, int playerIndex)
        {
            List<CharacterCard> partyMembers = gameManager.GetActiveCharacterCards(playerIndex);
            for (int characterIndex = 0; characterIndex < partyMembers.Count; characterIndex++)
            {
                handleLinks(gameManager, playerIndex, characterIndex, partyMembers[characterIndex]);
            }
        }

        public static void HandleLinks(GameManager gameManager, int playerIndex, int characterIndex)
        {
            handleLinks(gameManager, playerIndex, characterIndex, gameManager.GetActiveCharacterCards(playerIndex)[characterIndex]);
        }

        private static void handleLinks(GameManager gameManager, int playerIndex, int characterIndex, CharacterCard character)
        {
            if (character != null)
            {
                LinkCommon link = character.GetCharacterLink();
                if (link != null)
                {
                    if (link is Link)
                    {
                        //See if link started or ended
                        if (!link.GetLinkIsActive() && link.GetWhenLinkStarts().IsStateOccurring(gameManager, playerIndex, characterIndex))
                        {
                            link.OnActivate(gameManager, playerIndex, characterIndex);
                            gameManager.UpdateCharacterSlotTotals(playerIndex, characterIndex);
                        }
                        else if (link.GetLinkIsActive() && !link.GetWhenLinkStarts().IsStateOccurring(gameManager, playerIndex, characterIndex))
                        {
                            link.OnDeactivate(gameManager, playerIndex, characterIndex);
                            gameManager.UpdateCharacterSlotTotals(playerIndex, characterIndex);
                        }
                    }
                    else if (link is CumulativeLink)
                    {
                        //See if link started or ended
                        if (link.GetWhenLinkStarts().IsStateOccurring(gameManager, playerIndex, characterIndex))
                        {
                            link.OnActivate(gameManager, playerIndex, characterIndex);
                            gameManager.UpdateCharacterSlotTotals(playerIndex, characterIndex);
                        }
                        else if (link.GetLinkIsActive() && !link.GetWhenLinkStarts().IsStateOccurring(gameManager, playerIndex, characterIndex))
                        {
                            link.OnDeactivate(gameManager, playerIndex, characterIndex);
                            gameManager.UpdateCharacterSlotTotals(playerIndex, characterIndex);
                        }
                    }
                }
            }
        }
    }
}