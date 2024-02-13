using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpawner : MonoBehaviour
{
    public Transform spawnPos;
    [SerializeField] Vector2 range;
    public GameObject[] ship;
    public float timeToSpawn;
    bool check = false;
    int i = 0;
    float randTime;

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
            Instantiate(ship[i], pos, Quaternion.identity);
            randTime = Random.Range(timeToSpawn - 2, timeToSpawn + 2);
            if (i != ship.Length-1)
            {
                i++;
            }
            else
            {
                i = 0;
            }
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
