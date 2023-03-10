using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public int vidas = 3;
    public Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < -20)
        {
            vidas--;
            print(vidas);
            rb.angularVelocity = Vector3.zero;
            rb.MovePosition(initialPosition);
        }
    }
}
