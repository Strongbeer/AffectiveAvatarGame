using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HitEmotionMenu : MonoBehaviour {

    public Text ScoreText;
    public Image BGImage;

    public Animator Animation1;
    public Animator Animation2;

    private bool isShown = false;

    private float transition = 0.0f;

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShown)
            return;

        transition += Time.deltaTime;
        BGImage.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(129,129,129,129), transition);
    }

    public void ToggleEndMenu()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0.0F;
        isShown = false;
        //ScoreText.text = (int)score).ToString();
    }

    public void CotinueGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0F;
        isShown = true;
        StartCoroutine("SlowAnimation");
        //Debug.Log("SlowDown");
    }

    public IEnumerator SlowAnimation()
    {
        Animation1.speed = 0;
        Animation2.speed = 0;
        yield return new WaitForSeconds(5);
        Animation1.speed = 1;
        Animation2.speed = 1;
        Debug.Log("AnimationSlow");
    }
}