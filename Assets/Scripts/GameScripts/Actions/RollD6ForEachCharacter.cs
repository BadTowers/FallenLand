
namespace FallenLand
{
    public class RollD6ForEachCharacter : Action
    {
        public RollD6ForEachCharacter()
        {
        }

        public override void HandleAction(GameManager gameManager, int playerIndex)
        {
            int myIndex = gameManager.GetIndexForMyPlayer();
            if (myIndex == playerIndex)
            {
                gameManager.RollD6ForEachCharacterForEncounter(playerIndex);
            }
        }
    }
}