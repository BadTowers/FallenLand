
namespace FallenLand
{
    public class LosePartyMechanicalSuccesses : Punishment
    {
        public LosePartyMechanicalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            //gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Combat, GetRewardAmount());
        }
    }
}