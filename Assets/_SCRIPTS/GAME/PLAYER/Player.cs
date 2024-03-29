using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public DataPersistence _dataPersistence;
    public string nextPoint;

    [Header("Sounds")]
    [SerializeField] private AudioClip projectileSound;
    [SerializeField] private AudioClip collectableSound;

    [Header ("LAYERS")] //collider
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private LayerMask collectablesLayerMask;


    [Header ("COLLECTABLE / UI VARIABLES")]
    public int totalGems;
    public TextMeshProUGUI totalGemsText;

    [SerializeField] private Image dashcapeImage;
    //all the ImageKeys
    [SerializeField] private Image keyBlueImage,keyYellowImage,keyPurpleImage,keyPinkImage;
    public bool hasBlueKey;
    public bool hasYellowKey;
    public bool hasPurpleKey;
    public bool hasPinkKey;

    [Header("MAGIC PROJECTILE")]
    //the position of the empty object, the point where the bullet instantiate
    [SerializeField] private Transform controllerProjectile; 
    [SerializeField] private GameObject magicProjectile; //sprite G.O

    [Header("MOVMENT")]
    private float moveSpeed = 6f;
    private float jumpSpeed = 10f;
    private float horizontalInput;

    private bool isOnTheGround;
    private bool isWalking;
    private bool isJumping = false;

    [Header("DASH")]
    private float dashVelocity = 20f;
    private float dashTimer = 0.4f;
    private float inicialGravity;
    private bool iCanDash;
    public bool iCanMove = true; //restrict the movment of the player when dash 

   
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

        //Dash images
        dashcapeImage.enabled = false;

        //Dash boolean --> I can't dash until I get the special object
       iCanDash = false;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); //AxisRaw for no acceleration (we move on -1 to 1)

        isOnTheGround = IsOnTheGround(); // reulstado raycast
        isJumping = !isOnTheGround;

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
            _spriteRenderer.transform.rotation = Quaternion.Euler(0,180,0);
        }

        if (horizontalInput > 0) //if  +1 > 0 -->flip to Right
        {
           _spriteRenderer.transform.rotation = Quaternion.identity;

        }
    }

    private void LateUpdate()
    {
        _animator.SetBool("IsWalking", isWalking); 
       _animator.SetBool("IsJumping", isJumping);
    }
    
    private bool IsOnTheGround()  // en vez de linea usar una caja para que si nos encontramos al borde borde de la plataforma nos detecta suelo y podamos saltar
    {
        float extraHeightTest = 0.05f; //

        RaycastHit2D raycastHit2D = Physics2D.Raycast(_boxCollider2D.bounds.center, Vector2.down, _boxCollider2D.bounds.extents.y
            + extraHeightTest, groundLayerMask);   // (note 4 me) origin line --> centre from the collider, direction, distance (half of height)

        return raycastHit2D.collider != null;//yes = true if collides with something with the ground tag 
        
        
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
        SoundManager.instance.PlaySound(projectileSound);
         Instantiate(magicProjectile, controllerProjectile.position, controllerProjectile.rotation);
     }

    private void CollectDashCape(Collider2D other) //collectable DashCape --> given power for dash
    {
        SoundManager.instance.PlaySound(collectableSound);
        Destroy(other.gameObject);
        iCanDash = true;
        dashcapeImage.enabled = true;
    }
    public bool GetDashCape()
    {
        return iCanDash;
    }

    public void SetDashCape(bool dataJson)
    {
        iCanDash=dataJson;
        if (dataJson)
        {
            dashcapeImage.enabled = true;
        }
    }
    private void CollectGems(Collider2D other) //need to collect all 5 to complete the game
    {
        SoundManager.instance.PlaySound(collectableSound);
        Destroy(other.gameObject);
        totalGems++;
        totalGemsText.text = $"{totalGems}/5";

    }
    public int GetTotalGems() //for data persistence (safe)
    {
        return totalGems;
    }
    public void SetTotalGems(int newTotal) //(load)
    {
        totalGems = newTotal;
        if (totalGems > 0)
        {
            totalGemsText.text = $"{totalGems}/5";
        }
    }

    #region -->> KEYS LOGIC <<--
    private void CollectBlueKey(Collider2D other)
    {
        SoundManager.instance.PlaySound(collectableSound);
        Destroy(other.gameObject);
        keyBlueImage.enabled = true;
        
        hasBlueKey = true;
    }
    public bool GetBlueKey() //for data persistence (safe)
    {
        return hasBlueKey;                                   
    }
    public void SetBlueKey(bool dataJson) //(load)
    {
        hasBlueKey = dataJson;
        if (dataJson)
        {
            keyBlueImage.enabled=true;
        }
    }
    private void CollectYellowKey(Collider2D other)
    {
        SoundManager.instance.PlaySound(collectableSound);
        Destroy(other.gameObject);
        keyYellowImage.enabled = true;

        hasYellowKey = true;

    }
    public bool GetYellowKey() //for data persistence (safe)
    {
        return hasYellowKey;
    }
    public void SetYellowKey(bool dataJson) //(load)
    {
        hasYellowKey = dataJson;
        if (dataJson)
        {
            keyYellowImage.enabled = true;
        }
    }
    private void CollectPinkKey(Collider2D other)
    {
        SoundManager.instance.PlaySound(collectableSound);
        Destroy(other.gameObject);
        keyPinkImage.enabled = true;

        hasPinkKey = true;

    }
    public bool GetPinkKey() //for data persistence (safe)
    {
        return hasPinkKey;
    }
    public void SetPinkKey(bool dataJson) //(load)
    {
        hasPinkKey = dataJson;
        if (dataJson)
        {
            keyPinkImage.enabled = true;
        }
    }
    private void CollectPurpleKey(Collider2D other)
    {
        SoundManager.instance.PlaySound(collectableSound);
        Destroy(other.gameObject);
        keyPurpleImage.enabled = true;

        hasPurpleKey = true;
    }
    public bool GetPurpleKey() //for data persistence (safe)
    {
        return hasPurpleKey;
    }
    public void SetPurpleKey(bool dataJson) //(load)
    {
        hasPurpleKey = dataJson;
        if (dataJson)
        {
            keyPurpleImage.enabled = true;
            
        }
    }
    #endregion
    private void OnTriggerEnter2D(Collider2D other) //add all trigger collectables
    {
        if (other.gameObject.tag.Equals("Dash Cape"))
        {
            CollectDashCape(other);
            _dataPersistence.SaveJson(); //save data
        }
        else if (other.gameObject.tag.Equals("Gems"))
        {
            CollectGems(other);
            _dataPersistence.SaveJson(); //save data
        }
        else if(other.gameObject.tag.Equals("Blue Key"))
        {
            CollectBlueKey(other);
            _dataPersistence.SaveJson(); //save data
        }
        else if (other.gameObject.tag.Equals("Purple Key"))
        {
            CollectPurpleKey(other);
            _dataPersistence.SaveJson(); //save data
        }
        else if (other.gameObject.tag.Equals("Yellow Key"))
        {
            CollectYellowKey(other);
            _dataPersistence.SaveJson(); //save data
        }
        else if (other.gameObject.tag.Equals("Pink Key"))
        {
            CollectPinkKey(other);
            _dataPersistence.SaveJson(); //save data
        }
    }

}

