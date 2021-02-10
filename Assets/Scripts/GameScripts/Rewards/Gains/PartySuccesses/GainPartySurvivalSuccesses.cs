
namespace FallenLand
{
    public class GainPartySurvivalSuccesses : Reward
    {
        public GainPartySurvivalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            //gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Combat, GetRewardAmount());
        }
    }
}