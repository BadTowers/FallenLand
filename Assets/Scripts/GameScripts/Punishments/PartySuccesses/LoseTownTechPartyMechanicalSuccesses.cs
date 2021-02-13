
namespace FallenLand
{
    public class LoseTownTechPartyMechanicalSuccesses : Punishment
    {
        public LoseTownTechPartyMechanicalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseTownTechSuccesses(playerIndex, Skills.Mechanical, GetPunishmentAmount());
        }
    }
}