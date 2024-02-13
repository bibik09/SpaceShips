using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapon
{
    public int damage { get; set; }
    public int speed { get; set; }
    public Weapon(int d, int s) { damage = d; speed = s; }
}

public abstract class Entity: MonoBehaviour
{
    public abstract float movementSpeed { get; set; }
    public abstract int health { get; set; }

    public GameObject repairPrefab;
    public Rigidbody2D rb;
    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            die();
        }
    }

    public static int score = 0;
    public virtual void die()
    {
        Destroy(gameObject);
        score += 2;
        if (Random.Range(0, 10) > 6)
        {
            Instantiate(repairPrefab, transform.position, transform.rotation);
        }

    }
    public abstract void move();
}

public class Enemy : Entity
{
    public override float movementSpeed { get; set; } = 5;
    Vector2 movement;  
    //Rigidbody2D rb;
    
    public Weapon weapon = new Weapon(20, 30);

    public override int health { get; set; } =  100;

    public override void move()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        movement.x = -1;
        movement.y = 0;
        transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
    }

    void FixedUpdate()
    {
        move();
    }
    private void OnTriggerEnter2D(Collider2D turn)
    {
        if (!turn.GetComponent<BulletSpeed>() && !turn.GetComponent<EnemyBullet>() && !turn.GetComponent<EnemyChaser>() && !turn.GetComponent<EnemyTank>() && !turn.GetComponent<Enemy>())
        {
            movement.x *= -1;
        }
    }
}
