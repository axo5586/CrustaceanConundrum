using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelScripts : MonoBehaviour {
    private bool isX;
	// Use this for initialization
	void Start () {
        isX = transform.rotation.z == 0;
        //Debug.Log("isX: " + (isX ? "true" : "false"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
