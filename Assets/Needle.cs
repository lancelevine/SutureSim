using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Needle : MonoBehaviour
{
    public GameObject needleDriver, forceps;

    private bool isCollidedWithND1 = false, isCollidedWithND2 = false;
    private bool isCollidedWithF1 = false, isCollidedWithF2 = false;

    private GameObject collidedObject;

    private Rigidbody rigidBody;

    private enum needleStatus
    {
        empty,
        needleDriver,
        forceps
    };

    private needleStatus needleState = needleStatus.empty;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollidedWithND1 && isCollidedWithND2)
        {

            if(needleState == needleStatus.forceps || needleState == needleStatus.empty)
            {
                rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                this.transform.SetParent(needleDriver.transform);
                needleState = needleStatus.needleDriver;
                return;
            }

        }
        
        if (isCollidedWithF1 && isCollidedWithF2)
        {
            rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            this.transform.SetParent(forceps.transform);
            needleState = needleStatus.forceps;
            return;
        }
        if (isCollidedWithND1 && isCollidedWithND2 && needleState == needleStatus.needleDriver) return;

            rigidBody.constraints = RigidbodyConstraints.None;
            this.transform.SetParent(null);
            needleState = needleStatus.empty;
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Forceps.001")
        {
            isCollidedWithF1 = true;
        }
        if (collision.gameObject.name == "Forceps.002")
        {
            isCollidedWithF2 = true;
        }
        if (collision.gameObject.name == "Part01")
        {
            isCollidedWithND1 = true;
        }
        if (collision.gameObject.name == "Part 02")
        {
            isCollidedWithND2 = true;
        }

        NeedleDriver.collided = (isCollidedWithND1 && isCollidedWithND2);
        Forcep.collided = (isCollidedWithF1 && isCollidedWithF2);

        //Debug.Log("Needle collision" + collision.gameObject.name);
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Forceps.001")
        {
            isCollidedWithF1 = false;
        }
        if (collision.gameObject.name == "Forceps.002")
        {
            isCollidedWithF2 = false;
        }
        if (collision.gameObject.name == "Part01")
        {
            isCollidedWithND1 = false;
        }
        if (collision.gameObject.name == "Part 02")
        {
            isCollidedWithND2 = false;
        }

        NeedleDriver.collided = (isCollidedWithND1 && isCollidedWithND2);
        Forcep.collided = (isCollidedWithF1 && isCollidedWithF2);

        //Debug.Log("Needle collision exit" + collision.gameObject.name);
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        // Debug-draw all contact points and normals
        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
        }
    }
}
