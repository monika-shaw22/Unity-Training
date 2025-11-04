using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnZombie", 1f, spawnInterval);
    }

    void SpawnZombie()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
        Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
    }
}