using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : Entity
{
    public override float movementSpeed { get; set; } = 6;
    Vector2 moveDirection;
    //Rigidbody2D rb;
    Transform target;
    //public GameObject repairPrefab;

    public override int health { get; set; } = 50;

    public override void die()
    {
        Destroy(gameObject);
        score += 3;
        if (Random.Range(0, 10) > 6)
        {
            Instantiate(repairPrefab, transform.position, transform.rotation);
        }
        
    }

    public override void move()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * movementSpeed;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, movementSpeed * Time.deltaTime);
            moveDirection = direction;
        }
    }

    void FixedUpdate()
    {
        move();
    }
    private void OnTriggerEnter2D(Collider2D turn)
    {
        if (!turn.GetComponent<BulletSpeed>() && !turn.GetComponent<EnemyBullet>())
        {
            if (turn.GetComponent<Player>())
            {
                die();
            }
        }
    }
}
