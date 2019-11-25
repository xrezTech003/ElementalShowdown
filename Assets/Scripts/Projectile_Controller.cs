using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Controller : MonoBehaviour
{
    private Vector3 start;

    void Start()
    {
        start = transform.position;
    }

    void Update()
    {
        transform.LookAt(start);
    }
}
