using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void SpoilsCardDiscarded(string cardName);
    public static event SpoilsCardDiscarded OnSpoilsCardDiscarded;

    public static void SpoilsCardDiscard(string cardName)
    {
        OnSpoilsCardDiscarded?.Invoke(cardName);
    }
}
