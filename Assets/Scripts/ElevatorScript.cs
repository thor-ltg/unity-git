using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public Vector2 StartVelocity;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = StartVelocity;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ElevatorTrigger")
        {
            rb.linearVelocity *= -1;
        }
    }
}
