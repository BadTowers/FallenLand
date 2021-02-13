
namespace FallenLand
{
    public class LoseTownTechPartyMedicalSuccesses : Punishment
    {
        public LoseTownTechPartyMedicalSuccesses(int amount) : base(amount)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseTownTechSuccesses(playerIndex, Skills.Medical, GetPunishmentAmount());
        }
    }
}