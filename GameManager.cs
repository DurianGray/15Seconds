using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Heres what im going to do: We create a list of speeds, firerates, directions, etc, in the order that we instantiate our turrets. we then have the turrets grab their speeds and stuff by tagging them each with a number, maybe by adding to the z scale.
    public List<Turret> Turrets;
    public int level;
    public int stage;
    public Timer text;
    public bool levelGenerated = true;
    public Vector3 origin;
    public List<Vector3> turretPositions;
    public Transform cam;
    public GameObject platform;
    public bool gamePlaying = true;
    public float universalDelay = 500;
    public int transitionTime;
    public Timer timer;
    public LevelText levelText;
    public Vector3 playerPos;
    public Player player;
    public float transitionTimer;
    public bool transition;
    public Image fadescreen;
    public bool fading;
    public float alpha;
    public bool gameOver = false;
    public bool gamePaused = false;
    public GameObject gameOverMenu;
    public GameObject pauseMenu;
    public bool goMenuGenerated = false;
    public bool pauseMenuGenerated = false;
    public GameObject data;
    public SaveData save;


    // Use this for initialization
    void Start()
    {
        data = GameObject.Find("Data");
        save = data.GetComponent<SaveData>();
        fadescreen.gameObject.SetActive(true);
        cam = GetComponent<Transform>();
        stage = 1;
        levelGenerated = true;
        fading = true;
        if (save.currentLevel < 1)
        {
            level = 1;
        }
        else
        {
            level = save.currentLevel;
        }
        transition = false;
        origin = new Vector3(0, 0, 0);
        float y = -5.5f;
        while (y <= 4)
        {
            turretPositions.Add(new Vector3(-20f, y, 0f));
            y++;
        }
        y = -5.5f;
        while (y <= 4)
        {
            turretPositions.Add(new Vector3(20f, y, 0f));
            y++;
        }
        y = -5.5f;
        while (y <= 4)
        {
            turretPositions.Add(new Vector3(0f, y+20, 0f));
            y++;
        }
        transitionTimer = 0;
        //turret positions= left side  0,1,2,3,4,5,6,7,8,9
        //turret positions right side 10,11,12,13,14,15,16,17,18,19
        //turret positions center 20,21,22,23,24,25,26,27,28,29
        alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (level > save.currentLevel)
        {
            save.currentLevel = level;
        }
        if (Input.GetKeyDown("p") == true && !pauseMenuGenerated)
        {
            pauseMenuGenerated = true;
            pauseMenu.gameObject.SetActive(true);
            gamePaused = true;
        }
        if (pauseMenuGenerated && !gamePaused)
        {
            pauseMenuGenerated = false;
        }
        if (gameOver && !goMenuGenerated)
        {
            GameOverMenu();
        }
        if (!gameOver && goMenuGenerated)
        {
            goMenuGenerated = false;
        }
        if (fading)
        {
            alpha -= Time.deltaTime / 2;
            fadescreen.color = new Color(fadescreen.color.r, fadescreen.color.g, fadescreen.color.b, alpha);
            if (alpha <= 0)
            {
                fading = false;
                fadescreen.gameObject.SetActive(false);
                StartGame();
            }
        }
        if (timer.timeCount == 0 && levelGenerated == true && !fading)
        {
            levelGenerated = false;
            transition = true;
        }
        if(transition)
        {
            transitionTimer -= Time.deltaTime;
            
            if(transitionTimer <= 0)
            {
                transition = false;
                transitionTimer = 2;
                level++;
                levelText.StartCoroutine("LevelStart");
                timer.RoundStart();
            }
        }
        if (level == 1 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelOne");
        }
        if (level == 2 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelTwo");
        }
        if (level == 3 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelThree");
        }
        if (level == 4 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelFour");
        }
        if (level == 5 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelFive");
        }
        if (level == 6 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelSix");
        }
        if (level == 7 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelSeven");
        }
        if (level == 8 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelEight");
        }
        if (level == 9 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelNine");
        }
        if (level == 10 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelTen");
        }
        if (level == 11 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelEleven");
        }
        if (level == 12 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelTwelve");
        }
        if (level == 13 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelThirteen");
        }
        if (level == 14 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelFourteen");
        }
        if (level == 15 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelFifteen");
        }
        if (level == 16 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelSixteen");
        }
        if (level == 17 && levelGenerated == false && !transition && !fading)
        {
            StartCoroutine("GenLevelSeventeen");

        }

    }

    public void GameOverMenu()
    {
        gameOverMenu.SetActive(true);
        goMenuGenerated = true;
    }

    public void GameOver()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        gamePlaying = false;
    }
    public void StartGame()
    {
        //levelGenerated = false;
        //level++;
        // timer.RoundStart();
        // levelText.StartCoroutine("LevelStart");
        transition = true;
        Player toInstantiate = Instantiate(player, new Vector3(0, -3, 0), Quaternion.identity);
        toInstantiate.position = new Vector3(0, -3);
        toInstantiate.transform.SetParent(cam);
        player = toInstantiate;
        level--;
        levelGenerated = false;
    }
    public void ClearChildren()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    IEnumerator GenLevelOne()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[0], Quaternion.identity);
        TurretOne.ApplyStats(13, 0, 1.5f, 0f, turretPositions[0], 0, 1, player);
        TurretOne.transform.SetParent(cam);
    }
    IEnumerator GenLevelTwo()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[0], Quaternion.identity);
        TurretOne.ApplyStats(10, 0, 2f, 0f, turretPositions[0], 1, 1, player);
        TurretOne.ApplyBurstStats(3, 0.1f);
        TurretOne.transform.SetParent(cam);
        levelGenerated = true;
    }
    IEnumerator GenLevelThree()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[0], Quaternion.identity);
        TurretOne.ApplyStats(10, 0, 2.5f, 0f, turretPositions[0], 1, 1, player);
        TurretOne.ApplyBurstStats(3, 0.1f);
        TurretOne.transform.SetParent(cam);
        Turret TurretTwo = Instantiate(Turrets[0], turretPositions[10], Quaternion.identity);
        TurretTwo.ApplyStats(10, 0, 2.5f, 1.2f, turretPositions[10], 1, 1, player);
        TurretTwo.ApplyBurstStats(3, 0.1f);
        TurretTwo.transform.SetParent(cam);
        levelGenerated = true;
    }
    IEnumerator GenLevelFour()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[9], Quaternion.identity);
        TurretOne.ApplyStats(3, 0, 1.5f, 0f, turretPositions[9], 0, 1, player);
        TurretOne.transform.SetParent(cam);
        Turret TurretTwo = Instantiate(Turrets[0], turretPositions[19], Quaternion.identity);
        TurretTwo.ApplyStats(3, 0, 1.5f, .75f, turretPositions[19], 0, 1, player);
        TurretTwo.transform.SetParent(cam);
        levelGenerated = true;
    }
    IEnumerator GenLevelFive()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[8], Quaternion.identity);
        TurretOne.ApplyStats(3, 0, 1.5f, 0f, turretPositions[8], 0, 1, player);
        TurretOne.transform.SetParent(cam);
        Turret TurretTwo = Instantiate(Turrets[0], turretPositions[18], Quaternion.identity);
        TurretTwo.ApplyStats(3, 0, 1.5f, .5f, turretPositions[18], 0, 1, player);
        TurretTwo.transform.SetParent(cam);
        Turret TurretThree = Instantiate(Turrets[0], turretPositions[29], Quaternion.identity);
        TurretThree.ApplyStats(6, 0, 3, 0f, turretPositions[29], 0, 1, player);
        TurretThree.transform.SetParent(cam);
        levelGenerated = true;
    }
    IEnumerator GenLevelSix()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[29], Quaternion.identity);
        TurretOne.ApplyStats(12, 90, .2f, 0f, turretPositions[29], 2, 0, player);
        TurretOne.transform.SetParent(cam);
        TurretOne.ApplySprayStats(20);
        levelGenerated = true;
    }
    IEnumerator GenLevelSeven()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[9], Quaternion.identity);
        TurretOne.ApplyStats(7, 90, .2f, 0f, turretPositions[9], 2, 0, player);
        TurretOne.transform.SetParent(cam);
        TurretOne.ApplySprayStats(20);
        Turret TurretTwo = Instantiate(Turrets[0], turretPositions[19], Quaternion.identity);
        TurretTwo.ApplyStats(7, 90, .2f, 0f, turretPositions[19], 2, 0, player);
        TurretTwo.transform.SetParent(cam);
        TurretTwo.ApplySprayStats(-20);
        levelGenerated = true;
    }
    IEnumerator GenLevelEight()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[9], Quaternion.identity);
        TurretOne.ApplyStats(12, 90, .2f, 0f, turretPositions[9], 2, 0, player);
        TurretOne.transform.SetParent(cam);
        TurretOne.ApplySprayStats(20);
        Turret TurretTwo = Instantiate(Turrets[0], turretPositions[19], Quaternion.identity);
        TurretTwo.ApplyStats(12, 90, .2f, 0f, turretPositions[19], 2, 0, player);
        TurretTwo.transform.SetParent(cam);
        TurretTwo.ApplySprayStats(-15);
        levelGenerated = true;
    }
    IEnumerator GenLevelNine()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[0], Quaternion.identity);
        TurretOne.ApplyStats(10, 0, 1.5f, 0f, turretPositions[0], 0, 0, player);
        TurretOne.transform.SetParent(cam);
        Turret TurretTwo = Instantiate(Turrets[0], turretPositions[2], Quaternion.identity);
        TurretTwo.ApplyStats(7, 0, 3.5f, 0f, turretPositions[2], 0, 0, player);
        TurretTwo.transform.SetParent(cam); 
    }
    IEnumerator GenLevelTen()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[0], Quaternion.identity);
        TurretOne.ApplyStats(10, 0, 1.5f, 0f, turretPositions[0], 0, 0, player);
        TurretOne.transform.SetParent(cam);
        Turret TurretTwo = Instantiate(Turrets[0], turretPositions[4], Quaternion.identity);
        TurretTwo.ApplyStats(7, 0, 3f, 0f, turretPositions[4], 0, 0, player);
        TurretTwo.transform.SetParent(cam);
        Turret TurretThree = Instantiate(Turrets[0], turretPositions[12], Quaternion.identity);
        TurretThree.ApplyStats(5, 180, 3.5f, universalDelay, turretPositions[12], 0, 0, player);
        TurretThree.transform.SetParent(cam);
    }
    IEnumerator GenLevelEleven()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[0], Quaternion.identity);
        TurretOne.ApplyStats(10, 0, 1.8f, 0f, turretPositions[0], 1, 0, player);
        TurretOne.ApplyBurstStats(3, .1f);
        TurretOne.transform.SetParent(cam);
        Turret TurretTwo = Instantiate(Turrets[0], turretPositions[4], Quaternion.identity);
        TurretTwo.ApplyStats(7, 0, 2.5f, 0f, turretPositions[4], 0, 0, player);
        TurretTwo.transform.SetParent(cam);
        Turret TurretThree = Instantiate(Turrets[0], turretPositions[12], Quaternion.identity);
        TurretThree.ApplyStats(5, 180, 3.5f, universalDelay, turretPositions[12], 0, 0, player);
        TurretThree.transform.SetParent(cam);
    }
    IEnumerator GenLevelTwelve()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[0], Quaternion.identity);
        TurretOne.ApplyStats(10, 0, 1.8f, 0f, turretPositions[0], 1, 0, player);
        TurretOne.ApplyBurstStats(8, .1f);
        TurretOne.transform.SetParent(cam);
        Turret TurretTwo = Instantiate(Turrets[0], turretPositions[4], Quaternion.identity);
        TurretTwo.ApplyStats(7, 0, 2.5f, 0f, turretPositions[4], 1, 0, player);
        TurretTwo.ApplyBurstStats(2, .1f);
        TurretTwo.transform.SetParent(cam);
        Turret TurretThree = Instantiate(Turrets[0], turretPositions[12], Quaternion.identity);
        TurretThree.ApplyStats(5, 180, 3.5f, universalDelay, turretPositions[12], 0, 0, player);
        TurretThree.transform.SetParent(cam);
    }
    IEnumerator GenLevelThirteen()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[0], Quaternion.identity);
        TurretOne.ApplyStats(10, 0, 1.8f, 0f, turretPositions[0], 1, 0, player);
        TurretOne.ApplyBurstStats(8, .1f);
        TurretOne.transform.SetParent(cam);
        Turret TurretTwo = Instantiate(Turrets[0], turretPositions[4], Quaternion.identity);
        TurretTwo.ApplyStats(7, 0, 2.5f, 0f, turretPositions[4], 1, 0, player);
        TurretTwo.ApplyBurstStats(10, .1f);
        TurretTwo.transform.SetParent(cam);
        Turret TurretThree = Instantiate(Turrets[0], turretPositions[12], Quaternion.identity);
        TurretThree.ApplyStats(7, 180, 2.8f, universalDelay, turretPositions[12], 0, 1, player);
        TurretThree.transform.SetParent(cam);
    }
    IEnumerator GenLevelFourteen()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[29], Quaternion.identity);
        TurretOne.ApplyStats(15, 0, 1.5f, 0f, turretPositions[29], 1, 1, player);
        TurretOne.ApplyBurstStats(20, .1f);
        TurretOne.transform.SetParent(cam);
        
    }
    IEnumerator GenLevelFifteen()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[9], Quaternion.identity);
        TurretOne.ApplyStats(15, 0, 1.7f, 0f, turretPositions[9], 1, 1, player);
        TurretOne.ApplyBurstStats(10, .1f);
        TurretOne.transform.SetParent(cam);
        Turret TurretTwo = Instantiate(Turrets[0], turretPositions[19], Quaternion.identity);
        TurretTwo.ApplyStats(15, 0, 1.7f, 1.2f, turretPositions[19], 1, 1, player);
        TurretTwo.ApplyBurstStats(10, .1f);
        TurretTwo.transform.SetParent(cam);
    }
    IEnumerator GenLevelSixteen()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[19], Quaternion.identity);
        TurretOne.ApplyStats(12, 0, 1.5f, 0f, turretPositions[29], 1, 1, player);
        TurretOne.ApplyBurstStats(10, .1f);
        TurretOne.transform.SetParent(cam);
        Turret TurretTwo = Instantiate(Turrets[0], turretPositions[19], Quaternion.identity);
        TurretTwo.ApplyStats(7, 0, 1.5f, 1f, turretPositions[19], 1, 1, player);
        TurretTwo.ApplyBurstStats(5, .1f);
        TurretTwo.transform.SetParent(cam);
        Turret TurretThree = Instantiate(Turrets[0], turretPositions[12], Quaternion.identity);
        TurretThree.ApplyStats(7, 180, 1.3f, universalDelay, turretPositions[12], 0, 1, player);
        TurretThree.transform.SetParent(cam);
    }
    IEnumerator GenLevelSeventeen()
    {
        levelGenerated = true;
        yield return new WaitForSeconds(1.6f);
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[22], Quaternion.identity);
        TurretOne.ApplyStats(10, 90, .1f, 0f, turretPositions[22], 2, 0, player);
        TurretOne.transform.SetParent(cam);
        TurretOne.ApplySprayStats(15);
        Turret TurretTwo = Instantiate(Turrets[0], turretPositions[0], Quaternion.identity);
        TurretTwo.ApplyStats(7, 0, 3f, 1.5f, turretPositions[0], 0, 1, player);
        TurretTwo.transform.SetParent(cam);
        Turret TurretThree = Instantiate(Turrets[0], turretPositions[10], Quaternion.identity);
        TurretThree.ApplyStats(7, 180, 3f, 0f, turretPositions[10], 0, 1, player);
        TurretThree.transform.SetParent(cam);
    }
    public void BossFightOne()
    {
        Turret TurretOne = Instantiate(Turrets[0], turretPositions[29], Quaternion.identity);
        TurretOne.ApplyStats(10, 90, .5f, universalDelay - .5f, turretPositions[29], 2, 0, player);
        TurretOne.transform.SetParent(cam);
        TurretOne.ApplySprayStats(30);
        levelGenerated = true;
        Turret TurretTwo = Instantiate(Turrets[0], turretPositions[29], Quaternion.identity);
        TurretTwo.ApplyStats(7, 0, 1, universalDelay - 1f, turretPositions[29], 0, 1, player);
        TurretTwo.transform.SetParent(cam);
        Turret TurretThree = Instantiate(Turrets[0], turretPositions[29], Quaternion.identity);
        TurretThree.ApplyStats(7, 0, 1.5f, universalDelay, turretPositions[29], 1, 1, player);
        TurretThree.ApplyBurstStats(3, 0.1f);
        TurretThree.transform.SetParent(cam);
        levelGenerated = true;
        Turret TurretFour = Instantiate(Turrets[0], turretPositions[29], Quaternion.identity);
        TurretFour.ApplyStats(10, 90, .4f, universalDelay, turretPositions[29], 2, 0, player);
        TurretFour.transform.SetParent(cam);
        TurretFour.ApplySprayStats(-20);
    }
    //(int speedm, float directionm, float fireratem, float delaym, Vector3 positionm, int typem, int trackTypem, Player targetm)
}
    
    
