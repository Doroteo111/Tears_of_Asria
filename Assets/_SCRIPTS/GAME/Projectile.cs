using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Projectile : MonoBehaviour
{
    [Header("Projectile variables")]
    public float velocity;
    public float damage;

    private float lifeTimeProyectile = 1.5f;

    public Rigidbody2D _rb;
    private Enemy enemy;
    private Player player; // quiero acceder al horizontalinput

    private void Start()
    {
       // player = FindAnyObjectOfType<Player>().GetHorizontalInput();
       //busco un float
        // _rb.velocity = player.horizontalInput * velocity;

        _rb.velocity= transform.right*velocity; // * horizontainput

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
   
   /* private IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }*/
    
}
