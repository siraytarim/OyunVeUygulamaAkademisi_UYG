using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController2 : MonoBehaviour
{
    public float jumpForce=250;
    public float speed;
    private float moveDirection;

    bool moving;
    private bool jump;
    private bool grounded = true;
    Rigidbody2D rigidbody2d;
    Animator anim;
    SpriteRenderer spriterenderer;

    private void Awake()
    {
        anim = GetComponent<Animator>(); //caching animator
            
    }
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();    
    }

    private void FixedUpdate()
    {
        if (rigidbody2d.velocity != Vector2.zero)
            moving = true;

        else
            moving = false;
        
        rigidbody2d.velocity = new Vector2(speed * moveDirection, rigidbody2d.velocity.y);
        if (jump == true)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
            jump = false;
        }

    }

    private void Update()
    {
        if(grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
          {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                spriterenderer.flipX = true;
                anim.SetFloat("Speed", speed);
            }

            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                spriterenderer.flipX = false;
                anim.SetFloat("Speed", speed);

            }
          }

        else if(grounded == true)
        {
            moveDirection = 0.0f;
            anim.SetFloat("Speed", 0f);
        }

        if(grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");
            anim.SetBool("Grounded", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)       //zýplamayý kontrol etmek için kullanýyoruz
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            anim.SetBool("Grounded", true);
        }
    }
}
