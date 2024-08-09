using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed = 2f;
    private int currentPointIndex = 0;


    private void Update()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentPointIndex];
        Vector3 direction = (targetPoint.position - transform.position).normalized;

        EnemyPatrolMovementAnimationFlip(direction);
        EnemyPatrolMovement(direction, targetPoint);
    }    


    private void EnemyPatrolMovementAnimationFlip(Vector3 direction)
    {
        Vector3 scale = transform.localScale;

        if (direction.x > 0 && scale.x < 0)
        {
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
        }
        else if (direction.x < 0 && scale.x > 0)
        {
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
        }
    }


    private void EnemyPatrolMovement(Vector3 direction, Transform targetPoint)
    {
        transform.position += speed * Time.deltaTime * direction;

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
        }
    }
}
