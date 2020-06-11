
namespace FallenLand
{
    public class Gain68mmAdvancedRifle : Reward
    {
        public Gain68mmAdvancedRifle() : base(Constants.DONT_CARE)
        {
        }

        public override void HandleReward(GameManager gameManager)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            gameManager.DealSpecificSpoilToPlayer(myIndex, "6.8mm Advanced Rifle");
        }
    }
}