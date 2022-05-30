using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpSpeed;
    private Rigidbody rb;
    public GameObject obs;
    public bool Play;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Play = true;
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("spawnObs", 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Play == true)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    public void spawnObs()
    {
        if (Play)
        {
            float randomPos = Random.Range(-3, 6);
            Instantiate(obs, new Vector3(25, randomPos, 0), Quaternion.identity);
        }  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision happened");
            Play = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        score++;
        Debug.Log("Score: " + score);        
    }
}
