using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D _rb;
    public float force;
    private float timer;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position; //direction towards the plyer
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * force; //normalized --> direction stays the same
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) //hitInfo
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(1);
            Debug.Log("PLAYER DETECTED");
            Destroy(gameObject);
        }

    }
}
