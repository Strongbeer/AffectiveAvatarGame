using System.Collections;
using UnityEngine;

public class Emotes_opposite_emotions : MonoBehaviour {

    public GameObject triumph;
    public GameObject boredom;
    public GameObject frustration;
    public GameObject neutral;

    private bool isShown = false;

    // Use this for initialization
    void Start () {
        triumph.SetActive(false);
        boredom.SetActive(false);
        frustration.SetActive(false);
        neutral.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            triumph.SetActive(true);
            boredom.SetActive(false);
            frustration.SetActive(false);
            neutral.SetActive(false);
            yield return new WaitForSeconds(10F);
            triumph.SetActive(false);
            boredom.SetActive(false);
            frustration.SetActive(false);
            neutral.SetActive(true);
        } else if (coll.gameObject.tag == "Point")
        {
            triumph.SetActive(false);
            boredom.SetActive(false);
            frustration.SetActive(true);
            neutral.SetActive(false);
            yield return new WaitForSeconds(10F);
            triumph.SetActive(false);
            boredom.SetActive(false);
            frustration.SetActive(false);
            neutral.SetActive(true);
        }
    }
}
