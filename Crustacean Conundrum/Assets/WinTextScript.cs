using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTextScript : MonoBehaviour
{
    [SerializeField]
    private string levelToLoad;
    [SerializeField]
    private float time;

    private float timer;

    void Start()
    {
        timer = time;
    }

    void Update ()
    {
        timer -= Time.deltaTime;
		if (timer <= 0 && Input.anyKeyDown)
        {
            SceneManager.LoadScene(levelToLoad);
        }
	}
}
