
namespace FallenLand
{
    public class LoseMostValuableSpoilsThatAreNotVehicle : Punishment
    {
        public LoseMostValuableSpoilsThatAreNotVehicle(int amountOfCardsToLose) : base(amountOfCardsToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseMostValuableSpoilsThatAreNotVehicle(playerIndex, base.GetPunishmentAmount());
        }
    }
}