using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
     private DataPersistence dataPersistence;



    [Header ("LAYERS")] //collider
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private LayerMask collectablesLayerMask;


    [Header ("COLLECTABLE / UI VARIABLES")]
    private int totalGems;
    public TextMeshProUGUI totalGemsText;
    //all the ImageKeys
    [SerializeField] private Image keyBlueImage,keyYellowImage,keyPurpleImage,keyPinkImage;
    public bool hasBlueKey;
    public bool hasYellowKey;
    public bool hasPurpleKey;
    public bool hasPinkKey;

    [Header(" BASIC VARAIABLE")]

    [SerializeField] private float playerLife = 60f;

    [Header("MAGIC PROJECTILE")]
    // saber la posicion del empty object, el punto donde sale la bala
    [SerializeField] private Transform controllerProjectile; 
    [SerializeField] private GameObject magicProjectile; //sprite GO bala

    [Header("MOVMENT")]
    public float moveSpeed = 6f;
    public float jumpSpeed = 10f;
    public float horizontalInput;

    private bool isOnTheGround;
    private bool isWalking;


    [Header("DASH")]
    [SerializeField] private float dashVelocity;
    [SerializeField] private float dashTimer;
    private float inicialGravity;
    private bool iCanDash = true;
    private bool iCanMove = true; //restrict the movment of the player when dash 

   
    [Header("REFERENCE")]
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private TrailRenderer _trailRenderer;


    private void Awake()  //Set all the reference
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        inicialGravity = _rigidbody2D.gravityScale;

        _boxCollider2D = GetComponentInChildren<BoxCollider2D>();

        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }
    private void Start()
    {
        //Keys images
       keyPinkImage.enabled = false;
       keyYellowImage.enabled = false;
       keyPurpleImage.enabled = false;
       keyBlueImage.enabled = false;

        //Has Keys
        hasBlueKey = false;
        hasYellowKey = false;
        hasPurpleKey = false;
        hasPinkKey  = false;

        //hearts images

        //Dash boolean --> I can't dash until I get the special object
       iCanDash = false;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); //AxisRaw for no acceleration (we move on -1 to 1)

        isOnTheGround = IsOnTheGround();

        // DASH
        if (Input.GetKeyDown(KeyCode.LeftShift) && iCanDash) 
        {
            StartCoroutine(Dash());
        }

        // JUMP
        if (Input.GetKeyDown(KeyCode.Space) && IsOnTheGround())
        {
            _rigidbody2D.velocity = Vector2.up * jumpSpeed;
        }

        //SHOOT PROJECTILE
        if (Input.GetMouseButtonDown(1))  //Pressed rigth-click
        {
            
            //disparo
            ShootMagicProjectile();
        }
    }

    private void FixedUpdate()  //Handle Movment
    {
        if (iCanMove) //I can Dash only if I'M in movment
        {
            isWalking = _rigidbody2D.velocity.x != 0; // is walking = true when greater to 0
            _rigidbody2D.velocity = new Vector2(horizontalInput * moveSpeed, _rigidbody2D.velocity.y);
        }
      
        
        if (horizontalInput < 0) //if  -1 < 0 --> flip to Left
        {
            // _spriteRenderer.flipX = true;
            _spriteRenderer.transform.rotation = Quaternion.Euler(0,180,0);
        }

        if (horizontalInput > 0) //if  +1 > 0 -->flip to Right
        {
           // _spriteRenderer.flipX = false;
           _spriteRenderer.transform.rotation = Quaternion.identity;

        }
    }

    private void LateUpdate()
    {
        _animator.SetBool("IsWalking", isWalking); //walk animation
        //_animator.SetBool("IsDashing", isDashing);  añadir animacion
    }
       
    private bool IsOnTheGround()  // en vez de linea usar una caja para que si nos encontramos al borde borde de la plataforma nos detecta suelo y podamos saltar
    {
        float extraHeightTest = 0.05f; //

        RaycastHit2D raycastHit2D = Physics2D.Raycast(_boxCollider2D.bounds.center, Vector2.down, _boxCollider2D.bounds.extents.y
            + extraHeightTest, groundLayerMask);   // (note 4 me) origin line --> centre from the collider, direction, distance (half of height)

        return raycastHit2D.collider != null; //yes = true if collides with something with the ground tag 
    }

    public void TakeDamage(float damage)
    {
        playerLife -= damage; //reduce la vida del enemigo cada vez que recie daño

        if (playerLife <= 0)
        {
            //gameover;
        }


    }
    private IEnumerator Dash() 
    {
        //when I press shift I can't move or dash again until the dashTimer finised
        iCanMove = false;
        iCanDash = false;
        _rigidbody2D.gravityScale = 0;
        _rigidbody2D.velocity = new Vector2(dashVelocity * horizontalInput, 0); //movment in both directions
        _trailRenderer.emitting = true;

        yield return new WaitForSeconds(dashTimer);

        iCanMove = true;
        iCanDash = true;
        _rigidbody2D.gravityScale = inicialGravity;
        _trailRenderer.emitting=false;
    }
     private void ShootMagicProjectile()
     {
         Instantiate(magicProjectile, controllerProjectile.position, controllerProjectile.rotation);
     }

    private void GetDashCape(Collider2D other) //collectable DashCape --> given power for dash
    {
        Destroy(other.gameObject);
        iCanDash = true;
        //_audioSource.PlayOneShot(collectables);
        //interface update sprite cape
    }

    private void GetGems(Collider2D other) //need to collect all 5 to complete the game
    {
        Destroy(other.gameObject);
        totalGems++;
        totalGemsText.text = $"{totalGems}/5";
       
       // _audioSource.PlayOneShot(collectables[1]);

    }
    public int GetTotalGems() //for data persistence
    {
        return totalGems;
    }
    public void SetTotalGems(int newTotal)
    {
        totalGems = newTotal;
    }

    #region KEYS LOGIC
    private void GetBlueKeys(Collider2D other)
    {
        Destroy(other.gameObject);
        keyBlueImage.enabled = true;
        
        hasBlueKey = true;
        // Datapersistance.safe()
    }
    public bool HasGetBlueKeys() //for data persistence
    {
        return hasBlueKey;                                   ;
    }

    private void GetYellowKeys(Collider2D other)
    {
        Destroy(other.gameObject);
        keyYellowImage.enabled = true;

        hasYellowKey = true;

    }
    private void GetPinkKeys(Collider2D other)
    {
        Destroy(other.gameObject);
        keyPinkImage.enabled = true;

        hasPinkKey = true;

    }
    private void GetPurpleKeys(Collider2D other)
    {
        Destroy(other.gameObject);
        keyPurpleImage.enabled = true;

        hasPurpleKey = true;
    }
    #endregion
    private void OnTriggerEnter2D(Collider2D other) //add all trigger collectables
    {
        if (other.gameObject.tag.Equals("Dash Cape"))
        {
            GetDashCape(other);
        }
        else if (other.gameObject.tag.Equals("Gems"))
        {
            GetGems(other);
        }
        else if(other.gameObject.tag.Equals("Blue Key"))
        {
            GetBlueKeys(other);
        }
        else if (other.gameObject.tag.Equals("Purple Key"))
        {
            GetPurpleKeys(other);
        }
        else if (other.gameObject.tag.Equals("Yellow Key"))
        {
            GetYellowKeys(other);
        }
        else if (other.gameObject.tag.Equals("Pink Key"))
        {
            GetPinkKeys(other);
        }
    }

}

