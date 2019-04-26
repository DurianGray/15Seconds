using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

    public GameManager game;
    public Text text;
    public Timer timer;
    public bool paused = false;
    public bool cleared = true;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        cleared = false;
	}
	
	// Update is called once per frame
	void Update () {
        paused = game.gamePaused;
        if (!cleared && timer.timeCount == 0 && !game.fading)
        {
            cleared = true;
            text.text = "level cleared";
        }
	}
    IEnumerator LevelStart()
    {
        while (paused)
        {
            yield return null;
        }
        text.text = "15 SECONDS";
        while (paused)
        {
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        while (paused)
        {
            yield return null;
        }
        text.text = "LEVEL " + game.level;
        while (paused)
        {
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        while (paused)
        {
            yield return null;
        }
        text.text = "BEGIN";
        while (paused)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1.2f);
        while (paused)
        {
            yield return null;
        }
        cleared = false;
        text.text = "";
    }
}

