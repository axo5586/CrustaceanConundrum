using UnityEngine;

public class ButtonScript : MonoBehaviour {
    private bool pressed;
    [SerializeField]
    private Sprite PressedSprite;
    [SerializeField]
    private Sprite NotPressedSprite;
    private int pressCount;
    public bool Pressed
    {
        get
        {
            return pressed;
        }
        private set
        {
            pressed = value;
            GetComponent<SpriteRenderer>().sprite = value?PressedSprite:NotPressedSprite;
        }
    }
	// Use this for initialization
	void Start ()
    {
        Pressed = false;
        pressCount = 0;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Block")
        {
            Debug.Log("Enter");
            pressCount++;
            Pressed = pressCount > 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Block")
        {
            Debug.Log("Exit");
            pressCount--;
            Pressed = pressCount > 0;
        }
    }
}
