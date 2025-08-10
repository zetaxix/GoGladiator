using UnityEngine;

public class PlatformAttributes : MonoBehaviour
{
    [SerializeField] GameObject[] spawnableObjects;

    public static GameObject[] publicSpawnObjects;
    public static Transform[] publicspawnPoints;

    private void Awake()
    {
        publicSpawnObjects = spawnableObjects;
    }

    public static void NewPlatfromGetObject(GameObject newplatform)
    {
        Transform sp1 = newplatform.transform.Find("SpawnPoint1");
        Transform sp2 = newplatform.transform.Find("SpawnPoint2");

        if (sp1 == null || sp2 == null) Debug.LogWarning("SpawnPoints is null!");

        publicspawnPoints = new Transform[2];
        publicspawnPoints[0] = sp1;
        publicspawnPoints[1] = sp2;

        for (int i = 0; i < publicspawnPoints.Length; i++)
        {
            int randomIndex = Random.Range(0, publicSpawnObjects.Length);
            int randomX = Random.Range(-1, 2); // Sadece -1, 0, 1

            GameObject prefab = publicSpawnObjects[randomIndex];
            GameObject pooledObject = ObjectPooler.Instance.GetPooledObject(prefab.name);
            if (pooledObject != null)
            {
                pooledObject.transform.position = new Vector3(randomX, publicspawnPoints[i].position.y, publicspawnPoints[i].position.z);
                pooledObject.transform.rotation = Quaternion.identity;
                pooledObject.SetActive(true);
            }

        }
    }
}
