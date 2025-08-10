using System.Collections.Generic;
using UnityEngine;

public class PlatformPoolManager : MonoBehaviour
{
    public static PlatformPoolManager Instance;

    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private int poolSize = 10;

    private Queue<GameObject> platformPool = new Queue<GameObject>();

    private void Awake()
    {
        if (Instance == null) Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject platform = Instantiate(platformPrefab, Vector3.zero, Quaternion.identity);
            platform.SetActive(false);
            platformPool.Enqueue(platform);
        }
    }

    public GameObject GetPlatform()
    {
        GameObject platform = platformPool.Dequeue();
        platform.SetActive(true);
        platformPool.Enqueue(platform);
        return platform;
    }
}
