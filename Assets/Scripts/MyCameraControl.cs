using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraControl : MonoBehaviour
{

    public float changeAngle;
    public Vector3 camStartPos;
        
    void Update()
    {
        
        if (Input.GetAxis("Horizontal") > 0)
        {

            transform.localPosition = camStartPos + new Vector3(changeAngle * Input.GetAxis("Horizontal"), 0, 0);


        }
        if (Input.GetAxis("Horizontal") < 0)
        {

            transform.localPosition = camStartPos + new Vector3 (changeAngle * Input.GetAxis("Horizontal"), 0,0);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {

            transform.localPosition = camStartPos;
        }
    }
}
