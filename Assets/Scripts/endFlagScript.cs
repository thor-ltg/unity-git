using UnityEngine;
using UnityEngine.SceneManagement;

public class endFlagScript : MonoBehaviour
{
    public int LastLevel;
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
        if (collision.collider.tag == "Player" && SceneManager.GetActiveScene().name.Contains("Level"))
        {
            string[] nextsence = SceneManager.GetActiveScene().name.Split();
            if (int.Parse(nextsence[1]) == LastLevel)
            {
                nextsence[1] = "1";
            }
            else
            {
                nextsence[1] = (int.Parse(nextsence[1]) + 1).ToString();
            }
            SceneManager.LoadScene(nextsence[0] +" "+ nextsence[1]);
        }
        else if (collision.collider.tag == "Player")
        {
            GameObject Camera = GameObject.FindGameObjectWithTag("MainCamera");
            Camera.GetComponent<CameraScript>().target = GameObject.FindGameObjectWithTag("winScreen");
        }
    }
}
