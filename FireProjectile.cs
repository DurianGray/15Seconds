using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireProjectile : MonoBehaviour {

    public Vector3 position;
    public float firerate = 1;
    public float timeSinceFired = 2f;
    public Transform turret;
    public GameObject projectile;
    public Vector3 size = new Vector3 (1,1,1);
    public float delay = 0f;
    public int speed;
    public float direction;
    public Projectile proj;
    public float targetx;
    public float targety;
    public Vector3 targetPos;
    public bool tracking = false;

    // Use this for initialization
    public virtual void Start () {
        speed = 10;
	}
	
	// Update is called once per frame
	public virtual void Update () {
        if (timeSinceFired >= firerate)
        {
            if (tracking)
            {
                TrackPlayer();
            }
            Fire();
            timeSinceFired = 0f;
        }
        timeSinceFired += Time.deltaTime;
	}

    public void Fire()
    {
        position = transform.position;
        GameObject toInstantiate = Instantiate(projectile, position, Quaternion.identity);
        toInstantiate.transform.SetParent(turret);
        toInstantiate.transform.position = position;
        toInstantiate.transform.localScale = size;
        timeSinceFired = 0f;
    }
    public void TrackPlayer()
    {
        GameManager parent = GetComponentInParent<GameManager>();
        targetPos = parent.playerPos;
        float x = transform.position.x - targetPos.x;
        float y = transform.position.y - targetPos.y;
        direction = Mathf.Atan(y / x);
        direction = direction * Mathf.Rad2Deg;
    }
}
