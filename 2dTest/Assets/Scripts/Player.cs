using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;
    public float jump;
    public bool grounded;
    public enum PlayerState { idle, moving, jumping};

    private PlayerState playerState;
    private Animator anim;

    // Use this for initialization
    void Start () {
        playerState = PlayerState.idle;
        anim = gameObject.GetComponent<Animator>();
        Debug.Log("asdsa");
    }
	
	// Update is called once per frame
	void Update () {
        move();
        anim.SetBool("Grounded", grounded);
	}

    void move(){

        //Idle
        if (grounded)
        {
            Debug.Log("Grounded");
            playerState = PlayerState.idle;
        }

        // Move left and right
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            grounded = true;
            playerState = PlayerState.moving;
            
        }
        if
        (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            grounded = true;
            playerState = PlayerState.moving;
        }

        // Jump
        if (Input.GetKey(KeyCode.Space))
        {
            grounded = false;
            transform.Translate(0, jump * Time.deltaTime, 0);
            playerState = PlayerState.jumping;
        }
        
    }

    void playerStateController()
    {

        if (playerState == PlayerState.idle)
        {
            Debug.Log(GetComponent<Animation>().name);
        }
    }
}
