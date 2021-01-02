
namespace FallenLand
{
    public abstract class Punishment
    {
        private int Amount;
        private int CharacterIndex = Constants.INVALID_INDEX;

        public Punishment(int amount)
        {
            Amount = amount;
        }

        public void SetCharacterIndex(int characterIndex)
        {
            CharacterIndex = characterIndex;
        }

        public int GetCharacterIndex()
        {
            return CharacterIndex;
        }

        public int GetPunishmentAmount()
        {
            return Amount;
        }

        public abstract void HandlePunishment(GameManager gameManager, int playerIndex);
    }
}