using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingTurret : MonoBehaviour
{

    public List<StartingProjectile> projectiles;
    public Vector3 position;
    public float firerate = .5f;
    public float timeSinceFired = 0;
    public Transform turret;
    public GameObject projectile;
    public Vector3 size = new Vector3(1f, 1f, 1);
    public float delay = 0f;
    public int speed;
    public float direction;
    public float targetx;
    public float targety;
    public Vector3 targetPos;
    public int type;
    public Player target;
    public int burstLength;
    public float burstSpacing;
    public int trackType;
    public int burstMax;
    public int called;
    public float angleChange;
    public bool side;
    public bool paused = false;


    //List of types: Type 0 = regular, type 1 = burstfire,  type 2 = randomspray

    // Use this for initialization
    void Start()
    {
        timeSinceFired = timeSinceFired - delay;
        turret = transform;
        speed = 12;
        direction = 0;
        firerate = .5f;
        timeSinceFired = -1;
        type = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeSinceFired > firerate)
        {

                Fire(0);
                direction += 180;
                Fire(0);
                direction += 180;
            
        }
        
            timeSinceFired += Time.deltaTime;

    }
    
    
    public void Fire(int x)
    {
        position = transform.position;
        StartingProjectile toInstantiate = Instantiate(projectiles[x], position, Quaternion.identity);
        toInstantiate.CreateProjectile(speed, direction, type);
        toInstantiate.transform.position = position;
        toInstantiate.transform.localScale = size;
        toInstantiate.transform.SetParent(turret);
        timeSinceFired = 0f;
    }
    public void SprayFire()
    {
        direction += angleChange;
        Fire(0);
        timeSinceFired = 0;
    }
}
