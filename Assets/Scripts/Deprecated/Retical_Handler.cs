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
        
    }

    void Update()
    {
        if (rightHand.GetComponent<Right_Hand_Fire>().currState != Left_Hand_Tracker.state.NONE)
        {
            if (reticalTransform == null) reticalTransform = Instantiate(reticalObject, transform).transform;
            getPosition();
        }
        else
        {
            Destroy(reticalTransform.gameObject);
            reticalTransform = null;
        }
    }

    void getPosition()
    {
        Vector3 slope = rightHand.transform.position - Camera.transform.position;
        reticalTransform.position = rightHand.transform.position + slope * 1.5f;
        reticalTransform.position = new Vector3(reticalTransform.position.x, reticalTransform.position.y, reticalTransform.position.z);
        reticalTransform.LookAt(Camera.transform);
    }
}
