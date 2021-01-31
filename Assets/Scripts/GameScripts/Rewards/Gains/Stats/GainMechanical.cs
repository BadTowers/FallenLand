
namespace FallenLand
{
    public class GainMechanical : Reward
    {
        public GainMechanical(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Mechanical, GetRewardAmount());
        }
    }
}