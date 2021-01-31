
namespace FallenLand
{
    public class LoseDiplomacy : Punishment
    {
        public LoseDiplomacy(int amountToLose) : base(amountToLose)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseSkillAmount(playerIndex, GetCharacterIndex(), Skills.Diplomacy, GetPunishmentAmount());
        }
    }
}