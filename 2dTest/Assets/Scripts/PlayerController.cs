using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;
    public float jumpForce = 700f;
    bool facingRight = true;
    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    Rigidbody2D rb;
    float speed;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {

        //move();
    }

	// Update is called once per frame
	void Update () {

        //Walking
        movePlayer(speed);

        //Flipping the player
        if (speed > 0 && !facingRight)
        {
            flip();
        }
        else if (speed < 0 && facingRight)
        {
            flip();
        }

        //Input from user
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = -maxSpeed;
            anim.SetFloat("Speed", Mathf.Abs(speed));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = maxSpeed;
            anim.SetFloat("Speed", Mathf.Abs(speed));
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
            anim.SetFloat("Speed", Mathf.Abs(speed));
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
            anim.SetFloat("Speed", Mathf.Abs(speed));
        }
    

        //Jumping
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void jump()
    {
        anim.SetBool("Grounded", false);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
    }

    /*
    void move()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Grounded", grounded);

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }
    }*/

    void movePlayer(float playerSpeed)
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Grounded", grounded);
        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
    }

    /* Mobile buttons */
    public void moveLeft()
    {
        speed = -maxSpeed;
        anim.SetFloat("Speed", Mathf.Abs(speed));
        //GetComponent<Rigidbody2D>().velocity = new Vector3(-1 * speed, GetComponent<Rigidbody2D>().velocity.y, 0);
        //rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void moveRight()
    {
        speed = maxSpeed;
        anim.SetFloat("Speed", Mathf.Abs(speed));
        //rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void stopMoving()
    {
        speed = 0;
        anim.SetFloat("Speed", Mathf.Abs(speed));
        //rb.velocity = new Vector2(speed, rb.velocity.y);
    }

}
