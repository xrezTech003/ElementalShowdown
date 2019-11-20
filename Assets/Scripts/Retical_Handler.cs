using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Retical_Handler : MonoBehaviour
{
    public GameObject Camera;
    public GameObject rightHand;

    public GameObject reticalObject;
    public Transform reticalTransform;

    private const float distance = 1.0f;

    private void Start()
    {
        reticalTransform = Instantiate(reticalObject, transform).transform;
    }

    void Update()
    {
        if (rightHand.GetComponent<Right_Hand_Fire>().currState != Left_Hand_Tracker.state.NONE) getPosition();
        else reticalTransform.position = new Vector3(0, 1, 0);
    }

    void getPosition()
    {
        Vector3 slope = rightHand.transform.position - Camera.transform.position;
        reticalTransform.position = rightHand.transform.position + slope * 1.5f;
    }
}
