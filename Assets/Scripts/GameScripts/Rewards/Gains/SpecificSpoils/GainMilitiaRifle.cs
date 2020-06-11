
namespace FallenLand
{
    public class GainMilitiaRifle : Reward
    {
        public GainMilitiaRifle() : base(Constants.DONT_CARE)
        {
        }

        public override void HandleReward(GameManager gameManager)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            gameManager.DealSpecificSpoilToPlayer(myIndex, "Militia Rifle");
        }
    }
}