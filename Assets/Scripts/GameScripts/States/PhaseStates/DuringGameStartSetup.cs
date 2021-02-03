
namespace FallenLand
{
    public class DuringGameStartSetup : PhaseState
    {
        public override bool IsStateOccurring(GameManager gameManager, int _, int __)
        {
            return (gameManager.GetCurrentPhase() == Phases.Game_Start_Setup);
        }

        public override int NumberOfInstancesOfStateOccurring(GameManager _, int __, int ___)
        {
            return 1;
        }
    }
}