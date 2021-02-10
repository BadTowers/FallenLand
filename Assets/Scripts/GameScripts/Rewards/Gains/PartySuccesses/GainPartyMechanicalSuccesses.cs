
namespace FallenLand
{
    public class GainPartyMechanicalSuccesses : Reward
    {
        public GainPartyMechanicalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            //gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Combat, GetRewardAmount());
        }
    }
}