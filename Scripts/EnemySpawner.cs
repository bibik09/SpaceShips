using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPos;
    [SerializeField] Vector2 range;
    public GameObject enemy;
    public float timeToSpawn;
    float randTime;
    bool check = false;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        randTime = timeToSpawn;
    }

    IEnumerator SpawnEnemy()
    {
        if (check)
        {
            yield return new WaitForSeconds(randTime);
            Vector2 pos = spawnPos.position + new Vector3(Random.Range(-range.x, range.x), Random.Range(-range.y, range.y));
            Instantiate(enemy, pos, Quaternion.identity);
            randTime = Random.Range(timeToSpawn - 2, timeToSpawn + 2);    
        }
        else
        {
            check = true;
            yield return new WaitForSeconds(0);
        }
        RepeatSpawnEnemy();
    }

    void RepeatSpawnEnemy()
    {
        StartCoroutine(SpawnEnemy());
    }
}

