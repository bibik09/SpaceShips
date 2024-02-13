using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    public override float movementSpeed { get; set; } = 10;
    Vector2 movement;
    //Rigidbody2D rb;

    public override int health { get; set; } = 200;
    int maxHealth;

    public void heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public override void move()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    public override void die()
    {
        SceneManager.LoadScene(2);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        maxHealth = health;
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        move();
    }

    private void OnTriggerEnter2D(Collider2D turn)
    {
        if (turn.GetComponent<EnemyChaser>())
        {
            takeDamage(50);
        }
    }
}
