using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Right_Hand_Fire : MonoBehaviour
{
    public GameObject leftHand;

    public GameObject lightningObject;
    public GameObject lightningProjectile;

    public GameObject retical;

    public Left_Hand_Tracker.state currState;

    MLHandKeyPose[] gestures;

    void Start()
    {
        MLHands.Start();

        gestures = new MLHandKeyPose[1];
        gestures[0] = MLHandKeyPose.OpenHand;

        MLHands.KeyPoseManager.EnableKeyPoses(gestures, true, false);

        currState = Left_Hand_Tracker.state.NONE;
    }

    void Update()
    {
        transform.position = MLHands.Right.Center;
        checkState();

        if (GetGesture(MLHands.Right, MLHandKeyPose.OpenHand) && currState != Left_Hand_Tracker.state.NONE) fireProjectile();
    }

    private void OnDestroy()
    {
        MLHands.Stop();
    }

    void fireProjectile()
    {

        GameObject projectile;

        if (currState == Left_Hand_Tracker.state.LIGHTNING)
        {
            projectile = Instantiate(lightningProjectile);
            projectile.transform.position = retical.GetComponent<Retical_Handler>().reticalTransform.position;
            projectile.AddComponent<Rigidbody>();
            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.position * 5f);
        }
        else
        {
            return;
        }




    }

    void checkState()
    {
        if (leftHand.GetComponent<Left_Hand_Tracker>().currState == Left_Hand_Tracker.state.LIGHTNING)
        {
            if (currState != Left_Hand_Tracker.state.LIGHTNING)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(lightningObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                currState = Left_Hand_Tracker.state.LIGHTNING;
            }
        }
        else
        {
            if (transform.childCount > 0)
            {
                Transform tempTran = transform.GetChild(0);
                tempTran.parent = null;
                Destroy(tempTran.gameObject);
            }

            currState = Left_Hand_Tracker.state.NONE;
        }
    }

    private bool GetGesture(MLHand hand, MLHandKeyPose type)
    {
        if (hand != null)
        {
            if (hand.KeyPose == type)
            {
                if (hand.KeyPoseConfidence > 0.9f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
