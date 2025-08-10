using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObjectManager : MonoBehaviour
{
    public static EnvironmentObjectManager Instance;

    [SerializeField] private GameObject[] environmentPrefabs;
    [SerializeField] private int poolSize = 10;

    private Queue<GameObject> envPool = new Queue<GameObject>();

    private void Awake()
    {
        if (Instance == null) Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            int randomIndex = Random.Range(0, environmentPrefabs.Length);

            GameObject environment = Instantiate(environmentPrefabs[randomIndex], Vector3.zero, Quaternion.identity);
            environment.SetActive(false);
            envPool.Enqueue(environment);
        }
    }

    public GameObject GetEnvironment()
    {
        GameObject platform = envPool.Dequeue();
        platform.SetActive(true);
        envPool.Enqueue(platform);
        return platform;
    }
}
