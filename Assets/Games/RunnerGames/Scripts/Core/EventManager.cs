using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action onPlayerCollected;
    public static Action onPlayerDied;

    public static void OnPlayerColected()
    {
        onPlayerCollected?.Invoke();
    }

    public static void OnPlayerDied()
    {
        onPlayerDied?.Invoke();
    }
}
