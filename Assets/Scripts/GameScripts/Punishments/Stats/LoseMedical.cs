
namespace FallenLand
{
    public class LoseMedical : Punishment
    {
        public LoseMedical(int amountToLose) : base(amountToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseSkillAmount(playerIndex, GetCharacterIndex(), Skills.Medical, GetPunishmentAmount());
        }
    }
}