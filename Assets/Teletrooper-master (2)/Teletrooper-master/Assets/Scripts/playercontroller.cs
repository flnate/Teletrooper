using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    float _speed;
    float _jumpForce;
    float _moveInput;
    CharacterInfo charInfo;
    Rigidbody2D rb;    
    bool _isGrounded;
    int _extraJumps;

    void Start()
    {
        charInfo = GetComponentInParent<CharacterInfo>();
        _extraJumps = charInfo.jumpExtra;
        _jumpForce = charInfo.jumpForce;
        _speed = charInfo.moveSpeed;
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(_moveInput * _speed, rb.velocity.y);
    }


    void Update()
    {
        if(_isGrounded == true) _extraJumps = 1;
        if(Input.GetKeyDown(KeyCode.Space) && _extraJumps > 0)
        {
            rb.velocity = Vector2.up * _jumpForce;
            _extraJumps--;
        } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded = false;
    }
}