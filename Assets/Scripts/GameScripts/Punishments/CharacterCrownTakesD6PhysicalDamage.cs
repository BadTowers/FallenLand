
namespace FallenLand
{
    public class CharacterCrownTakesD6PhysicalDamage : Punishment
    {
        public CharacterCrownTakesD6PhysicalDamage(int amountOfD6s) : base(amountOfD6s)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (myIndex == playerIndex)
            {
                const int characterCrownIndex = 0;
                gameManager.CharacterCrownTakesD6Damage(playerIndex, characterCrownIndex, base.GetPunishmentAmount(), Constants.DAMAGE_PHYSICAL);
            }
        }
    }
}