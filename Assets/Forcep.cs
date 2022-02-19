using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Forcep : MonoBehaviour
{
    // a reference to the action
    public SteamVR_Action_Single Squeeze2;
    //public SteamVR_Action_Single SqueezeAction;
    // a reference to the hand
    public SteamVR_Input_Sources handType;

    public GameObject forcep1;
    public GameObject forcep2;
    public Plane planeTest;

    public Transform pivot1;
    public Transform pivot2;

    public static bool collided = false;

    private Quaternion originalPosition;
    private Quaternion originalPosition2;
    private float previousAxis = 0;
    private Vector3 rotateAmount1, rotateAmount2;
    private Vector3 previousPivotPosition;

    private bool vr = true;
    private bool opened = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = forcep1.transform.localRotation;
        originalPosition2 = forcep2.transform.localRotation;

        //planeTest = new Plane(new Vector3(1, 0, 1), new Vector3(0, 0, 0));
        //Squeeze.AddOnAxisListener(GripSqueezed, handType);

        //Squeeze.AddOnChangeListener(GripSqueezed, handType);
    }

    /*private void GripSqueezed(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta)
    {
        Debug.Log("Grip changed");
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            vr = false;
        }

        if (vr)
        {
            float squeezeValue = Squeeze2.GetAxis(SteamVR_Input_Sources.LeftHand);

            if (collided)
            {
                if (squeezeValue > previousAxis) return;
            }

            forcep1.transform.RotateAround(pivot1.position, forcep1.transform.forward * -1, (5 * previousAxis));
            forcep2.transform.RotateAround(pivot2.position, forcep2.transform.forward, (5 * previousAxis));

            rotateAmount1 = forcep1.transform.forward;
            rotateAmount2 = forcep2.transform.forward * -1;

            forcep1.transform.RotateAround(pivot1.position, rotateAmount1, 5 * squeezeValue);// + 25); // Input.GetAxis("Testing2") + 25);
            forcep2.transform.RotateAround(pivot2.position, rotateAmount2, 5 * squeezeValue);// + 25); // Input.GetAxis("Testing2") + 25);
            previousAxis = squeezeValue;
        }

        else
        {
            if (Input.GetKeyDown("space"))
            {
                //Debug.Log("space key was pressed");
                    float squeezeValue = 1;

                if (opened)
                {
                    forcep1.transform.RotateAround(pivot1.position, forcep1.transform.forward * -1, (5 * squeezeValue));
                    forcep2.transform.RotateAround(pivot2.position, forcep1.transform.forward , (5 * squeezeValue));
                }

                else
                {
                    rotateAmount1 = forcep1.transform.forward;
                    rotateAmount2 = forcep1.transform.forward * -1;

                    forcep1.transform.RotateAround(pivot1.position, rotateAmount1, 5 * squeezeValue);// + 25); // Input.GetAxis("Testing2") + 25);
                    forcep2.transform.RotateAround(pivot2.position, rotateAmount2, 5 * squeezeValue);// + 25); // Input.GetAxis("Testing2") + 25);                

                }

                opened = !opened;

            }
        }


    }
}
