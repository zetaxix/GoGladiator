using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;

    [Header("Platform Settings")]
    [SerializeField] private int numberOfPlatforms = 7;
    [SerializeField] private float platformLength = 10f;
    [SerializeField] private float spawnThreshold = 20f;

    private List<GameObject> spawnedEnvironments = new List<GameObject>();
    public float nextSpawnZ = 0f;

    private void Start()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            SpawnEnvironment();
        }
    }

    private void Update()
    {
        if (player.position.z + spawnThreshold > nextSpawnZ)
        {
            SpawnEnvironment();
            RecycleOldestPlatform();
        }
    }

    private void SpawnEnvironment()
    {
        GameObject newEnv = EnvironmentObjectManager.Instance.GetEnvironment();
        newEnv.transform.position = new Vector3(20.7199993f, -13.25f, 85 + nextSpawnZ);
        newEnv.transform.rotation = Quaternion.identity;

        spawnedEnvironments.Add(newEnv);
        nextSpawnZ += platformLength;

    }

    private void RecycleOldestPlatform()
    {
        if (spawnedEnvironments.Count > numberOfPlatforms)
        {
            GameObject oldest = spawnedEnvironments[0];
            oldest.SetActive(false);
            spawnedEnvironments.RemoveAt(0);
        }
    }
}
