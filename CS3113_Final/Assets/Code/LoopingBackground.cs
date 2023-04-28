using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    private float bgSpd;
    public float ogSpd;
    public Renderer backgroundRenderer;
    GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(ogSpd + Time.deltaTime * 0.25f,0f);
        
    }
}
