using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private BoxCollider2D playerCollider;
    private Vector2 playerColliderInitialSize;
    private Vector2 playerColliderInitialOffset;

    [SerializeField] private float playerMovementSpeed = 4f;

    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float jumpForce = 1f;


    private void Start()
    {
        //playerCollider = GetComponent<Collider2D>();

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
        if (vertical > 0)
        {
            playerRB.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
        }
    }
}






