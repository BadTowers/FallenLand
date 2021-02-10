
namespace FallenLand
{
    public class GainPartyDiplomacySuccesses : Reward
    {
        public GainPartyDiplomacySuccesses(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            //gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Combat, GetRewardAmount());
        }
    }
}