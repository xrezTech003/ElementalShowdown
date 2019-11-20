using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class CameraTest : MonoBehaviour
{
    public GameObject Camera;

    public GameObject blue;
    public GameObject red;
    public GameObject yellow;

    Transform xBlue;
    Transform yRed;
    Transform zYellow;

    void Start()
    {
        xBlue = Instantiate(blue, transform).transform;
        yRed = Instantiate(red, transform).transform;
        zYellow = Instantiate(yellow, transform).transform;
    }

    void Update()
    {
        xBlue.position = new Vector3(Camera.transform.position.x, 0, 0);
        yRed.position = new Vector3(0, Camera.transform.position.y, 0);
        zYellow.position = new Vector3(0, 0, Camera.transform.position.z);
    }
}
