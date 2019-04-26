using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Play : MonoBehaviour {
    public int x;
    public Image fadescreen;
    public float alpha;
    public bool fading;
    public Button play;
    public GameObject turret;
    public GameObject otherTurret;
    // Use this for initialization
    void Start () {
        Screen.SetResolution(1200, 550, false);
        alpha = 0;
        fading = false;
        play = GetComponent<Button>();

        
    }
	
	// Update is called once per frame
	void Update () {
        play.onClick.AddListener(Begin);
		if (fading)
        {
            fadescreen.color = new Color(fadescreen.color.r, fadescreen.color.g, fadescreen.color.b, alpha);
            alpha += Time.deltaTime * 1.5f;
        }
        if (alpha >= 1)
        {
            SceneManager.LoadScene("GameScene");
        }
	}

    public void Begin()
    {
        x++;
        fading = true;
        fadescreen.gameObject.SetActive(true);
        turret.SetActive(false);
        otherTurret.SetActive(false);
    }
}


