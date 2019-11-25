using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Handler : MonoBehaviour
{
    public int life = 5;
    private string weakness;
    private GameObject Camera;

    void Start()
    {
        weakness = "NONE";
        Camera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        transform.LookAt(Camera.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    void takeDamage()
    {
        life--;

        if (life == 0)
        {
            Destroy(gameObject);
        }
    }
}
