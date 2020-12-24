
namespace FallenLand
{
    public class GainVendettaDaggers : Reward
    {
        public GainVendettaDaggers() : base(Constants.DONT_CARE)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (playerIndex == myIndex)
            {
                gameManager.DealSpecificSpoilToPlayer(myIndex, "Vendetta Daggers");
            }
        }
    }
}