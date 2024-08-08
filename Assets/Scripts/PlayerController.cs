using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Animator Component")]
    [SerializeField] private Animator animator;

    [Header("Player Collider")]
    [SerializeField] private BoxCollider2D playerCollider;
    private Vector2 playerColliderInitialSize;
    private Vector2 playerColliderInitialOffset;

    [Header("Player Movement")]
    [SerializeField] private float playerMovementSpeed = 4f;

    [Header("Player Rigid Body and Jump")]
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float jumpForce = 1f;
    private bool isGrounded = false;


    private void Start()
    {
        playerColliderInitialSize = playerCollider.size;
        playerColliderInitialOffset = playerCollider.offset;
    }


    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayerHorizontalMovementAnimation(horizontal);
        PlayerCrouchAnimation();
        PlayerJumpAnimation(vertical);

        PlayerHorizontalMovement(horizontal);
        PlayerJump(vertical);
    }
    

    private void PlayerHorizontalMovementAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));


        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }


    private void PlayerCrouchAnimation()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            float offX = -0.0983f;
            float offY = 0.6097f;

            float sizeX = 0.6988f;
            float sizeY = 1.3398f;

            playerCollider.size = new Vector2(sizeX, sizeY);
            playerCollider.offset = new Vector2(offX, offY);

            animator.SetBool("IsCrouching", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerCollider.size = playerColliderInitialSize;
            playerCollider.offset = playerColliderInitialOffset;

            animator.SetBool("IsCrouching", false);
        }
    }


    private void PlayerJumpAnimation(float vertical)
    {
        if (vertical > 0)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
    }


    private void PlayerHorizontalMovement(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * playerMovementSpeed * Time.deltaTime;
        transform.position = position;
    }


    private void PlayerJump(float vertical)
    {
        if (vertical > 0 && isGrounded)
        {
            playerRB.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsGrounded", isGrounded);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("IsGrounded", isGrounded);
        }
    }
}






