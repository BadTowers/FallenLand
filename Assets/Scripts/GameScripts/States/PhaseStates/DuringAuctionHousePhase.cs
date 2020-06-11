
namespace FallenLand
{
    public class DuringAuctionHousePhase : PhaseState
    {
        public override bool IsStateOccurring(GameManager gameManager)
        {
            return (gameManager.GetCurrentPhase() == Phases.After_Town_Business_Auction_House);
        }
    }
}