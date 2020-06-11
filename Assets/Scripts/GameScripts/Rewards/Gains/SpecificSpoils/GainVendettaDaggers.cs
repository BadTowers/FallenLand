
namespace FallenLand
{
    public class GainVendettaDaggers : Reward
    {
        public GainVendettaDaggers() : base(Constants.DONT_CARE)
        {
        }

        public override void HandleReward(GameManager gameManager)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            gameManager.DealSpecificSpoilToPlayer(myIndex, "Vendetta Daggers");
        }
    }
}