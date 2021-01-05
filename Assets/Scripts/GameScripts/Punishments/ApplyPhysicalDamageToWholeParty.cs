
namespace FallenLand
{
    public class ApplyPhysicalDamageToWholeParty : Punishment
    {
        public ApplyPhysicalDamageToWholeParty(int amountToLose) : base(amountToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.ApplyPhysicalDamageToWholeParty(playerIndex, base.GetPunishmentAmount());
        }
    }
}