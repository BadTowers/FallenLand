
namespace FallenLand
{
    public class GainCompoundHuntingBow : Reward
    {
        public GainCompoundHuntingBow() : base(Constants.DONT_CARE)
        {
        }

        public override void HandleReward(GameManager gameManager)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            gameManager.DealSpecificSpoilToPlayer(myIndex, "Compound Hunting Bow");
        }
    }
}