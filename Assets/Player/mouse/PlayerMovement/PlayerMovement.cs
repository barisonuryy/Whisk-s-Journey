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
    public float verticalSpeed;
    public float gravity = 9.81f;
    private bool canWalk, canJump;
    private Animator anim;
    [SerializeField] private float rotateSpeed;

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

        
        // Apply jump force if the character is grounded
        if (IsGrounded()&&Keyboard.current.spaceKey.isPressed)
        {
            canJump = true;
            
        }
        if(IsGrounded()&&!Keyboard.current.spaceKey.isPressed)
        {
            canJump = false;
        }
        ccPlayer.Move(Vector3.up * (jumpForce*verticalSpeed * Time.deltaTime));
        
    }
    bool IsGrounded()
    {
        // Raycast to check if the character is grounded
        RaycastHit hit;
        float distanceToGround = 0.1f;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, distanceToGround))
        {
            return true;
        }
        verticalSpeed -= gravity * Time.deltaTime;
        return false;
    }

    private void OnAnimatorMove()
    {
        anim.SetBool("isWalk",canWalk);
        anim.SetBool("isJump",canJump);
    }
}
