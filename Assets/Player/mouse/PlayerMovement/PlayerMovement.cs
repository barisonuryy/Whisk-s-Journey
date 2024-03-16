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
    private Rigidbody rbPlayer;
    public Vector2 moveValue;
    public float movementSpeed, jumpForce;
    private bool canWalk, canJump;
    private Animator anim;
    [SerializeField] private float rotateSpeed;

    void Start()
    {

        rbPlayer = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Moving()
    {
        float valX = Input.GetAxis("Horizontal");
        float valY = Input.GetAxis("Vertical");

        if (valX!=0||valY!=0)
        {
           
            rbPlayer.velocity = (new Vector3(valX * movementSpeed * Time.deltaTime, 0, valY * movementSpeed * Time.deltaTime));
            transform.Rotate(new Vector3(0,rotateSpeed * Time.fixedDeltaTime*valX,0));
            canWalk = true;

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
            rbPlayer.AddForce(Vector3.up *jumpForce, ForceMode.Impulse);
        }
        if(IsGrounded()&&!Keyboard.current.spaceKey.isPressed)
        {
            canJump = false;
        }
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

        return false;
    }

    private void OnAnimatorMove()
    {
        anim.SetBool("isWalk",canWalk);
        anim.SetBool("isJump",canJump);
    }
}
