using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    public int speed = 2;
    public int jumpForce = 650;
    int bulletSpeed = 600;
    private Rigidbody2D _rigidbody;
    private Animator _animator; 
    private SpriteRenderer _renderer;
    public string currLvl = "Level1";

    public LayerMask whatIsGround;
    public Transform feet;
    public Transform camera;
 
    bool grounded = false;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator> ();
        _renderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (transform.position.x - camera.position.x <= -2.8f)
            _rigidbody.velocity = new Vector2(speed,_rigidbody.velocity.y);

        // float xScale = transform.localScale.x;
        // if ((xSpeed < 0 && xScale > 0) || (xSpeed > 0 && xScale < 1))
        // {
        //     transform.localScale *= new Vector2(-1,1);
        // }
        // _animator.SetFloat("Speed", Mathf.Abs(xSpeed));
    }

    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i){

            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began){
                _rigidbody.AddForce(new Vector2(0, jumpForce));
            }
        }
    }
}
