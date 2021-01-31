
namespace FallenLand
{
    public class GainMedical : Reward
    {
        public GainMedical(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Medical, GetRewardAmount());
        }
    }
}