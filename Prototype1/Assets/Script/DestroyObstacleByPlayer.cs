using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacleByPlayer : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.UpdateScore(5);
            Destroy(gameObject);
        }
    }
}
