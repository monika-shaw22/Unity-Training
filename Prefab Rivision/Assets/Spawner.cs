using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject circlePrefab;
    public float spawnInterval = 1f;
    public float spawnRange = 5f;
    void Start()
    {
        InvokeRepeating("SpawnCircle", 0f, spawnInterval);
    }

    void SpawnCircle()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomY = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
        Instantiate(circlePrefab, spawnPosition, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
