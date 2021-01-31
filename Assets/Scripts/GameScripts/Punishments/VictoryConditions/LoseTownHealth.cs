
namespace FallenLand
{
    public class LoseTownHealth : Punishment
    {
        public LoseTownHealth(int amountToLose) : base(amountToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseTownHealth(playerIndex, base.GetPunishmentAmount());
        }
    }
}