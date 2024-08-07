using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Animator animator;

    //private Collider2D playerCollider;


    private void Start()
    {
        //playerCollider = GetComponent<Collider2D>();
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
            animator.SetBool("IsCrouching", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
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
