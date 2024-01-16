using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // LAYERS
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
}

