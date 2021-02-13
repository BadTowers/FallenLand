
namespace FallenLand
{
    public class LoseTownTechPartySurvivalSuccesses : Punishment
    {
        public LoseTownTechPartySurvivalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseTownTechSuccesses(playerIndex, Skills.Survival, GetPunishmentAmount());
        }
    }
}