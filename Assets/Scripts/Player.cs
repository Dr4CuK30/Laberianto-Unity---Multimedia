using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    private int vidas = 3;
    private int coins = 0;
    public Vector3 initialPosition;
    public Vector3 goalPosition = new Vector3(-16.74f, 0, 18.33f);
    public GameObject table;
    public GameObject goal;
    private bool hasWon = false;
    private bool isReappearing = false; 
    // Start is called before the first frame update
    void Start()
    {
        TableControl.blockMovement = true;
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        goalPosition.y = goal.transform.position.y;
        StartCoroutine(Reappear());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < -20 && !isReappearing)
        {
            StartCoroutine(Reappear());
            vidas--;
            if (vidas == 0)
            {
                SceneManager.LoadScene("StartMenu");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) {
            other.gameObject.SetActive(false);
            coins++;
        } else if (other.CompareTag("Goal") && !hasWon)
        {
            if(coins == 3)
            {
                hasWon = true;
                StartCoroutine(PassLevel());
            }
        }
    }

    private void stopBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        table.transform.rotation = Quaternion.identity;
    }

    private IEnumerator PassLevel()
    {
        TableControl.blockMovement = true;
        stopBall();
        rb.MovePosition(goalPosition);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level2");
    }

    private IEnumerator Reappear()
    {
        rb.MovePosition(new Vector3(0,10000,0));
        isReappearing = true;
        TableControl.blockMovement = true;
        yield return new WaitForSeconds(0.5f);
        stopBall();
        rb.MovePosition(initialPosition);
        TableControl.blockMovement = false;
        isReappearing = false;
    }
}
