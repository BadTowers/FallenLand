
namespace FallenLand
{
    public class MovePartyToStartingTownLocation : Action
    {
        public MovePartyToStartingTownLocation()
        {
        }

        public override void HandleAction(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (myIndex == playerIndex)
            {
                gameManager.MovePartyToStartingTownLocation(playerIndex);
            }
        }
    }
}