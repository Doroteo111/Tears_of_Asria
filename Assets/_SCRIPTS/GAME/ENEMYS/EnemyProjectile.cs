using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D _rb;
    public float force;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position; //direction towards the plyer
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * force; //normalized --> direction stays the same
    }

}
