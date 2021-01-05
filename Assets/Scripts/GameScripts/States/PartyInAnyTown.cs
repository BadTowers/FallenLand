
namespace FallenLand
{
    public class PartyInAnyTown : PhaseState
    {
        private int PlayerIndex;

        public void SetPlayerIndex(int playerIndex)
        {
            PlayerIndex = playerIndex;
        }

        public int GetPlayerIndex()
        {
            return PlayerIndex;
        }

        public override bool IsStateOccurring(GameManager gameManager)
        {
            return gameManager.IsPartyInTown(PlayerIndex);
        }
    }
}