
namespace FallenLand
{
    public abstract class Precheck
    {
        public Precheck()
        {
        }

        public abstract bool PrechecksHold(GameManager gameManager, int playerIndex);
    }
}