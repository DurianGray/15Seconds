using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour {

    public GameManager game;
    public Button con;
    public GameObject menu;

	// Use this for initialization
	void Start () {
        con = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
        con.onClick.AddListener(Con);
        if (Input.GetKeyDown("p") == true)
        {
            Con();
        }
    }

    public void Con()
    {
        game.gamePaused = false;
        menu.gameObject.SetActive(false);
    }
}
