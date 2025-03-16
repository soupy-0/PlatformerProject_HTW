using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompCheck : MonoBehaviour
{
    public EnemyScript enemyScript;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Trigger Enter");
            EnemyScript enemy = collision.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                enemy.EnemyDamage(5);
            }
            
        }
    }
}
