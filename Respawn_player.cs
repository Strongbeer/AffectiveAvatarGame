using UnityEngine;

public class Respawn_player : MonoBehaviour {

    //public GameObject GroundHit;
    //public GameObject PlayerPrefab;
    public DeathMenu deathMenu;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Ground_Hitbox")
        {
            deathMenu.ToggleEndMenu();
            //Time.timeScale = 0;
            AudioListener.volume = 0;
            //Destroy(PlayerPrefab);
            // PlayerPrefab.transform.position = spawnPoint.transform.position;
        }
        else if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }

        // Instantiate(PlayerPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
