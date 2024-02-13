using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public GameObject player;
    public Text hp;

    void Update()
    {
        hp.text = "" + player.GetComponent<Player>().health;
    }
}
