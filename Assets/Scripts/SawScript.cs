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
        GetComponent<Animator>().Play("saw_Idle");
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
        if (collision.tag == "Fireball")
        {
            Destroy(gameObject, 0.5f);
            GetComponent<Animator>().Play("saw_Death");
            rb.linearVelocity = new Vector2(0, 0);
        }
    }
}
