
namespace FallenLand
{
    public class LosePartyDiplomacySuccesses : Punishment
    {
        public LosePartyDiplomacySuccesses(int amount) : base(amount)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            //gameManager.GainSkillAmount(playerIndex, GetCharacterIndex(), Skills.Combat, GetRewardAmount());
        }
    }
}