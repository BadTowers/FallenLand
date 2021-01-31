
namespace FallenLand
{
    public class Any4WheelVehicleInParty : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int _)
        {
            return gameManager.IsVehicleOfCertainType(playerIndex, SpoilsTypes.Four_Wheeled);
        }
    }
}