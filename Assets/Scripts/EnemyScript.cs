using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;

    private float enemyHealth = 5f;
    private float destroyDelay = 0.5f;

    private bool isHurt;
    private Animator anim;
    
  
    

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }
    
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed,0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            Flip();
            currentPoint = pointA.transform;
        }
        
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            Flip();
            currentPoint = pointB.transform;
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    
    public void EnemyDamage(int amount)
    {
        Debug.Log("Enemy Hit!");
        enemyHealth -= amount;
        if (!isHurt)
        {
            isHurt = true;
            anim.SetTrigger("HurtTrigger");
            Invoke(nameof(ResetHurt), 0.5f);
            
            if (enemyHealth <= 0)
            {
                Collider2D enemyCollider = gameObject.GetComponent<Collider2D>();
                if (enemyCollider != null)
                {
                    enemyCollider.enabled = false;
                }
                Destroy(gameObject, destroyDelay);
            } 
        }
    }

    private void ResetHurt()
    {
        isHurt = false;
    }
}
