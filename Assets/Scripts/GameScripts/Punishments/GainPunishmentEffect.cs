
namespace FallenLand
{
    public class GainPunishmentEffect : Punishment
    {
        private Effect EffectToApply;

        public GainPunishmentEffect(Effect effect) : base(0)
        {
            EffectToApply = effect;
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.ApplyEffectToPlayer(playerIndex, EffectToApply);
        }
    }
}