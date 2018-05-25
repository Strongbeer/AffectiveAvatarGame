using UnityEngine;

public class Die_text_hit : MonoBehaviour
{

    public static bool on; // switch the messages on and off
    public static string text;  //text to be displayed
    GUIText messages; // this will hold the GUIText component, to access its text


    void Start()
    {
        messages = (GUIText)GetComponent("GUIText");
    }
    void Update()
    {
        if (on)
        {
            messages.enabled = true;
            messages.text = text;
        }
        else
        {
            messages.enabled = false;
        }
    }
}