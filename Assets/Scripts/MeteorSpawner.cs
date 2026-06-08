using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    float spawnRate = 2f;
    float nextSpawnTime = 0f;

    float minX = -2.3f;
    float maxX = 2.3f;
    float Y = -6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextSpawnTime)
        {
            SpawnMeteor();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnMeteor()
    {
        float spawnX = Random.Range(minX, maxX);
        float spawnY = Y;
        Instantiate(meteorPrefab, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
    }
}
