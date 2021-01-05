
namespace FallenLand
{
    public class PartyInStartingTown : PhaseState
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
            return gameManager.IsPartyInStartingLocation(PlayerIndex);
        }
    }
}