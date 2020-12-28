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

        public delegate void D6DamageNeedsToBeDistributed(int numD6s);
        public static event D6DamageNeedsToBeDistributed OnD6DamageNeedsToBeDistributed;
        public static void D6DamageNeedsDistributing(int numD6s)
        {
            OnD6DamageNeedsToBeDistributed?.Invoke(numD6s);
        }

        public delegate void D6HealingNeedsDistributed(int numD6s);
        public static event D6HealingNeedsDistributed OnD6HealingNeedsDistributed;
        public static void D6HealingNeedsDistributing(int numD6s)
        {
            OnD6HealingNeedsDistributed?.Invoke(numD6s);
        }

        public delegate void CharacterCrownTakesDamage(int characterCrown, int amountOfDamage, byte damageType, int remainingHp);
        public static event CharacterCrownTakesDamage OnCharacterCrownTakesDamage;
        public static void CharacterCrownHasTakenDamage(int characterCrown, int amountOfDamage, byte damageType, int remainingHp)
        {
            OnCharacterCrownTakesDamage?.Invoke(characterCrown, amountOfDamage, damageType, remainingHp);
        }

        public delegate void VehicleDestroyed();
        public static event VehicleDestroyed OnVehicleDestroyed;
        public static void VehicleIsDestroyed()
        {
            OnVehicleDestroyed?.Invoke();
        }
    }
}
