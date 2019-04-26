using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int speed;
    public BoxCollider2D box;
    public Rigidbody2D rb;
    public bool deflected;
    public bool left;
    public Vector3 position;
    public float lifetime = 10f;
    public bool collided;
    public float direction;
    public float xmove;
    public float ymove;
    public int type;
    public float rotateSpeed;
    public bool rotate;
    public Turret parent;

    // Use this for initialization
    public virtual void Start () {
        parent = GetComponentInParent<Turret>();
        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        deflected = false;
        transform.localScale = new Vector3(0.5f, 0.5f);
        direction = direction * Mathf.Deg2Rad;
        rotateSpeed = 100;
    }
	
	// Update is called once per frame
	public virtual void Update () {
        if (parent.gameOver)
        {
            Destroy(this.gameObject);
        }
        if (parent.paused)
        {

        }
        else
        {
            position = transform.position;
            position.x += speed * Mathf.Cos(direction) * Time.deltaTime;
            position.y += speed * Mathf.Sin(direction) * Time.deltaTime;
            xmove = Mathf.Cos(direction);
            ymove = Mathf.Sin(direction);
            transform.position = position;
            transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
        }
 
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            collided = true;
            Destroy(gameObject);

        }
    }
    public void CreateProjectile(int speedm, float directionm, int typem)
    {
        speed = speedm;
        direction = directionm;
        type = typem;
    }
}
