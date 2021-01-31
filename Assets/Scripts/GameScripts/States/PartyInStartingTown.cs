
namespace FallenLand
{
    public class PartyInStartingTown : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int _)
        {
            return gameManager.IsPartyInStartingLocation(playerIndex);
        }
    }
}