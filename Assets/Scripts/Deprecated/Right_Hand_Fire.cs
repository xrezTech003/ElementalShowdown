using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Right_Hand_Fire : MonoBehaviour
{
    public GameObject leftHand;

    public GameObject lightningObject;
    public GameObject fireObject;
    public GameObject waterObject;
    public GameObject airObject;
    public GameObject earthObject;

    public GameObject lightningProjectile;
    public GameObject fireProjectile;
    public GameObject waterProjectile;
    public GameObject airProjectile;
    public GameObject earthProjectile;

    public GameObject retical;

    public Left_Hand_Tracker.state currState;

    private MLHandKeyPose[] gestures;

    private int interval;
    private int currTime;
    private float speed;

    void Start()
    {
        MLHands.Start();

        gestures = new MLHandKeyPose[1];
        gestures[0] = MLHandKeyPose.OpenHand;

        MLHands.KeyPoseManager.EnableKeyPoses(gestures, true, false);

        currState = Left_Hand_Tracker.state.NONE;

        interval = 30;
        currTime = interval;
        speed = 200f;
    }

    void Update()
    {
        transform.position = MLHands.Right.Center;
        checkState();

        if (GetGesture(MLHands.Right, MLHandKeyPose.OpenHand) && currState != Left_Hand_Tracker.state.NONE) fireElement();
        else if (currTime != interval) currTime = interval;
    }

    private void OnDestroy()
    {
        MLHands.Stop();
    }

    void fireElement()
    {

        GameObject projectile;

        if (currTime >= interval)
        {
            if (currState == Left_Hand_Tracker.state.LIGHTNING)
            {
                projectile = Instantiate(lightningProjectile, transform);
            }
            else if (currState == Left_Hand_Tracker.state.FIRE)
            {
                projectile = Instantiate(fireProjectile, transform);
            }
            else if (currState == Left_Hand_Tracker.state.WATER)
            {
                projectile = Instantiate(waterProjectile, transform);
            }
            else if (currState == Left_Hand_Tracker.state.AIR)
            {
                projectile = Instantiate(airProjectile, transform);
            }
            else if (currState == Left_Hand_Tracker.state.EARTH)
            {
                projectile = Instantiate(earthProjectile, transform);
            }
            else
            {
                return;
            }

            projectile.transform.position = retical.GetComponent<Retical_Handler>().reticalTransform.position;
            //projectile.transform.localRotation = Quaternion.Euler(90, 0, 0);
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
        else if (leftHand.GetComponent<Left_Hand_Tracker>().currState == Left_Hand_Tracker.state.FIRE)
        {
            if (currState != Left_Hand_Tracker.state.LIGHTNING)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(fireObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                currState = Left_Hand_Tracker.state.FIRE;
            }
        }
        else if (leftHand.GetComponent<Left_Hand_Tracker>().currState == Left_Hand_Tracker.state.WATER)
        {
            if (currState != Left_Hand_Tracker.state.LIGHTNING)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(waterObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                currState = Left_Hand_Tracker.state.WATER;
            }
        }
        else if (leftHand.GetComponent<Left_Hand_Tracker>().currState == Left_Hand_Tracker.state.AIR)
        {
            if (currState != Left_Hand_Tracker.state.LIGHTNING)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(airObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                currState = Left_Hand_Tracker.state.AIR;
            }
        }
        else if (leftHand.GetComponent<Left_Hand_Tracker>().currState == Left_Hand_Tracker.state.EARTH)
        {
            if (currState != Left_Hand_Tracker.state.LIGHTNING)
            {
                if (transform.childCount > 0)
                {
                    Transform tempTran = transform.GetChild(0);
                    tempTran.parent = null;
                    Destroy(tempTran.gameObject);
                }

                Instantiate(earthObject, transform);
                transform.GetChild(0).localPosition = Vector3.zero;

                currState = Left_Hand_Tracker.state.EARTH;
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
