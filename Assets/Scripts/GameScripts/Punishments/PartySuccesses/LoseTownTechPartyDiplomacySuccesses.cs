
namespace FallenLand
{
    public class LoseTownTechPartyDiplomacySuccesses : Punishment
    {
        public LoseTownTechPartyDiplomacySuccesses(int amount) : base(amount)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseTownTechSuccesses(playerIndex, Skills.Diplomacy, GetPunishmentAmount());
        }
    }
}