using System;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject target;
    public float moveFactor = 0.15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 DistanceToTarget = target.transform.position - transform.position;
        transform.position += new Vector3(DistanceToTarget.x * moveFactor, DistanceToTarget.y * moveFactor);
    }
}
