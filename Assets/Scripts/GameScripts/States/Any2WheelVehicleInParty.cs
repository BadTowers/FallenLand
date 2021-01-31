﻿
namespace FallenLand
{
    public class Any2WheelVehicleInParty : State
    {
        public override bool IsStateOccurring(GameManager gameManager, int playerIndex, int _)
        {
            return gameManager.IsVehicleOfCertainType(playerIndex, SpoilsTypes.Two_Wheeled);
        }
    }
}