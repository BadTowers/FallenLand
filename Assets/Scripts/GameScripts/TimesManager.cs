using System.Collections.Generic;

namespace FallenLand
{
    public class TimesManager
    {
        //each outer list is AND'ed together, each inner list item is OR'ed together
        public static bool AreTimeConstraintsMet(GameManager gameManager, List<List<Times>> times)
        {
            List<bool> listToAnd = new List<bool>();
            for (int i = 0; i < times.Count; i++)
            {
                List<bool> listToOr = new List<bool>();
                for (int j = 0; j < times[i].Count; j++)
                {
                    listToOr.Add(IsTimeConstraintMet(gameManager, times[i][j]));
                }
                listToAnd.Add(listToOr.Contains(true));
            }
            return !listToAnd.Contains(false);
        }

        public static bool IsTimeConstraintMet(GameManager gameManager, Times time)
        {
            bool isMet = false;

            if (isTimeConstraintMet_A(gameManager, time) || isTimeConstraintMet_D(gameManager, time))
            {
                isMet = true;
            }

            return isMet;
        }



        #region PrivateHelperFunctions
        private static bool isTimeConstraintMet_A(GameManager gameManager, Times time)
        {
            bool isMet = false;
            switch (time)
            {
                case Times.Anytime:
                    isMet = true;
                    break;
                case Times.After_Auction_House_Subphase:
                    UnityEngine.Debug.Log("Times.After_Action_House_Subphase was met");
                    isMet = (gameManager.GetCurrentPhase() == Phases.After_Town_Business_Auction_House);
                    break;
                default:
                    break;
            }

            return isMet;
        }

        private static bool isTimeConstraintMet_D(GameManager gameManager, Times time)
        {
            bool isMet = false;
            switch (time)
            {
                case Times.During_Deal_Subphase:
                    isMet = (gameManager.GetCurrentPhase() == Phases.Town_Business_Deal);
                    break;
                default:
                    break;
            }

            return isMet;
        }
        #endregion
    }
}