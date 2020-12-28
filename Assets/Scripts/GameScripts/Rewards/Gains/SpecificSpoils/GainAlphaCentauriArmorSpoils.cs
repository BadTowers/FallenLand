
namespace FallenLand
{
    public class GainAlphaCentauriArmorSpoils : Reward
    {
        public GainAlphaCentauriArmorSpoils() : base(Constants.DONT_CARE)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (playerIndex == myIndex)
            {
                gameManager.DealSpecificSpecialSpoilToPlayer(myIndex, "Alpha Centauri Armor");
            }
        }
    }
}