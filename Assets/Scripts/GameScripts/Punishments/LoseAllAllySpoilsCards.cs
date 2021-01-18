
namespace FallenLand
{
    public class LoseAllAllySpoilsCards : Punishment
    {
        public LoseAllAllySpoilsCards() : base(0)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseAllAllySpoilsCards(playerIndex);
        }
    }
}