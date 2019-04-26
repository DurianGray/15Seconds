using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour {

    public float timer = -5f;
    public int timeCount = -5;
    public Text text;
    public bool gamePlaying;
    public bool started = false;
    public GameManager game;
    public float UniversalDelay = 3f;
    public bool loading;
    public float startTimer = 0;

	
	void Start ()
    {
        gamePlaying = true;
        loading = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (game.gameOver == true || game.transition == true || game.gamePaused == true)
        {
            if (game.gameOver)
            {
                startTimer = 0;
            }
            return;
        }

        else if (loading)
        {
            text.text = timeCount.ToString();
            startTimer += Time.deltaTime;
            if (startTimer >= 5.7f)
            {
                startTimer = 0f;
                loading = false;
            }
        }
        else
        {
            timer -= Time.deltaTime;
            timeCount = (int)timer;
            if (timeCount <= 0)
            {
            }
            else if (started && timer >= 15)
            {

            }

            if (timeCount <= 0)
            {
                text.text = "0";
            }
            else
            {
                text.text = timeCount.ToString();
            }
            
        }
        
	}
    public void RoundStart()
    {
        timer = 15;
        timeCount = (int)timer;
        started = true;
        loading = true;
    }
    
}
