using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbienceVolume : MonoBehaviour
{
    public Sprite hundred;
    public Sprite fifty;
    public Sprite zero;
    public VolumeScript volumeScript;

    // Use this for initialization
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = hundred;
    }

    // Update is called once per frame
    void Update ()
    {
        if(volumeScript.ambienceVolume == 1f)
        {
            GetComponent<SpriteRenderer>().sprite = hundred;
        }
        if (volumeScript.ambienceVolume == .5f)
        {
            GetComponent<SpriteRenderer>().sprite = fifty;
        }
        if (volumeScript.ambienceVolume == 0f)
        {
            GetComponent<SpriteRenderer>().sprite = zero;
        }
    }
}
