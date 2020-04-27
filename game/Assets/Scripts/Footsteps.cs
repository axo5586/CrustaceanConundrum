using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputSound;
    public bool playerIsMoving;
    public bool playerXIsMoving;
    public bool playerYIsMoving;
    public bool leftShiftPressed;
    public float secondsPassed;
    public PlayerController[] players;

   

    public FMOD.Studio.EventInstance footsteps;
    public FMOD.Studio.EventInstance footstepsY;
    public FMOD.Studio.EventDescription footstepsDescription;

    public float speedParam;
    public float speedParamY;



    // Start is called before the first frame update
    void Start()
    {
        speedParam = 0.0f;
        speedParamY = 0.0f;
        footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/Character/gravel-walk-param");
        footstepsY = FMODUnity.RuntimeManager.CreateInstance("event:/Character/gravel-walk-param-2");
        footsteps.setParameterByName("speed", speedParam); 
        footstepsY.setParameterByName("speed2", speedParamY);

    }


    // Update is called once per frame
    void Update()
    {
        //if moving horizontally, player is moving on X-axis.
        if (Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Horizontal") <= -0.01f)
        {
            playerXIsMoving = true;
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            playerXIsMoving = false;
        }

        //if moving vertically, player is moving on Y-axis.
        if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Vertical") <= -0.01f)
        {
            playerYIsMoving = true;
        }
        else if (Input.GetAxis("Vertical") == 0)
        {
            playerYIsMoving = false;
        }


        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].shiftPressed == true)
            {
                leftShiftPressed = true;
            }
            else
            {
                leftShiftPressed = false;
            }
        }

        incrementTime();
      
        if(speedParam == .8f || speedParamY == .7f)
        {
            if (secondsPassed >= .2f)
            {
                CallFootsteps();
                secondsPassed = 0.0f;
            }
        }
        if (speedParam == .5f || speedParamY == .4f)
        {
            if (secondsPassed >= .4f)
            {
                CallFootsteps();
                secondsPassed = 0.0f;
            }
        }

        ParamChange();


    }

    void incrementTime()
    {
        secondsPassed += Time.deltaTime;
    }

    void CallFootsteps()
    {
        if (playerXIsMoving == true)
        {
            footsteps.start();
        }
        else if (playerYIsMoving == false)
        {
            speedParam = 0f;
        }
        if (playerYIsMoving == true)
        {
            footstepsY.start();
        }
        else if (playerYIsMoving == false)
        {
            speedParamY = 0f;
        }

    }

    void ParamChange()
    {
        if(leftShiftPressed == true && playerXIsMoving == true)
        {
            speedParam = .8f;
        }
        else if (leftShiftPressed == false && playerXIsMoving == true)
        {
            speedParam = 0.5f;
        }
        if (leftShiftPressed == true && playerYIsMoving == true)
        {
            speedParamY = .7f;
        }
        else if (leftShiftPressed == false && playerYIsMoving == true)
        {
            speedParamY = 0.4f;
        }



        footsteps.setParameterByName("speed", speedParam);
        footstepsY.setParameterByName("speed2", speedParamY);
    }

    void OnDisable()
    {
        playerIsMoving = false;
        playerXIsMoving = false;
        playerYIsMoving = false;
    }

    void OnDestroy()
    {
        footsteps.setParameterByName("speed", 0.0f);
        footstepsY.setParameterByName("speed2", 0.0f);
    }
}
