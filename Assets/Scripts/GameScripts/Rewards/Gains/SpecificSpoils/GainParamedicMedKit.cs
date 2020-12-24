
namespace FallenLand
{
    public class GainParamedicMedKit : Reward
    {
        public GainParamedicMedKit() : base(Constants.DONT_CARE)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (playerIndex == myIndex)
            {
                gameManager.DealSpecificSpoilToPlayer(myIndex, "Paramedic Medical Kit");
            }
        }
    }
}