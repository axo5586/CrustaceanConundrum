using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockX : MonoBehaviour
{
    float staticY;
    float startPositionY;
    // Use this for initialization
    void Start ()
    {
        startPositionY = transform.position.y;
        staticY = startPositionY;
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        //Debug.Log("Static positionY = " + staticY);

        //end case stop from going over border
        float x = transform.position.x;
        float y = transform.position.y;
        if (y > 4.5f) { y = 4.5f; rigidbody.velocity = Vector3.zero; }
        if (y < -4.5f) { y = -4.5f; rigidbody.velocity = Vector3.zero; }
        if (x < -7.0f) { x = -7.0f; rigidbody.velocity = Vector3.zero; }
        if (x > 7.0f) { x = 7.0f; rigidbody.velocity = Vector3.zero; }

        //Debug.Log("x: " + x + " y: " + y);


        //stop from going out of x axis
        if (y < staticY)
        {
            transform.position = new Vector3(transform.position.x, staticY, transform.position.z);
            rigidbody.velocity = Vector3.zero;
        }

        //stop from going out of x axis
        if (y > staticY)
        {
            transform.position = new Vector3(transform.position.x, staticY, transform.position.z);
            rigidbody.velocity = Vector3.zero;
        }

        /*if (rigidbody.velocity != Vector2.zero)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/move-object", transform.position);
        }*/

        rigidbody.velocity = Vector3.zero;

        
    }


}
