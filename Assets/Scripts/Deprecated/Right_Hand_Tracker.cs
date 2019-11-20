using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Right_Hand_Tracker : MonoBehaviour
{
    /*
    #region Variables
    public GameObject airObject;
    public GameObject lightningObject;
    public GameObject fireObject;
    public GameObject waterObject;
    public GameObject earthObject;

    MLHandKeyPose[] gestures;
    #endregion

    #region Unity Functions
    void Start()
    {
        Hand_Handler.rightHandState = Hand_Handler.state.NONE;

        gestures = new MLHandKeyPose[5];
        gestures[0] = MLHandKeyPose.C;
        gestures[1] = MLHandKeyPose.L;
        gestures[2] = MLHandKeyPose.OpenHandBack;
        gestures[3] = MLHandKeyPose.Ok;
        gestures[4] = MLHandKeyPose.Fist;

        MLHands.Start();

        MLHands.KeyPoseManager.EnableKeyPoses(gestures, true, false);
    }

    private void OnDestroy()
    {
        MLHands.Stop();
    }

    void Update()
    {
        transform.position = MLHands.Right.Center;
        checkState();
    }
    #endregion

    #region User Defined Functions
    void checkState()
    {
        if (GetGesture(MLHands.Right, MLHandKeyPose.C))
        {
            if (Hand_Handler.rightHandState != Hand_Handler.state.AIR)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(airObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                Hand_Handler.rightHandState = Hand_Handler.state.AIR;
            }
        }
        else if (GetGesture(MLHands.Right, MLHandKeyPose.L))
        {
            if (Hand_Handler.rightHandState != Hand_Handler.state.LIGHTNING)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(lightningObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                Hand_Handler.rightHandState = Hand_Handler.state.LIGHTNING;
            }
        }
        else if (GetGesture(MLHands.Right, MLHandKeyPose.OpenHandBack))
        {
            if (Hand_Handler.rightHandState != Hand_Handler.state.FIRE)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(fireObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                Hand_Handler.rightHandState = Hand_Handler.state.FIRE;
            }
        }
        else if (GetGesture(MLHands.Right, MLHandKeyPose.Ok))
        {
            if (Hand_Handler.rightHandState != Hand_Handler.state.WATER)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(waterObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                Hand_Handler.rightHandState = Hand_Handler.state.WATER;
            }
        }
        else if (GetGesture(MLHands.Right, MLHandKeyPose.Fist))
        {
            if (Hand_Handler.rightHandState != Hand_Handler.state.EARTH)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(earthObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                Hand_Handler.rightHandState = Hand_Handler.state.EARTH;
            }
        }
        else
        {
            if (Hand_Handler.rightHandState != Hand_Handler.state.NONE)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Hand_Handler.rightHandState = Hand_Handler.state.NONE;
            }
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
    #endregion
    */
}