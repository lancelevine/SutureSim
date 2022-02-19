using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class NeedleDriver : MonoBehaviour
{
    // a reference to the action
    public SteamVR_Action_Single Squeeze;
    //public SteamVR_Action_Single SqueezeAction;
    // a reference to the hand
    public SteamVR_Input_Sources handType;

    public GameObject scissor1;
    public GameObject scissor2;
    public Plane planeTest;

    public Transform pivot;

    private Quaternion originalPosition;
    private Quaternion originalPosition2;
    private float previousAxis = 0;
    private Vector3 rotateAmount1, rotateAmount2;
    private Vector3 previousPivotPosition;

    private bool vr = true;
    private bool opened = false;
    public static bool collided = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = scissor1.transform.localRotation;
        originalPosition2 = scissor2.transform.localRotation;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            vr = false;
        }

        if (vr)
        {

            float squeezeValue = Squeeze.GetAxis(SteamVR_Input_Sources.RightHand);

            if (!collided)
            {
                scissor1.transform.RotateAround(pivot.position, scissor1.transform.forward, (25 * previousAxis));
                scissor2.transform.RotateAround(pivot.position, scissor1.transform.forward * -1, (25 * previousAxis));

                rotateAmount1 = scissor1.transform.forward * -1;
                rotateAmount2 = scissor1.transform.forward;

                scissor1.transform.RotateAround(pivot.position, rotateAmount1, 25 * squeezeValue);// + 25); // Input.GetAxis("Testing2") + 25);
                scissor2.transform.RotateAround(pivot.position, rotateAmount2, 25 * squeezeValue);// + 25); // Input.GetAxis("Testing2") + 25);
                previousAxis = squeezeValue;
            }
            else
            {
                if (squeezeValue > previousAxis)
                {
                    scissor1.transform.RotateAround(pivot.position, scissor1.transform.forward, (25 * previousAxis));
                    scissor2.transform.RotateAround(pivot.position, scissor1.transform.forward * -1, (25 * previousAxis));

                    rotateAmount1 = scissor1.transform.forward * -1;
                    rotateAmount2 = scissor1.transform.forward;

                    scissor1.transform.RotateAround(pivot.position, rotateAmount1, 25 * squeezeValue);// + 25); // Input.GetAxis("Testing2") + 25);
                    scissor2.transform.RotateAround(pivot.position, rotateAmount2, 25 * squeezeValue);// + 25); // Input.GetAxis("Testing2") + 25);
                    previousAxis = squeezeValue;
                }
            }
        }

        else
        {
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("space key was pressed");
                    float squeezeValue = 1;

                if (opened)
                {
                    scissor1.transform.RotateAround(pivot.position, scissor1.transform.forward, (25 * squeezeValue));
                    scissor2.transform.RotateAround(pivot.position, scissor1.transform.forward * -1, (25 * squeezeValue));
                }

                else
                {
                    rotateAmount1 = scissor1.transform.forward * -1;
                    rotateAmount2 = scissor1.transform.forward;

                    scissor1.transform.RotateAround(pivot.position, rotateAmount1, 25 * squeezeValue);// + 25); // Input.GetAxis("Testing2") + 25);
                    scissor2.transform.RotateAround(pivot.position, rotateAmount2, 25 * squeezeValue);// + 25); // Input.GetAxis("Testing2") + 25);                

                }

                opened = !opened;

            }
        }


    }
}
