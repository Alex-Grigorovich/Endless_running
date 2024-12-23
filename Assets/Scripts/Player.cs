using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float speed;
    public Rigidbody2D rigidbody;
    public bool isGrounded; //Проверка "Стоит ли игрок на земле"

    
    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    public float jumpAmount = 35;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Idle", true);
    }

    void Update()
    {
        Running();
        Jump();

    }

    private void Running()
    {
        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Translate(Vector2.left * Time.deltaTime * speed);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            
            rigidbody.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        if (isGrounded == false)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
        
        
        if(rigidbody.velocity.y >= 0)
        {
            rigidbody.gravityScale = gravityScale;
        }
        else if (rigidbody.velocity.y < 0)
        {
            rigidbody.gravityScale = fallingGravityScale;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
}