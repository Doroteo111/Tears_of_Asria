using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header ("LAYERS")]
    [SerializeField] private LayerMask groundLayerMask;

    [Header("MOVMENT VARIABLES")]
    public float moveSpeed = 6f;
    public float jumpSpeed = 10f;
    private float horizontalInput;

    private bool isOnTheGround;
    private bool isWalking;
    private bool isFacing;

    [Header("VARIABLES DASH")]
    [SerializeField] private float dashVelocity;
    [SerializeField] private float dashTimer;
    private float inicialGravity;
    private bool iCanDash = true;
    private bool iCanMove = true; //restringir el movimiento del jugador cuando dashea

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

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); //AxisRaw for no acceleration (we move on -1 to 1)
       

        if (Input.GetKeyDown(KeyCode.LeftShift) && iCanDash)
        {
            StartCoroutine(Dash());
        }

        isOnTheGround = IsOnTheGround();

        if (Input.GetKeyDown(KeyCode.Space) && IsOnTheGround()) //if you press space key + the player is touching the ground = can jump
        {
            _rigidbody2D.velocity = Vector2.up * jumpSpeed;
        }

    }

    private void FixedUpdate()  //Handle Movment
    {
        if (iCanMove) //para el dash
        {
            isWalking = _rigidbody2D.velocity.x != 0; // is walking = true when greater to 0
            _rigidbody2D.velocity = new Vector2(horizontalInput * moveSpeed, _rigidbody2D.velocity.y);
        }
      
        
        if (horizontalInput < 0) //if  -1 < 0 --> flip to Left
        {
            _spriteRenderer.flipX = true;
        }

        if (horizontalInput > 0) //if  +1 > 0 -->flip to Right
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void LateUpdate()
    {
        _animator.SetBool("IsWalking", isWalking); //walk animation
        //_animator.SetBool("IsDashing", isDashing);  a�adir animacion
    }
       
    private bool IsOnTheGround()  // en vez de linea usar una caja para que si nos encontramos al borde borde de la plataforma nos detecta suelo y podamos saltar
    {
        float extraHeightTest = 0.05f; //

        RaycastHit2D raycastHit2D = Physics2D.Raycast(_boxCollider2D.bounds.center, Vector2.down, _boxCollider2D.bounds.extents.y
            + extraHeightTest, groundLayerMask);   // (origen rayo)centro del collider, direcci�n , distancia (la mitad de la altura)

        return raycastHit2D.collider != null; //si = true si A chocado con algo que es suelo
    }

    private IEnumerator Dash() //ver video de nuevo y comentar 
    {
        iCanMove = false;
        iCanDash = false;
        _rigidbody2D.gravityScale = 0;
        _rigidbody2D.velocity = new Vector2(dashVelocity * horizontalInput, 0); // movimimento horizontal
        _trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashTimer);

        iCanMove = true;
        iCanDash = true;
        _rigidbody2D.gravityScale = inicialGravity;
        _trailRenderer.emitting=false;
    }

}

