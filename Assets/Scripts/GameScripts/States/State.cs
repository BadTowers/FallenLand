﻿
namespace FallenLand
{
    public abstract class State
    {
        public abstract bool IsStateOccurring(GameManager gameManager, int playerIndex, int characterIndex);
        public abstract int NumberOfInstancesOfStateOccurring(GameManager gameManager, int playerIndex, int characterIndex);
    }
}
