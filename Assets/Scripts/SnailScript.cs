using UnityEngine;

public class SnailScript : MonoBehaviour
{
    public  float movespeed = -0.005f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(movespeed, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fireball")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "SnailTrigger")
        {
            movespeed *= -1;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
