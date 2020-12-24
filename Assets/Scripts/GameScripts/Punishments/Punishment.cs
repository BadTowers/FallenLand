
namespace FallenLand
{
    public abstract class Punishment
    {
        private int Amount;

        public Punishment(int amount)
        {
            Amount = amount;
        }

        public int GetPunishmentAmount()
        {
            return Amount;
        }

        public abstract void HandlePunishment(GameManager gameManager, int playerIndex);
    }
}