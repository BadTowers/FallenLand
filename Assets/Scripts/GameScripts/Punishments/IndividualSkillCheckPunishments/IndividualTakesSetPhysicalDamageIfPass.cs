
using System.Collections.Generic;

namespace FallenLand
{
    public class IndividualTakesSetPhysicalDamageIfPass : Punishment
    {
        public IndividualTakesSetPhysicalDamageIfPass(int amountOfDamage) : base(amountOfDamage)
        {
        }

        public override void HandlePunishment(GameManager gameManager, int playerIndex)
        {
            UnityEngine.Debug.LogError("TODO implement IndividualTakesInfectedDamage");
            EncounterCard encounter = gameManager.GetCurrentEncounter(playerIndex);
            List<int> d6Rolls = encounter.GetD6Rolls();
            List<byte> individualPassFailStates = encounter.GetIndividualPassFail();
            for (int characterIndex = 0; characterIndex < d6Rolls.Count; characterIndex++)
            {
                if (individualPassFailStates[characterIndex] == Constants.STATUS_PASSED)
                {
                    gameManager.DealSetAmountOfPhysicalDamageToIndividual(playerIndex, characterIndex, base.GetPunishmentAmount());
                }
            }
        }
    }
}