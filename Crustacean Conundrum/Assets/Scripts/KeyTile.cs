using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTile : MonoBehaviour {

    GameObject crabX;
    GameObject crabY;
    GameObject normalTile;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    // on trigger, destroy keytile and add dwkey to player who touched.
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("crabX"))
        {
            //destroy keytile and give a key to the crab who touched it, in this case crabX
            Destroy(gameObject);
            crabX.GetComponent<PlayerController>().GiveKey();

            //Get position of keytile, create a normal tile block on that position
            Vector3 crabXPos = crabX.transform.position;
            Instantiate(normalTile);
            normalTile.transform.position = crabXPos;
            
        }

        else if (other.GetComponent<Collider>().CompareTag("crabY"))
        {
            //destroy keytile and give a key to the crab who touched it, in this case crabY
            Destroy(gameObject);
            crabX.GetComponent<PlayerController>().GiveKey();

            //Get position of keytile, create a normal tile block on that position
            Vector3 crabYPos = crabY.transform.position;
            Instantiate(normalTile);
            normalTile.transform.position = crabYPos;
        }
    }
}
