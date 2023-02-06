using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Movement")]
    Rigidbody2D rb;
    public float movementSpeed, jumpForce;
    public bool isFacingRight, isJumping;
    public float damage;

    [Header("Ground Checker")]
    public float radius;
    public Transform groundChecker;
    public LayerMask whatIsGround;

    Animator anim;

    [Header("Knockback")]
    [SerializeField] private Transform _center;
    [SerializeField] private float _knockbackVel = 8f;
    [SerializeField] private float _knockbackTime = 1f;
    [SerializeField] private bool _knockbacked; 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        isFacingRight = true;
    }

    void Update()
    {
        jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * movementSpeed, rb.velocity.y);
        if (move != 0)
        {
            anim.SetTrigger("run");
        }
        else
        {
            anim.SetTrigger("idle");
        }
        if (move > 0 && !isFacingRight)
        {
            transform.eulerAngles = Vector2.zero;
            isFacingRight = true;
        }
        else if (move < 0 && isFacingRight)
        {
            transform.eulerAngles = Vector2.up * 180;
            isFacingRight = false;
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() )
        {
            rb.velocity = Vector2.up * jumpForce;   
        }
        if (!IsGrounded() && !isJumping)
        {
            isJumping = true;
            anim.SetTrigger("jump");
        }
        else if (IsGrounded() && isJumping)
        {
            isJumping = false;
        }
    }
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChecker.position, radius, whatIsGround);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundChecker.position, radius);
    }
}
