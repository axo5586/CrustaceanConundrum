using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputSound;
    public bool playerIsMoving;
    public bool leftShiftPressed;
    public float secondsPassed;
    public PlayerController[] players;

   

    public FMOD.Studio.EventInstance footsteps;
    public FMOD.Studio.EventDescription footstepsDescription;
    public FMOD.Studio.PARAMETER_DESCRIPTION pd;
    public FMOD.Studio.PARAMETER_ID pID;

    public float speedParam;



    // Start is called before the first frame update
    void Start()
    {
        speedParam = 0.0f;
        //InvokeRepeating("CallFootsteps", 0, speedParam);
        footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/Character/gravel-walk-param");
        //footsteps.start();
        footsteps.setParameterByName("speed", speedParam);
        //footstepsDescription = FMODUnity.RuntimeManager.GetEventDescription("event:/Character/gravel-walk");
        //footstepsDescription.getParameterDescriptionByName("speed", out pd);
        //pID = pd.id;
       

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
      
        if(speedParam == 1f)
        {
            if (secondsPassed >= .2f)
            {
                CallFootsteps();
                secondsPassed = 0.0f;
            }
        }
        if (speedParam == .6f)
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
        if (playerIsMoving == true)
        {

            //FMODUnity.RuntimeManager.PlayOneShot("event:/Character/gravel-walk");
            footsteps.start();
        }
        if(playerIsMoving == false)
        {
            //footsteps.stop(fade)
            speedParam = 0f;
        }
    }

    void ParamChange()
    {
        if(leftShiftPressed == true)
        {
            speedParam = 1f;
        }
        else if (playerIsMoving)
        {
            speedParam = 0.6f;
        }

        footsteps.setParameterByName("speed", speedParam);
    }

    void OnDisable()
    {
        playerIsMoving = false;
    }
}
