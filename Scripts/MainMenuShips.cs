using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuShips : MonoBehaviour
{
    public float movementSpeed = 5;
    Vector2 movement;
    Rigidbody2D rb;

    void die()
    {
        Destroy(gameObject);
    }

    public void move()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        movement.x = 0;
        movement.y = 1;
        //transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
    }

    void FixedUpdate()
    {
        move();
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    { 
        Destroy(gameObject);
    }
}
