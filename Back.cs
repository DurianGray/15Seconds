using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{

    public Button back;
    public GameObject menu;

    // Use this for initialization
    void Start()
    {
        back = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        back.onClick.AddListener(OpenMenu);
    }

    public void OpenMenu()
    {
        back.interactable = true;
        menu.SetActive(false);
    }
}
