
namespace FallenLand
{
    public class GainMilitiaRifle : Reward
    {
        public GainMilitiaRifle() : base(Constants.DONT_CARE)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (playerIndex == myIndex)
            {
                gameManager.DealSpecificSpoilToPlayer(myIndex, "Militia Rifle");
            }
        }
    }
}