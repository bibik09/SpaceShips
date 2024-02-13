using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed = 0.5f;
    public Renderer bgRenderer;

    public void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(0, Time.deltaTime * speed);
    }
}
