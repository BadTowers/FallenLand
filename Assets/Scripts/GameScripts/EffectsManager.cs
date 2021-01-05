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
                //Handle effect begin
                if (!activeEffects[i].GetHasBeenActivated())
                {
                    activeEffects[i].OnActivate(gameManager, playerIndex);
                    activeEffects[i].SetHasBeenActivated(true);
                }

                //Handle effect end
                if(activeEffects[i].GetWhenEffectDeactivates().IsStateOccurring(gameManager))
                {
                    activeEffects[i].OnDeactivate(gameManager, playerIndex);
                    if(activeEffects[i].GetEffectIsRemovedOnceEnded())
                    {
                        activeEffects[i].SetHasBeenActivated(false);
                        gameManager.RemoveActiveEffect(playerIndex, activeEffects[i]);
                    }
                }
            }
        }
    }
}