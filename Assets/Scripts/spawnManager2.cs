using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager2 : MonoBehaviour
{
    private float spawnRangeY = 7.5f;
    public GameObject[] enemies;

    public float startDelay;
    public float spawnInterval;

    public const float drain = 1;
    public float time = 0;

    void Start()
    {
        time = startDelay;
        //InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
    }

    void Update()
    {
        time -= drain * Time.deltaTime;

        if (time <= 0)
        {
            time = spawnInterval;
            SpawnEnemy();
        }
        if(spawnInterval <= 0.85f)
        {
            spawnInterval = 0.85f;
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = new Vector2(transform.position.x, (Random.Range(-spawnRangeY, spawnRangeY)));
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyIndex], spawnPos, enemies[enemyIndex].transform.rotation);
    }
}
