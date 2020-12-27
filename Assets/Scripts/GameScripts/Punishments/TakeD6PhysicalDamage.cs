
namespace FallenLand
{
    public class TakeD6PhysicalDamage : Punishment
    {
        public TakeD6PhysicalDamage(int amountOfD6s) : base(amountOfD6s)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (myIndex == playerIndex)
            {
                gameManager.DistributeD6PhysicalDamageToParty(playerIndex, base.GetPunishmentAmount());
            }
        }
    }
}