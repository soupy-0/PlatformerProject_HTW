using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    
    void Start()
    {
        health = maxHealth;
    }
    
    public void TakeDamage(int amount)
    {
        health -= amount;
        switch (health)
        {
            case 3:
                heart3.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case 2:
                heart2.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case 1:
                heart1.color = new Color(0.5f, 0.5f, 0.5f);
                break;
        }
        
        if (health <= 0)
        {
            PlayerDeath();
        }
    }
    
    public void PlayerDeath()
    {
        SceneManager.LoadScene("GameOverScreen");
    }
    
   
}
