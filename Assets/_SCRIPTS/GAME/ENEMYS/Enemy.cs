using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioClip plyHitSound;

   [Header(" BASIC VARAIABLE")]
    private float enemyLive = 6f;

    [Header(" Shooting Parameters")]
    private float enemyDamage = 1;
    //the position of the empty object, the point where the bullet instantiate
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform controllerProjectile;
    private float timer;

   
    private GameObject _player;
    private DetectPlayerCollider _detectPlayerCollider;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
      //  _detectPlayerCollider = FindObjectOfType<DetectPlayerCollider>().detectedPlayer;
    }

    private void Update()
    {
        //float distance = Vector2.Distance(transform.position, _player.transform.position);
        //every frame this float will represent the distance between enemy-player
        /*
        if(_detectPlayerCollider.detectedPlayer == true)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0; //every 2 second --> reset
                Shoot();
            }
        }*/
    }

   private void Shoot()
    {
        Instantiate(projectilePrefab, controllerProjectile.position, Quaternion.identity);
    }
    public void TakeDamage(float damage) //reduces the enemy's health every time they take damage from the player
    {
        enemyLive -= damage; 

        if (enemyLive <= 0)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {

        //wait for second animación y luego desaparece 
        Destroy(gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //if player touch the enemy will lost a heart
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(plyHitSound);
            collision.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
        }
    }
}
