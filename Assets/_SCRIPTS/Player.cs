using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region OLD CODE
    /*// LAYERS
    [SerializeField] private LayerMask groundLayerMask;

    //VARIABLES
    public float moveSpeed = 6.0f;
    public float jumpSpeed = 8f;
    private bool walking = false;
    public Vector2 lastMovment = Vector2.zero;

    //CONSTANT VARIABLES
    private const string AXIS_H = "Horizontal";

    //REFERENCES
    ///private Animator _animator;
    private Rigidbody2D _rigidbody2d;
    private CapsuleCollider2D _capsuleCollider2d;

    void Start()
    {
       // _animator = GetComponent<Animator>();
        _rigidbody2d = transform.GetComponent<Rigidbody2D>();
        _rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
       _capsuleCollider2d = transform.GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        walking = false;
        if (Mathf.Abs(Input.GetAxisRaw(AXIS_H)) > 0.2f)
        {
            _rigidbody2d.velocity = new Vector2(Input.GetAxisRaw(AXIS_H) * moveSpeed, _rigidbody2d.velocity.y);
            walking = true;
            lastMovment = new Vector2(Input.GetAxisRaw(AXIS_H), 0);
        }

        if (Input.GetKeyDown(KeyCode.H)) //GetHit
        {
            Debug.Log("me han hecho daño");
           // _animator.SetTrigger("Get_Hit");
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) //jump
        {
            _rigidbody2d.velocity = Vector2.up * jumpSpeed;
        }


    }
    private void LateUpdate()
    {
       // _animator.SetFloat(AXIS_H, Input.GetAxisRaw(AXIS_H));

        //_animator.SetBool("Walking", walking);
        //_animator.SetFloat("Last_H", lastMovment.x);
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(_capsuleCollider2d.bounds.center, _capsuleCollider2d.bounds.size,
                           0f, Vector2.down, 1f, groundLayerMask);
      return raycastHit2d.collider != null; // = true si A chocado con algo que es suelo
    
    }
    */
    #endregion

    // LAYERS
    [SerializeField] private LayerMask groundLayerMask;

    //VARIABLES
    private float horizontalInput;
    public float moveSpeed = 5f;
    public float jumpSpeed = 7f;

    private bool isOnTheGround;
   // private bool facingRight = true; 

    //REFERENCE
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;

    

    private void Awake()  //Set all the reference
    {
      
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        _boxCollider2D = GetComponentInChildren<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        isOnTheGround = IsOnTheGround();

        if (Input.GetKeyDown(KeyCode.Space) && IsOnTheGround()) //if you press space key + the player is touching the ground = can jump
        {
            _rigidbody2D.velocity = Vector2.up * jumpSpeed;
        }
    }
   
    private void FixedUpdate()
    {
       //Handle Movment (code monkey)
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody2D.velocity = new Vector2(-moveSpeed, _rigidbody2D.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                _rigidbody2D.velocity = new Vector2(+moveSpeed, _rigidbody2D.velocity.y);
                
            }
            else
            {
                //no keys pressed
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
            }

            /*  if (horizontalInput > 0 && !facingRight)
              {
                  Flip();
              }
              if (horizontalInput > 0 && facingRight)
              {
                  Flip();
              }*/
        }


    }
    /*
    private void Flip() // flip the character
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }*/

        private bool IsOnTheGround() // en vez de linea usar una caja para que si nos encontramos al borde borde de la plataforma nos detecta suelo y podamos saltar
    {
        float extraHeightTest = 0.05f; //

        RaycastHit2D raycastHit2D = Physics2D.Raycast(_boxCollider2D.bounds.center, Vector2.down, _boxCollider2D.bounds.extents.y
            + extraHeightTest, groundLayerMask);   // (origen rayo)centro del collider, dirección , distancia (la mitad de la altura)

        return raycastHit2D.collider != null; //si = true si A chocado con algo que es suelo

    }
}

