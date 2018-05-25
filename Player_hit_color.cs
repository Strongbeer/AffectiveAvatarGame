using System.Collections;
using UnityEngine;

public class Player_hit_color : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public Color Hit = new Color();
    private Color Neutral = Color.white;

    IEnumerator OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            player1.GetComponent<Renderer>().material.color = Hit;
            player2.GetComponent<Renderer>().material.color = Hit;
            player3.GetComponent<Renderer>().material.color = Hit;
            player4.GetComponent<Renderer>().material.color = Hit;
            yield return new WaitForSeconds(.5F);
            player1.GetComponent<Renderer>().material.color = Neutral;
            player2.GetComponent<Renderer>().material.color = Neutral;
            player3.GetComponent<Renderer>().material.color = Neutral;
            player4.GetComponent<Renderer>().material.color = Neutral;
        }
    }
}
