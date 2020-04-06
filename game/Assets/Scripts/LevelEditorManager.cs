using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

public class LevelEditorManager : MonoBehaviour {
    private string authToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJyanY4ODA2IiwiZXhwIjoxNTQ0MTE3NzA2fQ.1sByKTWFrEOJA5W_fzmJW04XyNbPAtg2fukAJD9SUDc"; // TODO get from server
    [SerializeField]
    private GameObject[] components;
    private sbyte currentComponent = -1;
    [SerializeField]
    private KeyCode[] keyCodes;
    [SerializeField]
    private SpriteRenderer preview;

    public const string SERVER_URL = "http://127.0.0.1:8000/api.php";

    public void Start()
    {
        if (keyCodes.Length != components.Length)
        {
            Debug.LogError("Components and key codes are a different length, you're gonna have a sad time");
        }
    }
    // Update is called once per frame
    public void Update () {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        preview.transform.position = mousePosition;
        for (sbyte i = 0; i < keyCodes.Length; i++)
        {
            if(Input.GetKeyDown(keyCodes[i]))
            {
                currentComponent = i;
                preview.sprite = components[i].GetComponent<SpriteRenderer>().sprite;
                preview.transform.rotation = components[i].transform.rotation;
                preview.transform.localScale = components[i].transform.localScale;
            }
        }
        if (Input.GetMouseButtonDown(0) && currentComponent!=-1)
        {
            // Spawn currentComponent at mouse position
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            GameObject obj = Instantiate(components[currentComponent]);
            obj.transform.position = position;
            obj.AddComponent<SerializableComponent>().componentNum = (byte)currentComponent;
            // Attach all buttons to gates
            ButtonScript[] buttons = FindObjectsOfType<ButtonScript>();
            GateScript gate = FindObjectOfType<GateScript>();
            if (gate) gate.Triggers = buttons;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string level=SerializeLevel();
            StartCoroutine(UploadLevel(authToken, "myLevel", level));
        }
	}

    IEnumerator UploadLevel(string auth, string name, string conts)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("method", "SubmitLevel"));
        formData.Add(new MultipartFormDataSection("auth", auth));
        formData.Add(new MultipartFormDataSection("name", name));
        formData.Add(new MultipartFormDataSection("conts", conts));

        UnityWebRequest www = UnityWebRequest.Post(SERVER_URL, formData);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
        Debug.Log(www.downloadHandler.text);
    }
    private string SerializeLevel()
    {
        StringBuilder builder = new StringBuilder("[");
        bool first = true;
        foreach (SerializableComponent obj in FindObjectsOfType<SerializableComponent>())
        {
            if(first)
            {
                first = false;
            }
            else
            {
                builder.Append(",");
            }
            builder.Append(obj.ToString());
        }
        builder.Append("]");
        return builder.ToString();
    }
}
