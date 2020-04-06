using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputSound;
    bool playerIsMoving;
    public float walkingSpeed;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CallFootsteps", 0, walkingSpeed);
    }


    // Update is called once per frame
    void Update()
    {
        //if moving, player is moving.
        if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Vertical") <= -0.01f || Input.GetAxis("Horizontal") <= -0.01f)
        {
            playerIsMoving = true;
        }
        else if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0)
        {
            playerIsMoving = false;
        }
    }

    void CallFootsteps()
    {
        if (playerIsMoving == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot(inputSound);
        }
        if(playerIsMoving == false)
        {

        }
    }

    void OnDisable()
    {
        playerIsMoving = false;
    }
}
