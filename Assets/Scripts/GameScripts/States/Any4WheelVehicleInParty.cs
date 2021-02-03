
namespace FallenLand
{
    public class Any4WheelVehicleInParty : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int _)
        {
            return gameManager.IsVehicleOfCertainType(playerIndex, SpoilsTypes.Four_Wheeled);
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager _, int __, int ___)
        {
            return 0;
        }
    }
}