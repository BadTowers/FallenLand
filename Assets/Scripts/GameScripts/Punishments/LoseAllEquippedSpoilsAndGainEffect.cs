
namespace FallenLand
{
    public class LoseAllEquippedSpoilsAndGainEffect : Punishment
    {
        private Effect EffectGained;

        public LoseAllEquippedSpoilsAndGainEffect(Effect effectGained) : base(0)
        {
            EffectGained = effectGained;
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseAllEquippedSpoils(playerIndex);
            gameManager.ApplyEffectToPlayer(playerIndex, EffectGained);
        }
    }
}