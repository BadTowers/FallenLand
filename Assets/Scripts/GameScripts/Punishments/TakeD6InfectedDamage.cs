
namespace FallenLand
{
    public class TakeD6InfectedDamage : Punishment
    {
        public TakeD6InfectedDamage(int amountOfD6s) : base(amountOfD6s)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.DistributeD6InfectedDamageToParty(playerIndex, base.GetPunishmentAmount());
        }
    }
}