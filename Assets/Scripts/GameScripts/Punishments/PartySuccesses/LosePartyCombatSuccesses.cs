
namespace FallenLand
{
    public class LosePartyCombatSuccesses : Punishment
    {
        public LosePartyCombatSuccesses(int amount) : base(amount)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            //gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Combat, GetRewardAmount());
        }
    }
}