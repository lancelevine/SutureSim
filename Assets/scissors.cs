using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scissors : MonoBehaviour
{
    public GameObject scissor1;
    public GameObject scissor2;
    public Transform pivot;

    private Quaternion originalPosition;
    private Quaternion originalPosition2;
    private float previousAxis = 0;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = scissor1.transform.localRotation;
        originalPosition2 = scissor2.transform.localRotation;
        //scissor2.transform.RotateAround(pivot.position, Vector3.forward, 50);
        //scissor1.transform.RotateAround(pivot.position, Vector3.back, 50);
    }

    // Update is called once per frame
    void Update()
    {
        //scissor2.transform.RotateAround(pivot.position, Vector3.forward, 5 * Time.deltaTime);
        //scissor1.transform.RotateAround(pivot.position, Vector3.back, 5 * Time.deltaTime);
        //Debug.Log(pivot.position);
        //Debug.Log((float)Input.GetAxis("Testing2"));
        //Debug.Log(originalPosition);
        //scissor1.transform.RotateAround(pivot.position, Vector3.back, 5 * Time.deltaTime);
        //scissor1.transform.
        if((float)Input.GetAxis("Testing2") != previousAxis)
        {
            /*Quaternion temp1 = originalPosition;
            Quaternion temp2 = originalPosition2;
            scissor1.transform.rotation = originalPosition;
            scissor2.transform.rotation = originalPosition2;*/

            //float amount = 25 * previousAxis + 25;
            scissor1.transform.RotateAround(pivot.position, Vector3.forward, (25 * previousAxis + 25));
            scissor2.transform.RotateAround(pivot.position, Vector3.back, (25 * previousAxis + 25));

            //float amount3 = 25 * Input.GetAxis("Testing2") + 25;
            //Debug.
            //Debug.Log(amount3);

            scissor1.transform.RotateAround(pivot.position, Vector3.back, 25 * Input.GetAxis("Testing2") + 25);
            scissor2.transform.RotateAround(pivot.position, Vector3.forward, 25 * Input.GetAxis("Testing2") + 25);
            previousAxis = Input.GetAxis("Testing2");
            //originalPosition = scissor1.transform.localRotation;
            //originalPosition2 = scissor2.transform.localRotation;
        }
    }
}
