
namespace FallenLand
{
    public class LoseSurvival : Punishment
    {
        public LoseSurvival(int amountToLose) : base(amountToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseSkillAmount(playerIndex, GetCharacterIndex(), Skills.Survival, GetPunishmentAmount());
        }
    }
}