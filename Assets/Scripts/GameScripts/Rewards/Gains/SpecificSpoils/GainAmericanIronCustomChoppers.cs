
namespace FallenLand
{
    public class GainAmericanIronCustomChoppers : Reward
    {
        public GainAmericanIronCustomChoppers() : base(Constants.DONT_CARE)
        {
        }

        public override void HandleReward(GameManager gameManager)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            gameManager.DealSpecificSpoilToPlayer(myIndex, "American Iron Custom Choppers");
        }
    }
}