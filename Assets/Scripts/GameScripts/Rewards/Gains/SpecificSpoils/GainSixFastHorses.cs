
namespace FallenLand
{
    public class GainSixFastHorses : Reward
    {
        public GainSixFastHorses() : base(Constants.DONT_CARE)
        {
        }

        public override void HandleReward(GameManager gameManager)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            gameManager.DealSpecificSpoilToPlayer(myIndex, "6 Fast Horses");
        }
    }
}