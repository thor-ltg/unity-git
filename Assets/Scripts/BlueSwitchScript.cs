using UnityEngine;

public class BlueSwitchScript : MonoBehaviour
{
    public yellowFlagScript yellowFlagScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            yellowFlagScript.Actived = true;
            Destroy(gameObject);
        }
    }
}
