
namespace FallenLand
{
    public class LoseMechanical : Punishment
    {
        public LoseMechanical(int amountToLose) : base(amountToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseSkillAmount(playerIndex, GetCharacterIndex(), Skills.Mechanical, GetPunishmentAmount());
        }
    }
}