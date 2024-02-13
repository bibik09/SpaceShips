using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float timeToSpawn;

    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    //void Update()
    //{
    //    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //}

    IEnumerator SpawnBullet()
    {
        yield return new WaitForSeconds(timeToSpawn);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        RepeatSpawnBullet();
    }
    void RepeatSpawnBullet()
    {
        StartCoroutine(SpawnBullet());
    }
}
