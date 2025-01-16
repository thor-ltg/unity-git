using UnityEngine;

public class giantSnailScript : MonoBehaviour
{
    public int Health;
    public float movespeed;
    public GameObject obstaclecourse;
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
            Health--;
            if (Health == 0)
            {
                movespeed *= 10;
                GetComponent<SpriteRenderer>().color = new Color(150, 0, 0);
                obstaclecourse.transform.position = new Vector3(10, 7, 0);
            }
        }
        if (collision.tag == "SnailTrigger")
        {
            movespeed *= -1;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
