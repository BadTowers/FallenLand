using System.Collections.Generic;

namespace FallenLand
{
    public class EffectsManager
    {
        public static void HandleEffects(GameManager gameManager, int playerIndex)
        {
            List<Effect> activeEffects = gameManager.GetActiveEffects(playerIndex);

            for (int i = activeEffects.Count - 1; i >= 0 ; i--)
            {
                if(activeEffects[i].GetWhenEffectEnds().IsStateOccurring(gameManager))
                {
                    activeEffects[i].HandleEffect(gameManager, playerIndex);
                    if(activeEffects[i].GetEffectIsRemovedOnceEnded())
                    {
                        gameManager.RemoveActiveEffect(playerIndex, activeEffects[i]);
                    }
                }
            }
        }
    }
}