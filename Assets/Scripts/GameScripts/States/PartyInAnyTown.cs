
namespace FallenLand
{
    public class PartyInAnyTown : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int _)
        {
            return gameManager.IsPartyInTown(playerIndex);
        }
    }
}