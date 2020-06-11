
namespace FallenLand
{
    public class DuringDealPhase : PhaseState
    {
        public override bool IsStateOccurring(GameManager gameManager)
        {
            return (gameManager.GetCurrentPhase() == Phases.Town_Business_Deal);
        }
    }
}