
namespace FallenLand
{
    public class DuringDealPhase : PhaseState
    {
        public override bool IsStateOccurring(GameManager gameManager, int _, int __)
        {
            return (gameManager.GetCurrentPhase() == Phases.Town_Business_Deal);
        }
    }
}