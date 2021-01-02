
namespace FallenLand
{
    public class GainPsychResistance : Reward
    {
        public GainPsychResistance(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            gameManager.GainPsychResistance(playerIndex, base.GetCharacterIndex(), base.GetRewardAmount());
        }
    }
}