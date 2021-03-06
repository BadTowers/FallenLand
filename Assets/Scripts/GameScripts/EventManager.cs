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

        public delegate void D6DamageNeedsToBeDistributed(int numD6s, byte damageType);
        public static event D6DamageNeedsToBeDistributed OnD6DamageNeedsToBeDistributed;
        public static void D6DamageNeedsDistributing(int numD6s, byte damageType)
        {
            OnD6DamageNeedsToBeDistributed?.Invoke(numD6s, damageType);
        }

        public delegate void D6HealingNeedsDistributed(int numD6s, byte healingType);
        public static event D6HealingNeedsDistributed OnD6HealingNeedsDistributed;
        public static void D6HealingNeedsDistributing(int numD6s, byte healingType)
        {
            OnD6HealingNeedsDistributed?.Invoke(numD6s, healingType);
        }

        public delegate void CharacterCrownTakesDamage(int characterCrown, int amountOfDamage, byte damageType, int remainingHp, bool equipmentDiscarded);
        public static event CharacterCrownTakesDamage OnCharacterCrownTakesDamage;
        public static void CharacterCrownHasTakenDamage(int characterCrown, int amountOfDamage, byte damageType, int remainingHp, bool equipmentDiscarded)
        {
            OnCharacterCrownTakesDamage?.Invoke(characterCrown, amountOfDamage, damageType, remainingHp, equipmentDiscarded);
        }

        public delegate void ShowTheGenericPopup(string textToShow);
        public static event ShowTheGenericPopup OnShowGenericPopup;
        public static void ShowGenericPopup(string textToShow)
        {
            OnShowGenericPopup?.Invoke(textToShow);
        }

        public delegate void CardsInAuctionHouseChanged();
        public static event CardsInAuctionHouseChanged OnAuctionHouseWasChanged;
        public static void AuctionHouseChanged()
        {
            OnAuctionHouseWasChanged?.Invoke();
        }

        public delegate void CardsInTownRosterChanged();
        public static event CardsInTownRosterChanged OnTownRosterWasChanged;
        public static void TownRosterChanged()
        {
            OnTownRosterWasChanged?.Invoke();
        }
    }
}
