﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMove : MonoBehaviour
{

    public float runSpeed=2;

    public float jumpSpeed=2;

    public float doubleJumpSpeed=2.5f;

    private bool canDoubleJump;

    Rigidbody2D rb2D;

    public bool betterJump=false;

    public float fallMultiplier=0.5f;

    public float lowJumpMultiplier=1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    public GameObject particleLeft;

    public GameObject particleRight;
    
    public float coyoteTime = 0.2f;

    private float coyoteCounter;

    public float jumpBufferLength = 0.5f;

    private float jumpBufferCount;

    public AudioSource clip;


    void Start()
    {
        rb2D=GetComponent<Rigidbody2D>();
    }

    private void Update() {

         if (CheckGround.isGrounded)
        {
            coyoteCounter=coyoteTime;
        }
        else
        {
            coyoteCounter-=Time.deltaTime;
        }

        
         if (Input.GetKey("space"))
        {
            jumpBufferCount = jumpBufferLength;

            if  (jumpBufferCount >= 0 && coyoteCounter>0f)
            {
                canDoubleJump=true;
                rb2D.velocity=new Vector2(rb2D.velocity.x, jumpSpeed);
                jumpBufferCount = 0;
                clip.Play();
            }
            else
            {
                jumpBufferCount -=Time.deltaTime;

                if(Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump",true);
                        rb2D.velocity=new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                        canDoubleJump=false;
                        
                    }
                }
            }
        }

        if (CheckGround.isGrounded==false)
        {
            animator.SetBool("Jump",true);
            animator.SetBool("Run",false);
            particleLeft.SetActive(false);
            particleRight.SetActive(false);
        }

        if (CheckGround.isGrounded==true) 
        {
            animator.SetBool("Jump",false);
            animator.SetBool("DoubleJump",false);
            animator.SetBool("Falling",false);
        }

        if(rb2D.velocity.y<0)
        {
            animator.SetBool("Falling",true);
        }
        if(rb2D.velocity.y>0)
        {
            animator.SetBool("Falling",false);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
            rb2D.velocity= new Vector2(runSpeed,rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run",true);

            if (CheckGround.isGrounded==true)
            {
                particleLeft.SetActive(true);
                particleRight.SetActive(false);
            }
            

        }
        else if (Input.GetKey("left"))
        {
            rb2D.velocity= new Vector2(-runSpeed,rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run",true);

             if (CheckGround.isGrounded==true)
            {
                particleLeft.SetActive(false);
                particleRight.SetActive(true);
            }
        }
        else
        {
            rb2D.velocity=new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run",false);

            particleLeft.SetActive(false);
            particleRight.SetActive(false);
        }
       

        if (betterJump)
        {
            if(rb2D.velocity.y<0)
            {
                rb2D.velocity+=Vector2.up*Physics2D.gravity.y*(fallMultiplier)*Time.deltaTime;
            }
            if(rb2D.velocity.y>0 && !Input.GetKey("space"))
            {
                rb2D.velocity+=Vector2.up*Physics2D.gravity.y*(lowJumpMultiplier)*Time.deltaTime;
            }
        }

    }
}



