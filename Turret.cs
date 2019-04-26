using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Turret : MonoBehaviour {

    public List<Projectile> projectiles;
    public Vector3 position;
    public float firerate = 1;
    public float timeSinceFired;
    public Transform turret;
    public GameObject projectile;
    public Vector3 size = new Vector3(.5f, .5f, 1);
    public int speed;
    public float direction;
    public float targetx;
    public float targety;
    public float delay;
    public Vector3 targetPos;
    public int type;
    public Player target;
    public int burstLength;
    public float burstSpacing;
    public int trackType;
    public int burstMax;
    public int called;
    public float angleChange;
    public float originalY;
    public float firstShot;
    public bool remove = false;
    public GameManager game;
    public Animator animator;
    public bool paused = false;
    public bool gameOver;
    public List<AudioClip> shots;
    public AudioSource audio;
    public AudioClip shot;

    //List of types: Type 0 = regular, type 1 = burstfire,  type 2 = randomspray

    // Use this for initialization
    void Start() {
        game = GetComponentInParent<GameManager>();
        timeSinceFired = -3f + firerate - delay;
        turret = transform;
        originalY = position.y - 20;
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
        gameOver = game.gameOver;
        paused = game.gamePaused;
        animator.SetBool("remove", remove);
        if (paused)
        {

        }
        else
        {
            if (game.transition == true)
            {
                Clear();
            }
            transform.position = position;   //moves in turret from right side
            if (position.x > 15)
            {
                position.x -= 2 * Time.deltaTime;
            }
            if (position.x < -15)  //moves in from left side
            {
                position.x += 2 * Time.deltaTime;
            }
            if (position.x == 0 && position.y > originalY)  //moves in from top
            {
                position.y -= 10 * Time.deltaTime;
            }
            if (trackType == 1)
            {
                TrackPlayer();
            }
            if (type == 0)
            {
                shot = shots[0];
                if (timeSinceFired < 0 && remove == false)
                {

                }
                else if (timeSinceFired >= firerate)
                {
                    Fire(0);
                    timeSinceFired = 0;
                }
                timeSinceFired += Time.deltaTime;
            }
            else if (type == 1)
            {
                shot = shots[1];
                if (burstLength > 0 && timeSinceFired > firerate && remove == false)
                {
                    BurstFire(0);
                }
                else if (burstLength <= 0)
                {
                    timeSinceFired = 0;
                    burstLength = burstMax;
                }
                timeSinceFired += Time.deltaTime;
            }
            else if (type == 2)
            {
                shot = shots[2];
                if (timeSinceFired > firerate && remove == false)
                {
                    SprayFire();
                }
                timeSinceFired += Time.deltaTime;
            }
            else if (type == 3)
            {

            }
        }
        
	}
    public void ApplyStats(int speedm, float directionm, float fireratem, float delaym, Vector3 positionm, int typem, int trackTypem, Player targetm)
    {
        speed = speedm;
        direction = directionm;
        firerate = fireratem;
        delay = delaym;
        type = typem;
        target = targetm;
        trackType = trackTypem;
        position = positionm;
    }
    public void ApplyBurstStats(int burstLengthm, float burstSpacingm)
    {
        burstLength = burstLengthm;
        burstSpacing = burstSpacingm;
        burstMax = burstLength;
    }
    public void ApplySprayStats(float angleChangem)
    {
        angleChange = angleChangem;
    }
    public void TrackPlayer()
    {
        called++;
        targetPos = target.position;
        float x = transform.position.x - targetPos.x;
        float y = transform.position.y - targetPos.y;
        direction = Mathf.Atan(y / x);
        direction = direction * Mathf.Rad2Deg;
        if (x > 0)
        {
            direction = direction + 180;
        }
    }
    public void Fire(int x)
    {
        if (game.gameOver == true || game.transition == true || paused)
        {

        }
        else
        {
            position = transform.position;
            Projectile toInstantiate = Instantiate(projectiles[x], position, Quaternion.identity);
            toInstantiate.CreateProjectile(speed, direction, type);
            toInstantiate.transform.position = position;
            toInstantiate.transform.localScale = size;
            toInstantiate.transform.SetParent(turret);
            timeSinceFired = 0f;
            audio.PlayOneShot(shot);
        }
        
    }
    public void BurstFire(int x)
    {
        burstLength--;
        Fire(0);
        timeSinceFired = firerate - burstSpacing;
        shot = shots[1];
    }
    public void SprayFire()
    {
        direction += angleChange;
        Fire(0);
        timeSinceFired = 0;
        shot = shots[2];
    }
    public void Clear()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        remove = true;
        Destroy(this.gameObject, 1);
    }
        
    public void GameOver()
    {

    }
}
