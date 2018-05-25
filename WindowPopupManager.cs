using UnityEngine;
using UnityEngine.UI;

public class WindowPopupManager : MonoBehaviour {

    public Text ScoreText;
    public Text hiScoreText;

    public AudioClip PlayerHitSound;

    public HitEmotionMenu hitEmotionMenu;
    public CollectEmotionMenu colEmotionMenu;
    public NothingEmotionMenu noEmotionMenu;
    public CharacterSelection characterSelection;
    public MainMenu mainMenu;

    private int GUIScoreText = 0;

    private int PlayerHitCount = 0;

    private int PointCount = 0;

    private float time = 0F;

    // Use this for initialization
    void Start () {

        characterSelection.ToggleEndMenu();
        ScoreText.text = "Score: 0";
        hiScoreText.text = "HighScore: 0";


    }

    void Update()
    {
        time += Time.deltaTime;
        if (PointCount == 0 && time >= 30F)
        {
            noEmotionMenu.ToggleEndMenu();
            time = 0;
        }
        //Debug.Log(time);

        if (Input.GetKey(KeyCode.Escape))
        {
            mainMenu.ToggleEndMenu();
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Point")
        {
            GUIScoreText += 1;
            PointCount++;
            ScoreText.text = "Score: " + GUIScoreText;
            hiScoreText.text = "HighScore: " + GUIScoreText;
            Destroy(col.gameObject);
            if (PointCount == 1)
            {
                colEmotionMenu.ToggleEndMenu();
            }
            else if (PointCount % 10 == 0)
            {
                colEmotionMenu.ToggleEndMenu();
            }
            Debug.Log(PointCount);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            GUIScoreText -= 1;
            PlayerHitCount++;
            ScoreText.text = "Score: " + GUIScoreText;
            GetComponent<AudioSource>().Play();
            if (PlayerHitCount == 1 )
            {
                hitEmotionMenu.ToggleEndMenu();
            }
            else if (PlayerHitCount % 5 == 0) {
                hitEmotionMenu.ToggleEndMenu();
            }
            Debug.Log(PlayerHitCount);
        }
    }

}
