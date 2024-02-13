using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : Entity
{
    public override float movementSpeed { get; set; } = 0;
    public override int health { get; set; } = 200;

    //public GameObject repairPrefab;
    public Weapon weapon = new Weapon(30, 20);

    void Start()
    {
        transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
    }
    public override void die()
    { 
        Destroy(gameObject);
        score += 4;
        if (Random.Range(0,10)>6)
        {
            Instantiate(repairPrefab, transform.position, transform.rotation);
        }
    }

    public override void move()
    {

    }
}
