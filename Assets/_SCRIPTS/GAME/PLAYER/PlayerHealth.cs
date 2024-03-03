using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private DataPersistence _dataPersistence;
    private HealthBar _healthBar;

    [Header(" BASIC VARAIABLE")]
    [SerializeField] private float startingHealth;//Amount of health the player has in the start
    public float currentHealth { get; private set; }
    private bool dead;

    private Animator _animator;

    [Header(" iFrames")] //the player is invulnerable for a short period of time (doesn't take damage)
    [SerializeField] private float iFramesDuration;
    [SerializeField] private float numberOfFlashes; //how many times the sprite flashes red, knowing how much time we have
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Player _player;
    private void Awake()
    {
        currentHealth = startingHealth;
        dead = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
        _dataPersistence = FindObjectOfType<DataPersistence>();
        _healthBar = FindObjectOfType<HealthBar>();
    }
    public void TakeDamage(float _damage)
    {
        //safeguard to make sure that the health doesn't go below 0
        //or above the max value
        //the max value will be startingHealth bc we never want more health than we have at the beginning

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth); 

        if (currentHealth > 0)
        {
            _dataPersistence.SaveJson(); //(safe)
            Debug.Log("DAÑO");
            StartCoroutine(Invunerability());
        }
        else
        { 
            
            dead = true;
            _animator.SetTrigger("Die"); 
        }
         
    }
    public float GetCurrentHealth() //for data persistence (safe)
    {
        return currentHealth;
    }

    public void SetCurrentHealth(float dataJson) //(load)
    {
        currentHealth = dataJson;
    }
    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        //animator.ResetTrigger("die");
        //Idle animation??
    }
    public void AddHealth(float _value) 
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invunerability() //7,9 = means the layers of enemy and player
    {
        Physics2D.IgnoreLayerCollision(7, 9, true);

        //invunerabity duration
        for (int i=0; i< numberOfFlashes; i++)
        {
            _spriteRenderer.color = new Color(1, 0, 0, 0.8f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            _spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 9, false);
    }
}
