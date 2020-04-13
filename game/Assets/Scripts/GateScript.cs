using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateScript : MonoBehaviour
{
    private bool opened;
    public bool gateOpenOnce;
    public bool gateCloseOnce;
    public bool openSceneGate;
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
            GetComponent<SpriteRenderer>().sprite = value ? OpenedSprite : NotOpenedSprite;
            //playedOnce = !playedOnce;
        }
    }
    [SerializeField]
    public ButtonScript[] Triggers;
	// Use this for initialization
	void Start () 
    {
        gateOpenOnce = false;
        gateCloseOnce = false;
        openSceneGate = true;
        openSound = FMODUnity.RuntimeManager.CreateInstance("event:/gate-open");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Opened = Triggers.All(button => button.Pressed);

        if (opened == true && !gateOpenOnce)
        {
            playGateOpen();
            gateOpenOnce = true;
        }

        if (opened == false && !gateCloseOnce)
        {
            playGateClose();
            gateCloseOnce = true;
        }


    }

    void playGateOpen()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/gate-open", transform.position);
        //openSound.start();
        //openSound.stop();
    }

    void playGateClose()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/gate-close", transform.position);
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
