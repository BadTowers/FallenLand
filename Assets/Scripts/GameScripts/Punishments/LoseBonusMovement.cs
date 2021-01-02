
namespace FallenLand
{
    public class LoseBonusMovement : Punishment
    {
        public LoseBonusMovement(int amountToLose) : base(amountToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.SubtractBonusMovement(playerIndex, base.GetPunishmentAmount());
        }
    }
}