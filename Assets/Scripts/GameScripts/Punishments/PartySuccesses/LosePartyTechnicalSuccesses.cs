
namespace FallenLand
{
    public class LosePartyTechnicalSuccesses : Punishment
    {
        public LosePartyTechnicalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            //gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Combat, GetRewardAmount());
        }
    }
}