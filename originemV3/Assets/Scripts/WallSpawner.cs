using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject[] walls;

    public float minRandomSpawnRate = 1;
    public float maxRandomSpawnRate = 10;
    public float minRandomNextSpawn = 1;
    public float maxRandomNextSpawn = 10;
    private double spawnRate = 1f;
    private float nextSpawn = 0f;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
        Move();
    }
    private void Move()
    {
        pos = transform.position;
        pos.z += StickControl.Instance.speed * Time.deltaTime;
        transform.position = pos;
    }
    private void Spawn()
    {
        int rand = Random.Range(0, walls.Length + 1);
        spawnRate = Random.Range(minRandomSpawnRate, maxRandomSpawnRate);
        nextSpawn += Time.deltaTime * Random.Range(minRandomNextSpawn, maxRandomNextSpawn);
        if (nextSpawn > spawnRate)
        {
            nextSpawn = 0;
            GameObject a = Instantiate(walls[Random.Range(0, rand)], transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(a, 5f);
        }
    }
}
