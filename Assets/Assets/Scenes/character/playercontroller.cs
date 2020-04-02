using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private float moveinput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extrajumps;
    public int extrajumpsvaule;

    void Start()
    {
        extrajumps = extrajumpsvaule;
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatIsGround);

        moveinput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);

        if(facingRight == false && moveinput > 0)
        {
            Flip();
        } else if(facingRight == true && moveinput < 0)
        {
            Flip();
        }
    }


    void Update()
    {
        if(isGrounded == true)
        {
            extrajumps = 1;
        }

        if(Input.GetKeyDown(KeyCode.Space) && extrajumps > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extrajumps--;
        } 
        else if(Input.GetKeyDown(KeyCode.Space) && extrajumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }
    }



    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }



}
