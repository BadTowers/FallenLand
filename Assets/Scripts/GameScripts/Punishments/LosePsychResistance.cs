
namespace FallenLand
{
    public class LosePsychResistance : Punishment
    {
        public LosePsychResistance(int amountToLose) : base(amountToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LosePsychResistance(playerIndex, base.GetCharacterIndex(), base.GetPunishmentAmount());
        }
    }
}