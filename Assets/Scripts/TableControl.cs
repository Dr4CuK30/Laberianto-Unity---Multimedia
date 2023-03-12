using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableControl : MonoBehaviour
{
    static public Boolean blockMovement = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && !blockMovement)
        {
            if (Input.GetKey(KeyCode.A) & transform.rotation.z < 0.2)
            {
                transform.Rotate(new Vector3(0, 0, 30f) * Time.deltaTime * 1.5f);
            }
            else if (Input.GetKey(KeyCode.D) & transform.rotation.z > -0.2)
            {
                transform.Rotate(new Vector3(0, 0, -30f) * Time.deltaTime * 1.5f);
            }
            if (Input.GetKey(KeyCode.S) & transform.rotation.x > -0.2 )
            {
                transform.Rotate(new Vector3(-30f, 0, 0) * Time.deltaTime * 1.5f);
            }
            else if (Input.GetKey(KeyCode.W) & transform.rotation.x < 0.2)
            {
                transform.Rotate(new Vector3(30f, 0, 0) * Time.deltaTime * 1.5f);
            }
        }
        else
        {
            if (transform.rotation.z > 0.00001) {
                transform.Rotate(new Vector3(0, 0, -30f) * Time.deltaTime * 1.5f);
            } else if (transform.rotation.z < -0.00001)
            {
                transform.Rotate(new Vector3(0, 0, 30f) * Time.deltaTime * 1.5f);
            }
            if (transform.rotation.x < -0.00001f)
            {
                transform.Rotate(new Vector3(30f, 0, 0) * Time.deltaTime * 1.5f);
            } else if (transform.rotation.x > 0.00001f)
            {
                transform.Rotate(new Vector3(-30f, 0, 0) * Time.deltaTime * 1.5f);
            }
            if (transform.rotation.y > 0.00001)
            {
                transform.Rotate(new Vector3(0, -30f, 0) * Time.deltaTime * 1.5f);
            }
            else if (transform.rotation.y < -0.00001)
            {
                transform.Rotate(new Vector3(0, 30f, 0) * Time.deltaTime * 1.5f);
            }

        }

    }
}
