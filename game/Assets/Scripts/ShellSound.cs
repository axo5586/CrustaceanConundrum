using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSound : MonoBehaviour
{
    public GameObject backgroundMusic;
    public Footsteps footstepsScript;
    public bool playerIsMoving;
    public bool playedOnce;
    public bool colliding;
    public FMOD.Studio.EventInstance moveObject;
    private FMOD.Studio.STOP_MODE mode;
    public GameObject shell;
    public bool shellIsMoving;

    //public float secondsPassed;


    public Vector3 previous;
    public float velocity;

    //velocity

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GameObject.Find("background-music");
        footstepsScript = backgroundMusic.GetComponent<Footsteps>();
        moveObject = FMODUnity.RuntimeManager.CreateInstance("event:/Character/move-object");
        colliding = false;
        playedOnce = false;
        shell = this.gameObject;
        shellIsMoving = false;
        //secondsPassed = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
        previous = transform.position;

        if(velocity != 0.0f)
        {
            shellIsMoving = true;
        }
        else
        {
            shellIsMoving = false;
        }

        if (footstepsScript.speedParam != 0.0f)
        {
            playerIsMoving = true;
        }
        else
        {
            playerIsMoving = false;
        }

        /*if(shellIsMoving)
        {
            //incrementTime();
        }*/


        if (colliding && playerIsMoving && shellIsMoving)
        {
            if (playedOnce == false)
            {
                moveObject.start();
                playedOnce = true;
            }
        }

        if (shellIsMoving == false)
        {
            moveObject.stop(mode);
            playedOnce = false;
        }
    }

    void incrementTime()
    {
        //secondsPassed += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "crabX" || collision.gameObject.name == "crabY")
        {
            colliding = true;
            if(playerIsMoving == true)
            {
                moveObject.start();
            }
            
        }
        else
        {
            colliding = false;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        colliding = false;
        moveObject.stop(mode);
    }
}
