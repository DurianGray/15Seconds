using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public Image fadescreen;
    public bool fading = false;
    public float alpha;

	void Start()
    {
        alpha = 0;
    }

    private void Update()
    {
        if (fading)
        {
            fadescreen.color = new Color(fadescreen.color.r, fadescreen.color.g, fadescreen.color.b, alpha);
            alpha += Time.deltaTime * 1.5f;
        }
        if (alpha >= 1)
        {
            fading = false;
            SceneManager.LoadScene("GameScene");
        }
    }
   
    

    public void GenLevel()
    {
        fading = true;
        fadescreen.gameObject.SetActive(true);
    }
}
