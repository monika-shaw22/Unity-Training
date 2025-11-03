using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public float spawnInterval = 1.5f;
    public float spawnRangeX = 8f;

    void Start()
    {
        InvokeRepeating("SpawnObject", 1f, spawnInterval);
    }

    void SpawnObject()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPos = new Vector2(randomX, transform.position.y);
        Instantiate(fallingObjectPrefab, spawnPos, Quaternion.identity);
    }
}