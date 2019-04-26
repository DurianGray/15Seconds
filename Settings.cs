using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    public Button settings;
    public GameObject menu;

	// Use this for initialization
	void Start () {
        settings = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
        settings.onClick.AddListener(OpenMenu);
    }

    public void OpenMenu()
    {
        if (menu == null)
        {
            menu = GameObject.Find("Settings");
        }
        menu.SetActive(true);
        settings.interactable = true;
    }
}
