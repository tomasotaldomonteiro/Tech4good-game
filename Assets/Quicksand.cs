using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quicksand : MonoBehaviour
{
    private PlayerController player; 

    private void Start()
    {
        player = GameObject.FindWithTag("Player")?.GetComponent<PlayerController>();
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
            player.speed *= 0.5f;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player.speed = 5f;
    }
}
    

