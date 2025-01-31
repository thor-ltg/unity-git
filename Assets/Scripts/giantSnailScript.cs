using UnityEngine;

public class giantSnailScript : MonoBehaviour
{
    public int Health;
    public float movespeed;
    public GameObject obstaclecourse;
    public GameObject endflag;
    public int stage = 3;
    GameObject MainCamera;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
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
                obstaclecourse.GetComponent<Transform>().position = new Vector3(2, 2.5f);
            }
        }
        if (collision.tag == "SnailTrigger")
        {
            movespeed *= -1;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        if (collision.tag == "Stone" && MainCamera.GetComponent<CameraScript>().target == gameObject)
        {
            movespeed *= 100;
            stage--;
            MainCamera.GetComponent<Camera>().orthographicSize = 5;
            MainCamera.GetComponent<CameraScript>().target = player;
            Destroy(collision.gameObject);
        }
        if (stage <= 0 && Health <= 0)
        {
            GameObject flag = Instantiate(endflag, transform.position + new Vector3(0, -2.1f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
