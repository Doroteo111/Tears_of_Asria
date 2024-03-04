using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;

    [Header("Sounds")]
    [SerializeField] private AudioClip collectableSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(collectableSound);
            collision.GetComponent<PlayerHealth>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
