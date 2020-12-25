﻿using UnityEngine;

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

        public delegate void D6DamageNeedsToBeDistributed(int numD6s);
        public static event D6DamageNeedsToBeDistributed OnD6DamageNeedsToBeDistributed;
        public static void D6DamageNeedsDistributing(int numD6s)
        {
            OnD6DamageNeedsToBeDistributed?.Invoke(numD6s);
        }
    }
}