
namespace FallenLand
{
    public class GainAmericanIronCustomChoppers : Reward
    {
        public GainAmericanIronCustomChoppers() : base(Constants.DONT_CARE)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (myIndex == playerIndex)
            {
                gameManager.DealSpecificSpoilToPlayer(myIndex, "American Iron Custom Choppers");
            }
        }
    }
}