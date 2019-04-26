using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Retry : MonoBehaviour {

    public Button retry;
    public Image retryImage;
    public GameManager game;
    public Image menu;
    public Image menu2;
    public Text text;
    public Button tomenu;
    public Image tomenuImage;
    public Text menutext;
    public Text gameOverText;
    public bool exit = false;
    public bool restarted = false;
    public Vector3 menuPosition;
    public float alpha = 1;

	// Use this for initialization
	void Start () {
        retryImage = retry.GetComponent<Image>();
        tomenuImage = tomenu.GetComponent<Image>();
	}

    // Update is called once per frame
    void Update()
    {
        retry.onClick.AddListener(Restart);
        if (!exit)
        {
            alpha = 1;
            menu.color = new Color(menu.color.r, menu.color.g, menu.color.b, alpha);
            menu2.color = new Color(menu2.color.r, menu2.color.g, menu2.color.b, alpha);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            menutext.color = new Color(menutext.color.r, menutext.color.g, menutext.color.b, alpha);
            tomenuImage.color = new Color(tomenuImage.color.r, tomenuImage.color.g, tomenuImage.color.b, alpha);
            retryImage.color = new Color(retryImage.color.r, retryImage.color.g, retryImage.color.b, alpha);
            gameOverText.color = new Color(gameOverText.color.r, gameOverText.color.g, gameOverText.color.b, alpha);
        }
        if (exit)
        {
            menu.color = new Color(menu.color.r, menu.color.g, menu.color.b, alpha);
            menu2.color = new Color(menu2.color.r, menu2.color.g, menu2.color.b, alpha);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            menutext.color = new Color(menutext.color.r, menutext.color.g, menutext.color.b, alpha);
            tomenuImage.color = new Color(tomenuImage.color.r, tomenuImage.color.g, tomenuImage.color.b, alpha);
            retryImage.color = new Color(retryImage.color.r, retryImage.color.g, retryImage.color.b, alpha);
            alpha -= Time.deltaTime * 5;
        }
        if (alpha <= 0)
        {
            menu.gameObject.SetActive(false);
            exit = false;
            retry.interactable = true;
            restarted = false;
        }
    }

    public void Restart()
    {
        if (!restarted)
        {
            game.transition = true;
            game.levelGenerated = false;
            game.gameOver = false;
            game.level--;
            exit = true;
            restarted = true;
        }
    }

}
