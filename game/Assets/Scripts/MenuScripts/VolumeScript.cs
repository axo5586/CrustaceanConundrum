using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeScript : MonoBehaviour
{
    public FMOD.Studio.Bus Ambience;
    public FMOD.Studio.Bus SFX;
    public GameObject ambienceUp;
    public GameObject ambienceDown;
    public GameObject sfxUp;
    public GameObject sfxDown;
    public float ambienceVolume;
    public float sfxVolume;

    // Start is called before the first frame update
    void Start()
    {
        Ambience = FMODUnity.RuntimeManager.GetBus("bus:/Ambience");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/SFX");

        ambienceVolume = 1.0f;
        sfxVolume = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Ambience.setFaderLevel(ambienceVolume);
        //sfxVolume.setFaderLevel(sfxVolume);

        Ambience.setVolume(ambienceVolume);
        SFX.setVolume(sfxVolume);
    }
}
