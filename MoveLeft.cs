using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Bird");
    }

    // Update is called once per frame
    void Update()
    {
        bool Moving = Player.GetComponent<PlayerMovement>().Play;
        if (Moving)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        if(transform.position.x <= -25)
        {
            Destroy(gameObject);
        }
    }
}
