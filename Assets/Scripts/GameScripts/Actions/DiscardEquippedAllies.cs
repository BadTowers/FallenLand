
namespace FallenLand
{
    public class DiscardEquippedAllies : Action
    {
        public DiscardEquippedAllies()
        {
        }

        public override void HandleAction(GameManager gameManager, int playerIndex)
        {
            gameManager.DiscardEquippedAllies(playerIndex);
        }
    }
}