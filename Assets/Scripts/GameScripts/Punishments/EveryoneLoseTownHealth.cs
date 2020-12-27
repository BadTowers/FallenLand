
namespace FallenLand
{
    public class EveryoneLoseTownHealth : Punishment
    {
        public EveryoneLoseTownHealth(int amountToLose) : base(amountToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.EveryoneLoseTownHealth(base.GetPunishmentAmount());
        }
    }
}