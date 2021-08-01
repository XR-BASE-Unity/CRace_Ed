using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform centerOfMass;
    
    public WheelCollider wheelColliderFrontLeft;
    public WheelCollider wheelColliderFrontRight;
    public WheelCollider wheelColliderRearLeft;
    public WheelCollider wheelColliderRearRight;

    public Transform wheelFrontLeft;
    public Transform wheelFrontRight;
    public Transform wheelRearLeft;
    public Transform wheelRearRight;

    public float motorTorque;
    public float maxSteer;
    public float brakeTorque;
    private Rigidbody center;

    public Light leftSmall;
    public Light leftBig;
    public Light rightSmall;
    public Light rightBig;

    public Light frontL;
    public Light frontR;

    public ParticleSystem brakeLeft;
    public ParticleSystem brakeRight;

    public AudioSource engineSound;
    private void Start()
    {
        center = GetComponent<Rigidbody>();
        center.centerOfMass = centerOfMass.localPosition;
        brakeLeft.Stop();
        brakeRight.Stop();
    }
    void FixedUpdate()
    {
        wheelColliderRearLeft.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderRearRight.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderFrontLeft.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderFrontRight.motorTorque = Input.GetAxis("Vertical") * motorTorque;

        engineSound.pitch = 1f + 1.5f * wheelColliderRearLeft.motorTorque/motorTorque;

    }

    private void Update()
    {
        wheelColliderFrontRight.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
        wheelColliderFrontLeft.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
    
        wheelColliderRearLeft.brakeTorque = Input.GetAxis("Jump") * brakeTorque;
        wheelColliderRearRight.brakeTorque = Input.GetAxis("Jump") * brakeTorque;


        if (Input.GetButtonDown("Jump"))
        {
            leftSmall.intensity = 3;
            leftBig.intensity = 3;
            rightBig.intensity = 3;
            rightSmall.intensity = 3;
            if (wheelColliderFrontLeft.motorTorque > 10)
            {
                brakeLeft.Play();
                brakeRight.Play();
            }

        }
        if (Input.GetButtonUp("Jump"))
        {
            brakeLeft.Stop();
            brakeRight.Stop();
            if (frontL.intensity == 0)
            {
                leftSmall.intensity = 0;
                leftBig.intensity = 0;
                rightBig.intensity = 0;
                rightSmall.intensity = 0;
            }
            if (frontL.intensity > 0)
            {
                leftSmall.intensity = 1;
                leftBig.intensity = 1;
                rightBig.intensity = 1;
                rightSmall.intensity = 1;
            }
            

            return;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (frontL.intensity < 3)
            {
                frontL.intensity = 3;
                frontR.intensity = 3;
                leftSmall.intensity = 1;
                leftBig.intensity = 1;
                rightBig.intensity = 1;
                rightSmall.intensity = 1;

                return;
            }
            if (frontL.intensity > 0)
            {
                frontL.intensity = 0;
                frontR.intensity = 0;
                leftSmall.intensity = 0;
                leftBig.intensity = 0;
                rightBig.intensity = 0;
                rightSmall.intensity = 0;

                return;
            }

        }
       
        //wheelColliderFrontLeft.brakeTorque = Input.GetAxis("Jump") * brakeTorque;
        //wheelColliderFrontRight.brakeTorque = Input.GetAxis("Jump") * brakeTorque;
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        wheelColliderFrontLeft.GetWorldPose(out pos, out rot);
        wheelFrontLeft.position = pos;
        wheelFrontLeft.rotation = rot;

        wheelColliderFrontRight.GetWorldPose(out pos, out rot);
        wheelFrontRight.position = pos;
        wheelFrontRight.rotation = rot * Quaternion.Euler(0,0,0);

        wheelColliderRearLeft.GetWorldPose(out pos, out rot);
        wheelRearLeft.position = pos;
        wheelRearLeft.rotation = rot;

        wheelColliderRearRight.GetWorldPose(out pos, out rot);
        wheelRearRight.position = pos;
        wheelRearRight.rotation = rot * Quaternion.Euler(0, 0, 0);

    }


}
