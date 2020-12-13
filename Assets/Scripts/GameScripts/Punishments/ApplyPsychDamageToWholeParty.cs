
namespace FallenLand
{
    public class ApplyPsychDamageToWholeParty : Punishment
    {
        public ApplyPsychDamageToWholeParty(int amountOfPsychDamage) : base(amountOfPsychDamage)
        {
        }

        public override void HandlePunishment(GameManager gameManager)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            gameManager.ApplyPsychDamageToWholeParty(myIndex, base.GetPunishmentAmount());
        }
    }
}