using System.Collections.Generic;

namespace FallenLand
{
    public class LinksManager
    {
        public static void HandleLinks(GameManager gameManager, int playerIndex)
        {
            List<CharacterCard> characters = gameManager.GetActiveCharacterCards(playerIndex);

            for (int characterIndex = 0; characterIndex < characters.Count; characterIndex++)
            {
                if (characters[characterIndex] != null)
                {
                    LinkCommon link = characters[characterIndex].GetCharacterLink();
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
}