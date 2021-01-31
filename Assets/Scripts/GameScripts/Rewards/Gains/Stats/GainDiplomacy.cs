
namespace FallenLand
{
    public class GainDiplomacy : Reward
    {
        public GainDiplomacy(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Diplomacy, GetRewardAmount());
        }
    }
}