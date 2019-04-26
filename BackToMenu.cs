using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

    public Button menu;
    public GameManager game;
    public bool fading;
    public float alpha = 0;
    public Image blackScreen;

	// Use this for initialization
	void Start () {
        menu = GetComponent<Button>();
        fading = false;
    }
	
	// Update is called once per frame
	void Update () {
        menu.onClick.AddListener(Menu);
        if (fading)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, alpha);
            alpha += Time.deltaTime;
        }
        if (alpha >= 1)
        {
            game.level = 0;
            game.gameOver = false;
            fading = false;
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Menu()
    {
        blackScreen.gameObject.SetActive(true);
        fading = true;
    }
}
