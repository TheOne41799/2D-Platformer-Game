using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOffPlatform : MonoBehaviour
{
    readonly private int damageAmount = 3;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.TakeDamage(damageAmount);
        }
    }
}
