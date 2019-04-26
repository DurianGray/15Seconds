using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool jumped = false;
    public bool doubleJumpAvailable = false;
    public bool fastFallAvailable = false;
    public Rigidbody2D rb;
    public int jumpVelocity;
    public Vector3 position;
    public int runSpeed = 10;
    public bool isFalling = false;
    public bool offKey = true;
    public float jumpInput = 0;
    public GameManager game;
    public Vector3 pausePosition;

    // Use this for initialization
    void Start () {
        game = GetComponentInParent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        position = new Vector3(0, -3, 0);
	}

	
	// Update is called once per frame
	void Update () {
        if(game.gameOver == true)
        {
            jumped = false;
            doubleJumpAvailable = true;
            fastFallAvailable = true;
        }
        else if (game.gamePaused == true)
        {
            Physics.gravity = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(0, 0);
            transform.position = position;
        }
        else
        {
            Physics.gravity = new Vector3(0, -1, 0);
            position = transform.position;
            jumpVelocity = (int)rb.velocity.y;
            position.x += Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
            transform.position = position;
            Jump();
            DoubleJump();
            FastFall();
            if (isFalling && !jumped)
            {
                doubleJumpAvailable = true;
                fastFallAvailable = true;
            }
            jumpInput = Input.GetAxisRaw("Vertical");
        }
        
	}

    
    public void Jump()
    {

        if (jumpVelocity == 0 && Input.GetAxisRaw("Vertical") > 0 && !jumped && !isFalling)
        {
            rb.AddForce(new Vector2(0, 500));
            jumped = true;
            fastFallAvailable = true;
            jumpVelocity += 100;
            doubleJumpAvailable = true;
            jumpInput = 1;
            offKey = false;
        }
        jumpInput = Input.GetAxisRaw("Vertical");
        if(jumpInput <= 0)
        {
            offKey = true;
        }
        if (jumpVelocity < 0)
        {
            isFalling = true;
        }
        if (isFalling && jumpVelocity == 0)
        {
            isFalling = false;
            doubleJumpAvailable = false;
            fastFallAvailable = false;
            jumped = false;
        }
    }
    public void DoubleJump()
    {
        if (doubleJumpAvailable && jumpVelocity < 4 && Input.GetAxisRaw("Vertical") > 0 && offKey)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 600));
            doubleJumpAvailable = false;
            fastFallAvailable = true;
            jumped = true;
            isFalling = false;
        }
    }
    public void FastFall()
    {
        if (fastFallAvailable && jumpVelocity < 6 && Input.GetAxisRaw("Vertical") < 0)
        {
            if (jumpVelocity > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1400));
            }
            else
            {
                int x = jumpVelocity * 100;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, x - 800));
            }
            fastFallAvailable = false;
            jumped = true;
            isFalling = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Projectile")
        {
            game.gameOver = true;
        }
    }
    IEnumerator GameOver()
    {
        game.gameOver = true;
        yield return new WaitForSeconds(1);

    }
    
}
