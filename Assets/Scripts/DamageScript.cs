using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    
    public int damage = 1;
    private HealthScript playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerHealth == null)
            {
                playerHealth = collision.gameObject.GetComponent<HealthScript>();
            }
            playerHealth.TakeDamage(damage);
        }
    }
}
