using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSound : MonoBehaviour
{
    public GameObject backgroundMusic;
    public Footsteps footstepsScript;
    public bool playerIsMoving;
    public bool playedOnce;
    public bool colliding;
    public FMOD.Studio.EventInstance wallCollision;
    private FMOD.Studio.STOP_MODE mode;
    
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GameObject.Find("background-music");
        footstepsScript = backgroundMusic.GetComponent<Footsteps>();
        wallCollision = FMODUnity.RuntimeManager.CreateInstance("event:/Interactables/wall-collision");
        colliding = false;
        playedOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(footstepsScript.speedParam != 0.0f)
        {
            playerIsMoving = true;
        }
        else
        {
            playerIsMoving = false;
        }

        if (colliding && playerIsMoving)
        {
            if (playedOnce == false)
            {
                wallCollision.start();
                playedOnce = true;
            }
        }

        if (playerIsMoving == false)
        {
            wallCollision.stop(mode);
            playedOnce = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "crabX" || collision.gameObject.name == "crabY")
        {
            colliding = true;

            if(playerIsMoving)
            {
                wallCollision.start();
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
        wallCollision.stop(mode);
    }
}
