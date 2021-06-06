using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("death");
            GameManager.Instance.GameOver();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag("Score"))
        {
            
            GameManager.Instance.AddScore();
        }
        
    }
}
