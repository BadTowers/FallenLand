
namespace FallenLand
{
    public class GainNextMasterCharacterElseChoose : Reward
    {
        public GainNextMasterCharacterElseChoose() : base(1)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (playerIndex == myIndex)
            {
                if (!gameManager.DealNextMasterCharacterToPlayer(myIndex))
                {
                    //TODO let the player choose a card from the remaining characters if a master wasn't dealt
                    UnityEngine.Debug.LogError("A master character could not be dealt for GainNextMasterCharacterElseChoose. Need to implement allowing the user to pick a card!");
                }
            }
        }
    }
}