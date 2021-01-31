
namespace FallenLand
{
    public class LosePrestige : Punishment
    {
        public LosePrestige(int amountToLose) : base(amountToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LosePrestige(playerIndex, base.GetPunishmentAmount());
        }
    }
}