
namespace FallenLand
{
    public class DuringGameStartSetup : PhaseState
    {
        public override bool IsStateOccurring(GameManager gameManager)
        {
            return (gameManager.GetCurrentPhase() == Phases.Game_Start_Setup);
        }
    }
}