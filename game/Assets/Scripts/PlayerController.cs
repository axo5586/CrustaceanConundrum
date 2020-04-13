using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private bool isX;
    private bool key;
   
    [SerializeField]
    private float speed;
    private float doubleSpeed;
    public bool shiftPressed;
    [SerializeField]
    private float leashX;
    [SerializeField]
    private float leashY;
    [SerializeField]
    private float leeway;
    private Vector3 lastPosition;
    private List<PlayerController> connectedPlayers;
    private List<Vector3> offsets;
    private Vector3 direction
    {
        get
        {
            return new Vector3(isX ? 1 : 0, isX ? 0 : 1, 0);
        }
    }
	// Use this for initialization
	void Start ()
    {
        connectedPlayers = new List<PlayerController>(2);
        offsets = new List<Vector3>(2);
        key = false;
        GetComponent<Rigidbody2D>().freezeRotation = true;
        doubleSpeed = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Make this a class attribute and run GetComponent in Start
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if(Input.GetKey(KeyCode.LeftShift))
        {
            doubleSpeed = 2;
            shiftPressed = true;
}
        else
        {
            doubleSpeed = 1;
            shiftPressed = false;
        }

        if (isX)
        {
            if (Input.GetKey(KeyCode.RightArrow) /*|| Input.GetKey(KeyCode.D)*/)
            {
                rigidbody.velocity = direction* Time.deltaTime * speed * doubleSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) /*|| Input.GetKey(KeyCode.A)*/)
            {
                rigidbody.velocity = direction * Time.deltaTime * -speed * doubleSpeed;
            }
            else
            {
                rigidbody.velocity = Vector3.zero;
            }
            float x = transform.position.x;
            if (x < -leashX - leeway) x = -leashX - leeway;
            if (x > leashX + leeway) x = leashX + leeway;
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            float y = transform.position.y;
            if (y > leashY) y = leashY;
            if (y < -leashY) y = -leashY;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);

            if (Input.GetButtonDown("Fire1"))
            {
                foreach (PlayerController player in connectedPlayers)
                {
                    offsets.Add(player.transform.position - transform.position);
                }
            }
            if (Input.GetButton("Fire1"))
            {
                for (int i = 0; i < connectedPlayers.Count; ++i)
                {
                    connectedPlayers[i].transform.position = offsets[i] + transform.position;
                }
            }
            else
            {
                offsets = new List<Vector3>(2);
            }
        }
        else
        {
            if (/*Input.GetKey(KeyCode.UpArrow) ||*/ Input.GetKey(KeyCode.W))
            {
                rigidbody.velocity = direction * Time.deltaTime * speed * doubleSpeed;
            }
            else if (/*Input.GetKey(KeyCode.DownArrow) ||*/ Input.GetKey(KeyCode.S))
            {
                //print("hi");
                rigidbody.velocity = direction * Time.deltaTime * -speed * doubleSpeed;
            }
            else
            {
                rigidbody.velocity = Vector3.zero;
            }
            float x = transform.position.x;
            if (x < -leashX) x = -leashX;
            if (x > leashX) x = leashX;
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            float y = transform.position.y;
            if (y > leashY + leeway) y = leashY + leeway;
            if (y < -leashY - leeway) y = -leashY - leeway;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);

            if (Input.GetButtonDown("Fire2"))
            {
                foreach (PlayerController player in connectedPlayers)
                {
                    offsets.Add(player.transform.position - transform.position);
                }
            }
            if (Input.GetButton("Fire2"))
            {
                if (connectedPlayers.Count >= 0)
                {
                    for (int i = 0; i < connectedPlayers.Count; ++i)
                    {
                        connectedPlayers[i].transform.position = offsets[i] + transform.position;
                    }
                }
                
            }
            else
            {
                offsets = new List<Vector3>(2);
            }
        }
    }

    //on trigger 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().CompareTag("Player"))
        {
            connectedPlayers.Add(other.GetComponent<PlayerController>());
            if (!isX)
            {
                print(connectedPlayers[0]);
            }
        }
        //if (other.GetComponent<Collider2D>().CompareTag("endTile"))
        //{
        //    if (key == true)
        //    {
        //        //GameManager.LoadScene("NextLevel");
        //    }
        //}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().CompareTag("Player"))
        {
            connectedPlayers.Remove(other.GetComponent<PlayerController>());
            if (!isX)
            {
                print(":exit");
            }
        }
    }

    public bool HaveKey()
    {
        return key;
    }

    public void GiveKey()
    {
        key = true;
    }
}
