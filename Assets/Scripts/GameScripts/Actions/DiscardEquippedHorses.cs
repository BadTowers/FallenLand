
namespace FallenLand
{
    public class DiscardEquippedHorses : Action
    {
        public DiscardEquippedHorses()
        {
        }

        public override void HandleAction(GameManager gameManager, int playerIndex)
        {
            gameManager.DiscardEquippedHorses(playerIndex);
        }
    }
}