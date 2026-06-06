using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject keyPrefab;
    public Transform[] spawnPoints;

    private GameObject currentKey;

    void Start()
    {
        SpawnKey();
    }

    public void SpawnKey()
    {
        int index = Random.Range(0, spawnPoints.Length);
        currentKey = Instantiate(keyPrefab, spawnPoints[index].position, Quaternion.identity);
    }

    public Transform GetKeyTransform()
    {
        if (currentKey == null) return null;
        return currentKey.transform;
    }
}