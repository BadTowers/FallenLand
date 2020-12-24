
namespace FallenLand
{
    public class ApplyPsychDamageToWholeParty : Punishment
    {
        public ApplyPsychDamageToWholeParty(int amountOfPsychDamage) : base(amountOfPsychDamage)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.ApplyPsychDamageToWholeParty(playerIndex, base.GetPunishmentAmount());
        }
    }
}