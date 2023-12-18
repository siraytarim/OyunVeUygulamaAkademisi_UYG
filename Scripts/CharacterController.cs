using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 1.0f;
    Rigidbody2D r2d;
    Animator animator;
    Vector3 charPos;
    [SerializeField] GameObject camera;
    int sayi;
    SpriteRenderer spriterenderer;
    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>(); //caching r2d
        animator = GetComponent<Animator>();
        charPos = transform.position;
        sayi = 1;
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()   
    {
        // r2d.velocity = new Vector2(speed, 0f);
       
        sayi = 2;
       
    }
    private void Update()
    {

        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y);
        transform.position = charPos;

        if(Input.GetAxis("Horizontal") == 0.0f)      //koþma tuþuna basýlmadýgý sürece idle pozisyonunda kalmasý için
        {
            animator.SetFloat("Speed", 0.0f);
        }
        else
        {
            animator.SetFloat("Speed", 1.0f);
        }
        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            spriterenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            spriterenderer.flipX = true;
        }

        animator.SetFloat("Speed",speed);
        sayi = 3;
    }

    private void LateUpdate()
    {
        camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1f);
        sayi = 4;
    }
}
