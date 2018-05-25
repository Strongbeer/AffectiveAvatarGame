using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {

    public Text ScoreText;
    public Image BGImage;

    private bool isShown = false;

    private float transition = 0.0f;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isShown)
            return;

        transition += Time.deltaTime;
        BGImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
	}

    public void ToggleEndMenu ()
    {
        gameObject.SetActive(true);
        isShown = false;
        //ScoreText.text = (int)score).ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame()
    {
        Application.Quit();
        //SceneManager.LoadScene("MainMenu");
    }
}
