
using System.Collections.Generic;

namespace FallenLand
{
    public class GainsManager
    {
        public static void HandleGains(GameManager gameManager, List<Dictionary<Gains, int>> gains)
        {
            for (int i = 0; i < gains.Count; i++)
            {
                foreach (KeyValuePair<Gains, int> entry in gains[i])
                {
                    if (Gains.Gain_Spoils_Cards == entry.Key)
                    {
                        int myIndex = gameManager.GetIndexForMyPlayer();
                        gameManager.DealSpoilsToPlayer(myIndex, entry.Value);
                    }
                }
            }
        }
    }
}
