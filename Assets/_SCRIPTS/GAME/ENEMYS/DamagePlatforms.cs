using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlatforms : MonoBehaviour
{
     private float platformDamage = 1f;

    [Header("Sounds")]
    [SerializeField] private AudioClip hitSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(platformDamage);
            SoundManager.instance.PlaySound(hitSound);
        }
    }
}
