using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveData : MonoBehaviour  {

    public SaveData current;
    public int currentLevel;
    public int highestLevel ;
    public List<int> levels;


    private void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Data").Length >= 2)
        {
            Destroy(this.gameObject);
        }
        current = GetComponent<SaveData>();
        DontDestroyOnLoad(current);
        currentLevel = 1;
        highestLevel = 20;
    }

    private void Update()
    {
        if (currentLevel > highestLevel)
        {
            highestLevel = currentLevel;
        }
    }

}
