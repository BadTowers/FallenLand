
namespace FallenLand
{
    public abstract class Reward
    {
        private int Amount;
        private int CharacterIndex = Constants.INVALID_INDEX;

        public Reward(int amount)
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

        public int GetRewardAmount()
        {
            return Amount;
        }

        public abstract void HandleReward(GameManager gameManager, int playerIndex);
    }
}