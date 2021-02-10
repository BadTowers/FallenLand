
namespace FallenLand
{
    public class LosePartySurvivalSuccesses : Punishment
    {
        public LosePartySurvivalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            //gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Combat, GetRewardAmount());
        }
    }
}