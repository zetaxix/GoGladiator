using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;

    [Header("Platform Settings")]
    [SerializeField] private int numberOfPlatforms = 7;
    [SerializeField] private float platformLength = 10f;
    [SerializeField] private float spawnThreshold = 20f;

    private List<GameObject> spawnedPlatforms = new List<GameObject>();
    public float nextSpawnZ = 0f;

    private void Start()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    private void Update()
    {
        if (player.position.z + spawnThreshold > nextSpawnZ)
        {
            SpawnPlatform();
            RecycleOldestPlatform();
        }
    }

    private void SpawnPlatform()
    {
        GameObject newPlatform = PlatformPoolManager.Instance.GetPlatform();
        newPlatform.transform.position = new Vector3(0, 0, nextSpawnZ);
        newPlatform.transform.rotation = Quaternion.identity;

        spawnedPlatforms.Add(newPlatform);
        nextSpawnZ += platformLength;

        PlatformAttributes.NewPlatfromGetObject(newPlatform);

    }

    private void RecycleOldestPlatform()
    {
        if (spawnedPlatforms.Count > numberOfPlatforms)
        {
            GameObject oldest = spawnedPlatforms[0];
            oldest.SetActive(false);
            spawnedPlatforms.RemoveAt(0);
        }
    }
}
