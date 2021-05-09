using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;
    public float moveSpeed;
    public Rigidbody2D rb;
    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask WhatIsGround;
    private bool canDoubleJump;
    private Animator anim;
    private SpriteRenderer sr;
    public float bounceForce;

    public void Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, bounceForce);
    }
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            transform.parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x < -0.01)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x > 0.01)
        {
            sr.flipX = false;
        }

        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, WhatIsGround);
        rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);

        if (isGrounded)
        {
            canDoubleJump = true;
        }




        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }


            else
            {
                if (canDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    canDoubleJump = false;
                }

            }
        }
    }
}