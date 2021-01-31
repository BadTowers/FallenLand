
namespace FallenLand
{
    public class LoseCombat : Punishment
    {
        public LoseCombat(int amountToLose) : base(amountToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseSkillAmount(playerIndex, GetCharacterIndex(), Skills.Combat, GetPunishmentAmount());
        }
    }
}