using System.Collections.Generic;

namespace FallenLand
{
    public class EncounterResultsHandler
    {
        public static void HandleFailure(GameManager gameManager, int playerIndex)
        {
            List<Punishment> punishments = gameManager.GetCurrentEncounter(playerIndex).GetPunishmentsOnFail();

            for (int i = 0; i < punishments.Count; i++)
            {
                punishments[i].HandlePunishment(gameManager, playerIndex);
            }
        }

        public static void HandleSuccess(GameManager gameManager, int playerIndex)
        {
            EncounterCard encounterCard = gameManager.GetCurrentEncounter(playerIndex);
            List<Reward> rewards = encounterCard.GetRewardsOnSuccess();

            for (int i = 0; i < rewards.Count; i++)
            {
                rewards[i].HandleReward(gameManager, playerIndex);
            }

            List<Punishment> punishments = encounterCard.GetPunishmentsOnSuccess();
            for (int i = 0; i < punishments.Count; i++)
            {
                punishments[i].HandlePunishment(gameManager, playerIndex);
            }
        }
    }
}