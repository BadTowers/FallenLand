
namespace FallenLand
{
    public class LoseTechnical : Punishment
    {
        public LoseTechnical(int amountToLose) : base(amountToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseSkillAmount(playerIndex, GetCharacterIndex(), Skills.Technical, GetPunishmentAmount());
        }
    }
}