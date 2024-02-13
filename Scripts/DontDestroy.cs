using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject music;
    static bool check = true;
    private void Awake()
    {
        if (check)
        {
            music.GetComponent<AudioSource>().enabled = true;
            DontDestroyOnLoad(transform.gameObject);
            check = false;
        }
        
    }
}
