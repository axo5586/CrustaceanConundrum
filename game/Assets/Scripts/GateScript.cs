using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateScript : MonoBehaviour
{
    private bool opened;
    public bool gateOpenState;
    public bool newGateState;
    FMOD.Studio.EventInstance openSound;


    [SerializeField]
    private string nextLevel;
    [SerializeField]
    private Sprite OpenedSprite;
    [SerializeField]
    private Sprite NotOpenedSprite;
    

    public bool Opened
    {
        get
        {
            return opened;
        }
        private set
        {
            opened = value;
            
            //playedOnce = !playedOnce;
        }
    }
    [SerializeField]
    public ButtonScript[] Triggers;

	// Use this for initialization
	void Start () 
    {
        gateOpenState = false;
        openSound = FMODUnity.RuntimeManager.CreateInstance("event:/Interactables/gate-open");
    }
	
	// Update is called once per frame
	void Update ()
    {
        opened = Triggers.All(button => button.Pressed);
        GetComponent<SpriteRenderer>().sprite = gateOpenState ? OpenedSprite : NotOpenedSprite;
        newGateState = opened;
        if(gateOpenState != newGateState)
        {
            playGateOpen();
            gateOpenState = newGateState;
        }
        if ((gateOpenState == true) != newGateState)
        {
            playGateClose();
            gateOpenState = newGateState;
        }

    }

    void playGateOpen()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Interactables/gate-open", transform.position);
        //openSound.start();
        //openSound.stop();
    }

    void playGateClose()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Interactables/gate-close", transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Opened && nextLevel == "")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (Opened)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Opened && nextLevel == "")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (Opened)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
