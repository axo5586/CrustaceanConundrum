using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockY : MonoBehaviour {

    float staticX;
    float startPositionX;
    // Use this for initialization
    void Start ()
    {
        startPositionX = transform.position.x;
        staticX = startPositionX;
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        //end case stop from going over border
        float x = transform.position.x;
        float y = transform.position.y;
        if (y > 4.5f) { y = 4.5f; rigidbody.velocity = Vector3.zero; }
        if (y < -4.5f) { y = -4.5f; rigidbody.velocity = Vector3.zero; }
        if (x < -7.0f) { x = -7.0f; rigidbody.velocity = Vector3.zero; }
        if (x > 7.0f) { x = 7.0f; rigidbody.velocity = Vector3.zero; }

        //stop from going out of y axis
        if (x > staticX)
        {
            transform.position = new Vector3(staticX, transform.position.y, transform.position.z);
            rigidbody.velocity = Vector3.zero;
        }

        //stop from going out of y axis
        if (x < staticX)
        {
            transform.position = new Vector3(staticX, transform.position.y, transform.position.z);
            rigidbody.velocity = Vector3.zero;
        }

        rigidbody.velocity = Vector3.zero;
    }
}
