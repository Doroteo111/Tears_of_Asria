using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlatforms : MonoBehaviour
{
    [SerializeField] private float platformDamage;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(platformDamage);
        }
    }
}
