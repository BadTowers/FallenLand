
namespace FallenLand
{
    public class GainSurvival : Reward
    {
        public GainSurvival(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Survival, GetRewardAmount());
        }
    }
}