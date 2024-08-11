using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUpController : MonoBehaviour
{
    [SerializeField] private int healAmount = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            SoundManager.Instance.Play(Sounds.PICK_UP);

            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
