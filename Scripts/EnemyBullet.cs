using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject enemyShip;

    float speed;
    public Rigidbody2D rb;
    int damage;

    void Start()
    {
        if (enemyShip.GetComponent<Enemy>())
        {
            speed = enemyShip.GetComponent<Enemy>().weapon.speed;
            damage = enemyShip.GetComponent<Enemy>().weapon.damage;
        }
        else if (enemyShip.GetComponent<EnemyTank>())
        {
            speed = enemyShip.GetComponent<EnemyTank>().weapon.speed;
            damage = enemyShip.GetComponent<EnemyTank>().weapon.damage;
        }
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            Destroy(gameObject);
            player.takeDamage(damage);
        }
        else if (!hitInfo.GetComponent<Enemy>() && !hitInfo.GetComponent<EnemyChaser>() && !hitInfo.GetComponent<EnemyTank>() && !hitInfo.GetComponent<BulletSpeed>() && !hitInfo.GetComponent<Repair>()) 
            Destroy(gameObject);
    }
}
