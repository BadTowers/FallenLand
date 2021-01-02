
namespace FallenLand
{
    public class GainActionCards : Reward
    {
        public GainActionCards(int amount) : base(amount)
        {
        }

        public override void HandleReward(GameManager gameManager, int playerIndex)
        {
            UnityEngine.Debug.LogError("GainActionCards handle reward not implemented!");
        }
    }
}