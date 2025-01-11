using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    public float walkspeed = 6;
    public float jumpspeed = 11;

    Vector3 startPosition;

    public Rigidbody2D rbElevator;

    GroundCheckScript groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        groundCheck = GetComponentInChildren<GroundCheckScript>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocityX = Input.GetAxisRaw("Horizontal") * walkspeed;
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.isGrounded)
        {
            rb.linearVelocityY = jumpspeed;
        }
        if (-10 > transform.position.y)
        {
            transform.position = startPosition;
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