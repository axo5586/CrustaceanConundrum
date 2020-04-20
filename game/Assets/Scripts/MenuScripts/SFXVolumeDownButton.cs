using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXVolumeDownButton : MonoBehaviour
{

    //color
    Color startColor;
    Renderer renderer;

    public VolumeScript volumeScript;

    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        startColor = renderer.material.color;
    }

    // Update is called once per frame
    void Update ()
    {
        
    }

    private void OnMouseDown()
    {

        if (volumeScript.sfxVolume == 1f)
        {
            volumeScript.sfxVolume = .5f;
        }
        else if (volumeScript.sfxVolume == .5f)
        {
            volumeScript.sfxVolume = 0f;
        }
        else if (volumeScript.sfxVolume == 0f)
        {
            volumeScript.sfxVolume = 0f;
        }
    }

    //hover to highlight
    void OnMouseOver()
    {
        renderer.material.color = Color.red;
    }
    void OnMouseExit()
    {
        renderer.material.color = startColor;
    }
}
