
namespace FallenLand
{
    public class AddWeekPenalty : Punishment
    {
        public AddWeekPenalty(int amountToLose) : base(amountToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.AddWeekPenalty(playerIndex, GetPunishmentAmount());
        }
    }
}