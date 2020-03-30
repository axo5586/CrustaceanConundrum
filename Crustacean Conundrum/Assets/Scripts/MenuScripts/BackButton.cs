using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{

    //color
    Color startColor;
    Renderer renderer;

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
        SceneManager.LoadScene("StartMenu");
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
