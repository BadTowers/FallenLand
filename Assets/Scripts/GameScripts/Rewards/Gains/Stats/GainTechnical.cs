
namespace FallenLand
{
    public class GainTechnical : Reward
    {
        public GainTechnical(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Technical, GetRewardAmount());
        }
    }
}