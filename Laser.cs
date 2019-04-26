using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile {

    public float halfLaserLength;

	// Use this for initialization
	public override void Start () {
        halfLaserLength = transform.localScale.x / 2;
        LaserShooter parent = GetComponentInParent<LaserShooter>();
        direction = parent.direction;
        position = parent.position;
        Vector3 rotate = new Vector3(0, 0, direction);
        direction = direction * Mathf.Deg2Rad;
        transform.Rotate(rotate);
        position = new Vector3(transform.position.x + (halfLaserLength * Mathf.Cos(direction)), transform.position.y + (halfLaserLength * Mathf.Sin(direction)));
        transform.position = position;
        deflected = false;
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        speed = 0;
        lifetime = 0.7f;
        base.Start();
        collided = false;
    }
	
	// Update is called once per frame
	public override void Update () {
        speed = 0;
        base.Update();
	}
}
