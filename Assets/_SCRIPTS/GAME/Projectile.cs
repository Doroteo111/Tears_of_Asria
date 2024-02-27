using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Projectile : MonoBehaviour
{
    [Header("Projectile variables")]
    public float velocity;
    public float damage;

    private float lifeTimeProyectile = 0.4f;

    public Rigidbody2D _rb;
    private Enemy enemy;
   

    private void Start()
    {
        _rb.velocity= transform.right*velocity; 

        Destroy(gameObject,lifeTimeProyectile); //the projectile will autodestroy in 1.5 sec
    }
    

    private void OnTriggerEnter2D(Collider2D other) //hitInfo
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log("SHOOT ENEMY");
            Destroy(gameObject); 
        }
       
    }
}
