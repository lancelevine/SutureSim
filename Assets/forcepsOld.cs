using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceps : MonoBehaviour
{
    public GameObject forcep1;
    public GameObject forcep2;
    public Transform pivot1, pivot2;

    private Quaternion originalPosition;
    private Quaternion originalPosition2;
    private float previousAxis = 0;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = forcep1.transform.localRotation;
        originalPosition2 = forcep2.transform.localRotation;
        //forcep2.transform.RotateAround(pivot.position, Vector3.forward, 50);
        //forcep1.transform.RotateAround(pivot.position, Vector3.back, 50);
    }

    // Update is called once per frame
    void Update()
    {
        //forcep2.transform.RotateAround(pivot.position, Vector3.forward, 5 * Time.deltaTime);
        //forcep1.transform.RotateAround(pivot.position, Vector3.back, 5 * Time.deltaTime);
        //Debug.Log(pivot.position);
        //Debug.Log((float)Input.GetAxis("Testing2"));
        //Debug.Log(originalPosition);
        //forcep1.transform.RotateAround(pivot.position, Vector3.back, 5 * Time.deltaTime);
        //forcep1.transform.
        if (Input.GetAxis("Testing2") != previousAxis)
        {
            /*Quaternion temp1 = originalPosition;
            Quaternion temp2 = originalPosition2;
            forcep1.transform.rotation = originalPosition;
            forcep2.transform.rotation = originalPosition2;*/

            //float amount = 25 * previousAxis + 25;
            forcep1.transform.RotateAround(pivot1.position, Vector3.forward, (25 * previousAxis + 25));
            forcep2.transform.RotateAround(pivot2.position, Vector3.back, (25 * previousAxis + 25));

            //float amount3 = 25 * Input.GetAxis("Testing2") + 25;
            //Debug.
            //Debug.Log(amount3);

            forcep1.transform.RotateAround(pivot1.position, Vector3.back, 25 * Input.GetAxis("Testing2") + 25);
            forcep2.transform.RotateAround(pivot2.position, Vector3.forward, 25 * Input.GetAxis("Testing2") + 25);
            previousAxis = Input.GetAxis("Testing2");
            //originalPosition = forcep1.transform.localRotation;
            //originalPosition2 = forcep2.transform.localRotation;
        }
    }
}
