
namespace FallenLand
{
    public class LoseCarryCapacity : Punishment
    {
        public LoseCarryCapacity(int amountToLose) : base(amountToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseCarryWeight(playerIndex, base.GetCharacterIndex(), base.GetPunishmentAmount());
        }
    }
}