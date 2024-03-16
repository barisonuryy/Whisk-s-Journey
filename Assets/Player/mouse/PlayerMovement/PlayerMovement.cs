using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController ccPlayer;
    public Vector2 moveValue;
    public float movementSpeed, jumpForce;
    private float verticalSpeed;
    public float gravity = 9.81f;
    private bool canWalk, canJump;
    private Animator anim;
    [SerializeField] private float rotateSpeed;
    private bool isGrounded;

    void Start()
    {

        ccPlayer = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Moving()
    {
        float valY = Input.GetAxis("Horizontal");
        float valX = Input.GetAxis("Vertical");
        if (valY != 0 || valX != 0)
        {
            canWalk = true; 
            if (valX!=0)
            {
                ccPlayer.Move(transform.forward *valX* (movementSpeed * Time.deltaTime));
            }

            if (valY != 0)
            {
                ccPlayer.Move(transform.right * valY * (movementSpeed / 2 * Time.deltaTime));
                transform.Rotate(new Vector3(0,rotateSpeed * Time.fixedDeltaTime*valY,0));
            }
        }
     

       else
        {
            canWalk = false;
        }


    }

    void Update()
    {
     
 


    }

    private void FixedUpdate()
    {
        Jump();
        Moving();

    }

    void Jump()
    {
        isGrounded = ccPlayer.isGrounded;
        // Apply jump force if the character is grounded
        if (!isGrounded)
        {
            verticalSpeed -= gravity * Time.deltaTime;
            
           
            
            
        }
        else 
        {
            verticalSpeed = -gravity * Time.deltaTime;
         
            
            if (Input.GetKey(KeyCode.Space))
            {
                verticalSpeed = Mathf.Sqrt(2f * jumpForce * gravity);
                canJump = true;
            }

          
        }


        if (isGrounded && !Input.GetKey(KeyCode.Space))
        {
            verticalSpeed = 0f;
            canJump = false;
           
        }
        ccPlayer.Move(Vector3.up * (jumpForce*verticalSpeed * Time.deltaTime));
        
    }


    private void OnAnimatorMove()
    {
        anim.SetBool("isWalk",canWalk);
        anim.SetBool("isJump",canJump);
        anim.SetBool("isGrounded",isGrounded);
    }
}
