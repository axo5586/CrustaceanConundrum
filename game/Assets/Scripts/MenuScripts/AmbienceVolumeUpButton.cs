using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbienceVolumeUpButton : MonoBehaviour
{

    //color
    Color startColor;
    Renderer renderer;

    public VolumeScript volumeScript;
    public float volumeFloat;

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

        if (volumeScript.ambienceVolume == 1f)
        {
            volumeScript.ambienceVolume = 1;
        }
        else if (volumeScript.ambienceVolume == .5f)
        {
            volumeScript.ambienceVolume = 1;
        }
        else if (volumeScript.ambienceVolume == 0f)
        {
            volumeScript.ambienceVolume = 0.5f;
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
