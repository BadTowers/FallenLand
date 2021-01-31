
namespace FallenLand
{
    public class GainCombat : Reward
    {
        public GainCombat(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Combat, GetRewardAmount());
        }
    }
}