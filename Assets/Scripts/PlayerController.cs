using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posOffset = gameObject.transform.position;
        Vector3 rotOffset = Vector3.zero;
        // Time.deltaTime
        if (Input.GetKey(KeyCode.W)) 
        {
            posOffset += new Vector3(0f, 0f, Time.deltaTime * speed);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            posOffset -= new Vector3(0f, 0f, Time.deltaTime * speed);
        }

        gameObject.transform.position = posOffset;

        if (Input.GetKey(KeyCode.A))

        {
            gameObject.transform.Rotate(new Vector3(0f, -Time.deltaTime * angle, 0f));
        }
        if (Input.GetKey(KeyCode.D))

        {
            gameObject.transform.Rotate(new Vector3(0f, Time.deltaTime * angle, 0f));
        }
    }
}
