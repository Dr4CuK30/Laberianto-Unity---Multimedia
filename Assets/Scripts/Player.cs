using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad = 1;
    new Rigidbody rigidbody;
    Vector3 initialPosition;
    int monedas = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        rigidbody.AddForce(new Vector3(horizontal, 0, vertical) * velocidad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("goal"))
        {
            Debug.Log("Ganaste!!");
        }
        else if (other.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            monedas++;
        }
        else if (other.CompareTag("enemy"))
        {
            rigidbody.MovePosition(initialPosition);
            rigidbody.velocity = Vector3.zero;
        }
    }
}
