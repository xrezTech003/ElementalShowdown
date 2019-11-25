using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Right_Hand_Tracker : MonoBehaviour
{

    #region Variables
    public enum state { NONE, AIR, LIGHTNING, FIRE, WATER, EARTH, SMOKE };
    public state currState;

    public GameObject Camera;

    public GameObject airObject;
    public GameObject lightningObject;
    public GameObject fireObject;
    public GameObject waterObject;
    public GameObject earthObject;

    public GameObject lightningProjectile;
    public GameObject fireProjectile;
    public GameObject waterProjectile;
    public GameObject airProjectile;
    public GameObject earthProjectile;

    private int interval;
    private int currTime;
    private float speed;

    MLHandKeyPose[] gestures;
    #endregion

    #region Unity Functions
    void Start()
    {
        currState = state.NONE;

        gestures = new MLHandKeyPose[5];
        gestures[0] = MLHandKeyPose.Finger;
        gestures[1] = MLHandKeyPose.L;
        gestures[2] = MLHandKeyPose.OpenHand;
        gestures[3] = MLHandKeyPose.Ok;
        gestures[4] = MLHandKeyPose.Fist;

        MLHands.Start();

        MLHands.KeyPoseManager.EnableKeyPoses(gestures, true, false);

        interval = 30;
        currTime = interval;
        speed = 200f;
    }

    private void OnDestroy()
    {
        MLHands.Stop();
    }

    void Update()
    {
        transform.position = MLHands.Right.Center;
        checkState();
        if (currState != state.NONE) fireElement();
    }
    #endregion

    #region User Defined Functions
    void fireElement()
    {
        GameObject projectile;

        if (currTime >= interval)
        {
            if (currState == state.LIGHTNING)
            {
                projectile = Instantiate(lightningProjectile, transform);
            }
            else if (currState == state.FIRE)
            {
                projectile = Instantiate(fireProjectile, transform);
            }
            else if (currState == state.WATER)
            {
                projectile = Instantiate(waterProjectile, transform);
            }
            else if (currState == state.AIR)
            {
                projectile = Instantiate(airProjectile, transform);
            }
            else if (currState == state.EARTH)
            {
                projectile = Instantiate(earthProjectile, transform);
            }
            else
            {
                return;
            }

            projectile.transform.position = getReticalPosition();
            projectile.AddComponent<Rigidbody>();
            projectile.GetComponent<Rigidbody>().useGravity = false;
            projectile.GetComponent<Rigidbody>().AddRelativeForce(projectile.transform.localPosition * speed);
            projectile.transform.parent = null;

            currTime = 0;
        }
        else
        {
            currTime++;
        }
    }

    Vector3 getReticalPosition()
    {
        Vector3 tempVec;

        Vector3 slope = transform.position - Camera.transform.position;
        tempVec = transform.position + slope * 1.5f;

        return tempVec;
    }

    void checkState()
    {
        if (GetGesture(MLHands.Right, MLHandKeyPose.Finger))
        {
            if (currState != state.AIR)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(airObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                currState = state.AIR;
            }
        }
        else if (GetGesture(MLHands.Right, MLHandKeyPose.L))
        {
            if (currState != state.LIGHTNING)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(lightningObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                currState = state.LIGHTNING;
            }
        }
        else if (GetGesture(MLHands.Right, MLHandKeyPose.OpenHand))
        {
            if (currState != state.FIRE)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(fireObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                currState = state.FIRE;
            }
        }
        else if (GetGesture(MLHands.Right, MLHandKeyPose.Ok))
        {
            if (currState != state.WATER)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(waterObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                currState = state.WATER;
            }
        }
        else if (GetGesture(MLHands.Right, MLHandKeyPose.Fist))
        {
            if (currState != state.EARTH)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(earthObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                currState = state.EARTH;
            }
        }
        else
        {
            if (currState != state.NONE)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                currState = state.NONE;
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
}