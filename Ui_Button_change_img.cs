using UnityEngine;
using UnityEngine.UI;

public class Ui_Button_change_img : MonoBehaviour
{
    public Sprite spriteToChangeTo;
    public Image theImage;
    private float time;

    // Use this for initialization
    void Start()
    {
        time += Time.deltaTime;
        theImage.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (theImage.enabled == false && time == 15F)
        {
            theImage.enabled = true;
            time = 0F;
        }
    }

    public void ChangeImage(Image myImageToUpdate)
    {
        myImageToUpdate.sprite = spriteToChangeTo;
        theImage.enabled = false;
    }
}
