
namespace FallenLand
{
    public class Gain68mmAdvancedRifle : Reward
    {
        public Gain68mmAdvancedRifle() : base(Constants.DONT_CARE)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (playerIndex == myIndex)
            {
                gameManager.DealSpecificSpoilToPlayer(myIndex, "6.8mm Advanced Rifle");
            }
        }
    }
}