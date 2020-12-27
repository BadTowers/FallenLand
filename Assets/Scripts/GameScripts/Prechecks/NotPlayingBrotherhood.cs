
namespace FallenLand
{
    public class NotPlayingBrotherhood : Precheck
    {
        public NotPlayingBrotherhood()
        {
        }

        public override bool PrechecksHold(GameManager gameManager, int playerIndex)
        {
            bool precheckHolds = false;

            if (gameManager.GetFaction(playerIndex).GetName() != "The Brotherhood")
            {
                precheckHolds = true;
            }
            return precheckHolds;
        }
    }
}