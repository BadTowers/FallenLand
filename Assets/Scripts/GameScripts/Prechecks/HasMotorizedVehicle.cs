
namespace FallenLand
{
    public class HasMotorizedVehicle : Precheck
    {
        public HasMotorizedVehicle()
        {
        }

        public override bool PrechecksHold(GameManager gameManager, int playerIndex)
        {
            bool precheckHolds = false;

            SpoilsCard vehicle = gameManager.GetActiveVehicle(playerIndex);
            if (vehicle != null && vehicle.GetSpoilsTypes().Contains(SpoilsTypes.Motorized))
            {
                precheckHolds = true;
            }
            return precheckHolds;
        }
    }
}