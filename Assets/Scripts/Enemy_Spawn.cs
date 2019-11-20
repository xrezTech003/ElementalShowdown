using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject targetEnemy;

    public GameObject Camera;

    void Start()
    {
        Instantiate(targetEnemy, new Vector3(30, 0, 0), Quaternion.identity).transform.LookAt(Camera.transform);
    }

    void Update()
    {
        
    }
}
