using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Projectile : MonoBehaviour
{
    public float velocity;
    public float damage;


    public Rigidbody2D _rb;
    private Enemy enemy;
    private Player player; // quiero acceder al horizontalinput

    private void Start()
    {
        /*player=FindAnyObjectByType<Player>();
        _rb.velocity = player.horizontalInput * velocity;*/

        _rb.velocity= transform.right*velocity;
    }
    private void Update()
    {
        //DeleteBullet();
    }

    private void OnTriggerEnter2D(Collider2D other) //hitInfo
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log("SHOOT ENEMY");
        }
        /*hitInfo.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
            Debug.Log("SHOOT ENEMY");
        }
        Destroy(gameObject);
        Debug.Log(hitInfo.name);
    }
   
   /* private IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }*/
    }
}
