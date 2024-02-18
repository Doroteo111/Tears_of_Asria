using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTester : MonoBehaviour
{
    public GameObject teleport;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.transform.position = new Vector2(teleport.transform.position.x, 
                teleport.transform.position.y);
        }
    }
}
