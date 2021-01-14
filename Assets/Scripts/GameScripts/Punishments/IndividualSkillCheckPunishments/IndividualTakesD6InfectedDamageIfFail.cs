
using System.Collections.Generic;

namespace FallenLand
{
    public class IndividualTakesD6InfectedDamageIfFail : Punishment
    {
        public IndividualTakesD6InfectedDamageIfFail(int amountOfDamage) : base(amountOfDamage)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            EncounterCard encounter = gameManager.GetCurrentEncounter(playerIndex);
            List<int> d6Rolls = encounter.GetD6Rolls();
            List<byte> individualPassFailStates = encounter.GetIndividualPassFail();
            for (int characterIndex = 0; characterIndex < d6Rolls.Count; characterIndex++)
            {
                if (individualPassFailStates[characterIndex] == Constants.STATUS_FAILED)
                {
                    int amountOfDamage = d6Rolls[characterIndex] * base.GetPunishmentAmount();
                    gameManager.DealSetAmountOfInfectedDamageToIndividual(playerIndex, characterIndex, amountOfDamage);
                }
            }
        }
    }
}