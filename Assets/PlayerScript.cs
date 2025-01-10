using UnityEngine;

public class skibidiscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    public float walkspeed = 6;
    public float jumpspeed = 11;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocityX = Input.GetAxisRaw("Horizontal") * walkspeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocityY = jumpspeed;
        }
    }
}