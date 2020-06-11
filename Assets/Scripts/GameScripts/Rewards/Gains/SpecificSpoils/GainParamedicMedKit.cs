
namespace FallenLand
{
    public class GainParamedicMedKit : Reward
    {
        public GainParamedicMedKit() : base(Constants.DONT_CARE)
        {
        }

        public override void HandleReward(GameManager gameManager)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            gameManager.DealSpecificSpoilToPlayer(myIndex, "Paramedic Medical Kit");
        }
    }
}