using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateScript : MonoBehaviour
{
    private bool opened;
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
        }
    }
    [SerializeField]
    public ButtonScript[] Triggers;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        Opened = Triggers.All(button => button.Pressed);
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
