using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    public float speed = 30f;
    public Rigidbody2D rb;
    public int damage = 20;


    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.GetComponent<Enemy>() != null)
        {
            hitInfo.GetComponent<Enemy>().takeDamage(damage);
            Destroy(gameObject);
        }
        else if (hitInfo.GetComponent<EnemyChaser>() != null)
        {
            hitInfo.GetComponent<EnemyChaser>().takeDamage(damage);
            Destroy(gameObject);
        }
        else if (hitInfo.GetComponent<EnemyTank>() != null)
        {
            hitInfo.GetComponent<EnemyTank>().takeDamage(damage);
            Destroy(gameObject);
        }
        else if (!hitInfo.GetComponent<Player>() && !hitInfo.GetComponent<Repair>())
        {
            Destroy(gameObject);
        }
    }

    

}
