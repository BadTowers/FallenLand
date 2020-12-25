
namespace FallenLand
{
    public class TakeD6Damage : Punishment
    {
        public TakeD6Damage(int amountOfD6s) : base(amountOfD6s)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.DistributeD6DamageToParty(playerIndex, base.GetPunishmentAmount());
        }
    }
}