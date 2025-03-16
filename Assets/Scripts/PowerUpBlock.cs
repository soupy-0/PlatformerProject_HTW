using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBlock : MonoBehaviour
{
    private bool isUsed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isUsed && collision.CompareTag("Player"))
        {
            isUsed = true;
            Debug.Log("Powered Up");
            
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.SpeedPowerUp();
            }

            GetComponent<SpriteRenderer>().color = Color.green;
            GetComponent<BoxCollider2D>().enabled = false;
            
        }
    }
}
