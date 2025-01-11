using UnityEngine;

public class SawScript : MonoBehaviour
{
    public Vector2 startVelocity;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = startVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SawTrigger")
        {
            rb.linearVelocity *= -1;
        }
    }
}
