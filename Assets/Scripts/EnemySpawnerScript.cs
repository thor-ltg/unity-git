using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject Enemy;
    public float SpawnTime;
    public float DespawnTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("DelayedUpdate", SpawnTime);
    }
    void DelayedUpdate()
    {
        GameObject EnemyClone = Instantiate(Enemy, transform.position, Quaternion.identity);
        Destroy(EnemyClone, DespawnTime);
        CancelInvoke();
    }
}
