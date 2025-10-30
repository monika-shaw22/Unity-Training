using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        foreach (Transform point in spawnPoints)
        {
            Instantiate(enemyPrefab, point.position, point.rotation);
        }
    }
}
