﻿using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

    public Image BGImage;

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
        BGImage.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(129, 129, 129, 129), transition);
    }

    public void ToggleEndMenu()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0.0F;
        isShown = false;
    }

    public void CotinueGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0F;
        isShown = true;
    }
}
