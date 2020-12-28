
namespace FallenLand
{
    public class VehicleDestroyed : Punishment
    {
        public VehicleDestroyed() : base(1)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.DestroyVehicle(playerIndex);
        }
    }
}