using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound; //sound that will play when pickin up a new checkpoint
    private Transform currentLastCheckPoint; // store our last checkpoint
    private PlayerHealth _playerHealth; //reset the player health

    private Animator _animator;
    //animacion sprite cambiar de color

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
    }

    public void Respawn()
    {
        transform.position = currentLastCheckPoint.position; //move player to checkpoint position
        _playerHealth.Respawn();
    }

    //activation checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Checkpoint")
        {
            Debug.Log("CHECKPOINT");
            currentLastCheckPoint = collision.transform; //store the checkpoint that we activated as the current one
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false; //desactivate checkpoint collider
            collision.GetComponent<Animator>().SetTrigger("Activated");

        }
    }
}
