using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTile : MonoBehaviour
{ 
    GameObject crabX;
    GameObject crabY;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
     
    }

    //on trigger 
    //destroys endtile if player touches with key
    private void OnTriggerEnter(Collider other)
    {
        //if crabX has key and touches end tile, destroy endtile
        if (crabX.GetComponent<PlayerController>().HaveKey() == true)
        {
            if (other.GetComponent<Collider>().CompareTag("crabX"))
            {
                //need to test whether or not it will destroy the end tile or scene changes first, if latter occurs, just delete all this code i guess.
                Destroy(gameObject);
            }
        }
        //if crabY has key and touches end tile, destroy endtile
        else if (crabY.GetComponent<PlayerController>().HaveKey() == false)
        {
            if (other.GetComponent<Collider>().CompareTag("crabY"))
            {
                Destroy(gameObject);
            }
        }
    }
}
