using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerCollider : MonoBehaviour
{
    
    public bool detectedPlayer;

    private void Start()
    {
        detectedPlayer = false;
    }
    private void OnTriggerEnter2D(Collider2D collision) //if player touch the enemy will lost a heart
    {
        if (collision.tag == "Player")
        {
            detectedPlayer = true;
            Debug.Log("player AIM");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            detectedPlayer = false;
            Debug.Log("player is OUT");
        }
    }
}
