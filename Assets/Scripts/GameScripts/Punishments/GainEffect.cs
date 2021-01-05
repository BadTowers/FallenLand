
namespace FallenLand
{
    public class GainEffect : Punishment
    {
        private Effect EffectToApply;

        public GainEffect(Effect effect) : base(0)
        {
            EffectToApply = effect;
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.ApplyEffectToPlayer(playerIndex, EffectToApply);
        }
    }
}