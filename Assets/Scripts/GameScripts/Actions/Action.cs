
namespace FallenLand
{
    public abstract class Action
    {
        public Action()
        {
        }

        public abstract void HandleAction(GameManager gameManager, int playerIndex);
    }
}