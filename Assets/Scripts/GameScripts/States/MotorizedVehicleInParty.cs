
namespace FallenLand
{
    public class MotorizedVehicleInParty : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int _)
        {
            return gameManager.IsVehicleOfCertainType(playerIndex, SpoilsTypes.Motorized);
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager _, int __, int ___)
        {
            return 0;
        }
    }
}