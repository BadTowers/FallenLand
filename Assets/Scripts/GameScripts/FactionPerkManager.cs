using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
    public class FactionPerkManager
    {
        public static void HandlePhase(GameManager gameManager)
        {
            List<Player> players = gameManager.GetPlayers();
            int myIndex = gameManager.GetIndexForMyPlayer();

            List<Perk> perks = players[myIndex].GetPlayerFaction().GetPerks();
            for (int i = 0; i < perks.Count; i++)
            {
                ConditionalGain conditionalGain = perks[i].GetConditionalGain();
                ConditionalGainHelpers.HandleConditionalGain(gameManager, conditionalGain);
            }
        }
    }
}