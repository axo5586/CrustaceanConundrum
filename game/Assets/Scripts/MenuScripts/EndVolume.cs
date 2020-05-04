using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndVolume : MonoBehaviour
{
    public FMOD.Studio.Bus Ambience;
    public FMOD.Studio.Bus SFX;
    private FMOD.Studio.STOP_MODE mode;

    // Start is called before the first frame update
    void Start()
    {
        Ambience = FMODUnity.RuntimeManager.GetBus("bus:/Ambience");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
        Ambience.stopAllEvents(mode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}