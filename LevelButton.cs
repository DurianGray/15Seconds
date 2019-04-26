using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {
    public int level;
    public Text text;
    public Button button;
    public Image buttonImage;
    public GameObject data;
    public SaveData save;
    public Image fadescreen;
    public bool interactable;
    public Image lockImage;
    public LoadLevel loader;
    public GameObject cam;


	// Use this for initialization
	void Start () {
        data = GameObject.Find("Data");
        save = data.GetComponent<SaveData>();
        cam = GameObject.Find("Main Camera");
        loader = cam.GetComponent<LoadLevel>();
        level = int.Parse(text.text);
        button = GetComponent<Button>();
        buttonImage = button.GetComponent<Image>();
        interactable = true;
        if (save.highestLevel < level)
        {
            interactable = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(interactable)
        {
            button.onClick.AddListener(Load);
        }
        else
        {
            button.image.color = new Color(0, 0, 0, 68);
        }
      
    }

    public void Load()
    {
        save.currentLevel = level;
        loader.GenLevel();
      
    }
}
