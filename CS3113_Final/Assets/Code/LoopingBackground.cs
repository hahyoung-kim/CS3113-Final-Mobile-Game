using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{

    public float backgroungSpeed;
    public Renderer backgroundRenderer;

    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroungSpeed * Time.deltaTime,0f);
    }
}
