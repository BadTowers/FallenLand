
namespace FallenLand
{
    public class LosePartyMedicalSuccesses : Punishment
    {
        public LosePartyMedicalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            //gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Combat, GetRewardAmount());
        }
    }
}