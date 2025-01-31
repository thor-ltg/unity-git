using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FireSnailScript : MonoBehaviour
{
    public GameObject FireballObject;
    GameObject Player;
    public float shoottime = 0.5f;
    public float shootspeed = 15;
    public float fireballdespawntime = 5;
    bool CanShoot = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (CanShoot)
        {
            StartCoroutine("ShootFire");
        }
    }
    IEnumerator ShootFire()
    {
        CanShoot = false;
        GameObject Fireball = Instantiate(FireballObject, transform.position, Quaternion.identity);
        Rigidbody2D Fireballrb = Fireball.GetComponent<Rigidbody2D>();
        Fireballrb.linearVelocity = ((Player.transform.position - transform.position).normalized)*shootspeed;
        Destroy(Fireball, fireballdespawntime);
        yield return new WaitForSeconds(shoottime);
        CanShoot = true;
    }

}