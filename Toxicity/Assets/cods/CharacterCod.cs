using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterCod : MonoBehaviour
{
    Rigidbody2D rb;
    Animator Anim;

    public float PowerJump;
    
    public bool isGrounded;
    public bool doubleJump;


    public float moveSpeed;
    public float moveHorizontal;

    public bool faceDirection;

    public float health =100;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        PowerJump = 12;
        moveSpeed = 9;
        faceDirection = true;
        
        

    }

    void Update()
    {
        CharakterRun();
        CharacterJump();
        CharacterAnimation();
    }


    void CharakterRun()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
    }

    void CharacterJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.up * PowerJump;
                doubleJump = true;
                
            }
            else if (doubleJump)
            {
                
                PowerJump *= 3f/4f;
                rb.velocity = Vector2.up * PowerJump;
                doubleJump = false;
                
                PowerJump *= 4f/3f;
            }
           
        }
    }
    void CharacterDirection()
    {
        faceDirection = !faceDirection;
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.y += 180f;
        transform.rotation = Quaternion.Euler(rotation);
    }
    public void CharacterDamage(float damage)
    {
        health -= damage;
        Anim.SetTrigger("ishurting");
        if (health <= 0)
        {
            moveSpeed = 0;
            Anim.SetTrigger("isdeathing");
        }
    }


    void CharacterAnimation()
    {
        if (Input.GetKeyDown(KeyCode.X) && moveHorizontal!=0 && isGrounded==true)
        {
            Anim.SetTrigger("isSwordRunAttack");
        }
        else if (Input.GetKeyDown(KeyCode.X) && isGrounded==true)
        {
            Anim.SetTrigger("isSwordAttack");
        }
        else  if (Input.GetKeyDown(KeyCode.X))
        {
            Anim.SetTrigger("isSwordAirAttack");
        }
        

        if (moveHorizontal != 0)
        {
            Anim.SetBool("isSwordRunning",true);
        }
        else
        {
            Anim.SetBool("isSwordRunning", false);
        }

        if (isGrounded == false)
        {
            Anim.SetBool("isSwordRunning", false);
            Anim.SetBool("isJumping", true);
        }
        else
        {
            Anim.SetBool("isJumping", false);
        }

        if (faceDirection == false && moveHorizontal > 0)
        {
            CharacterDirection();
        }
        if (faceDirection && moveHorizontal < 0)
        {
            CharacterDirection();
        }
    }






    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }    
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        
        if (col.gameObject.tag=="Ground")
        {
            isGrounded = true;
        }

    }
    void OnCollisionExit2D(Collision2D col)
    {
        
        if (col.gameObject.tag=="Ground")
        {
            isGrounded = false;
        }
    }
}
