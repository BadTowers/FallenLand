
namespace FallenLand
{
    public class PartyTakeInfectedDamage : Punishment
    {
        public PartyTakeInfectedDamage(int amountOfDamage) : base(amountOfDamage)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.DealSetAmountOfInfectedDamageToParty(playerIndex, base.GetPunishmentAmount());
        }
    }
}