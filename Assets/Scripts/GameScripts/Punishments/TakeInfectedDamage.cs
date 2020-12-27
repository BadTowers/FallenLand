
namespace FallenLand
{
    public class TakeInfectedDamage : Punishment
    {
        public TakeInfectedDamage(int amountOfDamage) : base(amountOfDamage)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.DealSetAmountOfInfectedDamageToParty(playerIndex, base.GetPunishmentAmount());
        }
    }
}