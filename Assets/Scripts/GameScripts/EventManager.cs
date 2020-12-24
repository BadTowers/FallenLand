using UnityEngine;

namespace FallenLand
{
    public class EventManager : MonoBehaviour
    {
        public delegate void SpoilsCardDiscarded(SpoilsCard card);
        public static event SpoilsCardDiscarded OnSpoilsCardDiscarded;

        public static void SpoilsCardDiscard(SpoilsCard card)
        {
            OnSpoilsCardDiscarded?.Invoke(card);
        }
    }
}
