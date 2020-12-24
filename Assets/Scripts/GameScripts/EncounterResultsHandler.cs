using System.Collections.Generic;

namespace FallenLand
{
    public class EncounterResultsHandler
    {
        public static void HandleFailure(GameManager gameManager, int playerIndex)
        {
            List<Punishment> punishments = gameManager.GetCurrentEncounter(playerIndex).GetPunishments();

            for (int i = 0; i < punishments.Count; i++)
            {
                punishments[i].HandlePunishment(gameManager, playerIndex);
            }
        }

        public static void HandleSuccess(GameManager gameManager, int playerIndex)
        {
            List<Reward> rewards = gameManager.GetCurrentEncounter(playerIndex).GetRewards();

            for (int i = 0; i < rewards.Count; i++)
            {
                rewards[i].HandleReward(gameManager, playerIndex);
            }
        }
    }
}