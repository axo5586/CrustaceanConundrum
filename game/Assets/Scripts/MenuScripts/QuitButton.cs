using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    //color
    Color startColor;
    Renderer renderer;

    // Use this for initialization
    void Start ()
    {
        renderer = GetComponent<SpriteRenderer>();
        startColor = renderer.material.color;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
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

    //quit
    private void OnMouseDown()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
