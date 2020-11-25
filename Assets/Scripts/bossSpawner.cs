using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawner : MonoBehaviour
{
    private float spawnRangeX = 20f;
    public GameObject boss;

    public float startDelay;
    public float spawnInterval;

    void Start()
    {
        InvokeRepeating("SpawnBoss", startDelay, spawnInterval);
    }

    void SpawnBoss()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), transform.position.y);
        Instantiate(boss, spawnPos, gameObject.transform.rotation);
    }
}
