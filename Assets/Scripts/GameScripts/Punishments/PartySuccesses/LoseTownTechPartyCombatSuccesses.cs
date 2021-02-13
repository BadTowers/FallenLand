
namespace FallenLand
{
    public class LoseTownTechPartyCombatSuccesses : Punishment
    {
        public LoseTownTechPartyCombatSuccesses(int amount) : base(amount)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseTownTechSuccesses(playerIndex, Skills.Combat, GetPunishmentAmount());
        }
    }
}