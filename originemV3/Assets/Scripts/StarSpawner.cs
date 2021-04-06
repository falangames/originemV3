using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Star", new Vector3(Random.Range(transform.position.x - 600, transform.position.x + 600), Random.Range(transform.position.y - 600, transform.position.y + 600), Random.Range(transform.position.z - 600, transform.position.z + 600)), Quaternion.identity);
    }
}
