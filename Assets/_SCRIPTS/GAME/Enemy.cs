using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header(" BASIC VARAIABLE")]

    [SerializeField] private float enemyLive = 100f;

    void Start()
    {
        
    }

    public void TakeDamage(float damage)
    {
        enemyLive -= damage; //reduce la vida del enemigo cada vez que recie da�o

        if(enemyLive <= 0)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        //wait for second animaci�n y luego desaparece 
        Destroy(gameObject);
    }
}
