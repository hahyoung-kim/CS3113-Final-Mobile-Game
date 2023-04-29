using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoopingBackground : MonoBehaviour
{
    private float bgSpd;
    public float ogSpd;
    public Renderer backgroundRenderer;
    GameManager _gameManager;
    public GameObject player;

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        
        print(backgroundRenderer.material.mainTextureOffset);
        if (_gameManager.GetLives() > 0 && !_gameManager.IsPaused()) {
            if (_gameManager.IsRainbow()) {
                backgroundRenderer.material.mainTextureOffset += new Vector2(ogSpd + Time.deltaTime * 0.2f * (float) (Math.Log(player.transform.position.x)),0f);
            } else {
                backgroundRenderer.material.mainTextureOffset += new Vector2(ogSpd + Time.deltaTime * 0.05f * (float) (Math.Log(player.transform.position.x)),0f);
            }
        }
        
    }
}
