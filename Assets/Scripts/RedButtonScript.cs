using UnityEngine;

public class RedButtonScript : MonoBehaviour
{
    public GameObject rock;
    public GameObject GiantSnail;
    public GameObject MainCamera;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && MainCamera.GetComponent<CameraScript>().target == player)
        {
            GiantSnail.GetComponent<giantSnailScript>().movespeed *= 0.01f;
            MainCamera.GetComponent<CameraScript>().target = GiantSnail;
            MainCamera.GetComponent<Camera>().orthographicSize = 15;
            GameObject Rock = Instantiate(rock, GiantSnail.transform.position + new Vector3(0, 20), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
