using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMoveScript : MonoBehaviour
{

    [SerializeField] public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered Next Level");

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Switching to Scene " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }
}
