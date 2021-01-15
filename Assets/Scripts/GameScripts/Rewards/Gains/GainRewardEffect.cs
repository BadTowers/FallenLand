
namespace FallenLand
{
    public class GainRewardEffect : Reward
    {
        private Effect EffectToApply;

        public GainRewardEffect(Effect effect) : base(0)
        {
            EffectToApply = effect;
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.ApplyEffectToPlayer(playerIndex, EffectToApply);
        }
    }
}