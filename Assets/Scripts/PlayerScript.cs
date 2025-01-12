using System.Diagnostics.Tracing;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    BoxCollider2D StandingHitbox;
    CircleCollider2D DuckingHitbox;
    Rigidbody2D rb;
    public float walkspeed = 6;
    public float jumpspeed = 11;

    Vector3 startPosition;

    SpriteRenderer spriteRenderer;

    public Rigidbody2D rbElevator;

    GroundCheckScript groundCheck;

    public GameObject fireball;
    public Vector3 fireballOffset;
    public Vector2 fireballSpeed;
    public float fireballLifetime;
    int Direction = 1;

    Animator animator;

    bool duck = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        groundCheck = GetComponentInChildren<GroundCheckScript>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StandingHitbox = GetComponent<BoxCollider2D>();
        DuckingHitbox = GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!duck)
        {
            HandleMovement();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject newfireball = Instantiate(fireball, transform.position + fireballOffset*Direction, Quaternion.identity);
            Rigidbody2D fireballRb = newfireball.GetComponent<Rigidbody2D>();
            fireballRb.linearVelocity = fireballSpeed*Direction;
            Destroy(newfireball, fireballLifetime);
        }
        if (-10 > transform.position.y)
        {
            transform.position = startPosition;
        }
        if (duck)
        {
            DuckingHitbox.enabled = true;
            StandingHitbox.enabled = false;
        }
        else
        {
            DuckingHitbox.enabled = false;
            StandingHitbox.enabled = true;
        }
        HandleAnimations();
    }
    void HandleMovement()
    {
        rb.linearVelocityX = Input.GetAxisRaw("Horizontal") * walkspeed;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Direction = -1;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Direction = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.isGrounded)
        {
            rb.linearVelocityY = jumpspeed;
        }
    }
    void HandleAnimations()
    {
        if (rb.linearVelocity.sqrMagnitude <= 0 && !duck)
        {
            animator.Play("Player_Idle");
        }
        else if (groundCheck.isGrounded && !duck)
        {
            animator.Play("Player_Walk");
        }
        else if (!duck)
        {
            animator.Play("Player_Jump");
        }
        if (Direction == -1)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.Play("Player_Duck");
            duck = true;
        }
        else
        {
            duck = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            transform.position = startPosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ElevatorActivator")
        {
            rbElevator.linearVelocity = new Vector2(0, 3);
        }
    }
}