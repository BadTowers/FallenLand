
namespace FallenLand
{
    public class LoseAllEquippedRangedWeapons : Punishment
    {
        public LoseAllEquippedRangedWeapons() : base(0)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            gameManager.LoseAllEquippedRangeWeapons(playerIndex);
        }
    }
}