using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private BoxCollider2D playerCollider;

    private Vector2 playerColliderInitialSize;
    private Vector2 playerColliderInitialOffset;


    private void Start()
    {
        //playerCollider = GetComponent<Collider2D>();

        playerColliderInitialSize = playerCollider.size;
        playerColliderInitialOffset = playerCollider.offset;
    }


    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(speed));


        Vector3 scale = transform.localScale;

        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;


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
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerCollider.size = playerColliderInitialSize;
            playerCollider.offset = playerColliderInitialOffset;

            animator.SetBool("IsCrouching", false);
        }


        if (jump > 0.1f)
        {
            animator.SetBool("IsJumping", true);
        }
        else if (jump < 0.1f)
        {
            animator.SetBool("IsJumping", false);
        }
    }
}






