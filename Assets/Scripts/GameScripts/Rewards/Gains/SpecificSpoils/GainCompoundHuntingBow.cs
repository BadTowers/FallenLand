
namespace FallenLand
{
    public class GainCompoundHuntingBow : Reward
    {
        public GainCompoundHuntingBow() : base(Constants.DONT_CARE)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (playerIndex == myIndex)
            {
                gameManager.DealSpecificSpoilToPlayer(myIndex, "Compound Hunting Bow");
            }
        }
    }
}