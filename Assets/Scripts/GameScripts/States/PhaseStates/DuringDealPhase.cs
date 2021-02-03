
namespace FallenLand
{
    public class DuringDealPhase : PhaseState
    {
        public override bool IsStateOccurring(GameManager gameManager, int _, int __)
        {
            return (gameManager.GetCurrentPhase() == Phases.Town_Business_Deal);
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager _, int __, int ___)
        {
            return 1;
        }
    }
}