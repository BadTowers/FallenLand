
namespace FallenLand
{
    public class GainPartyTechnicalSuccesses : Reward
    {
        public GainPartyTechnicalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            //gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Combat, GetRewardAmount());
        }
    }
}