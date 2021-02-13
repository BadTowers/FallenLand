
namespace FallenLand
{
    public class LoseTownTechPartyTechnicalSuccesses : Punishment
    {
        public LoseTownTechPartyTechnicalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseTownTechSuccesses(playerIndex, Skills.Technical, GetPunishmentAmount());
        }
    }
}