using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Handler : MonoBehaviour
{
    public enum typing { NONE, AIR, FIRE, WATER, EARTH, LIGHTNING };
    public bool respawn;

    public int life;
    public typing weakness;
    public typing secondaryWeakness;

    private GameObject Camera;

    void Start()
    {
        Camera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        transform.LookAt(Camera.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        /*
        if (respawn)
        {
            gameObject.SetActive(false);

            for (int i = 0; i < 120; i++);

            gameObject.SetActive(true);
        }
        else
        {
        */
            Destroy(gameObject);
        //}
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
