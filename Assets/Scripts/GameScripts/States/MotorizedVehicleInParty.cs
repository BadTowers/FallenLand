
namespace FallenLand
{
    public class MotorizedVehicleInParty : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int _)
        {
            return gameManager.IsVehicleOfCertainType(playerIndex, SpoilsTypes.Motorized);
        }
    }
}